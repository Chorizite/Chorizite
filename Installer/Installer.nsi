!define SOFTWARECOMPANY "Thrungus"
!define APPNAME "Chorizite"
!define BUILDPATH ".\..\bin\net8.0"

; Main Install settings
SetCompressor LZMA

!include "MUI.nsh"
!include "WordFunc.nsh"
!include "DotNetCore.nsh"
!include "vcredist.nsh"

Name "${APPNAME} ${VERSION}"
InstallDir "C:\Games\Chorizite"
InstallDirRegKey HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" ""
;SetFont "Verdana" 8
Icon ".\..\chorizite.ico"
OutFile ".\..\bin\${APPNAME}-Installer-${VERSION}.exe"

; Use compression

!define MUI_ABORTWARNING

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

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

	SetOutPath "$INSTDIR\Lua\LuaScripts"
	File /r "${BUILDPATH}\Lua\LuaScripts\"

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

; Modern install component descriptions
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT ${CoreSection} ""
!insertmacro MUI_FUNCTION_DESCRIPTION_END

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
