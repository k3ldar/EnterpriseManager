/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Checks.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

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
