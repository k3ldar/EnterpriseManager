using System;

namespace POS.Diary
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#endif

#if CACHE_APPOINTMENTS
#warning Appointments cached in POS.Diary
#else
#warning Appointments not cached in POS.Diary
#endif
}
