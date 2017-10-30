using System;

namespace Reports
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#endif
}
