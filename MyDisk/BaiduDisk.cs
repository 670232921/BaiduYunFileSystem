using BaiduApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyDisk
{
    class BaiduDisk : Pfm.FormatterDispatch
    {
   public Pfm.Marshaller marshaller;

        string _user = null;
        Baidu1 baidu1 = null;
        Dictionary<long, Entry> opens = new Dictionary<long, Entry>();
        Dictionary<long, Entry> fileIds = new Dictionary<long, Entry>();
        long opennedid = 0;
        Entry _lastListEntry = null;
        List<Entry> _lastEntries = new List<Entry>();

        public BaiduDisk(string user, string pass)
        {
            _user = user;
            baidu1 = new Baidu1(user, pass, 10);
        }

        public bool IsAviliable()
        {
            return baidu1.IsLogin;
        }

        private long GetFileId(Entry entry)
        {
            lock (fileIds)
            {
                if (!fileIds.ContainsValue(entry))
                {
                    fileIds.Add(fileIds.Count, entry);
                }

                return fileIds.First(item => item.Value == entry).Key;
            }
        }

        private long GetOpenId(Entry entry, long exitId)
        {
            lock (opens)
            {
                if (!opens.ContainsValue(entry))
                {
                    opens.Add(exitId, entry);
                }

                return opens.First(item => item.Value == entry).Key;
            }
        }

        private Entry GetEntryByName(string[] name)
        {
            //if (!opens.ContainsKey(opennedid))
            //{
            //    return null;
            //}
            //Entry parent = opens[opennedid];
            string path = "/" + String.Join("/", name);
            foreach (var item in fileIds)
            {
                //if (item.Value.path == parent.path + "/" + name)
                //{
                //    return item.Value;
                //}
                if (item.Value.path == path)
                {
                    return item.Value;
                }
            }
            return null;
        }

        private Entry GetEntryFormId(long id)
        {
            lock (fileIds)
            {
                return fileIds[id];
            }
        }

        private List<Entry> ListEntries(Entry parent)
        {
            lock (_lastEntries)
            {
                if (parent != _lastListEntry)
                {
                    _lastListEntry = parent;
                    _lastEntries = baidu1.List(parent);
                }
                return _lastEntries;
            }
        }

        #region interface impletement
        public void Access(Pfm.MarshallerAccessOp op)
        {
            long openId = op.OpenId();
            int err = 0;
            Pfm.OpenAttribs att = new Pfm.OpenAttribs();
            if (opens.ContainsKey(openId))
            {
                var entry = opens[openId];
                att.accessLevel = Pfm.accessLevelReadData;
                //att.attribs.accessTime = entry.local_mtime;
                //att.attribs.createTime = entry.local_ctime;
                //att.attribs.changeTime = entry.local_mtime;
                //att.attribs.writeTime = entry.local_mtime;
                att.attribs.fileType = entry.isdir != 0 ? Pfm.fileTypeFolder : Pfm.fileTypeFile;
                att.attribs.fileId = GetFileId(entry);
                att.attribs.fileSize = entry.size;
                att.openId = openId;
                att.openSequence = 1;
            }
            else
            {
                err = Pfm.errorNotFound;
            }
            op.Complete(err, att, null);
        }

        public void Capacity(Pfm.MarshallerCapacityOp op)
        {
            long openId = op.OpenId();
            op.Complete(Pfm.errorSuccess, GetEntryFormId(openId).size, 0);
        }

        public void Close(Pfm.MarshallerCloseOp op)
        {
            op.Complete(Pfm.errorSuccess);
        }

        public void Control(Pfm.MarshallerControlOp op)
        {
            op.Complete(Pfm.errorInvalid, 0);
        }

        public void Delete(Pfm.MarshallerDeleteOp op)
        {
            op.Complete(Pfm.errorAccessDenied);
        }

        public void FlushFile(Pfm.MarshallerFlushFileOp op)
        {
            op.Complete(Pfm.errorInvalid, new Pfm.OpenAttribs(), null);
        }

        public void FlushMedia(Pfm.MarshallerFlushMediaOp op)
        {
            op.Complete(Pfm.errorSuccess, -1/*flushTimeoutMsecs*/);
        }

        public void List(Pfm.MarshallerListOp op)
        {
            long openId = op.OpenId();
            int err = 0;
            if (!opens.ContainsKey(openId) || opens[openId].isdir == 0)
            {
                err = Pfm.errorAccessDenied;
            }
            else
            {
                Entry entry = opens[openId];
                var entrys = ListEntries(entry);
                foreach (var item in entrys)
                {
                    Pfm.Attribs att = new Pfm.Attribs();
                    att.accessTime = entry.local_mtime;
                    att.createTime = entry.local_ctime;
                    att.changeTime = entry.local_mtime;
                    att.writeTime = entry.local_mtime;
                    att.fileId = GetFileId(item);
                    att.fileSize = item.size;
                    att.fileType = item.isdir != 0 ? Pfm.fileTypeFolder : Pfm.fileTypeFile;
                    op.Add(att, item.server_filename);
                }
            }
            op.Complete(err, true);
        }

        public void ListEnd(Pfm.MarshallerListEndOp op)
        {
            op.Complete(Pfm.errorSuccess);
        }

        public void MediaInfo(Pfm.MarshallerMediaInfoOp op)
        {
            Pfm.MediaInfo info = new Pfm.MediaInfo();
            op.Complete(Pfm.errorSuccess, info, _user);
        }

        public void Move(Pfm.MarshallerMoveOp op)
        {
            op.Complete(Pfm.errorAccessDenied, false/*existed*/, null/*openAttribs*/, 0/*parentFileId*/, null/*endName*/, 0, null, 0, null);
        }

        public void MoveReplace(Pfm.MarshallerMoveReplaceOp op)
        {
            op.Complete(Pfm.errorAccessDenied);
        }

        public void Open(Pfm.MarshallerOpenOp op)
        {
            int perr = 0;
            bool existed = false;
            Pfm.OpenAttribs openAttribs = new Pfm.OpenAttribs();
            long parentFileId = 0;
            string endName = null;
            long newExistingOpenId = op.NewExistingOpenId();

            var names = op.NameParts();

            string des = "open:opennedid:" + opennedid.ToString() + ";names:" + String.Join(";", names);
            Debug.WriteLine(des);

            if (names.Length == 0)
            {
                if (opennedid == 0)
                {
                    opennedid = newExistingOpenId;
                    Entry entry = new Entry();
                    entry.isdir = 1;
                    opens.Add(opennedid, entry);
                }
                existed = true;
                openAttribs.openId = opennedid;
                openAttribs.openSequence = 1;
                openAttribs.accessLevel = Pfm.accessLevelReadData;
                openAttribs.attribs.fileId = GetFileId(opens[opennedid]);
                openAttribs.attribs.fileType = Pfm.fileTypeFolder;
            }
            else// if (names.Length == 1)
            {
                Entry entry = GetEntryByName(names);
                if (entry == null)
                {
                    perr = Pfm.errorNotFound;
                }
                else
                {
                    long id = GetOpenId(entry, newExistingOpenId);
                    existed = true;
                    openAttribs.openId = id;
                    openAttribs.openSequence = 1;
                    openAttribs.accessLevel = Pfm.accessLevelReadData;
                    openAttribs.attribs.fileType = entry.isdir != 0 ? Pfm.fileTypeFolder : Pfm.fileTypeFile;
                    openAttribs.attribs.fileId = GetFileId(entry);
                    openAttribs.attribs.fileSize = entry.size;
                    openAttribs.attribs.accessTime = entry.local_mtime;
                    openAttribs.attribs.createTime = entry.local_ctime;
                    openAttribs.attribs.changeTime = entry.local_mtime;
                    openAttribs.attribs.writeTime = entry.local_mtime;
                    endName = entry.server_filename;
                }
            }
            //else
            //{
            //    Debug.WriteLine(string.Format("opendId:{0},names:{1}", opennedid, String.Join(";", names)));
            //    perr = Pfm.errorParentNotFound;
            //}
            op.Complete(perr, existed, openAttribs, parentFileId, endName, 0, null, 0, null);
        }

        public void Read(Pfm.MarshallerReadOp op)
        {
            op.Complete(Pfm.errorSuccess, 0);
        }

        public void ReadXattr(Pfm.MarshallerReadXattrOp op)
        {
            op.Complete(Pfm.errorNotFound, 0/*xattrSize*/, 0/*transferredSize*/);
        }

        public void Replace(Pfm.MarshallerReplaceOp op)
        {
            op.Complete(Pfm.errorAccessDenied, null/*openAttribs*/, null);
        }

        public void SetSize(Pfm.MarshallerSetSizeOp op)
        {
            op.Complete(Pfm.errorAccessDenied);
        }

        public void Write(Pfm.MarshallerWriteOp op)
        {
            op.Complete(Pfm.errorAccessDenied, 0/*actualSize*/);
        }

        public void WriteXattr(Pfm.MarshallerWriteXattrOp op)
        {
            op.Complete(Pfm.errorAccessDenied, 0/*transferredSize*/);
        }
        #endregion interface impletement
    }
}
