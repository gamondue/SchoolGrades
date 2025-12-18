[Setup]
AppName=SchoolGrades
AppVersion=0.60.0
; Installer icon (compile-time path relative to this script)
SetupIconFile=..\SchoolGrades\Icons\gamon LegoLogo decentrato trasparente 256x256.ico
; Icon used for uninstaller (Add/Remove Programs)
UninstallDisplayIcon={app}\Icons\gamon LegoLogo decentrato trasparente 256x256.ico
; DefaultDirName will be determined by PrivilegesRequired and user choice
DefaultDirName={autopf}\SchoolGrades
DefaultGroupName=SchoolGrades
OutputBaseFilename=SchoolGrades_Demo_Installer
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64compatible
; Allow user to choose installation mode
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog

[Tasks]
Name: "allusers"; Description: "Installa per tutti gli utenti (richiede privilegi amministratore)"; Flags: exclusive unchecked
Name: "currentuser"; Description: "Installa solo per l'utente corrente"; Flags: exclusive
Name: "copydemodata"; Description: "Copia dati demo (opzionale)"; Flags: unchecked

[Code]
var
  DemoInfoShown: Boolean;

function GetDefaultDirName(Param: String): String;
begin
  if IsTaskSelected('allusers') then
    Result := ExpandConstant('{commonpf}\SchoolGrades')
  else
    Result := ExpandConstant('{userpf}\SchoolGrades');
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  DemoInfoShown := False;
end;

procedure InitializeWizard();
begin
  // No input page for demo data - we will copy to Documents\SchoolGrades\Data and inform the user
end;

procedure CurPageChanged(CurPageID: Integer);
var
  DemoDest: String;
begin
  if CurPageID = wpSelectDir then
  begin
    WizardForm.DirEdit.Text := GetDefaultDirName('');
  end;

  // When leaving the Select Tasks page, if demo task selected, inform the user where demo data will be copied
  if (CurPageID = wpSelectTasks) and IsTaskSelected('copydemodata') and not DemoInfoShown then
  begin
    DemoDest := ExpandConstant('{userdocs}\SchoolGrades\Data');
    MsgBox('I dati demo saranno copiati nella cartella: ' + #13#10 + DemoDest, mbInformation, MB_OK);
    DemoInfoShown := True;
  end;
end;

function ShouldInstallDemoData(): Boolean;
begin
  Result := IsTaskSelected('copydemodata');
end;

[Files]
; path relative to the folder in which this file is stored
Source: "..\SchoolGrades\bin\Release\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Demo data files (copied into Documents\SchoolGrades\Data when demo option selected)
Source: "..\DemoData\Data"; DestDir: "{userdocs}\SchoolGrades\Data"; Check: ShouldInstallDemoData; Flags: ignoreversion recursesubdirs createallsubdirs
; demo Images files (copied into Documents\SchoolGrades\Images when demo option selected)
Source: "..\DemoData\Images"; DestDir: "{userdocs}\SchoolGrades\Images"; Check: ShouldInstallDemoData; Flags: ignoreversion recursesubdirs createallsubdirs
; If no demo, copy empty sqlite database into Documents\SchoolGrades\Data
Source: "SchoolGrades_EMPTY.sqlite"; DestDir: "{userdocs}\SchoolGrades\Data"; Check: not ShouldInstallDemoData; Flags: ignoreversion recursesubdirs createallsubdirs
; schgrd.cfg selection: demo vs no-demo - always copy as schgrd.cfg in destination
Source: "schgrd_DEMO.cfg"; DestDir: "{userdocs}\SchoolGrades\Config"; DestName: "schgrd.cfg"; Check: ShouldInstallDemoData; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "schgrd_NO_DEMO.cfg"; DestDir: "{userdocs}\SchoolGrades\Config"; DestName: "schgrd.cfg"; Check: not ShouldInstallDemoData; Flags: ignoreversion recursesubdirs createallsubdirs
; Copy application icon into installed Icons folder for shortcuts and uninstaller
Source: "..\SchoolGrades\Icons\gamon LegoLogo decentrato trasparente 256x256.ico"; DestDir: "{app}\Icons"; Flags: ignoreversion

[Icons]
Name: "{group}\SchoolGrades"; Filename: "{app}\SchoolGrades.exe"; IconFilename: "{app}\Icons\gamon LegoLogo decentrato trasparente 256x256.ico"
Name: "{userdesktop}\SchoolGrades"; Filename: "{app}\SchoolGrades.exe"; IconFilename: "{app}\Icons\gamon LegoLogo decentrato trasparente 256x256.ico"; Tasks: currentuser
Name: "{commonprograms}\SchoolGrades"; Filename: "{app}\SchoolGrades.exe"; IconFilename: "{app}\Icons\gamon LegoLogo decentrato trasparente 256x256.ico"; Tasks: allusers
Name: "{commondesktop}\SchoolGrades"; Filename: "{app}\SchoolGrades.exe"; IconFilename: "{app}\Icons\gamon LegoLogo decentrato trasparente 256x256.ico"; Tasks: allusers

[Run]
Filename: "{app}\SchoolGrades.exe"; Description: "Avvia SchoolGrades"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\Icons\gamon LegoLogo decentrato trasparente 256x256.ico"
Type: filesandordirs; Name: "{userdocs}\SchoolGrades\Data"
Type: filesandordirs; Name: "{userdocs}\SchoolGrades"