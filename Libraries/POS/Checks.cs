using System;

namespace POS.Base
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#endif

#if LOCALHOST && DEBUG
#warning POS.dll build with support for local host only.  Remove for release
#endif
}
