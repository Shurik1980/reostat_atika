; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "�������"
#define MyAppVersion "7.0"
#define MyAppPublisher "��� ��� �����"
#define MyAppURL "http://www.dgu-service.ru"
#define MyAppExeName "reostat.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{CDC1C99E-C4C3-4F54-A9CB-A25A695C3D35}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Reostat
DisableDirPage=yes
DefaultGroupName={#MyAppName}
InfoBeforeFile=C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\install.txt
OutputDir=C:\Reostat_RF\src\Setup
OutputBaseFilename=setup
SetupIconFile=C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\reostat.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\reostat.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\config.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\CRRedist2008_x86.msi"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\CRRedist2008_x64.msi"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\CrystalReport1.rpt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\CrystalReport7.rpt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\LBIndustrialCtrls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\Lxsoft.Controls.LedControl.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\rangeExt.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\rangePower.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\reostat.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\ZedGraph.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Reostat_RF\src\gui\reostat\reostat\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
