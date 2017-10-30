using System;

namespace Heavenskincare.WebsiteTemplate
{
#if BuildRelease
#warning Building Release Build of Website
#endif

#if BuildDebug
#warning Building Debug Version of the Website
#endif

#if FAKE_ADDRESS
#warning Remove Fake Address For Release of Heaven.WebsiteTemplate.dll
#endif

#if DEBUG
#warning Debug Build Heaven.WebsiteTemplate.dll
#endif

#if TRACE
#warning Trace enabled for Heaven.WebsiteTemplate.dll
#endif

#if ERROR_MANAGER
#warning Building Website with Error Manager
#else
#warning Building website without Error Manager
#endif

#if DISPLAY_DEBUG_INFO
#warning Building Website With DISPLAY_DEBUG_INFO
#endif
}