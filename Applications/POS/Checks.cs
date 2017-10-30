using System;

namespace PointOfSale
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#else
#if !LANGUAGES
#warning Building without support for languages
#endif
#endif

#if AutoLogin
#warning AutoLogin Directive Included
#endif

#if ReplicationTriggers
#warning ReplicationTriggers Directive Included
#endif

#if CreateXMLFiles
#warning CreateXMLFiles Directive Included
#endif

#if ERROR_MANAGER
#warning Building POS with support for Error Manager
#endif

#if debugTestForm
#warning debugTestForm  Directive Included
#endif

#if BuildRelease
#warning Building Release Version of PointOfSale.exe
#endif

#if BuildDebug
#warning Building DEBUG Version of PointOfSale.exe
#endif

}
