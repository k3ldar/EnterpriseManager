using System;

namespace SieraDelta.Website
{
#if FAKE_ADDRESS
#warning Remove FAKE_ADDRESS compiler directive for Release of SieraDelta.Website.dll
#endif

#if DEBUG
#warning Debug Build SieraDelta.Website.dll
#endif

#if TRACE
#warning Trace enabled for SieraDelta.Website.dll
#endif

#if ERROR_MANAGER
#warning Building with Error Manager for SieraDelta.Website.dll
#else
#warning Building without Error Manager for SieraDelta.Website.dll
#endif
}