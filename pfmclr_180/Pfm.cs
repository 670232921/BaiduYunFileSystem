using System;
using System.Runtime.InteropServices;

public class Pfm
{
    public const int accessLevelDelete = 4;
    public const int accessLevelOwner = 6;
    public const int accessLevelReadData = 2;
    public const int accessLevelReadInfo = 1;
    public const int accessLevelWriteData = 5;
    public const int accessLevelWriteInfo = 3;
    public const int clientFlagXattr = 1;
    public const int colorBlue = 5;
    public const int colorDefault = 1;
    public const int colorGray = 2;
    public const int colorGreen = 3;
    public const int colorInvalid = 0;
    public const int colorOrange = 8;
    public const int colorPurple = 4;
    public const int colorRed = 7;
    public const int colorYellow = 6;
    public const int controlFlagForceBuffered = 2;
    public const int controlFlagForceUnbuffered = 1;
    public const int errorAccessDenied = 5;
    public const int errorBadName = 12;
    public const int errorCancelled = 2;
    public const int errorCorruptData = 0x11;
    public const int errorDeleted = 0x10;
    public const int errorDisconnect = 1;
    public const int errorEndOfData = 14;
    public const int errorExists = 10;
    public const int errorFailed = 7;
    public const int errorInvalid = 4;
    public const int errorNoSpace = 11;
    public const int errorNotAFile = 15;
    public const int errorNotAFolder = 0x13;
    public const int errorNotEmpty = 13;
    public const int errorNotFound = 8;
    public const int errorOutOfMemory = 6;
    public const int errorParentNotFound = 9;
    public const int errorSuccess = 0;
    public const int errorTimeout = 0x12;
    public const int errorUnsupported = 3;
    public const int extraFlagOffline = 1;
    public const int extraFlagReserved1 = 2;
    private static Factories factories = PfmShim.GetFactories();
    public const int fastPipeFlagAsyncClient = 8;
    public const int fastPipeFlagAsyncServer = 0x10;
    public const int fastPipeFlagFastMapping = 2;
    public const int fastPipeFlagNamedDevice = 4;
    public const int fileFlagAlias = 0x40;
    public const int fileFlagArchive = 0x20;
    public const int fileFlagExecute = 8;
    public const int fileFlagHasIcon = 0x10;
    public const int fileFlagHidden = 2;
    public const int fileFlagReadOnly = 1;
    public static int fileFlagsInvalid = 0xff;
    public const int fileFlagSystem = 4;
    public const int fileMountFlagConsoleUi = 1;
    public const int fileMountFlagEditOptions = 0x20;
    public const int fileMountFlagInProcess = 2;
    public const int fileMountFlagMultiMount = 0x40;
    public const int fileMountFlagReserved1 = 8;
    public const int fileMountFlagVerbose = 4;
    public const int fileTypeFile = 1;
    public const int fileTypeFolder = 2;
    public const int fileTypeNone = 0;
    public const int fileTypeSymlink = 3;
    public const int flushFlagOpen = 1;
    public const int instInstalled = 0;
    public const int instNotInstalled = 3;
    public const int instOldBuild = 1;
    public const int instOldVersion = 2;
    public const int mountFlagBrowse = 0x10000;
    public const int mountFlagCacheNameSpace = 0x4000;
    public const int mountFlagForceBuffered = 0x100;
    public const int mountFlagForceUnbuffered = 0x80;
    public const int mountFlagGroupOwned = 0x1000;
    public const int mountFlagGroupRead = 0x400;
    public const int mountFlagGroupWrite = 0x800;
    public const int mountFlagLocalDriveType = 0x80000;
    public const int mountFlagReadOnly = 1;
    public const int mountFlagUncOnly = 0x10;
    public const int mountFlagUnmountOnDisconnect = 0x40000;
    public const int mountFlagUnmountOnRelease = 0x20000;
    public const int mountFlagVerbose = 0x20;
    public const int mountFlagWorldOwned = 0x2000;
    public const int mountFlagWorldRead = 4;
    public const int mountFlagWorldWrite = 8;
    public const int statusFlagClosed = 8;
    public const int statusFlagDisconnected = 4;
    public const int statusFlagInitializing = 1;
    public const int statusFlagReady = 2;
    public const long timeInvalid = 0L;
    public const int unmountFlagBackground = 1;
    public const int volumeFlagCaseSensitive = 8;
    public const int volumeFlagCompressed = 2;
    public const int volumeFlagEncrypted = 4;
    public const int volumeFlagFakeNamedStreams = 0x4000;
    public const int volumeFlagNoAccessTime = 0x200;
    public const int volumeFlagNoChangeTime = 0x800;
    public const int volumeFlagNoCreateTime = 0x100;
    public const int volumeFlagNoWriteTime = 0x400;
    public const int volumeFlagReadOnly = 1;
    public const int volumeFlagSymlinks = 0x2000;
    public const int volumeFlagTouchMap = 0x10;
    public const int volumeFlagXattr = 0x1000;

    public static int ApiFactory(out Api api)
    {
        return factories.ApiFactory(out api);
    }

    public static int InstallCheck()
    {
        return factories.InstallCheck();
    }

    public static int MarshallerFactory(out Marshaller marshaller)
    {
        return factories.MarshallerFactory(out marshaller);
    }

    public static void SystemCloseFd(IntPtr fd)
    {
        factories.SystemCloseFd(fd);
    }

    public static int SystemCreatePipe(out IntPtr readFd, out IntPtr writeFd)
    {
        return factories.SystemCreatePipe(out readFd, out writeFd);
    }

    public static int SystemGetStdout(out IntPtr fd)
    {
        return factories.SystemGetStdout(out fd);
    }

    public interface Api : IDisposable
    {
        int FastPipeCreate(Pfm.FastPipeCreateParams params_, out IntPtr clientFd, out IntPtr serverFd);
        int FileMountFactory(out Pfm.FileMount fileMount);
        int MountCreate(Pfm.MountCreateParams params_, out Pfm.Mount mount);
        int MountEndNameOpen(string mountEndName, out Pfm.Mount mount);
        int MountIdOpen(int mountId, out Pfm.Mount mount);
        int MountIterate(long startChangeInstance, out long nextChangeInstance, out Pfm.MountIterator iterator);
        int MountMonitorFactory(out Pfm.MountMonitor monitor);
        int MountPointOpen(string mountPoint, out Pfm.Mount mount);
        int MountSourceNameOpen(string mountSourceName, out Pfm.Mount mount);
        int SysStart();
        string Version();
    }

    public class Attribs
    {
        public long accessTime;
        public long changeTime;
        public int color;
        public long createTime;
        public int extraFlags;
        public int fileFlags;
        public long fileId;
        public long fileSize;
        public int fileType;
        public int resourceSize;
        public long writeTime;
    }

    public interface Factories : IDisposable
    {
        int ApiFactory(out Pfm.Api api);
        int InstallCheck();
        int MarshallerFactory(out Pfm.Marshaller marshaller);
        void SystemCloseFd(IntPtr fd);
        int SystemCreatePipe(out IntPtr readFd, out IntPtr writeFd);
        int SystemGetStdout(out IntPtr fd);
    }

    public class FastPipeCreateParams
    {
        public int fastPipeFlags;
    }

    public interface FileMount : IDisposable
    {
        void Cancel();
        void Detach();
        Pfm.Mount GetMount();
        void Send(string data, bool endOfLine);
        int Start(Pfm.FileMountCreateParams params_);
        void Status(string data, bool endOfLine);
        int WaitReady();
    }

    public class FileMountCreateParams
    {
        public char driveLetter;
        public int fileMountFlags;
        public string formatterName;
        public string mountFileName;
        public int mountFlags = 0x44000;
        public string ownerId;
        public string password;
        public Pfm.FileMountUi ui;
    }

    public interface FileMountUi
    {
        void ClearPassword();
        void Complete(string errorMessage);
        string QueryPassword(string prompt, int count);
        void Resume();
        void Start();
        void Status(string data, bool endOfLine);
        void Suspend();
    }

    public interface FormatterDispatch
    {
        void Access(Pfm.MarshallerAccessOp op);
        void Capacity(Pfm.MarshallerCapacityOp op);
        void Close(Pfm.MarshallerCloseOp op);
        void Control(Pfm.MarshallerControlOp op);
        void Delete(Pfm.MarshallerDeleteOp op);
        void FlushFile(Pfm.MarshallerFlushFileOp op);
        void FlushMedia(Pfm.MarshallerFlushMediaOp op);
        void List(Pfm.MarshallerListOp op);
        void ListEnd(Pfm.MarshallerListEndOp op);
        void MediaInfo(Pfm.MarshallerMediaInfoOp op);
        void Move(Pfm.MarshallerMoveOp op);
        void MoveReplace(Pfm.MarshallerMoveReplaceOp op);
        void Open(Pfm.MarshallerOpenOp op);
        void Read(Pfm.MarshallerReadOp op);
        void ReadXattr(Pfm.MarshallerReadXattrOp op);
        void Replace(Pfm.MarshallerReplaceOp op);
        void SetSize(Pfm.MarshallerSetSizeOp op);
        void Write(Pfm.MarshallerWriteOp op);
        void WriteXattr(Pfm.MarshallerWriteXattrOp op);
    }

    public interface FormatterSerializeOpen
    {
        void SerializeOpen(long openId, out long openSequence);
    }

    public interface Marshaller : IDisposable
    {
        void ClearPassword();
        int ConvertSystemError(int err);
        int GetClientFlags();
        int GetClientVersion();
        int GetPassword(IntPtr read, string prompt, out string password);
        void Line(string data, bool endOfLine);
        void Print(string data);
        void ServeCancel();
        void ServeDispatch(Pfm.MarshallerServeParams params_);
        void SetStatus(IntPtr fd);
        void SetTrace(string traceChannelName);
    }

    public interface MarshallerAccessOp : IDisposable
    {
        int AccessLevel();
        void Complete(int perr, Pfm.OpenAttribs openAttribs, Pfm.FormatterSerializeOpen serializeOpen);
        long OpenId();
    }

    public interface MarshallerCapacityOp : IDisposable
    {
        void Complete(int perr, long totalCapacity, long availableCapacity);
        long OpenId();
    }

    public interface MarshallerCloseOp : IDisposable
    {
        void Complete(int perr);
        long OpenId();
        long OpenSequence();
    }

    public interface MarshallerControlOp : IDisposable
    {
        int AccessLevel();
        void Complete(int perr, int outputSize);
        int ControlCode();
        byte[] Input();
        int InputSize();
        int MaxOutputSize();
        long OpenId();
        byte[] Output();
        IntPtr PinnedInput();
        IntPtr PinnedOutput();
    }

    public interface MarshallerDeleteOp : IDisposable
    {
        void Complete(int perr);
        string EndName();
        long OpenId();
        long ParentFileId();
        long WriteTime();
    }

    public interface MarshallerFlushFileOp : IDisposable
    {
        long AccessTime();
        long ChangeTime();
        int Color();
        void Complete(int perr, Pfm.OpenAttribs openAttribs, Pfm.FormatterSerializeOpen serializeOpen);
        long CreateTime();
        int FileFlags();
        int FlushFlags();
        byte[] LinkData();
        int LinkDataSize();
        long OpenId();
        long WriteTime();
    }

    public interface MarshallerFlushMediaOp : IDisposable
    {
        void Complete(int perr, int msecFlushDelay);
    }

    public interface MarshallerListEndOp : IDisposable
    {
        void Complete(int perr);
        long ListId();
        long OpenId();
    }

    public interface MarshallerListOp : IDisposable
    {
        bool Add(Pfm.Attribs attribs, string endName);
        void Complete(int perr, bool noMore);
        long ListId();
        long OpenId();
    }

    public interface MarshallerMediaInfoOp : IDisposable
    {
        void Complete(int perr, Pfm.MediaInfo mediaInfo, string mediaLabel);
        long OpenId();
    }

    public interface MarshallerMoveOp : IDisposable
    {
        void Complete(int perr, bool existed, Pfm.OpenAttribs openAttribs, long parentFileId, string endName, int linkNamePartCount, byte[] linkData, int linkDataSize, Pfm.FormatterSerializeOpen serializeOpen);
        bool DeleteSource();
        int ExistingAccessLevel();
        long NewExistingOpenId();
        string SourceEndName();
        long SourceOpenId();
        long SourceParentFileId();
        int TargetNamePartCount();
        string[] TargetNameParts();
        long WriteTime();
    }

    public interface MarshallerMoveReplaceOp : IDisposable
    {
        void Complete(int perr);
        bool DeleteSource();
        string SourceEndName();
        long SourceOpenId();
        long SourceParentFileId();
        string TargetEndName();
        long TargetOpenId();
        long TargetParentFileId();
        long WriteTime();
    }

    public interface MarshallerOpenOp : IDisposable
    {
        void Complete(int perr, bool existed, Pfm.OpenAttribs openAttribs, long parentFileId, string endName, int linkNamePartCount, byte[] linkData, int linkDataSize, Pfm.FormatterSerializeOpen serializeOpen);
        int CreateFileFlags();
        int CreateFileType();
        int ExistingAccessLevel();
        int NamePartCount();
        string[] NameParts();
        long NewCreateOpenId();
        long NewExistingOpenId();
        long WriteTime();
    }

    public interface MarshallerReadOp : IDisposable
    {
        void Complete(int perr, int actualSize);
        byte[] Data();
        long FileOffset();
        long OpenId();
        IntPtr PinnedData();
        int RequestedSize();
    }

    public interface MarshallerReadXattrOp : IDisposable
    {
        void Complete(int perr, int xattrSize, int transferredSize);
        byte[] Data();
        string Name();
        int Offset();
        long OpenId();
        IntPtr PinnedData();
        int RequestedSize();
    }

    public interface MarshallerReplaceOp : IDisposable
    {
        void Complete(int perr, Pfm.OpenAttribs openAttribs, Pfm.FormatterSerializeOpen serializeOpen);
        int CreateFileFlags();
        long NewCreateOpenId();
        string TargetEndName();
        long TargetOpenId();
        long TargetParentFileId();
        long WriteTime();
    }

    public class MarshallerServeParams
    {
        public int dataAlign;
        public Pfm.FormatterDispatch dispatch;
        public string formatterName;
        public IntPtr fromFormatterWrite;
        public IntPtr toFormatterRead;
        public int volumeFlags;

        public MarshallerServeParams()
        {
            this.toFormatterRead = this.fromFormatterWrite = new IntPtr(-1);
        }
    }

    public interface MarshallerSetSizeOp : IDisposable
    {
        void Complete(int perr);
        long FileSize();
        long OpenId();
    }

    public interface MarshallerWriteOp : IDisposable
    {
        void Complete(int perr, int actualSize);
        byte[] Data();
        long FileOffset();
        long OpenId();
        IntPtr PinnedData();
        int RequestedSize();
    }

    public interface MarshallerWriteXattrOp : IDisposable
    {
        void Complete(int perr, int transferredSize);
        byte[] Data();
        string Name();
        int Offset();
        long OpenId();
        IntPtr PinnedData();
        int RequestedSize();
        int XattrSize();
    }

    public class MediaInfo
    {
        public long createTime;
        public int mediaFlags;
        public int mediaId32;
        public long mediaId64;
        public byte[] mediaUuid;
    }

    public interface Mount : IDisposable
    {
        int Control(int controlCode, byte[] input, int inputSize, byte[] output, int maxOutputSize, out int outputSize);
        int Flush();
        string GetAppId();
        long GetChangeInstance();
        char GetDriveLetter();
        string GetFormatterName();
        string GetMountEndName();
        int GetMountFlags();
        int GetMountId();
        string GetMountPoint();
        string GetMountSourceName();
        string GetOwnerId();
        string GetOwnerName();
        int GetStatusFlags();
        string GetUncName();
        int GetVolumeFlags();
        int Refresh();
        int Unmount(int unmountFlags);
        int WaitReady(int timeoutMsecs);
    }

    public class MountCreateParams
    {
        public string appId;
        public char driveLetter;
        public IntPtr fromAuthRead;
        public IntPtr fromFormatterRead;
        public int mountFlags = 0x44000;
        public string mountSourceName;
        public string ownerId;
        public IntPtr toAuthWrite;
        public IntPtr toFormatterWrite;

        public MountCreateParams()
        {
            this.toFormatterWrite = this.fromFormatterRead = this.toAuthWrite = this.fromAuthRead = new IntPtr(-1);
        }
    }

    public interface MountIterator : IDisposable
    {
        int Next(out long changeInstance);
    }

    public interface MountMonitor : IDisposable
    {
        void Cancel();
        int Wait(long nextChangeInstance, int timeoutMsecs);
    }

    public class OpenAttribs
    {
        public int accessLevel;
        public Pfm.Attribs attribs = new Pfm.Attribs();
        public int controlFlags;
        public long openId;
        public long openSequence;
        public int touch;
    }
}

