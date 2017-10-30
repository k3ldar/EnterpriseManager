
namespace Library
{
#if !DEBUG
#if TRACE
#warning Trace enabled for release
#endif
#endif

#if INHERITED_DAL
#warning Building Library.dll with inherited DAL
#endif
}
