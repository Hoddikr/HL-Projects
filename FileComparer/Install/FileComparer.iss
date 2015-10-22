
[Setup]
AppId={{526C9FAD-3FFF-4A0D-A655-9D92742F4576}
AppName=File Comparer
AppVersion=0.1.0
AppVerName=File Comparer 0.1.0
AppPublisher=HL
DefaultDirName={pf}\HL\File Comparer
DefaultGroupName=HL\File Comparer
OutputDir=".\Setup"
Compression=lzma
SolidCompression=no
MinVersion=0,5.0

#define BUILD = "..\FileComparer\FileComparer\bin\Release"

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "{#BUILD}\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "{#BUILD}\*.xml"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "{#BUILD}\*.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "{#BUILD}\*.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\File Comparer"; Filename: "{app}\File Comparer.exe"
Name: "{group}\{cm:UninstallProgram,File Comparer}"; Filename: "{uninstallexe}"
Name: {commondesktop}\File Comparer; Filename: {app}\File Comparer.exe; Tasks: desktopicon

[Run]
Filename: "{app}\File Comparer.exe"; Description: "{cm:LaunchProgram,File Comparer}"; Flags: nowait postinstall skipifsilent unchecked