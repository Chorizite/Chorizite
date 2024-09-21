; Define your application name
!define APPNAME "MagicHat.DecalService"
!define SOFTWARECOMPANY "HackThePlanet"
!define SERVICEGUID "{dcfb2961-ea07-43fa-4D61-676963486174}"

!define ASSEMBLY "MagicHat.DecalService.dll"
!define CLASSNAME "MagicHat.DecalService.MagicHatService"

!define BUILDPATH "../bin"

; Main Install settings
; compressor goes first
SetCompressor LZMA

!getdllversion "${BUILDPATH}\${ASSEMBLY}" Expv_
!define VERSION ${Expv_1}.${Expv_2}.${Expv_3}

Name "${APPNAME} ${VERSION}"
InstallDir "C:\Games\DecalPlugins\${APPNAME}"
InstallDirRegKey HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" ""
;SetFont "Verdana" 8
;Icon "icon.ico"
OutFile ".\bin\Release\${APPNAME}-Installer-${VERSION}.exe"

; Use compression

; Modern interface settings
!include "MUI.nsh"
!include "WordFunc.nsh"

!define MUI_ABORTWARNING

!insertmacro MUI_PAGE_WELCOME
;!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

; Set languages (first is default language)
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_RESERVEFILE_LANGDLL

; https://nsis.sourceforge.io/Download_and_Install_dotNET_45
Function CheckAndDownloadDotNet48
    # Set up our Variables
    Var /GLOBAL dotNET48IsThere
    Var /GLOBAL dotNET_CMD_LINE
    Var /GLOBAL EXIT_CODE

    # We are reading a version release DWORD that Microsoft says is the documented
    # way to determine if .NET Framework 4.8 is installed
    ReadRegDWORD $dotNET48IsThere HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Release"
    IntCmp $dotNET48IsThere 528049 is_equal is_less is_greater

    is_equal:
        Goto done_compare_not_needed
    is_greater:
        Goto done_compare_not_needed
    is_less:
        Goto done_compare_needed

    done_compare_needed:
        #.NET Framework 4.8 install is *NEEDED*
 
        # Microsoft Download Center EXE:
        # Web Bootstrapper: https://go.microsoft.com/fwlink/?LinkId=2085155
        # Full Download: https://go.microsoft.com/fwlink/?linkid=2088631
 
        # Setup looks for components\dotNET48Full.exe relative to the install EXE location
        # This allows the installer to be placed on a USB stick (for computers without internet connections)
        # If the .NET Framework 4.8 installer is *NOT* found, Setup will connect to Microsoft's website
        # and download it for you
 
        # Reboot Required with these Exit Codes:
        # 1641 or 3010
 
        # Command Line Switches:
        # /showrmui /passive /norestart
 
        # Silent Command Line Switches:
        # /q /norestart
 
 
        # Let's see if the user is doing a Silent install or not
        IfSilent is_quiet is_not_quiet
 
        is_quiet:
            StrCpy $dotNET_CMD_LINE "/q /norestart"
            Goto LookForLocalFile
        is_not_quiet:
            StrCpy $dotNET_CMD_LINE "/showrmui /passive /norestart"
            Goto LookForLocalFile
 
        LookForLocalFile:
            # Let's see if the user stored the Full Installer
            IfFileExists "$EXEPATH\components\dotNET48Full.exe" do_local_install do_network_install
 
            do_local_install:
                # .NET Framework found on the local disk.  Use this copy
 
                ExecWait '"$EXEPATH\components\dotNET48Full.exe" $dotNET_CMD_LINE' $EXIT_CODE
                Goto is_reboot_requested
 
            # Now, let's Download the .NET
            do_network_install:
 
                Var /GLOBAL dotNetDidDownload
                NSISdl::download "https://go.microsoft.com/fwlink/?linkid=2088631" "$TEMP\dotNET48Web.exe" $dotNetDidDownload
 
                StrCmp $dotNetDidDownload success fail
                success:
                    ExecWait '"$TEMP\dotNET45Web.exe" $dotNET_CMD_LINE' $EXIT_CODE
                    Goto is_reboot_requested
 
                fail:
                    MessageBox MB_OK|MB_ICONEXCLAMATION "Unable to download .NET Framework.  ${PRODUCT_NAME} will be installed, but will not function without the Framework!"
                    Goto done_dotNET_function
 
                # $EXIT_CODE contains the return codes.  1641 and 3010 means a Reboot has been requested
                is_reboot_requested:
                    ${If} $EXIT_CODE = 1641
                    ${OrIf} $EXIT_CODE = 3010
                        SetRebootFlag true
                    ${EndIf}
 
    done_compare_not_needed:
        # Done dotNET Install
        Goto done_dotNET_function
 
    #exit the function
    done_dotNET_function:
 
FunctionEnd

Section "" CoreSection
	ReadRegStr $0 HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" "Version"
	${VersionCompare} ${VERSION} $0 $R0

	${If} $R0 == 2
		IfSilent +2
		MessageBox MB_OK "UBService version $0 is already installed. Skipping install of version ${VERSION}."
		Quit
	${EndIf}

; Set Section properties
	SetOverwrite on

	; Set Section Files and Shortcuts
	SetOutPath "$INSTDIR\"
	
	File "${BUILDPATH}\${ASSEMBLY}"

SectionEnd

Section -FinishSection

	WriteRegStr HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}" "Version" "${VERSION}"

	;Unregister old plugin
	ClearErrors
	ReadRegStr $0 HKLM "Software\Decal\Services\${SERVICEGUID}" ""
	${IfNot} ${Errors}
		DeleteRegKey HKLM "Software\Decal\Services\${SERVICEGUID}"
	${EndIf}

    
	WriteRegStr HKLM "Software\Decal\Services\${SERVICEGUID}" "" "${APPNAME}"
	WriteRegDWORD HKLM "Software\Decal\Services\${SERVICEGUID}" "Enabled" "1"
	WriteRegStr HKLM "Software\Decal\Services\${SERVICEGUID}" "Object" "${CLASSNAME}"
	WriteRegStr HKLM "Software\Decal\Services\${SERVICEGUID}" "Assembly" "${ASSEMBLY}"
	WriteRegStr HKLM "Software\Decal\Services\${SERVICEGUID}" "Path" "$INSTDIR"
	WriteRegStr HKLM "Software\Decal\Services\${SERVICEGUID}" "Surrogate" "{71A69713-6593-47EC-0002-0000000DECA1}"
	WriteRegStr HKLM "Software\Decal\Services\${SERVICEGUID}" "Uninstaller" "${APPNAME}"

	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$INSTDIR\uninstall.exe"
	WriteUninstaller "$INSTDIR\uninstall.exe"

    ; make sure dotnet 4.8 is installed
    Call CheckAndDownloadDotNet48
	
SectionEnd

; Modern install component descriptions
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	!insertmacro MUI_DESCRIPTION_TEXT ${CoreSection} ""
!insertmacro MUI_FUNCTION_DESCRIPTION_END

;Uninstall section
Section Uninstall

	;Remove from registry...
	DeleteRegKey HKLM "Software\${SOFTWARECOMPANY}\${APPNAME}"
	DeleteRegKey HKLM "Software\Decal\Services\${SERVICEGUID}"
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"

	; Delete self
	Delete "$INSTDIR\uninstall.exe"

	;Clean up
	Delete "$INSTDIR\${ASSEMBLY}"

SectionEnd

; eof