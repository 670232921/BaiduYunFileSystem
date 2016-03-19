using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SuppressUnmanagedCodeSecurity]
internal class PfmShim
{
    public static Pfm.Factories GetFactories()
    {
        return new Factories();
    }

    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_FastPipeCreate", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_FastPipeCreate(IntPtr th, int fastPipeFlags, out IntPtr clientFd, out IntPtr serverFd);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_FileMountFactory", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_FileMountFactory(IntPtr th, out IntPtr fileMount);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountCreate", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountCreate(IntPtr th, string mountSourceName, int mountFlags, char driveLetter, string ownerId, IntPtr toFormatterWrite, IntPtr fromFormatterRead, IntPtr toAuthWrite, IntPtr fromAuthRead, string appId, out IntPtr mount);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountEndNameOpen", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountEndNameOpen(IntPtr th, string mountEndName, out IntPtr mount);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountIdOpen", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountIdOpen(IntPtr th, int mountId, out IntPtr mount);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountIterate", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountIterate(IntPtr th, long startChangeInstance, out long nextChangeInstance, out IntPtr iterator);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountMonitorFactory", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountMonitorFactory(IntPtr th, out IntPtr monitor);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountPointOpen", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountPointOpen(IntPtr th, string mountPoint, out IntPtr mount);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_MountSourceNameOpen", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_MountSourceNameOpen(IntPtr th, string mountSourceName, out IntPtr mount);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_Release", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmApi_Release(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_SysStart", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmApi_SysStart(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmApi_Version", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmApi_Version(IntPtr th, IntPtr stringBoxContext, StringBox_Set_t stringBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFactories_ApiFactory", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFactories_ApiFactory(IntPtr th, out IntPtr api);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFactories_InstallCheck", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFactories_InstallCheck(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFactories_MarshallerFactory", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFactories_MarshallerFactory(IntPtr th, out IntPtr marshaller);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFactories_SystemCloseFd", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmFactories_SystemCloseFd(IntPtr th, IntPtr fd);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFactories_SystemCreatePipe", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFactories_SystemCreatePipe(IntPtr th, out IntPtr readFd, out IntPtr writeFd);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFactories_SystemGetStdout", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFactories_SystemGetStdout(IntPtr th, out IntPtr fd);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_Cancel", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmFileMount_Cancel(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_Detach", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmFileMount_Detach(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_GetMount", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern IntPtr PfmFileMount_GetMount(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_Release", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmFileMount_Release(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_Send", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmFileMount_Send(IntPtr th, string data, bool endOfLine);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_Start", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFileMount_Start(IntPtr th, string mountFileName, int mountFlags, int fileMountFlags, char driveLetter, string ownerId, string formatterName, string password, IntPtr uiContext, FileMountUi_Start_t uiStart, FileMountUi_Complete_t uiComplete, FileMountUi_Status_t uiStatus, FileMountUi_Suspend_t uiSuspend, FileMountUi_Resume_t uiResume, FileMountUi_QueryPassword_t uiQueryPassword, FileMountUi_ClearPassword_t uiClearPassword);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_Status", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmFileMount_Status(IntPtr th, string data, bool endOfLine);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmFileMount_WaitReady", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmFileMount_WaitReady(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_ClearPassword", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_ClearPassword(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_ConvertSystemError", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMarshaller_ConvertSystemError(IntPtr th, int err);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_GetClientFlags", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMarshaller_GetClientFlags(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_GetClientVersion", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMarshaller_GetClientVersion(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_GetPassword", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMarshaller_GetPassword(IntPtr th, IntPtr read, string prompt, IntPtr passwordBoxContext, StringBox_Set_t passwordBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_Line", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_Line(IntPtr th, string data, bool endOfLine);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_Print", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_Print(IntPtr th, string data);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_Release", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_Release(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_ServeCancel", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_ServeCancel(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_ServeDispatch", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_ServeDispatch(IntPtr th, int volumeFlags, string formatterName, int dataAlign, IntPtr toFormatterRead, IntPtr fromFormatterWrite, IntPtr dispatchContext, FormatterDispatch_Open_t dispatchOpen, FormatterDispatch_Replace_t dispatchReplace, FormatterDispatch_Move_t dispatchMove, FormatterDispatch_MoveReplace_t dispatchMoveReplace, FormatterDispatch_Delete_t dispatchDelete, FormatterDispatch_Close_t dispatchClose, FormatterDispatch_FlushFile_t dispatchFlushFile, FormatterDispatch_List_t dispatchList, FormatterDispatch_ListEnd_t dispatchListEnd, FormatterDispatch_Read_t dispatchRead, FormatterDispatch_Write_t dispatchWrite, FormatterDispatch_SetSize_t dispatchSetSize, FormatterDispatch_Capacity_t dispatchCapacity, FormatterDispatch_FlushMedia_t dispatchFlushMedia, FormatterDispatch_Control_t dispatchControl, FormatterDispatch_MediaInfo_t dispatchMediaInfo, FormatterDispatch_Access_t dispatchAccess, FormatterDispatch_ReadXattr_t dispatchReadXattr, FormatterDispatch_WriteXattr_t dispatchWriteXattr);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_SetStatus", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_SetStatus(IntPtr th, IntPtr fd);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshaller_SetTrace", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshaller_SetTrace(IntPtr th, string traceChannelName);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerAccessOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerAccessOp_Complete(IntPtr th, int perr, long openId, long openSequence, int accessLevel, int controlFlags, int touch, int fileType, int fileFlags, int extraFlags, int color, int resourceSize, long fileId, long fileSize, long createTime, long accessTime, long writeTime, long changeTime, IntPtr serializeOpenContext, FormatterSerializeOpen_SerializeOpen_t serializeOpen);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerCapacityOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerCapacityOp_Complete(IntPtr th, int perr, long totalCapacity, long availableCapacity);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerCloseOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerCloseOp_Complete(IntPtr th, int perr);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerControlOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerControlOp_Complete(IntPtr th, int perr, int outputSize);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerDeleteOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerDeleteOp_Complete(IntPtr th, int perr);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerFlushFileOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerFlushFileOp_Complete(IntPtr th, int perr, long openId, long openSequence, int accessLevel, int controlFlags, int touch, int fileType, int fileFlags, int extraFlags, int color, int resourceSize, long fileId, long fileSize, long createTime, long accessTime, long writeTime, long changeTime, IntPtr serializeOpenContext, FormatterSerializeOpen_SerializeOpen_t serializeOpen);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerFlushMediaOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerFlushMediaOp_Complete(IntPtr th, int perr, int msecFlushDelay);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerListEndOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerListEndOp_Complete(IntPtr th, int perr);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerListOp_Add", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern bool PfmMarshallerListOp_Add(IntPtr th, int fileType, int fileFlags, int extraFlags, int color, int resourceSize, long fileId, long fileSize, long createTime, long accessTime, long writeTime, long changeTime, string endName);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerListOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerListOp_Complete(IntPtr th, int perr, bool noMore);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerMediaInfoOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerMediaInfoOp_Complete(IntPtr th, int perr, byte[] mediaUuid, long mediaId64, int mediaId32, int mediaFlags, long createTime, string mediaLabel);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerMoveOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerMoveOp_Complete(IntPtr th, int perr, bool existed, long openId, long openSequence, int accessLevel, int controlFlags, int touch, int fileType, int fileFlags, int extraFlags, int color, int resourceSize, long fileId, long fileSize, long createTime, long accessTime, long writeTime, long changeTime, long parentFileId, string endName, int linkNamePartCount, IntPtr linkData, int linkDataSize, IntPtr serializeOpenContext, FormatterSerializeOpen_SerializeOpen_t serializeOpen);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerMoveOp_TargetNamePart", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerMoveOp_TargetNamePart(IntPtr th, int index, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerMoveReplaceOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerMoveReplaceOp_Complete(IntPtr th, int perr);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerOpenOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerOpenOp_Complete(IntPtr th, int perr, bool existed, long openId, long openSequence, int accessLevel, int controlFlags, int touch, int fileType, int fileFlags, int extraFlags, int color, int resourceSize, long fileId, long fileSize, long createTime, long accessTime, long writeTime, long changeTime, long parentFileId, string endName, int linkNamePartCount, IntPtr linkData, int linkDataSize, IntPtr serializeOpenContext, FormatterSerializeOpen_SerializeOpen_t serializeOpen);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerOpenOp_NamePart", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerOpenOp_NamePart(IntPtr th, int index, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerReadOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerReadOp_Complete(IntPtr th, int perr, int actualSize);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerReadXattrOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerReadXattrOp_Complete(IntPtr th, int perr, int xattrSize, int transferredSize);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerReplaceOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerReplaceOp_Complete(IntPtr th, int perr, long openId, long openSequence, int accessLevel, int controlFlags, int touch, int fileType, int fileFlags, int extraFlags, int color, int resourceSize, long fileId, long fileSize, long createTime, long accessTime, long writeTime, long changeTime, IntPtr serializeOpenContext, FormatterSerializeOpen_SerializeOpen_t serializeOpen);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerSetSizeOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerSetSizeOp_Complete(IntPtr th, int perr);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerWriteOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerWriteOp_Complete(IntPtr th, int perr, int actualSize);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMarshallerWriteXattrOp_Complete", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMarshallerWriteXattrOp_Complete(IntPtr th, int perr, int transferredSize);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_Control", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_Control(IntPtr th, int controlCode, IntPtr input, int inputSize, IntPtr output, int maxOutputSize, out int outputSize);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_Flush", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_Flush(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetAppId", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetAppId(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetChangeInstance", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern long PfmMount_GetChangeInstance(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetDriveLetter", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern char PfmMount_GetDriveLetter(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetFormatterName", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetFormatterName(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetMountEndName", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetMountEndName(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetMountFlags", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_GetMountFlags(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetMountId", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_GetMountId(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetMountPoint", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetMountPoint(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetMountSourceName", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetMountSourceName(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetOwnerId", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetOwnerId(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetOwnerName", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetOwnerName(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetStatusFlags", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_GetStatusFlags(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetUncName", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_GetUncName(IntPtr th, IntPtr nameBoxContext, StringBox_Set_t nameBox);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_GetVolumeFlags", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_GetVolumeFlags(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_Refresh", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_Refresh(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_Release", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMount_Release(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_Unmount", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_Unmount(IntPtr th, int unmountFlags);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMount_WaitReady", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMount_WaitReady(IntPtr th, int timeoutMsecs);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMountIterator_Next", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMountIterator_Next(IntPtr th, out long changeInstance);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMountIterator_Release", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMountIterator_Release(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMountMonitor_Cancel", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMountMonitor_Cancel(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMountMonitor_Release", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern void PfmMountMonitor_Release(IntPtr th);
    [DllImport("pfmshim_180", EntryPoint="pfm180_PfmMountMonitor_Wait", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=true)]
    private static extern int PfmMountMonitor_Wait(IntPtr th, long nextChangeInstance, int timeoutMsecs);
    private static FormatterSerializeOpen_SerializeOpen_t SerializeOpen(Pfm.FormatterSerializeOpen so)
    {
        SerializeOpenShim shim = null;
        if (so != null)
        {
            shim = new SerializeOpenShim(so);
        }
        if (shim != null)
        {
            return shim.serializeOpen;
        }
        return null;
    }

    private class Api : Pfm.Api, IDisposable
    {
        internal IntPtr th = IntPtr.Zero;

        public void Dispose()
        {
            if (this.th != IntPtr.Zero)
            {
                PfmShim.PfmApi_Release(this.th);
            }
            this.th = IntPtr.Zero;
        }

        public int FastPipeCreate(Pfm.FastPipeCreateParams fpcp, out IntPtr clientFd, out IntPtr serverFd)
        {
            return PfmShim.PfmApi_FastPipeCreate(this.th, fpcp.fastPipeFlags, out clientFd, out serverFd);
        }

        public int FileMountFactory(out Pfm.FileMount outFileMount)
        {
            PfmShim.FileMount mount = new PfmShim.FileMount();
            int num = PfmShim.PfmApi_FileMountFactory(this.th, out mount.th);
            if (num != 0)
            {
                mount.Dispose();
                mount = null;
            }
            outFileMount = mount;
            return num;
        }

        public int MountCreate(Pfm.MountCreateParams mcp, out Pfm.Mount outMount)
        {
            PfmShim.Mount mount = new PfmShim.Mount();
            int num = PfmShim.PfmApi_MountCreate(this.th, mcp.mountSourceName, mcp.mountFlags, mcp.driveLetter, mcp.ownerId, mcp.toFormatterWrite, mcp.fromFormatterRead, mcp.toAuthWrite, mcp.fromAuthRead, mcp.appId, out mount.th);
            if (num != 0)
            {
                mount.Dispose();
                mount = null;
            }
            outMount = mount;
            return num;
        }

        public int MountEndNameOpen(string mountEndName, out Pfm.Mount outMount)
        {
            PfmShim.Mount mount = new PfmShim.Mount();
            int num = PfmShim.PfmApi_MountEndNameOpen(this.th, mountEndName, out mount.th);
            if (num != 0)
            {
                mount.Dispose();
                mount = null;
            }
            outMount = mount;
            return num;
        }

        public int MountIdOpen(int mountId, out Pfm.Mount outMount)
        {
            PfmShim.Mount mount = new PfmShim.Mount();
            int num = PfmShim.PfmApi_MountIdOpen(this.th, mountId, out mount.th);
            if (num != 0)
            {
                mount.Dispose();
                mount = null;
            }
            outMount = mount;
            return num;
        }

        public int MountIterate(long startChangeInstance, out long outNextChangeInstance, out Pfm.MountIterator outIterator)
        {
            PfmShim.MountIterator iterator = new PfmShim.MountIterator();
            int num = PfmShim.PfmApi_MountIterate(this.th, startChangeInstance, out outNextChangeInstance, out iterator.th);
            if (num != 0)
            {
                iterator.Dispose();
                iterator = null;
            }
            outIterator = iterator;
            return num;
        }

        public int MountMonitorFactory(out Pfm.MountMonitor outMonitor)
        {
            PfmShim.MountMonitor monitor = new PfmShim.MountMonitor();
            int num = PfmShim.PfmApi_MountMonitorFactory(this.th, out monitor.th);
            if (num != 0)
            {
                monitor.Dispose();
                monitor = null;
            }
            outMonitor = monitor;
            return num;
        }

        public int MountPointOpen(string mountPoint, out Pfm.Mount outMount)
        {
            PfmShim.Mount mount = new PfmShim.Mount();
            int num = PfmShim.PfmApi_MountPointOpen(this.th, mountPoint, out mount.th);
            if (num != 0)
            {
                mount.Dispose();
                mount = null;
            }
            outMount = mount;
            return num;
        }

        public int MountSourceNameOpen(string mountSourceName, out Pfm.Mount outMount)
        {
            PfmShim.Mount mount = new PfmShim.Mount();
            int num = PfmShim.PfmApi_MountSourceNameOpen(this.th, mountSourceName, out mount.th);
            if (num != 0)
            {
                mount.Dispose();
                mount = null;
            }
            outMount = mount;
            return num;
        }

        public int SysStart()
        {
            return PfmShim.PfmApi_SysStart(this.th);
        }

        public string Version()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmApi_Version(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }
    }

    private class Dispatch
    {
        internal PfmShim.FormatterDispatch_Access_t access;
        internal PfmShim.FormatterDispatch_Capacity_t capacity;
        internal PfmShim.FormatterDispatch_Close_t close;
        internal PfmShim.FormatterDispatch_Control_t control;
        internal PfmShim.FormatterDispatch_Delete_t delete_;
        internal Pfm.FormatterDispatch dispatch;
        internal PfmShim.FormatterDispatch_FlushFile_t flushFile;
        internal PfmShim.FormatterDispatch_FlushMedia_t flushMedia;
        internal PfmShim.FormatterDispatch_List_t list;
        internal PfmShim.FormatterDispatch_ListEnd_t listEnd;
        internal PfmShim.FormatterDispatch_MediaInfo_t mediaInfo;
        internal PfmShim.FormatterDispatch_Move_t move;
        internal PfmShim.FormatterDispatch_MoveReplace_t moveReplace;
        internal PfmShim.FormatterDispatch_Open_t open;
        internal PfmShim.FormatterDispatch_Read_t read;
        internal PfmShim.FormatterDispatch_ReadXattr_t readXattr;
        internal PfmShim.FormatterDispatch_Replace_t replace;
        internal PfmShim.FormatterDispatch_SetSize_t setSize;
        internal PfmShim.FormatterDispatch_Write_t write;
        internal PfmShim.FormatterDispatch_WriteXattr_t writeXattr;

        internal Dispatch(Pfm.FormatterDispatch inDispatch)
        {
            this.dispatch = inDispatch;
            this.open = new PfmShim.FormatterDispatch_Open_t(this.Open);
            this.replace = new PfmShim.FormatterDispatch_Replace_t(this.Replace);
            this.move = new PfmShim.FormatterDispatch_Move_t(this.Move);
            this.moveReplace = new PfmShim.FormatterDispatch_MoveReplace_t(this.MoveReplace);
            this.delete_ = new PfmShim.FormatterDispatch_Delete_t(this.Delete);
            this.close = new PfmShim.FormatterDispatch_Close_t(this.Close);
            this.flushFile = new PfmShim.FormatterDispatch_FlushFile_t(this.FlushFile);
            this.list = new PfmShim.FormatterDispatch_List_t(this.List);
            this.listEnd = new PfmShim.FormatterDispatch_ListEnd_t(this.ListEnd);
            this.read = new PfmShim.FormatterDispatch_Read_t(this.Read);
            this.write = new PfmShim.FormatterDispatch_Write_t(this.Write);
            this.setSize = new PfmShim.FormatterDispatch_SetSize_t(this.SetSize);
            this.capacity = new PfmShim.FormatterDispatch_Capacity_t(this.Capacity);
            this.flushMedia = new PfmShim.FormatterDispatch_FlushMedia_t(this.FlushMedia);
            this.control = new PfmShim.FormatterDispatch_Control_t(this.Control);
            this.mediaInfo = new PfmShim.FormatterDispatch_MediaInfo_t(this.MediaInfo);
            this.access = new PfmShim.FormatterDispatch_Access_t(this.Access);
            this.readXattr = new PfmShim.FormatterDispatch_ReadXattr_t(this.ReadXattr);
            this.writeXattr = new PfmShim.FormatterDispatch_WriteXattr_t(this.WriteXattr);
        }

        internal void Access(IntPtr context, IntPtr ox, long openId, int accessLevel)
        {
            AccessOp op = null;
            try
            {
                op = new AccessOp();
                op.ox = ox;
                op.openId = openId;
                op.accessLevel = accessLevel;
                this.dispatch.Access(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    AccessOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Capacity(IntPtr context, IntPtr ox, long openId)
        {
            CapacityOp op = null;
            try
            {
                op = new CapacityOp();
                op.ox = ox;
                op.openId = openId;
                this.dispatch.Capacity(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    CapacityOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Close(IntPtr context, IntPtr ox, long openId, long openSequence)
        {
            CloseOp op = null;
            try
            {
                op = new CloseOp();
                op.ox = ox;
                op.openId = openId;
                op.openSequence = openSequence;
                this.dispatch.Close(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    CloseOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Control(IntPtr context, IntPtr ox, long openId, int accessLevel, int controlCode, IntPtr input, int inputSize, IntPtr output, int maxOutputSize)
        {
            ControlOp op = null;
            try
            {
                op = new ControlOp();
                op.ox = ox;
                op.openId = openId;
                op.accessLevel = accessLevel;
                op.controlCode = controlCode;
                op.inputMem = input;
                op.inputSize = inputSize;
                op.outputMem = output;
                op.maxOutputSize = maxOutputSize;
                this.dispatch.Control(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    ControlOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Delete(IntPtr context, IntPtr ox, long openId, long parentFileId, string endName, long writeTime)
        {
            DeleteOp op = null;
            try
            {
                op = new DeleteOp();
                op.ox = ox;
                op.openId = openId;
                op.parentFileId = parentFileId;
                op.endName = endName;
                op.writeTime = writeTime;
                this.dispatch.Delete(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    DeleteOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void FlushFile(IntPtr context, IntPtr ox, long openId, int flushFlags, int fileFlags, int color, long createTime, long accessTime, long writeTime, long changeTime)
        {
            FlushFileOp op = null;
            try
            {
                op = new FlushFileOp();
                op.ox = ox;
                op.openId = openId;
                op.flushFlags = flushFlags;
                op.fileFlags = fileFlags;
                op.color = color;
                op.createTime = createTime;
                op.accessTime = accessTime;
                op.writeTime = writeTime;
                op.changeTime = changeTime;
                this.dispatch.FlushFile(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    FlushFileOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void FlushMedia(IntPtr context, IntPtr ox)
        {
            FlushMediaOp op = null;
            try
            {
                op = new FlushMediaOp();
                op.ox = ox;
                this.dispatch.FlushMedia(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    FlushMediaOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void List(IntPtr context, IntPtr ox, long openId, long listId)
        {
            ListOp op = null;
            try
            {
                op = new ListOp();
                op.ox = ox;
                op.openId = openId;
                op.listId = listId;
                this.dispatch.List(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    ListOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void ListEnd(IntPtr context, IntPtr ox, long openId, long listId)
        {
            ListEndOp op = null;
            try
            {
                op = new ListEndOp();
                op.ox = ox;
                op.openId = openId;
                op.listId = listId;
                this.dispatch.ListEnd(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    ListEndOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void MediaInfo(IntPtr context, IntPtr ox, long openId)
        {
            MediaInfoOp op = null;
            try
            {
                op = new MediaInfoOp();
                op.ox = ox;
                op.openId = openId;
                this.dispatch.MediaInfo(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    MediaInfoOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Move(IntPtr context, IntPtr ox, long sourceOpenId, long sourceParentFileId, string sourceEndName, int targetNamePartCount, bool deleteSource, long writeTime, int existingAccessLevel, long newExistingOpenId)
        {
            MoveOp op = null;
            try
            {
                PfmShim.StringBox box = new PfmShim.StringBox();
                op = new MoveOp();
                op.ox = ox;
                op.sourceOpenId = sourceOpenId;
                op.sourceParentFileId = sourceParentFileId;
                op.sourceEndName = sourceEndName;
                op.targetNamePartCount = targetNamePartCount;
                op.deleteSource = deleteSource;
                op.writeTime = writeTime;
                op.existingAccessLevel = existingAccessLevel;
                op.newExistingOpenId = newExistingOpenId;
                op.targetNameParts = new string[targetNamePartCount];
                for (int i = 0; i < targetNamePartCount; i++)
                {
                    PfmShim.PfmMarshallerMoveOp_TargetNamePart(ox, i, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
                    op.targetNameParts[i] = box.val;
                }
                this.dispatch.Move(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    MoveOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void MoveReplace(IntPtr context, IntPtr ox, long sourceOpenId, long sourceParentFileId, string sourceEndName, long targetOpenId, long targetParentFileId, string targetEndName, bool deleteSource, long writeTime)
        {
            MoveReplaceOp op = null;
            try
            {
                op = new MoveReplaceOp();
                op.ox = ox;
                op.sourceOpenId = sourceOpenId;
                op.sourceParentFileId = sourceParentFileId;
                op.sourceEndName = sourceEndName;
                op.targetOpenId = targetOpenId;
                op.targetParentFileId = targetParentFileId;
                op.targetEndName = targetEndName;
                op.deleteSource = deleteSource;
                op.writeTime = writeTime;
                this.dispatch.MoveReplace(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    MoveReplaceOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Open(IntPtr context, IntPtr ox, int namePartCount, int createFileType, int createFileFlags, long writeTime, long newCreateOpenId, int existingAccessLevel, long newExistingOpenId)
        {
            OpenOp op = null;
            try
            {
                PfmShim.StringBox box = new PfmShim.StringBox();
                op = new OpenOp();
                op.ox = ox;
                op.namePartCount = namePartCount;
                op.createFileType = createFileType;
                op.createFileFlags = createFileFlags;
                op.writeTime = writeTime;
                op.newCreateOpenId = newCreateOpenId;
                op.existingAccessLevel = existingAccessLevel;
                op.newExistingOpenId = newExistingOpenId;
                op.nameParts = new string[namePartCount];
                for (int i = 0; i < namePartCount; i++)
                {
                    PfmShim.PfmMarshallerOpenOp_NamePart(ox, i, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
                    op.nameParts[i] = box.val;
                }
                this.dispatch.Open(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    OpenOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Read(IntPtr context, IntPtr ox, long openId, long fileOffset, IntPtr data, int requestedSize)
        {
            ReadOp op = null;
            try
            {
                op = new ReadOp();
                op.ox = ox;
                op.openId = openId;
                op.fileOffset = fileOffset;
                op.dataMem = data;
                op.requestedSize = requestedSize;
                this.dispatch.Read(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    ReadOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void ReadXattr(IntPtr context, IntPtr ox, long openId, string name, int offset, IntPtr data, int requestedSize)
        {
            ReadXattrOp op = null;
            try
            {
                op = new ReadXattrOp();
                op.ox = ox;
                op.openId = openId;
                op.name = name;
                op.offset = offset;
                op.dataMem = data;
                op.requestedSize = requestedSize;
                this.dispatch.ReadXattr(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    ReadXattrOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Replace(IntPtr context, IntPtr ox, long targetOpenId, long targetParentFileId, string targetEndName, int createFileFlags, long writeTime, long newCreateOpenId)
        {
            ReplaceOp op = null;
            try
            {
                op = new ReplaceOp();
                op.ox = ox;
                op.targetOpenId = targetOpenId;
                op.targetParentFileId = targetParentFileId;
                op.targetEndName = targetEndName;
                op.createFileFlags = createFileFlags;
                op.writeTime = writeTime;
                op.newCreateOpenId = newCreateOpenId;
                this.dispatch.Replace(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    ReplaceOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void SetSize(IntPtr context, IntPtr ox, long openId, long fileSize)
        {
            SetSizeOp op = null;
            try
            {
                op = new SetSizeOp();
                op.ox = ox;
                op.openId = openId;
                op.fileSize = fileSize;
                this.dispatch.SetSize(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    SetSizeOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void Write(IntPtr context, IntPtr ox, long openId, long fileOffset, IntPtr data, int requestedSize)
        {
            WriteOp op = null;
            try
            {
                op = new WriteOp();
                op.ox = ox;
                op.openId = openId;
                op.fileOffset = fileOffset;
                op.dataMem = data;
                op.requestedSize = requestedSize;
                this.dispatch.Write(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    WriteOp.Complete(ref ox);
                }
                throw;
            }
        }

        internal void WriteXattr(IntPtr context, IntPtr ox, long openId, string name, int xattrSize, int offset, IntPtr data, int requestedSize)
        {
            WriteXattrOp op = null;
            try
            {
                op = new WriteXattrOp();
                op.ox = ox;
                op.openId = openId;
                op.name = name;
                op.xattrSize = xattrSize;
                op.offset = offset;
                op.dataMem = data;
                op.requestedSize = requestedSize;
                this.dispatch.WriteXattr(op);
            }
            catch
            {
                if (op != null)
                {
                    op.Dispose();
                }
                else
                {
                    WriteXattrOp.Complete(ref ox);
                }
                throw;
            }
        }

        private class AccessOp : Pfm.MarshallerAccessOp, IDisposable
        {
            internal int accessLevel;
            internal long openId;
            internal IntPtr ox;

            public int AccessLevel()
            {
                return this.accessLevel;
            }

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerAccessOp_Complete(ox, 7, 0L, 0L, 0, 0, 0, 0, 0, 0, 0, 0, 0L, 0L, 0L, 0L, 0L, 0L, IntPtr.Zero, null);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, Pfm.OpenAttribs openAttribs, Pfm.FormatterSerializeOpen serializeOpen)
            {
                try
                {
                    PfmShim.PfmMarshallerAccessOp_Complete(this.ox, perr, openAttribs.openId, openAttribs.openSequence, openAttribs.accessLevel, openAttribs.controlFlags, openAttribs.touch, openAttribs.attribs.fileType, openAttribs.attribs.fileFlags, openAttribs.attribs.extraFlags, openAttribs.attribs.color, openAttribs.attribs.resourceSize, openAttribs.attribs.fileId, openAttribs.attribs.fileSize, openAttribs.attribs.createTime, openAttribs.attribs.accessTime, openAttribs.attribs.writeTime, openAttribs.attribs.changeTime, IntPtr.Zero, PfmShim.SerializeOpen(serializeOpen));
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long OpenId()
            {
                return this.openId;
            }
        }

        private class CapacityOp : Pfm.MarshallerCapacityOp, IDisposable
        {
            internal long openId;
            internal IntPtr ox;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerCapacityOp_Complete(ox, 7, 0L, 0L);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, long totalCapacity, long availableCapacity)
            {
                try
                {
                    PfmShim.PfmMarshallerCapacityOp_Complete(this.ox, perr, totalCapacity, availableCapacity);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long OpenId()
            {
                return this.openId;
            }
        }

        private class CloseOp : Pfm.MarshallerCloseOp, IDisposable
        {
            internal long openId;
            internal long openSequence;
            internal IntPtr ox;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerCloseOp_Complete(ox, 7);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr)
            {
                try
                {
                    PfmShim.PfmMarshallerCloseOp_Complete(this.ox, perr);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long OpenId()
            {
                return this.openId;
            }

            public long OpenSequence()
            {
                return this.openSequence;
            }
        }

        private class ControlOp : Pfm.MarshallerControlOp, IDisposable
        {
            internal int accessLevel;
            internal int controlCode;
            internal byte[] input;
            internal IntPtr inputMem;
            internal GCHandle inputPin;
            internal int inputSize;
            internal int maxOutputSize;
            internal long openId;
            internal byte[] output;
            internal IntPtr outputMem;
            internal GCHandle outputPin;
            internal IntPtr ox;

            public int AccessLevel()
            {
                return this.accessLevel;
            }

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerControlOp_Complete(ox, 7, 0);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, int outputSize)
            {
                try
                {
                    if ((this.output != null) && (outputSize != 0))
                    {
                        Marshal.Copy(this.output, 0, this.outputMem, outputSize);
                    }
                    PfmShim.PfmMarshallerControlOp_Complete(this.ox, perr, outputSize);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public int ControlCode()
            {
                return this.controlCode;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public byte[] Input()
            {
                if ((this.input == null) && (this.inputSize != 0))
                {
                    this.input = new byte[this.inputSize];
                    Marshal.Copy(this.inputMem, this.input, 0, this.inputSize);
                }
                return this.input;
            }

            public int InputSize()
            {
                return this.inputSize;
            }

            public int MaxOutputSize()
            {
                return this.maxOutputSize;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public byte[] Output()
            {
                if ((this.output == null) && (this.maxOutputSize != 0))
                {
                    this.output = new byte[this.maxOutputSize];
                }
                return this.output;
            }

            public IntPtr PinnedInput()
            {
                if (this.input != null)
                {
                    return IntPtr.Zero;
                }
                return this.inputMem;
            }

            public IntPtr PinnedOutput()
            {
                if (this.output != null)
                {
                    return IntPtr.Zero;
                }
                return this.outputMem;
            }
        }

        private class DeleteOp : Pfm.MarshallerDeleteOp, IDisposable
        {
            internal string endName;
            internal long openId;
            internal IntPtr ox;
            internal long parentFileId;
            internal long writeTime;

            public void Complete(int perr)
            {
                try
                {
                    PfmShim.PfmMarshallerDeleteOp_Complete(this.ox, perr);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerDeleteOp_Complete(ox, 7);
                ox = IntPtr.Zero;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public string EndName()
            {
                return this.endName;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public long ParentFileId()
            {
                return this.parentFileId;
            }

            public long WriteTime()
            {
                return this.writeTime;
            }
        }

        private class FlushFileOp : Pfm.MarshallerFlushFileOp, IDisposable
        {
            internal long accessTime;
            internal long changeTime;
            internal int color;
            internal long createTime;
            internal int fileFlags;
            internal int flushFlags;
            internal byte[] linkData;
            internal int linkDataSize;
            internal long openId;
            internal IntPtr ox;
            internal long writeTime;

            public long AccessTime()
            {
                return this.accessTime;
            }

            public long ChangeTime()
            {
                return this.changeTime;
            }

            public int Color()
            {
                return this.color;
            }

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerFlushFileOp_Complete(ox, 7, 0L, 0L, 0, 0, 0, 0, 0, 0, 0, 0, 0L, 0L, 0L, 0L, 0L, 0L, IntPtr.Zero, null);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, Pfm.OpenAttribs openAttribs, Pfm.FormatterSerializeOpen serializeOpen)
            {
                try
                {
                    PfmShim.PfmMarshallerFlushFileOp_Complete(this.ox, perr, openAttribs.openId, openAttribs.openSequence, openAttribs.accessLevel, openAttribs.controlFlags, openAttribs.touch, openAttribs.attribs.fileType, openAttribs.attribs.fileFlags, openAttribs.attribs.extraFlags, openAttribs.attribs.color, openAttribs.attribs.resourceSize, openAttribs.attribs.fileId, openAttribs.attribs.fileSize, openAttribs.attribs.createTime, openAttribs.attribs.accessTime, openAttribs.attribs.writeTime, openAttribs.attribs.changeTime, IntPtr.Zero, PfmShim.SerializeOpen(serializeOpen));
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public long CreateTime()
            {
                return this.createTime;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public int FileFlags()
            {
                return this.fileFlags;
            }

            public int FlushFlags()
            {
                return this.flushFlags;
            }

            public byte[] LinkData()
            {
                return this.linkData;
            }

            public int LinkDataSize()
            {
                return this.linkDataSize;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public long WriteTime()
            {
                return this.writeTime;
            }
        }

        private class FlushMediaOp : Pfm.MarshallerFlushMediaOp, IDisposable
        {
            internal IntPtr ox;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerFlushMediaOp_Complete(ox, 7, 0);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, int msecFlushDelay)
            {
                try
                {
                    PfmShim.PfmMarshallerFlushMediaOp_Complete(this.ox, perr, msecFlushDelay);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }
        }

        private class ListEndOp : Pfm.MarshallerListEndOp, IDisposable
        {
            internal long listId;
            internal long openId;
            internal IntPtr ox;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerListEndOp_Complete(ox, 7);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr)
            {
                try
                {
                    PfmShim.PfmMarshallerListEndOp_Complete(this.ox, perr);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long ListId()
            {
                return this.listId;
            }

            public long OpenId()
            {
                return this.openId;
            }
        }

        private class ListOp : Pfm.MarshallerListOp, IDisposable
        {
            internal long listId;
            internal long openId;
            internal IntPtr ox;

            public bool Add(Pfm.Attribs attribs, string endName)
            {
                return PfmShim.PfmMarshallerListOp_Add(this.ox, attribs.fileType, attribs.fileFlags, attribs.extraFlags, attribs.color, attribs.resourceSize, attribs.fileId, attribs.fileSize, attribs.createTime, attribs.accessTime, attribs.writeTime, attribs.changeTime, endName);
            }

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerListOp_Complete(ox, 7, true);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, bool noMore)
            {
                try
                {
                    PfmShim.PfmMarshallerListOp_Complete(this.ox, perr, noMore);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long ListId()
            {
                return this.listId;
            }

            public long OpenId()
            {
                return this.openId;
            }
        }

        private class MediaInfoOp : Pfm.MarshallerMediaInfoOp, IDisposable
        {
            internal long openId;
            internal IntPtr ox;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerMediaInfoOp_Complete(ox, 7, null, 0L, 0, 0, 0L, null);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, Pfm.MediaInfo mediaInfo, string mediaLabel)
            {
                try
                {
                    PfmShim.PfmMarshallerMediaInfoOp_Complete(this.ox, perr, mediaInfo.mediaUuid, mediaInfo.mediaId64, mediaInfo.mediaId32, mediaInfo.mediaFlags, mediaInfo.createTime, mediaLabel);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long OpenId()
            {
                return this.openId;
            }
        }

        private class MoveOp : Pfm.MarshallerMoveOp, IDisposable
        {
            internal bool deleteSource;
            internal int existingAccessLevel;
            internal long newExistingOpenId;
            internal IntPtr ox;
            internal string sourceEndName;
            internal long sourceOpenId;
            internal long sourceParentFileId;
            internal int targetNamePartCount;
            internal string[] targetNameParts;
            internal long writeTime;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerMoveOp_Complete(ox, 7, false, 0L, 0L, 0, 0, 0, 0, 0, 0, 0, 0, 0L, 0L, 0L, 0L, 0L, 0L, 0L, null, 0, IntPtr.Zero, 0, IntPtr.Zero, null);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, bool existed, Pfm.OpenAttribs openAttribs, long parentFileId, string endName, int linkNamePartCount, byte[] linkData, int linkDataSize, Pfm.FormatterSerializeOpen serializeOpen)
            {
                try
                {
                    IntPtr zero = IntPtr.Zero;
                    if (linkDataSize != 0)
                    {
                        zero = GCHandle.Alloc(linkData, GCHandleType.Pinned).AddrOfPinnedObject();
                    }
                    PfmShim.PfmMarshallerMoveOp_Complete(this.ox, perr, existed, openAttribs.openId, openAttribs.openSequence, openAttribs.accessLevel, openAttribs.controlFlags, openAttribs.touch, openAttribs.attribs.fileType, openAttribs.attribs.fileFlags, openAttribs.attribs.extraFlags, openAttribs.attribs.color, openAttribs.attribs.resourceSize, openAttribs.attribs.fileId, openAttribs.attribs.fileSize, openAttribs.attribs.createTime, openAttribs.attribs.accessTime, openAttribs.attribs.writeTime, openAttribs.attribs.changeTime, parentFileId, endName, linkNamePartCount, zero, linkDataSize, IntPtr.Zero, PfmShim.SerializeOpen(serializeOpen));
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public bool DeleteSource()
            {
                return this.deleteSource;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public int ExistingAccessLevel()
            {
                return this.existingAccessLevel;
            }

            public long NewExistingOpenId()
            {
                return this.newExistingOpenId;
            }

            public string SourceEndName()
            {
                return this.sourceEndName;
            }

            public long SourceOpenId()
            {
                return this.sourceOpenId;
            }

            public long SourceParentFileId()
            {
                return this.sourceParentFileId;
            }

            public int TargetNamePartCount()
            {
                return this.targetNamePartCount;
            }

            public string[] TargetNameParts()
            {
                return this.targetNameParts;
            }

            public long WriteTime()
            {
                return this.writeTime;
            }
        }

        private class MoveReplaceOp : Pfm.MarshallerMoveReplaceOp, IDisposable
        {
            internal bool deleteSource;
            internal IntPtr ox;
            internal string sourceEndName;
            internal long sourceOpenId;
            internal long sourceParentFileId;
            internal string targetEndName;
            internal long targetOpenId;
            internal long targetParentFileId;
            internal long writeTime;

            public void Complete(int perr)
            {
                try
                {
                    PfmShim.PfmMarshallerMoveReplaceOp_Complete(this.ox, perr);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerMoveReplaceOp_Complete(ox, 7);
                ox = IntPtr.Zero;
            }

            public bool DeleteSource()
            {
                return this.deleteSource;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public string SourceEndName()
            {
                return this.sourceEndName;
            }

            public long SourceOpenId()
            {
                return this.sourceOpenId;
            }

            public long SourceParentFileId()
            {
                return this.sourceParentFileId;
            }

            public string TargetEndName()
            {
                return this.targetEndName;
            }

            public long TargetOpenId()
            {
                return this.targetOpenId;
            }

            public long TargetParentFileId()
            {
                return this.targetParentFileId;
            }

            public long WriteTime()
            {
                return this.writeTime;
            }
        }

        private class OpenOp : Pfm.MarshallerOpenOp, IDisposable
        {
            internal int createFileFlags;
            internal int createFileType;
            internal int existingAccessLevel;
            internal int namePartCount;
            internal string[] nameParts;
            internal long newCreateOpenId;
            internal long newExistingOpenId;
            internal IntPtr ox;
            internal long writeTime;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerOpenOp_Complete(ox, 7, false, 0L, 0L, 0, 0, 0, 0, 0, 0, 0, 0, 0L, 0L, 0L, 0L, 0L, 0L, 0L, null, 0, IntPtr.Zero, 0, IntPtr.Zero, null);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, bool existed, Pfm.OpenAttribs openAttribs, long parentFileId, string endName, int linkNamePartCount, byte[] linkData, int linkDataSize, Pfm.FormatterSerializeOpen serializeOpen)
            {
                try
                {
                    IntPtr zero = IntPtr.Zero;
                    if (linkDataSize != 0)
                    {
                        zero = GCHandle.Alloc(linkData, GCHandleType.Pinned).AddrOfPinnedObject();
                    }
                    PfmShim.PfmMarshallerOpenOp_Complete(this.ox, perr, existed, openAttribs.openId, openAttribs.openSequence, openAttribs.accessLevel, openAttribs.controlFlags, openAttribs.touch, openAttribs.attribs.fileType, openAttribs.attribs.fileFlags, openAttribs.attribs.extraFlags, openAttribs.attribs.color, openAttribs.attribs.resourceSize, openAttribs.attribs.fileId, openAttribs.attribs.fileSize, openAttribs.attribs.createTime, openAttribs.attribs.accessTime, openAttribs.attribs.writeTime, openAttribs.attribs.changeTime, parentFileId, endName, linkNamePartCount, zero, linkDataSize, IntPtr.Zero, PfmShim.SerializeOpen(serializeOpen));
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public int CreateFileFlags()
            {
                return this.createFileFlags;
            }

            public int CreateFileType()
            {
                return this.createFileType;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public int ExistingAccessLevel()
            {
                return this.existingAccessLevel;
            }

            public int NamePartCount()
            {
                return this.namePartCount;
            }

            public string[] NameParts()
            {
                return this.nameParts;
            }

            public long NewCreateOpenId()
            {
                return this.newCreateOpenId;
            }

            public long NewExistingOpenId()
            {
                return this.newExistingOpenId;
            }

            public long WriteTime()
            {
                return this.writeTime;
            }
        }

        private class ReadOp : Pfm.MarshallerReadOp, IDisposable
        {
            internal byte[] data;
            internal IntPtr dataMem;
            internal GCHandle dataPin;
            internal long fileOffset;
            internal long openId;
            internal IntPtr ox;
            internal int requestedSize;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerReadOp_Complete(ox, 7, 0);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, int actualSize)
            {
                try
                {
                    if ((this.data != null) && (actualSize != 0))
                    {
                        Marshal.Copy(this.data, 0, this.dataMem, actualSize);
                    }
                    PfmShim.PfmMarshallerReadOp_Complete(this.ox, perr, actualSize);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public byte[] Data()
            {
                if ((this.data == null) && (this.requestedSize != 0))
                {
                    this.data = new byte[this.requestedSize];
                }
                return this.data;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long FileOffset()
            {
                return this.fileOffset;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public IntPtr PinnedData()
            {
                if (this.data != null)
                {
                    return IntPtr.Zero;
                }
                return this.dataMem;
            }

            public int RequestedSize()
            {
                return this.requestedSize;
            }
        }

        private class ReadXattrOp : Pfm.MarshallerReadXattrOp, IDisposable
        {
            internal byte[] data;
            internal IntPtr dataMem;
            internal GCHandle dataPin;
            internal string name;
            internal int offset;
            internal long openId;
            internal IntPtr ox;
            internal int requestedSize;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerReadXattrOp_Complete(ox, 7, 0, 0);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, int xattrSize, int transferredSize)
            {
                try
                {
                    if ((this.data != null) && (transferredSize != 0))
                    {
                        Marshal.Copy(this.data, 0, this.dataMem, transferredSize);
                    }
                    PfmShim.PfmMarshallerReadXattrOp_Complete(this.ox, perr, xattrSize, transferredSize);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public byte[] Data()
            {
                if ((this.data == null) && (this.requestedSize != 0))
                {
                    this.data = new byte[this.requestedSize];
                }
                return this.data;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public string Name()
            {
                return this.name;
            }

            public int Offset()
            {
                return this.offset;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public IntPtr PinnedData()
            {
                if (this.data != null)
                {
                    return IntPtr.Zero;
                }
                return this.dataMem;
            }

            public int RequestedSize()
            {
                return this.requestedSize;
            }
        }

        private class ReplaceOp : Pfm.MarshallerReplaceOp, IDisposable
        {
            internal int createFileFlags;
            internal long newCreateOpenId;
            internal IntPtr ox;
            internal string targetEndName;
            internal long targetOpenId;
            internal long targetParentFileId;
            internal long writeTime;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerReplaceOp_Complete(ox, 7, 0L, 0L, 0, 0, 0, 0, 0, 0, 0, 0, 0L, 0L, 0L, 0L, 0L, 0L, IntPtr.Zero, null);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, Pfm.OpenAttribs openAttribs, Pfm.FormatterSerializeOpen serializeOpen)
            {
                try
                {
                    PfmShim.PfmMarshallerReplaceOp_Complete(this.ox, perr, openAttribs.openId, openAttribs.openSequence, openAttribs.accessLevel, openAttribs.controlFlags, openAttribs.touch, openAttribs.attribs.fileType, openAttribs.attribs.fileFlags, openAttribs.attribs.extraFlags, openAttribs.attribs.color, openAttribs.attribs.resourceSize, openAttribs.attribs.fileId, openAttribs.attribs.fileSize, openAttribs.attribs.createTime, openAttribs.attribs.accessTime, openAttribs.attribs.writeTime, openAttribs.attribs.changeTime, IntPtr.Zero, PfmShim.SerializeOpen(serializeOpen));
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public int CreateFileFlags()
            {
                return this.createFileFlags;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long NewCreateOpenId()
            {
                return this.newCreateOpenId;
            }

            public string TargetEndName()
            {
                return this.targetEndName;
            }

            public long TargetOpenId()
            {
                return this.targetOpenId;
            }

            public long TargetParentFileId()
            {
                return this.targetParentFileId;
            }

            public long WriteTime()
            {
                return this.writeTime;
            }
        }

        private class SetSizeOp : Pfm.MarshallerSetSizeOp, IDisposable
        {
            internal long fileSize;
            internal long openId;
            internal IntPtr ox;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerSetSizeOp_Complete(ox, 7);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr)
            {
                try
                {
                    PfmShim.PfmMarshallerSetSizeOp_Complete(this.ox, perr);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long FileSize()
            {
                return this.fileSize;
            }

            public long OpenId()
            {
                return this.openId;
            }
        }

        private class WriteOp : Pfm.MarshallerWriteOp, IDisposable
        {
            internal byte[] data;
            internal IntPtr dataMem;
            internal GCHandle dataPin;
            internal long fileOffset;
            internal long openId;
            internal IntPtr ox;
            internal int requestedSize;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerWriteOp_Complete(ox, 7, 0);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, int actualSize)
            {
                try
                {
                    PfmShim.PfmMarshallerWriteOp_Complete(this.ox, perr, actualSize);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public byte[] Data()
            {
                if ((this.data == null) && (this.requestedSize != 0))
                {
                    this.data = new byte[this.requestedSize];
                    Marshal.Copy(this.dataMem, this.data, 0, this.requestedSize);
                }
                return this.data;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public long FileOffset()
            {
                return this.fileOffset;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public IntPtr PinnedData()
            {
                if (this.data != null)
                {
                    return IntPtr.Zero;
                }
                return this.dataMem;
            }

            public int RequestedSize()
            {
                return this.requestedSize;
            }
        }

        private class WriteXattrOp : Pfm.MarshallerWriteXattrOp, IDisposable
        {
            internal byte[] data;
            internal IntPtr dataMem;
            internal GCHandle dataPin;
            internal string name;
            internal int offset;
            internal long openId;
            internal IntPtr ox;
            internal int requestedSize;
            internal int xattrSize;

            internal static void Complete(ref IntPtr ox)
            {
                PfmShim.PfmMarshallerWriteXattrOp_Complete(ox, 7, 0);
                ox = IntPtr.Zero;
            }

            public void Complete(int perr, int transferredSize)
            {
                try
                {
                    PfmShim.PfmMarshallerWriteXattrOp_Complete(this.ox, perr, transferredSize);
                    this.ox = IntPtr.Zero;
                }
                catch
                {
                    Complete(ref this.ox);
                    throw;
                }
            }

            public byte[] Data()
            {
                if ((this.data == null) && (this.requestedSize != 0))
                {
                    this.data = new byte[this.requestedSize];
                    Marshal.Copy(this.dataMem, this.data, 0, this.requestedSize);
                }
                return this.data;
            }

            public void Dispose()
            {
                Complete(ref this.ox);
            }

            public string Name()
            {
                return this.name;
            }

            public int Offset()
            {
                return this.offset;
            }

            public long OpenId()
            {
                return this.openId;
            }

            public IntPtr PinnedData()
            {
                if (this.data != null)
                {
                    return IntPtr.Zero;
                }
                return this.dataMem;
            }

            public int RequestedSize()
            {
                return this.requestedSize;
            }

            public int XattrSize()
            {
                return this.xattrSize;
            }
        }
    }

    private class Factories : Pfm.Factories, IDisposable
    {
        internal static string shimAssemblyName = "pfmshim_180";
        internal IntPtr shimModule = IntPtr.Zero;
        internal static string thisAssemblyFileName = Assembly.GetExecutingAssembly().Location;
        internal static string thisAssemblyFolder = Path.GetDirectoryName(thisAssemblyFileName);
        internal static string thisAssemblyName = "pfmclr_180";

        internal Factories()
        {
            string fileName = null;
            string str2 = IntPtr.Size == 8 ? "x64" : "x86";
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                fileName = PathCombine(thisAssemblyFolder, "win-" + str2, shimAssemblyName + ".dll");
                this.shimModule = LoadLibraryExW(fileName, IntPtr.Zero, 8);
            }
            else
            {
                IntPtr ptr;
                ptr = ptr = mono_image_loaded(thisAssemblyName);
                if (ptr != IntPtr.Zero)
                {
                    string str3 = null;
                    try
                    {
                        Process process = new Process();
                        process.EnableRaisingEvents = false;
                        process.StartInfo.FileName = "uname";
                        process.StartInfo.Arguments = "-s -m";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;
                        process.Start();
                        str3 = process.StandardOutput.ReadToEnd();
                    }
                    catch (Exception)
                    {
                    }
                    if (str3 == null)
                    {
                        str3 = "";
                    }
                    if (str3.Contains("arm"))
                    {
                        str2 = "arm";
                    }
                    if (str3.Contains("Darwin"))
                    {
                        fileName = PathCombine(thisAssemblyFolder, "mac", shimAssemblyName + ".bundle");
                    }
                    else if (str3.Contains("Linux"))
                    {
                        fileName = PathCombine(thisAssemblyFolder, "lin-" + str2, shimAssemblyName + ".so");
                    }
                }
                if (fileName != null)
                {
                    mono_dllmap_insert(ptr, shimAssemblyName, IntPtr.Zero, fileName, IntPtr.Zero);
                }
            }
        }

        public int ApiFactory(out Pfm.Api outApi)
        {
            PfmShim.Api api = new PfmShim.Api();
            int num = PfmShim.PfmFactories_ApiFactory(IntPtr.Zero, out api.th);
            if (num != 0)
            {
                api.Dispose();
                api = null;
            }
            outApi = api;
            return num;
        }

        public void Dispose()
        {
            if (this.shimModule != IntPtr.Zero)
            {
                FreeLibrary(this.shimModule);
                this.shimModule = IntPtr.Zero;
            }
        }

        [DllImport("kernel32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        internal static extern void FreeLibrary(IntPtr module);
        public int InstallCheck()
        {
            return PfmShim.PfmFactories_InstallCheck(IntPtr.Zero);
        }

        [DllImport("kernel32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        internal static extern IntPtr LoadLibraryExW(string fileName, IntPtr reserved1, int flags);
        public int MarshallerFactory(out Pfm.Marshaller outMarshaller)
        {
            PfmShim.Marshaller marshaller = new PfmShim.Marshaller();
            int num = PfmShim.PfmFactories_MarshallerFactory(IntPtr.Zero, out marshaller.th);
            if (num != 0)
            {
                marshaller.Dispose();
                marshaller = null;
            }
            outMarshaller = marshaller;
            return num;
        }

        [DllImport("__Internal", CharSet=CharSet.Ansi, ExactSpelling=true)]
        internal static extern void mono_dllmap_insert(IntPtr assembly, string dllName, IntPtr funcName, string targetDllName, IntPtr targetFuncName);
        [DllImport("__Internal", CharSet=CharSet.Ansi, ExactSpelling=true)]
        internal static extern IntPtr mono_image_loaded(string assemblyFileName);
        public void SystemCloseFd(IntPtr fd)
        {
            PfmShim.PfmFactories_SystemCloseFd(IntPtr.Zero, fd);
        }

        public int SystemCreatePipe(out IntPtr readFd, out IntPtr writeFd)
        {
            return PfmShim.PfmFactories_SystemCreatePipe(IntPtr.Zero, out readFd, out writeFd);
        }

        public int SystemGetStdout(out IntPtr fd)
        {
            return PfmShim.PfmFactories_SystemGetStdout(IntPtr.Zero, out fd);
        }
    }

    private class FileMount : Pfm.FileMount, IDisposable
    {
        internal IntPtr th = IntPtr.Zero;
        internal PfmShim.FileMountUiShim ui;

        public void Cancel()
        {
            PfmShim.PfmFileMount_Cancel(this.th);
        }

        public void Detach()
        {
            PfmShim.PfmFileMount_Detach(this.th);
        }

        public void Dispose()
        {
            if (this.th != IntPtr.Zero)
            {
                PfmShim.PfmFileMount_Release(this.th);
            }
            this.th = IntPtr.Zero;
        }

        public Pfm.Mount GetMount()
        {
            PfmShim.Mount mount = new PfmShim.Mount();
            mount.th = PfmShim.PfmFileMount_GetMount(this.th);
            if (mount.th == IntPtr.Zero)
            {
                mount.Dispose();
                mount = null;
            }
            return mount;
        }

        public void Send(string data, bool endOfLine)
        {
            PfmShim.PfmFileMount_Send(this.th, data, endOfLine);
        }

        public int Start(Pfm.FileMountCreateParams fmp)
        {
            this.ui = new PfmShim.FileMountUiShim(fmp.ui);
            int num = PfmShim.PfmFileMount_Start(this.th, fmp.mountFileName, fmp.mountFlags, fmp.fileMountFlags, fmp.driveLetter, fmp.ownerId, fmp.formatterName, fmp.password, IntPtr.Zero, this.ui.start, this.ui.complete, this.ui.status, this.ui.suspend, this.ui.resume, this.ui.queryPassword, this.ui.clearPassword);
            this.ui = null;
            return num;
        }

        public void Status(string data, bool endOfLine)
        {
            PfmShim.PfmFileMount_Status(this.th, data, endOfLine);
        }

        public int WaitReady()
        {
            return PfmShim.PfmFileMount_WaitReady(this.th);
        }
    }

    private delegate void FileMountUi_ClearPassword_t(IntPtr context);

    private delegate void FileMountUi_Complete_t(IntPtr context, string errorMessage);

    private delegate void FileMountUi_QueryPassword_t(IntPtr context, string prompt, int count, IntPtr passwordBoxContext, PfmShim.StringBox_Set_t passwordBox);

    private delegate void FileMountUi_Resume_t(IntPtr context);

    private delegate void FileMountUi_Start_t(IntPtr context);

    private delegate void FileMountUi_Status_t(IntPtr context, string data, bool endOfLine);

    private delegate void FileMountUi_Suspend_t(IntPtr context);

    private class FileMountUiShim
    {
        internal PfmShim.FileMountUi_ClearPassword_t clearPassword;
        internal PfmShim.FileMountUi_Complete_t complete;
        internal PfmShim.FileMountUi_QueryPassword_t queryPassword;
        internal PfmShim.FileMountUi_Resume_t resume;
        internal PfmShim.FileMountUi_Start_t start;
        internal PfmShim.FileMountUi_Status_t status;
        internal PfmShim.FileMountUi_Suspend_t suspend;
        internal Pfm.FileMountUi ui;

        internal FileMountUiShim(Pfm.FileMountUi inUi)
        {
            this.ui = inUi;
            if (this.ui != null)
            {
                this.ui = inUi;
                this.start = new PfmShim.FileMountUi_Start_t(this.Start);
                this.complete = new PfmShim.FileMountUi_Complete_t(this.Complete);
                this.status = new PfmShim.FileMountUi_Status_t(this.Status);
                this.suspend = new PfmShim.FileMountUi_Suspend_t(this.Suspend);
                this.resume = new PfmShim.FileMountUi_Resume_t(this.Resume);
                this.queryPassword = new PfmShim.FileMountUi_QueryPassword_t(this.QueryPassword);
                this.clearPassword = new PfmShim.FileMountUi_ClearPassword_t(this.ClearPassword);
            }
        }

        internal void ClearPassword(IntPtr context)
        {
            this.ui.ClearPassword();
        }

        internal void Complete(IntPtr context, string errorMessage)
        {
            this.ui.Complete(errorMessage);
        }

        internal void QueryPassword(IntPtr context, string prompt, int count, IntPtr passwordBoxContext, PfmShim.StringBox_Set_t passwordBox)
        {
            passwordBox(passwordBoxContext, this.ui.QueryPassword(prompt, count));
        }

        internal void Resume(IntPtr context)
        {
            this.ui.Resume();
        }

        internal void Start(IntPtr context)
        {
            this.ui.Start();
        }

        internal void Status(IntPtr context, string data, bool endOfLine)
        {
            this.ui.Status(data, endOfLine);
        }

        internal void Suspend(IntPtr context)
        {
            this.ui.Suspend();
        }
    }

    private delegate void FormatterDispatch_Access_t(IntPtr context, IntPtr op, long openId, int accessLevel);

    private delegate void FormatterDispatch_Capacity_t(IntPtr context, IntPtr op, long openId);

    private delegate void FormatterDispatch_Close_t(IntPtr context, IntPtr op, long openId, long openSequence);

    private delegate void FormatterDispatch_Control_t(IntPtr context, IntPtr op, long openId, int accessLevel, int controlCode, IntPtr input, int inputSize, IntPtr output, int maxOutputSize);

    private delegate void FormatterDispatch_Delete_t(IntPtr context, IntPtr op, long openId, long parentFileId, string endName, long writeTime);

    private delegate void FormatterDispatch_FlushFile_t(IntPtr context, IntPtr op, long openId, int flushFlags, int fileFlags, int color, long createTime, long accessTime, long writeTime, long changeTime);

    private delegate void FormatterDispatch_FlushMedia_t(IntPtr context, IntPtr op);

    private delegate void FormatterDispatch_List_t(IntPtr context, IntPtr op, long openId, long listId);

    private delegate void FormatterDispatch_ListEnd_t(IntPtr context, IntPtr op, long openId, long listId);

    private delegate void FormatterDispatch_MediaInfo_t(IntPtr context, IntPtr op, long openId);

    private delegate void FormatterDispatch_Move_t(IntPtr context, IntPtr op, long sourceOpenId, long sourceParentFileId, string sourceEndName, int targetNamePartCount, bool deleteSource, long writeTime, int existingAccessLevel, long newExistingOpenId);

    private delegate void FormatterDispatch_MoveReplace_t(IntPtr context, IntPtr op, long sourceOpenId, long sourceParentFileId, string sourceEndName, long targetOpenId, long targetParentFileId, string targetEndName, bool deleteSource, long writeTime);

    private delegate void FormatterDispatch_Open_t(IntPtr context, IntPtr op, int namePartCount, int createFileType, int createFileFlags, long writeTime, long newCreateOpenId, int existingAccessLevel, long newExistingOpenId);

    private delegate void FormatterDispatch_Read_t(IntPtr context, IntPtr op, long openId, long fileOffset, IntPtr data, int requestedSize);

    private delegate void FormatterDispatch_ReadXattr_t(IntPtr context, IntPtr op, long openId, string name, int offset, IntPtr data, int requestedSize);

    private delegate void FormatterDispatch_Replace_t(IntPtr context, IntPtr op, long targetOpenId, long targetParentFileId, string targetEndName, int createFileFlags, long writeTime, long newCreateOpenId);

    private delegate void FormatterDispatch_SetSize_t(IntPtr context, IntPtr op, long openId, long fileSize);

    private delegate void FormatterDispatch_Write_t(IntPtr context, IntPtr op, long openId, long fileOffset, IntPtr data, int requestedSize);

    private delegate void FormatterDispatch_WriteXattr_t(IntPtr context, IntPtr op, long openId, string name, int xattrSize, int offset, IntPtr data, int requestedSize);

    private delegate void FormatterSerializeOpen_SerializeOpen_t(IntPtr context, long openId, out long openSequence);

    private class Marshaller : Pfm.Marshaller, IDisposable
    {
        private PfmShim.Dispatch dispatch;
        internal IntPtr th = IntPtr.Zero;

        public void ClearPassword()
        {
            PfmShim.PfmMarshaller_ClearPassword(this.th);
        }

        public int ConvertSystemError(int err)
        {
            return PfmShim.PfmMarshaller_ConvertSystemError(this.th, err);
        }

        public void Dispose()
        {
            if (this.th != IntPtr.Zero)
            {
                PfmShim.PfmMarshaller_Release(this.th);
            }
            this.th = IntPtr.Zero;
        }

        public int GetClientFlags()
        {
            return PfmShim.PfmMarshaller_GetClientFlags(this.th);
        }

        public int GetClientVersion()
        {
            return PfmShim.PfmMarshaller_GetClientVersion(this.th);
        }

        public int GetPassword(IntPtr read, string prompt, out string password)
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            int num = PfmShim.PfmMarshaller_GetPassword(this.th, read, prompt, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            password = box.val;
            return num;
        }

        public void Line(string data, bool endOfLine)
        {
            PfmShim.PfmMarshaller_Line(this.th, data, endOfLine);
        }

        public void Print(string data)
        {
            PfmShim.PfmMarshaller_Print(this.th, data);
        }

        public void ServeCancel()
        {
            PfmShim.PfmMarshaller_ServeCancel(this.th);
        }

        public void ServeDispatch(Pfm.MarshallerServeParams msp)
        {
            PfmShim.Dispatch dispatch = new PfmShim.Dispatch(msp.dispatch);
            PfmShim.PfmMarshaller_ServeDispatch(this.th, msp.volumeFlags, msp.formatterName, msp.dataAlign, msp.toFormatterRead, msp.fromFormatterWrite, IntPtr.Zero, dispatch.open, dispatch.replace, dispatch.move, dispatch.moveReplace, dispatch.delete_, dispatch.close, dispatch.flushFile, dispatch.list, dispatch.listEnd, dispatch.read, dispatch.write, dispatch.setSize, dispatch.capacity, dispatch.flushMedia, dispatch.control, dispatch.mediaInfo, dispatch.access, dispatch.readXattr, dispatch.writeXattr);
            dispatch = null;
        }

        public void SetStatus(IntPtr fd)
        {
            PfmShim.PfmMarshaller_SetStatus(this.th, fd);
        }

        public void SetTrace(string traceChannelName)
        {
            PfmShim.PfmMarshaller_SetTrace(this.th, traceChannelName);
        }
    }

    private class Mount : Pfm.Mount, IDisposable
    {
        internal IntPtr th = IntPtr.Zero;

        public int Control(int controlCode, byte[] input, int inputSize, byte[] output, int maxOutputSize, out int outputSize)
        {
            IntPtr zero = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            if (inputSize != 0)
            {
                zero = GCHandle.Alloc(input, GCHandleType.Pinned).AddrOfPinnedObject();
            }
            if (maxOutputSize != 0)
            {
                ptr2 = GCHandle.Alloc(output, GCHandleType.Pinned).AddrOfPinnedObject();
            }
            return PfmShim.PfmMount_Control(this.th, controlCode, zero, inputSize, ptr2, maxOutputSize, out outputSize);
        }

        public void Dispose()
        {
            if (this.th != IntPtr.Zero)
            {
                PfmShim.PfmMount_Release(this.th);
            }
            this.th = IntPtr.Zero;
        }

        public int Flush()
        {
            return PfmShim.PfmMount_Flush(this.th);
        }

        public string GetAppId()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetAppId(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public long GetChangeInstance()
        {
            return PfmShim.PfmMount_GetChangeInstance(this.th);
        }

        public char GetDriveLetter()
        {
            return PfmShim.PfmMount_GetDriveLetter(this.th);
        }

        public string GetFormatterName()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetFormatterName(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public string GetMountEndName()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetMountEndName(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public int GetMountFlags()
        {
            return PfmShim.PfmMount_GetMountFlags(this.th);
        }

        public int GetMountId()
        {
            return PfmShim.PfmMount_GetMountId(this.th);
        }

        public string GetMountPoint()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetMountPoint(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public string GetMountSourceName()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetMountSourceName(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public string GetOwnerId()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetOwnerId(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public string GetOwnerName()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetOwnerName(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public int GetStatusFlags()
        {
            return PfmShim.PfmMount_GetStatusFlags(this.th);
        }

        public string GetUncName()
        {
            PfmShim.StringBox box = new PfmShim.StringBox();
            PfmShim.PfmMount_GetUncName(this.th, IntPtr.Zero, new PfmShim.StringBox_Set_t(box.Set));
            return box.val;
        }

        public int GetVolumeFlags()
        {
            return PfmShim.PfmMount_GetVolumeFlags(this.th);
        }

        public int Refresh()
        {
            return PfmShim.PfmMount_Refresh(this.th);
        }

        public int Unmount(int unmountFlags)
        {
            return PfmShim.PfmMount_Unmount(this.th, unmountFlags);
        }

        public int WaitReady(int timeoutMsecs)
        {
            return PfmShim.PfmMount_WaitReady(this.th, timeoutMsecs);
        }
    }

    private class MountIterator : Pfm.MountIterator, IDisposable
    {
        internal IntPtr th = IntPtr.Zero;

        public void Dispose()
        {
            if (this.th != IntPtr.Zero)
            {
                PfmShim.PfmMountIterator_Release(this.th);
            }
            this.th = IntPtr.Zero;
        }

        public int Next(out long changeInstance)
        {
            return PfmShim.PfmMountIterator_Next(this.th, out changeInstance);
        }
    }

    private class MountMonitor : Pfm.MountMonitor, IDisposable
    {
        internal IntPtr th = IntPtr.Zero;

        public void Cancel()
        {
            PfmShim.PfmMountMonitor_Cancel(this.th);
        }

        public void Dispose()
        {
            if (this.th != IntPtr.Zero)
            {
                PfmShim.PfmMountMonitor_Release(this.th);
            }
            this.th = IntPtr.Zero;
        }

        public int Wait(long nextChangeInstance, int timeoutMsecs)
        {
            return PfmShim.PfmMountMonitor_Wait(this.th, nextChangeInstance, timeoutMsecs);
        }
    }

    private class SerializeOpenShim
    {
        internal GCHandle gcRef;
        internal PfmShim.FormatterSerializeOpen_SerializeOpen_t serializeOpen;
        internal Pfm.FormatterSerializeOpen so;

        internal SerializeOpenShim(Pfm.FormatterSerializeOpen inSo)
        {
            this.so = inSo;
            this.serializeOpen = new PfmShim.FormatterSerializeOpen_SerializeOpen_t(this.SerializeOpen);
        }

        internal void SerializeOpen(IntPtr context, long openId, out long openSequence)
        {
            this.so.SerializeOpen(openId, out openSequence);
            this.gcRef.Free();
        }
    }

    private class StringBox
    {
        internal string val;

        internal void Set(IntPtr context, string password)
        {
            this.val = password;
        }
    }

    private delegate void StringBox_Set_t(IntPtr context, [MarshalAs(UnmanagedType.LPWStr)] string val);

    static string PathCombine(string a, string b, string c)
    {
        return Path.Combine(Path.Combine(a, b), c);
    }
}

