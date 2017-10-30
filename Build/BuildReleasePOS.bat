call T:\HeavenMain\Build\buildrelease.bat

DEL t:\HeavenMain\build\buildpos.txt

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe" "T:\HeavenMain\Applications\PointOfSale.sln" /Rebuild Release /out "t:\HeavenMain\build\buildpos.txt"



T:

cd \
CD HeavenMain

CD Builds

CD POS

CD Release

DEL *.pdb
DEL *.vshost.ex*

cd Plugins
DEL *DayView*
DEL FirebirdSQL*
DEL ICSharpCode.*
DEL itextsharp.dll
Del Languages.dll
DEL Library.dll
Del MailChimp.dll
DEL MonthCalendar.*
DEL NHunsp*.*
DEL QRCode.dll
DEL Reports.*
DEL SalonDiary.*
DEL SieraDelta.*
Del Library.dll
DEL MailChimp.dll
DEL *.pdb

RD /s /q en-US
RD /s /q es-ES
RD /s /q he
RD /s /q hr-HR
RD /s /q ms-MY
RD /s /q nl-NL
RD /s /q sl-SI
RD /s /q zh-cn
RD /s /q zh-sg
RD /s /q zh-TW
RD /s /q da-DK
