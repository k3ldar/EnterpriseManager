using System;

namespace POS.Debug
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#endif
}
