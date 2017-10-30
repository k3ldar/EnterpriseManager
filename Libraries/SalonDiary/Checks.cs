using System;

namespace SalonDiary
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#endif


#if CACHE_APPOINTMENTS
#warning Appointments cached in SalonDiary
#endif
}
