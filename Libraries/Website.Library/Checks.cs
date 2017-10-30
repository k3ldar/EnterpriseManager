
namespace Website.Library
{
#if FAKE_ADDRESS
#warning Remove FAKE_ADDRESS compiler directive for Release of Website.Library.dll
#endif

#if DEBUG
#warning Debug Build Website.Library.dll
#endif

#if TRACE
#warning Trace enabled for Website.Library.dll
#endif

#if ERROR_MANAGER
#warning Building with Error Manager for Website.Library.dll
#else
#warning Building without Error Manager for Website.Library.dll
#endif

#if DISPLAY_DEBUG_INFO
#warning Building Website.Library.dll With DISPLAY_DEBUG_INFO
#endif
}
