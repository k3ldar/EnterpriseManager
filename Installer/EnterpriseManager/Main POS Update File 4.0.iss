; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Small Business Enterprise Manager"
#define MyAppVersion "4.0"
#define MyAppPublisher "Shifoo Systems"
#define MyAppURL "http://www.shifoo.com"
#define MyAppExeName "Shifoo.SMB.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{A6B8B271-A978-4880-A1CE-F69930D52520}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppName}
LicenseFile=POSLicence.txt
OutputDir=Builds
OutputBaseFilename=Shifoo_SMB_v_{#MyAppVersion}
SetupIconFile=..\..\Applications\POS\favicon.ico
Compression=lzma
SolidCompression=yes
AppCopyright=Copyright (c) 2010 - 2018.  Shifoo Systems.
PrivilegesRequired=lowest
DisableDirPage=auto
ShowLanguageDialog=auto
Uninstallable=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; OnlyBelowVersion: 0,6.1

[Files]
Source: "..\..\Builds\POS\Release\Shifoo.System.exe"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
;Source: "T:\HeavenMain\Manuals\POS Manual.pdf"; DestDir: "{app}\POS"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\CelebrityImages.xml"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\ControlHints.xml"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\DidYouKnow.xml"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\FirebirdSql.Data.FirebirdClient.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Hunspellx64.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Hunspellx86.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\ICSharpCode.SharpZipLib.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\NHunspell.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\QRCode.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\ServiceStack.Text.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Calendar.DayView.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\MonthCalendar.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\SharedLib.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\SharedControls.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\itextsharp.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\ProductImages.xml"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\SalonDiary.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Languages.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Library.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\POS.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Reports.dll"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\splash.img"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Dictionary\cs_CZ.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\da_DK.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\da_DK.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_AU.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_AU.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_CA.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_CA.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_GB.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_GB.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_US.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_US.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_ZA.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\en_ZA.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\es_ES.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\es_ES.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\he_IL.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\he_IL.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\nl_NL.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\nl_NL.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\sl_SI.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\sl_SI.dic"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Dictionary\cs_CZ.aff"; DestDir: "{app}\SMB\Dictionary"; Flags: ignoreversion
Source: "..\..\Builds\POS\Release\Images\AppointmentSummary.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\BirthdayBackground.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\BirthdayBackground.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\CALENDAR_1.ico"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\ChangedAppointments.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\EditWrokingHours.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\EmployeeNoTreatments.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\images.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\InvoiceFooterPaid.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\InvoiceHeader.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\InvoiceHeaderPaid.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\InvoiceHeaderPaidBlank.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\LinkedAppointment.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\LinkedAppointments 2.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\locked.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\meeting.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\newappointment.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\newappointment.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\notes.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\reports.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\revertuser.png"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\SalonReportHeader.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\ShippingLabel.bmp"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\showminutes.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\StockReportHeader.jpg"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\swapuser.png"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\till2.ico"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\till2.png"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\till-icon.png"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\treatments.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\treatments1.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Images\warning.bmp"; DestDir: "{app}\SMB\Images"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Accounts.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Accounts.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Administration.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Administration.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.AutoUpdate.dll"; DestDir: "{app}\Plugins"; DestName: "POS.AutoUpdate.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Cash.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Cash.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Cash.dll"; DestDir: "{app}\Plugins"; DestName: "POS.CashManager.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.CurrencyWatch.dll"; DestDir: "{app}\Plugins"; DestName: "POS.CurrencyWatch.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Customers.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Customers.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.DatabaseBackupPluginModule.dll"; DestDir: "{app}\Plugins"; DestName: "POS.DatabaseBackupPluginModule.dll"; Flags: ignoreversion; Components: SMB
;Source: "..\..\Builds\POS\Release\Plugins\POS.Debug.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Debug.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Diary.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Diary.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Export.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Export.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.FileBackup.dll"; DestDir: "{app}\Plugins"; DestName: "POS.FileBackup.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.HelpDesk.dll"; DestDir: "{app}\Plugins"; DestName: "POS.HelpDesk.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Images.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Images.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Invoices.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Invoices.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Marketing.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Marketing.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Orders.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Orders.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.PurchaseOrders.dll"; DestDir: "{app}\Plugins"; DestName: "POS.PurchaseOrders.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Staff.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Staff.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.StockControl.dll"; DestDir: "{app}\Plugins"; DestName: "POS.StockControl.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Suppliers.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Suppliers.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Till.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Till.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.TrainingSchedule.dll"; DestDir: "{app}\Plugins"; DestName: "POS.TrainingSchedule.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.Updater.dll"; DestDir: "{app}\Plugins"; DestName: "POS.Updater.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.VoucherManagement.dll"; DestDir: "{app}\Plugins"; DestName: "POS.VoucherManagement.dll"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\Plugins\POS.WebsiteAdministration.dll"; DestDir: "{app}\Plugins"; DestName: "POS.WebsiteAdministration.dll"; Flags: ignoreversion; Components: SMB

; language files
Source: "..\..\Builds\POS\Release\da-DK\Languages.resources.dll"; DestDir: "{app}\Languages\da-DK"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\zh-SG\Languages.resources.dll"; DestDir: "{app}\Languages\zh-SG"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\zh-CN\Languages.resources.dll"; DestDir: "{app}\Languages\zh-CN"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\sl-SI\Languages.resources.dll"; DestDir: "{app}\Languages\sl-SI"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\nl-NL\Languages.resources.dll"; DestDir: "{app}\Languages\nl-NL"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\ms-MY\Languages.resources.dll"; DestDir: "{app}\Languages\ms-MY"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\he\Languages.resources.dll"; DestDir: "{app}\Languages\he"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\es-ES\Languages.resources.dll"; DestDir: "{app}\Languages\es-ES"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\en-US\Languages.resources.dll"; DestDir: "{app}\Languages\en-US"; Flags: ignoreversion; Components: SMB
Source: "..\..\Builds\POS\Release\zh-TW\Languages.resources.dll"; DestDir: "{app}\Languages\zh-TW"; Flags: ignoreversion; Components: SMB

; NEVER remove the following line, this is required so that the installation process works
Source: "PosUpdate.exe.installed"; DestDir: "{app}\SMB"; Flags: ignoreversion; Components: SMB
;Source: "T:\HeavenMain\Installer\POS\PosConfiguration.dat"; DestDir: "{app}\SMB"; Flags: ignoreversion onlyifdoesntexist; Components: SMB
Source: "..\..\Builds\POS\Debug\PluginConfig.xml"; DestDir: "{app}\SMB"; Flags: ignoreversion onlyifdoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\SMB\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\SMB\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\SMB\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\SMB\{#MyAppExeName}"; WorkingDir: "{app}\SMB"; Flags: postinstall nowait; Description: "Start Small Business Enterprise Manager"; StatusMsg: "Start Small Business Enterprise Manager"; Components: SMB

[UninstallRun]
;Filename: "{app}\Firebird\Bin\UnInstallFBHeaven.bat"; WorkingDir: "{app}\Firebird\Bin"; Flags: waituntilterminated runhidden; StatusMsg: "Installing Firebird Database Engine"; Components: Firebird
;Filename: "{app}\Service\Heavenskincare.POS.Service.exe"; Parameters: "/u"; WorkingDir: "{app}\Service"; Flags: waituntilterminated runhidden

[Components]
Name: "SMB"; Description: "Small Business Enterprise Manager"; Types: full custom compact; 

[Dirs]
Name: "{app}\SMB"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Dictionary"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\Products"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\HomePageBanners"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\OfferImages"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\PageBanners"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\Treatments"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\Celebrities"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Images\WebsiteTreatments"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Errors"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Invoices"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Labels"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Logs"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Marketing"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\sl-SI"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\en-US"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\es-ES"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\he"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\ms-MY"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\nl-NL"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\zh-TW"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\zh-SG"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\zh-CN"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full
Name: "{app}\SMB\Languages\da-DK"; Flags: uninsalwaysuninstall; Components: SMB; Permissions: everyone-full

[InstallDelete]
Type: files; Name: "*.pdb"; Components: SMB

[Code]
const
  //
  // Server install Type
  //
  StandAlone = 8000;
  Client = 8001;
  Server = 8002;

type
  //
  // Enumeration used to specify a .NET framework version 
  //
  TDotNetFramework = (
    DotNet_v11_4322,  // .NET Framework 1.1
    DotNet_v20_50727, // .NET Framework 2.0
    DotNet_v30,       // .NET Framework 3.0
    DotNet_v35,       // .NET Framework 3.5
    DotNet_v4_Client, // .NET Framework 4.0 Client Profile
    DotNet_v4_Full,   // .NET Framework 4.0 Full Installation
    DotNet_v45);      // .NET Framework 4.5


var
  Distributor, Password: String;
  PageDistributor: TInputQueryWizardPage;
  PageInstallType: TInputOptionWizardPage;
  PageSelectServer: TInputOptionWizardPage;
  installType: Integer;
  serverName: String;
  svcContents: string;
  posContents: string;
  posXML: string;
  svcXML: string;
  bCanContinue: boolean;

const 
  crlf = #13#10;

//
// Checks whether the specified .NET Framework version and service pack
// is installed (See: http://www.kynosarges.de/DotNetVersion.html)
//
// Parameters:
//   Version     - Required .NET Framework version
//   ServicePack - Required service pack level (0: None, 1: SP1, 2: SP2 etc.)
//
function IsDotNetInstalled(Version: TDotNetFramework; ServicePack: cardinal): boolean;
var
    KeyName      : string;
    Check45      : boolean;
    Success      : boolean;
    InstallFlag  : cardinal; 
    ReleaseVer   : cardinal;
    ServiceCount : cardinal;
begin
    // Registry path for the requested .NET Version
    KeyName := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\';

    case Version of
      DotNet_v11_4322:  KeyName := KeyName + 'v1.1.4322';
      DotNet_v20_50727: KeyName := KeyName + 'v2.0.50727';
      DotNet_v30:       KeyName := KeyName + 'v3.0';
      DotNet_v35:       KeyName := KeyName + 'v3.5';
      DotNet_v4_Client: KeyName := KeyName + 'v4\Client';
      DotNet_v4_Full:   KeyName := KeyName + 'v4\Full';
      DotNet_v45:       KeyName := KeyName + 'v4\Full';
    end;

    // .NET 3.0 uses "InstallSuccess" key in subkey Setup
    if (Version = DotNet_v30) then
      Success := RegQueryDWordValue(HKLM, KeyName + '\Setup', 'InstallSuccess', InstallFlag) else
      Success := RegQueryDWordValue(HKLM, KeyName, 'Install', InstallFlag);

    // .NET 4.0/4.5 uses "Servicing" key instead of "SP"
    if (Version = DotNet_v4_Client) or
       (Version = DotNet_v4_Full) or
       (Version = DotNet_v45) then
      Success := Success and RegQueryDWordValue(HKLM, KeyName, 'Servicing', ServiceCount) else
      Success := Success and RegQueryDWordValue(HKLM, KeyName, 'SP', ServiceCount);

    // .NET 4.5 is distinguished from .NET 4.0 by the Release key
    if (Version = DotNet_v45) then
      begin
        Success := Success and RegQueryDWordValue(HKLM, KeyName, 'Release', ReleaseVer);
        Success := Success and (ReleaseVer >= 378389);
      end;

    Result := Success and (InstallFlag = 1) and (ServiceCount >= ServicePack);
end;

function BoolToStr(b: Boolean): string;
begin
  if (b) then
  begin
    Result := 'true';
  end else
  begin
    Result := 'false';
  end
end;

// Split a string into an array using passed delimeter
procedure SplitString(var Dest: TArrayOfString; Text: String; Separator: String);
var
	i: Integer;
begin
	i := 0;
	repeat
		SetArrayLength(Dest, i+1);
		if Pos(Separator,Text) > 0 then	begin
			Dest[i] := Copy(Text, 1, Pos(Separator, Text)-1);
			Text := Copy(Text, Pos(Separator,Text) + Length(Separator), Length(Text));
			i := i + 1;
		end else begin
			 Dest[i] := Text;
			 Text := '';
		end;
	until Length(Text)=0;
end;


function InitializeSetup(): Boolean;
begin
    if not IsDotNetInstalled(DotNet_v4_Client, 0) then begin
        MsgBox('Point Of Sale requires Microsoft .NET Framework 4.5.2 Client Profile.'#13#13
            'Please use Windows Update to install this version,'#13
            'and then re-run the Point of Sale setup program.', mbInformation, MB_OK);
        result := false;
    end else
        result := true;


    if (result) then
    begin
    end
end;
