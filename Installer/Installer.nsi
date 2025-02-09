!define SOFTWARECOMPANY "Thrungus"
!define APPNAME "Chorizite"
!define BUILDPATH ".\..\bin\net8.0"

; Main Install settings
SetCompressor LZMA

!addplugindir .
!include "MUI2.nsh"
!include "WordFunc.nsh"
!include "DotNetCore.nsh"
!include "vcredist.nsh"

Name "${APPNAME} ${VERSION}"
InstallDir "C:\Games\Chorizite"
InstallDirRegKey HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" ""
;SetFont "Verdana" 8
Icon ".\..\chorizite.ico"
OutFile ".\..\bin\${APPNAME}-Installer-${VERSION}.exe"
!define HttpWebRequestURL "https://chorizite.github.io/plugin-index/index.json"

; Use compression

!define MUI_ABORTWARNING
!define MUI_COMPONENTSPAGE_SMALLDESC

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

; Set languages (first is default language)
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_RESERVEFILE_LANGDLL

Section "" CoreSection
	SetOverwrite on

	; Set Section Files and Shortcuts
	SetOutPath "$INSTDIR\"
	File "${BUILDPATH}\*.*"

	SetOutPath "$INSTDIR\runtimes\win-x86\native"
	File "${BUILDPATH}\runtimes\win-x86\native\*.*"

SectionEnd

Section -FinishSection

	WriteRegStr HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" "Version" "${VERSION}"

	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$INSTDIR\uninstall.exe"
	WriteUninstaller "$INSTDIR\uninstall.exe"

	!insertmacro CheckDotNetCore 8.0
	!insertmacro CheckVCRedist

SectionEnd

Section InstallPlugins
  CreateDirectory $TEMP\chorizite-setup
  
	;download installer
  DetailPrint `Downloading plugin index: ${HttpWebRequestURL}`
	inetc::get `${HttpWebRequestURL}` "$TEMP\chorizite-setup\plugins.json" /end

  nsJSON::Set /file $TEMP\chorizite-setup\plugins.json
  nsJSON::Get /count `Plugins` /end
  Pop $R0
  IntOp $R0 $R0 - 1
  ${For} $R1 0 $R0
    nsJSON::Get `Plugins` /index $R1 `Name` /end
    Pop $R2
    nsJSON::Get `Plugins` /index $R1 `Latest` `DownloadUrl` /end
    Pop $R3
    nsJSON::Get `Plugins` /index $R1 `Latest` `Version` /end
    Pop $R4
    nsJSON::Get `Plugins` /index $R1 `IsCorePlugin` /end
    Pop $R5
    ${If} $R5 == true
      DetailPrint `Downloading $R2-$R4 from $R3`
      inetc::get `$R3` "$TEMP\chorizite-setup\$R2-$R4.zip" /end
      CreateDirectory "$INSTDIR\plugins\$R2"
      nsisunz::UnzipToLog "$TEMP\chorizite-setup\$R2-$R4.zip" "$INSTDIR\plugins\$R2"
      Delete "$TEMP\chorizite-setup\$R2-$R4.zip"
    ${EndIf}

    Delete "$TEMP\chorizite-setup\plugins.json"
  ${Next}
SectionEnd

;Uninstall section
Section Uninstall

	;Remove from registry...
	DeleteRegKey HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}"
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"

	; Delete self
	Delete "$INSTDIR\uninstall.exe"

	;Clean up
	Delete "$INSTDIR\*.*"
	Delete "$INSTDIR\runtimes"
	Delete "$INSTDIR\Lua"

SectionEnd

; eof
