//----------------------------------------------------------------------------
// Pismo Technic Inc. Copyright 2006-2015 Joe Lowe
//
// Permission is granted to any person obtaining a copy of this Software,
// to deal in the Software without restriction, including the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and sell copies of
// the Software.
//
// The above copyright and permission notice must be left intact in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS WITHOUT WARRANTY.
//----------------------------------------------------------------------------
// file name:  pfmapi.hxx
// created:    2005.12.02
//----------------------------------------------------------------------------
#ifndef PFMAPI_HXX
#define PFMAPI_HXX
#include "ptfactory1.h"
#ifdef __cplusplus_cli
#pragma managed(push,off)
#endif

#define PFM_COMPANY                 Pismo Technic Inc.
#define PFM_COMPANYA               "Pismo Technic Inc."
#define PFM_COMPANYW              L"Pismo Technic Inc."
#define PFM_REVURL                  com.pismotechnic
#define PFM_REVURLA                "com.pismotechnic"
#define PFM_REVURLW               L"com.pismotechnic"
#define PFM_PRODUCT                 Pismo File Mount
#define PFM_PRODUCTA               "Pismo File Mount"
#define PFM_PRODUCTW              L"Pismo File Mount"
#define PFM_PRODID                  PismoFileMount
#define PFM_PRODIDA                "PismoFileMount"
#define PFM_PRODIDW               L"PismoFileMount"
#define PFM_COPYRIGHT               Pismo Technic Inc. Copyright 2006-2015 Joe Lowe
#define PFM_COPYRIGHTA             "Pismo Technic Inc. Copyright 2006-2015 Joe Lowe"
#define PFM_COPYRIGHTW            L"Pismo Technic Inc. Copyright 2006-2015 Joe Lowe"
#define PFM_DATE                    2015.12.02
#define PFM_DATEA                  "2015.12.02"
#define PFM_DATEW                 L"2015.12.02"
#define PFM_BUILDTAG                pfm.1.0.0.180
#define PFM_BUILDTAGA              "pfm.1.0.0.180"
#define PFM_BUILDTAGW             L"pfm.1.0.0.180"
#define PFM_BUILD                   180
#define PFM_BUILDA                 "180"
#define PFM_BUILDW                L"180"
#define PFM_PREFIX                  pfm
#define PFM_PREFIXA                "pfm"
#define PFM_PREFIXW               L"pfm"
#define PFM_APIID                   pfmapi
#define PFM_APIIDA                 "pfmapi"
#define PFM_APIIDW                L"pfmapi"
#define PFM_APIBASENAME             pfmapi_180
#define PFM_APIBASENAMEA           "pfmapi_180"
#define PFM_APIBASENAMEW          L"pfmapi_180"
#define PFM_KERNELBASENAME          pfmfs_180
#define PFM_KERNELBASENAMEA        "pfmfs_180"
#define PFM_KERNELBASENAMEW       L"pfmfs_180"
#define PFM_CMDBASENAME             pfm
#define PFM_CMDBASENAMEA           "pfm"
#define PFM_CMDBASENAMEW          L"pfm"


static int const pfmMountFlagReadOnly = 0x00000001;
static int const pfmMountFlagWorldRead = 0x00000004;
static int const pfmMountFlagWorldWrite = 0x00000008;
static int const pfmMountFlagUncOnly = 0x00000010;
static int const pfmMountFlagVerbose = 0x00000020;
static int const pfmMountFlagForceUnbuffered = 0x00000080;
static int const pfmMountFlagForceBuffered = 0x00000100;
static int const pfmMountFlagGroupRead = 0x00000400;
static int const pfmMountFlagGroupWrite = 0x00000800;
static int const pfmMountFlagGroupOwned = 0x00001000;
static int const pfmMountFlagWorldOwned = 0x00002000;
static int const pfmMountFlagCacheNameSpace = 0x00004000;
static int const pfmMountFlagBrowse = 0x00010000;
static int const pfmMountFlagUnmountOnRelease = 0x00020000;
static int const pfmMountFlagUnmountOnDisconnect = 0x00040000;
static int const pfmMountFlagLocalDriveType = 0x00080000;

static int const pfmUnmountFlagBackground = 0x0001;

static int const pfmStatusFlagInitializing = 0x0001;
static int const pfmStatusFlagReady = 0x0002;
static int const pfmStatusFlagDisconnected = 0x0004;
static int const pfmStatusFlagClosed = 0x0008;

static int const pfmErrorSuccess = 0;
static int const pfmErrorDisconnect = 1;
static int const pfmErrorCancelled = 2;
static int const pfmErrorUnsupported = 3;
static int const pfmErrorInvalid = 4;
static int const pfmErrorAccessDenied = 5;
static int const pfmErrorOutOfMemory = 6;
static int const pfmErrorFailed = 7;
static int const pfmErrorNotFound = 8;
static int const pfmErrorParentNotFound = 9;
static int const pfmErrorExists = 10;
static int const pfmErrorNoSpace = 11;
static int const pfmErrorBadName = 12;
static int const pfmErrorNotEmpty = 13;
static int const pfmErrorEndOfData = 14;
static int const pfmErrorNotAFile = 15;
static int const pfmErrorDeleted = 16;
static int const pfmErrorCorruptData = 17;
static int const pfmErrorTimeout = 18;
static int const pfmErrorNotAFolder = 19;

static int8_t const pfmFileTypeNone = 0;
static int8_t const pfmFileTypeFile = 1;
static int8_t const pfmFileTypeFolder = 2;
static int8_t const pfmFileTypeSymlink = 3;

static uint8_t const pfmFileFlagsInvalid = 0xFF;

static uint8_t const pfmFileFlagReadOnly = 0x01;
static uint8_t const pfmFileFlagHidden = 0x02;
static uint8_t const pfmFileFlagSystem = 0x04;
static uint8_t const pfmFileFlagExecute = 0x08;
static uint8_t const pfmFileFlagHasIcon = 0x10;
static uint8_t const pfmFileFlagArchive = 0x20;
static uint8_t const pfmFileFlagAlias = 0x40;

static uint8_t const pfmExtraFlagOffline = 0x01;
static uint8_t const pfmExtraFlagReserved1 = 0x02;

static uint8_t const pfmColorInvalid = 0;
static uint8_t const pfmColorDefault = 1;
static uint8_t const pfmColorGray = 2;
static uint8_t const pfmColorGreen = 3;
static uint8_t const pfmColorPurple = 4;
static uint8_t const pfmColorBlue = 5;
static uint8_t const pfmColorYellow = 6;
static uint8_t const pfmColorRed = 7;
static uint8_t const pfmColorOrange = 8;

static int64_t const pfmTimeInvalid = 0;

static int8_t const pfmAccessLevelReadInfo = 1;
static int8_t const pfmAccessLevelReadData = 2;
static int8_t const pfmAccessLevelWriteInfo = 3;
static int8_t const pfmAccessLevelDelete = 4;
static int8_t const pfmAccessLevelWriteData = 5;
static int8_t const pfmAccessLevelOwner = 6;

static uint8_t const pfmControlFlagForceUnbuffered = 1;
static uint8_t const pfmControlFlagForceBuffered = 2;

static int const pfmClientFlagXattr = 0x0001;

static int const pfmVolumeFlagReadOnly = 0x0001;
static int const pfmVolumeFlagCompressed = 0x0002;
static int const pfmVolumeFlagEncrypted = 0x0004;
static int const pfmVolumeFlagCaseSensitive = 0x0008;
static int const pfmVolumeFlagTouchMap = 0x0010;
static int const pfmVolumeFlagNoCreateTime = 0x0100;
static int const pfmVolumeFlagNoAccessTime = 0x0200;
static int const pfmVolumeFlagNoWriteTime = 0x0400;
static int const pfmVolumeFlagNoChangeTime = 0x0800;
static int const pfmVolumeFlagXattr = 0x1000;
static int const pfmVolumeFlagSymlinks = 0x2000;
static int const pfmVolumeFlagFakeNamedStreams = 0x4000;

static int const pfmFlushFlagOpen = 0x0001;

struct PfmMountCreateParams
{
   size_t paramsSize;
   wchar_t const* mountSourceName;
   int mountFlags;
   int reserved1;
   wchar_t driveLetter;
   wchar_t reserved2[sizeof(void*)/sizeof(wchar_t)-1];
   wchar_t const* ownerId;
   PT_FD_T toFormatterWrite;
   PT_FD_T fromFormatterRead;
   PT_FD_T toAuthWrite;
   PT_FD_T fromAuthRead;
   uint64_t blockModeOffset;
   unsigned blockModeAlign;
   unsigned reserved3[1];
   wchar_t const* appId;

   PfmMountCreateParams()
      { memset( this, 0, sizeof( *this)); paramsSize = sizeof( *this);
      mountFlags = pfmMountFlagCacheNameSpace|pfmMountFlagUnmountOnDisconnect;
      toFormatterWrite = fromFormatterRead = toAuthWrite = fromAuthRead = PT_FD_INVALID; }
};

struct/*interface*/ PfmMount
{
   virtual void PT_CCALL AddRef() = 0;
   virtual void PT_CCALL Release() = 0;
   virtual int /*err*/ PT_CCALL Refresh() = 0;
   virtual int PT_CCALL GetMountId() = 0;
   virtual int PT_CCALL GetMountFlags() = 0;
   virtual int PT_CCALL GetStatusFlags() = 0;
   virtual int PT_CCALL GetVolumeFlags() = 0;
   virtual int64_t PT_CCALL GetChangeInstance() = 0;
   virtual wchar_t const* PT_CCALL GetMountSourceName() = 0;
   virtual wchar_t const* PT_CCALL GetMountPoint() = 0;
   virtual wchar_t const* PT_CCALL GetUncName() = 0;
   virtual wchar_t const* PT_CCALL GetOwnerId() = 0;
   virtual wchar_t const* PT_CCALL GetOwnerName() = 0;
   virtual wchar_t const* PT_CCALL GetFormatterName() = 0;
   virtual wchar_t PT_CCALL GetDriveLetter() = 0;
   virtual int /*err*/ PT_CCALL WaitReady( int timeoutMsecs) = 0;
   virtual int /*err*/ PT_CCALL Unmount( int unmountFlags) = 0;
   virtual int /*err*/ PT_CCALL Flush() = 0;
   virtual int /*err*/ PT_CCALL Control( int controlCode, void const* input, size_t inputSize, void* output, size_t maxOutputSize, size_t* outputSize) = 0;
   virtual wchar_t const* PT_CCALL GetMountEndName() = 0;
   virtual wchar_t const* PT_CCALL GetAppId() = 0;
};

struct/*interface*/ PfmFileMountUi
{
   virtual void PT_CCALL Start() = 0;
   virtual void PT_CCALL Complete( wchar_t const* errorMessage) = 0;
   virtual void PT_CCALL Status( wchar_t const* data, int/*bool*/ endOfLine) = 0;
   virtual void PT_CCALL Suspend() = 0;
   virtual void PT_CCALL Resume() = 0;
   virtual wchar_t const* PT_CCALL QueryPassword( wchar_t const* prompt, int count) = 0;
   virtual void PT_CCALL ClearPassword() = 0;
};

static int const pfmFileMountFlagConsoleUi = 0x0001;
static int const pfmFileMountFlagInProcess = 0x0002;
static int const pfmFileMountFlagVerbose = 0x0004;
static int const pfmFileMountFlagReserved1 = 0x0008;
static int const pfmFileMountFlagEditOptions = 0x0020;
static int const pfmFileMountFlagMultiMount = 0x0040;

struct PfmFileMountCreateParams
{
   size_t paramsSize;
   wchar_t const* mountFileName;
   wchar_t const* reserved1;
   wchar_t const* const* reserved_argv;
   int reserved_argc;
   int mountFlags;
   int fileMountFlags;
   int reserved2;
   wchar_t driveLetter;
   wchar_t reserved3[sizeof(int)*2/sizeof(wchar_t)-1];
   wchar_t const* ownerId;
   wchar_t const* formatterName;
   wchar_t const* password;
   PfmFileMountUi* ui;
   void const* reserved4[3];

   PfmFileMountCreateParams()
      { memset( this, 0, sizeof( *this)); this->paramsSize = sizeof( *this);
      this->mountFlags = pfmMountFlagCacheNameSpace|pfmMountFlagUnmountOnDisconnect; }
};

struct/*interface*/ PfmFileMount
{
   virtual void PT_CCALL AddRef() = 0;
   virtual void PT_CCALL Release() = 0;
   virtual int /*err*/ PT_CCALL GetInterface( char const* id, void*) = 0;
   virtual void PT_CCALL Cancel() = 0;
   virtual int /*err*/ PT_CCALL Start( PfmFileMountCreateParams const* params_) = 0;
   virtual void PT_CCALL Send( wchar_t const* data, int/*bool*/ endOfLine) = 0;
   virtual void PT_CCALL Status( wchar_t const* data, int/*bool*/ endOfLine) = 0;
   virtual int /*err*/ PT_CCALL WaitReady() = 0;
   virtual PfmMount* PT_CCALL GetMount() = 0;
   virtual void PT_CCALL Detach() = 0;
};

struct/*interface*/ PfmMountIterator
{
   virtual void PT_CCALL AddRef() = 0;
   virtual void PT_CCALL Release() = 0;
   virtual int /*mountId*/ PT_CCALL Next( int64_t* changeInstance) = 0;
};

struct/*interface*/ PfmMountMonitor
{
   virtual void PT_CCALL AddRef() = 0;
   virtual void PT_CCALL Release() = 0;
   virtual int /*err*/ PT_CCALL Wait( int64_t nextChangeInstance, int timeoutMsecs) = 0;
   virtual void PT_CCALL Cancel() = 0;
};

static int const pfmFastPipeFlagFastMapping = 0x0002;
static int const pfmFastPipeFlagNamedDevice = 0x0004;
static int const pfmFastPipeFlagAsyncClient = 0x0008;
static int const pfmFastPipeFlagAsyncServer = 0x0010;

struct PfmFastPipeCreateParams
{
   size_t paramsSize;
   wchar_t const* baseDeviceName;
   int fastPipeFlags;
   #if UINT_MAX < SIZE_MAX
   int reserved1[1];
   #endif
   wchar_t* deviceName;
   size_t maxDeviceNameChars;

   PfmFastPipeCreateParams() { memset( this, 0, sizeof( *this)); this->paramsSize = sizeof( *this); }
};

static int const pfmFastPipeOpTypeRead = 1;
static int const pfmFastPipeOpTypeWrite = 2;
static int const pfmFastPipeOpTypeSend = 3;

struct PfmFastPipeOp
{
   uint64_t clientId;
   uint64_t offset;
   int opType;
   #if UINT_MAX < SIZE_MAX
   int reserved1[1];
   #endif
   void const* input;
   size_t maxInputSize;
   void* output;
   size_t maxOutputSize;
   uint64_t opaque[(sizeof(void*)*4+48)/8];
};

struct PfmFastPipeSendContext;

typedef void (PT_CCALL* PfmFastPipeSendContext_Complete)( PfmFastPipeSendContext*, int err, size_t inputSize, size_t outputSize);

struct PfmFastPipeSendContext
{
   PfmFastPipeSendContext_Complete complete;
   #if UINT_MAX == SIZE_MAX
   uint8_t align1[4];
   #endif
   uint64_t opaque[(sizeof(void*)*10+40)/8];
};

struct/*interface*/ PfmFastPipeServer
{
   virtual void PT_CCALL Release() = 0;
   virtual void PT_CCALL InitOp( PfmFastPipeOp* op) = 0;
   virtual void PT_CCALL FreeOp( PfmFastPipeOp* op) = 0;
   virtual int /*err*/ PT_CCALL Receive( PfmFastPipeOp* op) = 0;
   virtual void PT_CCALL Complete( PfmFastPipeOp* op, int err, size_t inputSize, size_t outputSize) = 0;
   virtual void PT_CCALL Cancel() = 0;
};

struct/*interface*/ PfmApi
{
   virtual void PT_CCALL AddRef() = 0;
   virtual void PT_CCALL Release() = 0;
   virtual char const* PT_CCALL Version() = 0;
   virtual int /*err*/ PT_CCALL SysStart() = 0;
   virtual int /*err*/ PT_CCALL MountCreate( PfmMountCreateParams const* params_, PfmMount** mount) = 0;
   virtual int /*err*/ PT_CCALL MountSourceNameOpen( wchar_t const* mountSourceName, PfmMount** mount) = 0;
   virtual int /*err*/ PT_CCALL MountPointOpen( wchar_t const* mountPoint, PfmMount** mount) = 0;
   virtual int /*err*/ PT_CCALL MountIdOpen( int mountId, PfmMount** mount) = 0;
   virtual int /*err*/ PT_CCALL MountIterate( int64_t startChangeInstance, int64_t* nextChangeInstance, PfmMountIterator** iterator) = 0;
   virtual int /*err*/ PT_CCALL MountMonitorFactory( PfmMountMonitor** monitor) = 0;
   virtual int /*err*/ PT_CCALL FileMountFactory( PfmFileMount** fileMount) = 0;
   virtual int /*err*/ PT_CCALL FastPipeCreate( PfmFastPipeCreateParams const* params_, PT_FD_T* clientFd, PT_FD_T* serverFd) = 0;
   virtual int /*err*/ PT_CCALL FastPipeCancel( PT_FD_T) = 0;
   virtual int /*err*/ PT_CCALL FastPipeEnableFastMapping( PT_FD_T clientFd) = 0;
   virtual int /*err*/ PT_CCALL FastPipeServerFactory( PT_FD_T serverFd, PfmFastPipeServer**) = 0;
   virtual int /*err*/ PT_CCALL FastPipeClientContext( PT_FD_T clientFd, int* clientContext) = 0;
   virtual void PT_CCALL FastPipeSend( PT_FD_T clientFd, int clientContext, uint64_t offset, void const* input, size_t maxInputSize, void* output, size_t maxOutputSize, PfmFastPipeSendContext*) = 0;
   virtual int /*err*/ PT_CCALL MountEndNameOpen( wchar_t const* mountEndName, PfmMount** mount) = 0;
};

typedef PfmMountIterator PfmIterator;
typedef PfmMountMonitor PfmMonitor;

   // PfmApi interface version history.
   //    PfmApi1 - 2007.12.31
   //       First public release.
   //    PfmApi2 - 2008.01.25
   //       Auth handles now optional when creating mounts.
   //       WaitReady() added to PfmMount.
   //    PfmApi3 - 2008.02.12
   //       New driveletter parameter in PfmApi::Create.
   //       GetDriveLetter() added to PfmMount.
   //    PfmApi4 - 2008.11.04
   //       Improved handling of process visible mounts (SxS load error fix).
   //    PfmApi5 - 2009.02.26
   //       Fastpipe support.
   //    PfmApi6 - 2010.01.27
   //       Fastpipe and marshaller cancel.
   //    PfmApi7 - 2012.04.12
   //       Version and build installation check.
   //       FileMountCreate() added.
   //       Non-privileged user visible drive letter support.
   //    PfmApi8 - 2012.11.19
   //       Mount.GetMountPoint() added.
   //    PfmApi9 - 2013.12.30
   //       Unmount-on-release support added.
   //    PfmApi10 - 2015.03.25
   //       Dropped virtual mount point support.
   //       Dropped visible process support.
   //       Dropped arbitrary mount point support.
   //       Dropped alerter support.
   //       New device and file versioned name convention.
   //    PfmApi11 - 2015.04.xx
   //       Mount endName and sourceName.
   //       Fake local drive letter mount option.
PTFACTORY1_DECLARE( PfmApi, PFM_PRODIDW, PFM_APIIDW);
PT_INLINE int/*error*/ PfmApiFactory( PfmApi** pfmApi)
   { return PfmApiGetInterface( "PfmApi11", pfmApi); }
// void PfmApiUnload( void);

static int const pfmInstInstalled = 0;
static int const pfmInstOldBuild = 1;
static int const pfmInstOldVersion = 2;
static int const pfmInstNotInstalled = 3;

PT_INLINE int PfmInstallCheck( void)
{
   int res = pfmInstNotInstalled;
   PfmApi* api;
   PfmApiUnload();
   if ( PfmApiFactory( &api) == 0)
   {
      res = pfmInstOldBuild;
      if (strcmp( PT_VCAL0( api, Version), PFM_BUILDTAGA) >= 0)
      {
         res = pfmInstInstalled;
      }
   }
   else if ( PfmApiGetInterface( "PfmApi0", &api) == 0 || PfmApiGetInterface( "PfmApi1", &api) == 0)
   {
      res = pfmInstOldVersion;
   }
   if(api) PT_VCAL0(api,Release);
   if(res != pfmInstInstalled) PfmApiUnload();
   return res;
}

struct PfmAttribs
{
   int8_t fileType;
   uint8_t fileFlags;
   uint8_t extraFlags;
   uint8_t color;
   unsigned resourceSize;
   int64_t fileId;
   uint64_t fileSize;
   int64_t createTime;
   int64_t accessTime;
   int64_t writeTime;
   int64_t changeTime;
};

struct PfmOpenAttribs
{
   int64_t openId;
   int64_t openSequence;
   int8_t accessLevel;
   uint8_t controlFlags;
   uint8_t reserved1[2];
   unsigned touch;
   PfmAttribs attribs;
};

struct PfmNamePart
{
   wchar_t const* name;
   size_t len;
   char const* name8;
   size_t len8;
};

struct PfmMediaInfo
{
   PT_UUID mediaUuid;
   uint64_t mediaId64;
   unsigned mediaId32;
   uint8_t mediaFlags;
   uint8_t reserved1[3];
   int64_t createTime;
};

static unsigned const pfmOpFormatterUseSize = 20*sizeof(int)+20*sizeof(void*);

struct/*interface*/ PfmFormatterDispatch;

struct PfmMarshallerServeParams
{
   size_t paramsSize;
   PfmFormatterDispatch* dispatch;
   int volumeFlags;
   #if UINT_MAX < SIZE_MAX
   PT_UINT8 align1[sizeof(size_t)-sizeof(int)];
   #endif
   char const* formatterName;
   size_t dataAlign;
   size_t maxDirectMsgSize;
   PT_FD_T toFormatterRead;
   PT_FD_T fromFormatterWrite;

   PfmMarshallerServeParams()
      { memset( this, 0, sizeof( *this)); paramsSize = sizeof( *this);
      toFormatterRead = fromFormatterWrite = PT_FD_INVALID; }
};

struct/*interface*/ PfmFormatterSerializeOpen
{
   virtual void PT_CCALL SerializeOpen( int64_t openId, int64_t* openSequence) = 0;
};

struct/*interface*/ PfmMarshallerOpenOp
{
   virtual PfmNamePart const* PT_CCALL NameParts() = 0;
   virtual size_t PT_CCALL NamePartCount() = 0;
   virtual int8_t PT_CCALL CreateFileType() = 0;
   virtual uint8_t PT_CCALL CreateFileFlags() = 0;
   virtual int64_t PT_CCALL WriteTime() = 0;
   virtual int64_t PT_CCALL NewCreateOpenId() = 0;
   virtual int8_t PT_CCALL ExistingAccessLevel() = 0;
   virtual int64_t PT_CCALL NewExistingOpenId() = 0;
   virtual void PT_CCALL Complete( int perr, uint8_t/*bool*/ existed, PfmOpenAttribs const* openAttribs, int64_t parentFileId, wchar_t const* endName, size_t linkNamePartCount, void const* linkData, size_t linkDataSize, PfmFormatterSerializeOpen* serializeOpen) = 0;
};

struct/*interface*/ PfmMarshallerReplaceOp
{
   virtual int64_t PT_CCALL TargetOpenId() = 0;
   virtual int64_t PT_CCALL TargetParentFileId() = 0;
   virtual PfmNamePart const* PT_CCALL TargetEndName() = 0;
   virtual uint8_t PT_CCALL CreateFileFlags() = 0;
   virtual int64_t PT_CCALL WriteTime() = 0;
   virtual int64_t PT_CCALL NewCreateOpenId() = 0;
   virtual void PT_CCALL Complete( int perr, PfmOpenAttribs const* openAttribs, PfmFormatterSerializeOpen* serializeOpen) = 0;
};

struct/*interface*/ PfmMarshallerMoveOp
{
   virtual int64_t PT_CCALL SourceOpenId() = 0;
   virtual int64_t PT_CCALL SourceParentFileId() = 0;
   virtual PfmNamePart const* PT_CCALL SourceEndName() = 0;
   virtual PfmNamePart const* PT_CCALL TargetNameParts() = 0;
   virtual size_t PT_CCALL TargetNamePartCount() = 0;
   virtual uint8_t/*bool*/ PT_CCALL DeleteSource() = 0;
   virtual int64_t PT_CCALL WriteTime() = 0;
   virtual int8_t PT_CCALL ExistingAccessLevel() = 0;
   virtual int64_t PT_CCALL NewExistingOpenId() = 0;
   virtual void PT_CCALL Complete( int perr, uint8_t/*bool*/ existed, PfmOpenAttribs const* openAttribs, int64_t parentFileId, wchar_t const* endName, size_t linkNamePartCount, void const* linkData, size_t linkDataSize, PfmFormatterSerializeOpen* serializeOpen) = 0;
};

struct/*interface*/ PfmMarshallerMoveReplaceOp
{
   virtual int64_t PT_CCALL SourceOpenId() = 0;
   virtual int64_t PT_CCALL SourceParentFileId() = 0;
   virtual PfmNamePart const* PT_CCALL SourceEndName() = 0;
   virtual int64_t PT_CCALL TargetOpenId() = 0;
   virtual int64_t PT_CCALL TargetParentFileId() = 0;
   virtual PfmNamePart const* PT_CCALL TargetEndName() = 0;
   virtual uint8_t/*bool*/ PT_CCALL DeleteSource() = 0;
   virtual int64_t PT_CCALL WriteTime() = 0;
   virtual void PT_CCALL Complete( int perr) = 0;
};

struct/*interface*/ PfmMarshallerDeleteOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual int64_t PT_CCALL ParentFileId() = 0;
   virtual PfmNamePart const* PT_CCALL EndName() = 0;
   virtual int64_t PT_CCALL WriteTime() = 0;
   virtual void PT_CCALL Complete( int perr) = 0;
};

struct/*interface*/ PfmMarshallerCloseOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual int64_t PT_CCALL OpenSequence() = 0;
   virtual void PT_CCALL Complete( int perr) = 0;
};

struct/*interface*/ PfmMarshallerFlushFileOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual uint8_t PT_CCALL FlushFlags() = 0;
   virtual uint8_t PT_CCALL FileFlags() = 0;
   virtual uint8_t PT_CCALL Color() = 0;
   virtual int64_t PT_CCALL CreateTime() = 0;
   virtual int64_t PT_CCALL AccessTime() = 0;
   virtual int64_t PT_CCALL WriteTime() = 0;
   virtual int64_t PT_CCALL ChangeTime() = 0;
   virtual void PT_CCALL Complete( int perr, PfmOpenAttribs const* openAttribs, PfmFormatterSerializeOpen* serializeOpen) = 0;
   virtual void const* PT_CCALL LinkData() = 0;
   virtual unsigned PT_CCALL LinkDataSize() = 0;
};

struct/*interface*/ PfmMarshallerListOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual int64_t PT_CCALL ListId() = 0;
   virtual uint8_t/*bool*/ PT_CCALL Add( PfmAttribs const* attribs, wchar_t const* endName) = 0;
   virtual uint8_t/*bool*/ PT_CCALL Add8( PfmAttribs const* attribs, char const* endName) = 0;
   virtual void PT_CCALL Complete( int perr, uint8_t/*bool*/ noMore) = 0;
};

struct/*interface*/ PfmMarshallerListEndOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual int64_t PT_CCALL ListId() = 0;
   virtual void PT_CCALL Complete( int perr) = 0;
};

struct/*interface*/ PfmMarshallerReadOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual uint64_t PT_CCALL FileOffset() = 0;
   virtual void* PT_CCALL Data() = 0;
   virtual size_t PT_CCALL RequestedSize() = 0;
   virtual void PT_CCALL Complete( int perr, size_t actualSize) = 0;
};

struct/*interface*/ PfmMarshallerWriteOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual uint64_t PT_CCALL FileOffset() = 0;
   virtual void const* PT_CCALL Data() = 0;
   virtual size_t PT_CCALL RequestedSize() = 0;
   virtual void PT_CCALL Complete( int perr, size_t actualSize) = 0;
};

struct/*interface*/ PfmMarshallerSetSizeOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual uint64_t PT_CCALL FileSize() = 0;
   virtual void PT_CCALL Complete( int perr) = 0;
};

struct/*interface*/ PfmMarshallerCapacityOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual void PT_CCALL Complete( int perr, uint64_t totalCapacity, uint64_t availableCapacity) = 0;
};

struct/*interface*/ PfmMarshallerFlushMediaOp
{
   virtual void PT_CCALL Complete( int perr, int msecFlushDelay) = 0;
};

struct/*interface*/ PfmMarshallerControlOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual int8_t PT_CCALL AccessLevel() = 0;
   virtual int PT_CCALL ControlCode() = 0;
   virtual void const* PT_CCALL Input() = 0;
   virtual size_t PT_CCALL InputSize() = 0;
   virtual void* PT_CCALL Output() = 0;
   virtual size_t PT_CCALL MaxOutputSize() = 0;
   virtual void PT_CCALL Complete( int perr, size_t outputSize) = 0;
};

struct/*interface*/ PfmMarshallerMediaInfoOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual void PT_CCALL Complete( int perr, PfmMediaInfo const* mediaInfo, wchar_t const* mediaLabel) = 0;
};

struct/*interface*/ PfmMarshallerAccessOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual int8_t PT_CCALL AccessLevel() = 0;
   virtual void PT_CCALL Complete( int perr, PfmOpenAttribs const* openAttribs, PfmFormatterSerializeOpen* serializeOpen) = 0;
};

struct/*interface*/ PfmMarshallerReadXattrOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual PfmNamePart const* PT_CCALL Name() = 0;
   virtual unsigned PT_CCALL Offset() = 0;
   virtual void* PT_CCALL Data() = 0;
   virtual size_t PT_CCALL RequestedSize() = 0;
   virtual void PT_CCALL Complete( int perr, unsigned xattrSize, size_t transferredSize) = 0;
};

struct/*interface*/ PfmMarshallerWriteXattrOp
{
   virtual int64_t PT_CCALL OpenId() = 0;
   virtual PfmNamePart const* PT_CCALL Name() = 0;
   virtual unsigned PT_CCALL XattrSize() = 0;
   virtual unsigned PT_CCALL Offset() = 0;
   virtual void const* PT_CCALL Data() = 0;
   virtual size_t PT_CCALL RequestedSize() = 0;
   virtual void PT_CCALL Complete( int perr, size_t transferredSize) = 0;
};

struct/*interface*/ PfmFormatterDispatch
{
   virtual void PT_CCALL Open( PfmMarshallerOpenOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Replace( PfmMarshallerReplaceOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Move( PfmMarshallerMoveOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL MoveReplace( PfmMarshallerMoveReplaceOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Delete( PfmMarshallerDeleteOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Close( PfmMarshallerCloseOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL FlushFile( PfmMarshallerFlushFileOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL List( PfmMarshallerListOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL ListEnd( PfmMarshallerListEndOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Read( PfmMarshallerReadOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Write( PfmMarshallerWriteOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL SetSize( PfmMarshallerSetSizeOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Capacity( PfmMarshallerCapacityOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL FlushMedia( PfmMarshallerFlushMediaOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Control( PfmMarshallerControlOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL MediaInfo( PfmMarshallerMediaInfoOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL Access( PfmMarshallerAccessOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL ReadXattr( PfmMarshallerReadXattrOp* op, void* formatterUse) = 0;
   virtual void PT_CCALL WriteXattr( PfmMarshallerWriteXattrOp* op, void* formatterUse) = 0;
};

struct/*interface*/ PfmMarshaller
{
   virtual void PT_CCALL Release() = 0;
   virtual void PT_CCALL SetTrace( wchar_t const* traceChannelName) = 0;
   virtual void PT_CCALL SetStatus( PT_FD_T fd) = 0;
   virtual void PT_CCALL Line( wchar_t const* data, uint8_t/*bool*/ endOfLine) = 0;
   virtual void PT_CCALL Print( wchar_t const* data) = 0;
   virtual void PT_CCALL Vprintf( wchar_t const* format, va_list args) = 0;
   virtual void PT_CCALL Printf( wchar_t const* format, ...) = 0;
   virtual int /*perr*/ PT_CCALL ConvertSystemError( int err) = 0;
   virtual int /*err*/ PT_CCALL Identify( void const* mountFileData, size_t mountFileDataSize, char const* formatterName) = 0;
   virtual int /*err*/ PT_CCALL GetPassword( PT_FD_T read, wchar_t const* prompt, wchar_t const** password) = 0;
   virtual void PT_CCALL ClearPassword() = 0;
   virtual void PT_CCALL ServeDispatch( PfmMarshallerServeParams const* params_) = 0;
   virtual void PT_CCALL ServeCancel() = 0;
   virtual int PT_CCALL GetClientVersion() = 0;
   virtual int PT_CCALL GetClientFlags() = 0;
};

#define INTERFACE_NAME PfmMarshallerPreMount
PT_INTERFACE_DEFINE
{
   PT_INTERFACE_FUN1( int/*error*/, PreMount, PfmFormatterDispatch* dispatch);
};
#undef INTERFACE_NAME

#ifdef PFMMARSHALLER_STATIC

PT_EXTERNC int/*error*/ PT_CCALL PfmMarshallerFactory( PfmMarshaller** marshaller);

PT_EXTERNC void PT_CCALL PfmMarshallerSetPreMount( PfmMarshaller* marshaller, PfmMarshallerPreMount* preMount);

#endif

   // Marshaller interface version history.
   //    PfmMarshaller1- 2007.12.31
   //       First public release.
   //    PfmMarshaller2- 2008.02.08
   //       Added FormatterOps::MediaInfo to return media ID and label.
   //    PfmMarshaller3- 2009.03.02
   //       Added fastpipe.
   //    PfmMarshaller4- 2009.06.03
   //       Concurrent marshaller
   //    PfmMarshaller5- 2010.04.22
   //       Move::ExistingAccessLevel
   //    PfmMarshaller6- 2011.01.27
   //       Access operation.
   //       File color attribute.
   //    PfmMarshaller7- 2013.03.11
   //       Xattr support.
   //       Mac alias flag.
   //       Client flags.
   //    PfmMarshaller8- 2013.05
   //       Symlink support.
   //    PfmMarshaller9- 2015.06
   //       Deprecated single-threaded formatter interfaces.

#ifndef PFMMARSHALLER_STATIC

PTFACTORY1_DECLARE( PfmMarshaller, PFM_PRODIDW, PFM_APIIDW);
PT_INLINE int/*error*/ PT_CCALL PfmMarshallerFactory( PfmMarshaller** marshaller)
   { return PfmMarshallerGetInterface( "PfmMarshaller9", marshaller); }
// void PfmMarshallerUnload( void);

#endif

#ifdef __cplusplus_cli
#pragma managed(pop)
#endif
#endif
