!include LogicLib.nsh

!macro CheckVCRedist  
  Var /GLOBAL VCRedistDownload
  Var /GLOBAL isInstalled

  ReadRegDWORD $isInstalled HKLM "SOFTWARE\WOW6432Node\Microsoft\VisualStudio\14.0\VC\Runtimes\x86" "Installed"
  StrCpy $VCRedistDownload "https://aka.ms/vs/17/release/vc_redist.x86.exe"

  ${If} $isInstalled != "1"
    MessageBox MB_YESNO "NOTE: This application requires$\r$\n\
      'Microsoft Visual C++ Redistributable'$\r$\n\
      to function properly.$\r$\n$\r$\n\
      Download and install now?" /SD IDYES IDNO VSRedistInstalled
    
    ;if no goto executed, install vcredist
    ;create temp dir
    CreateDirectory $TEMP\chorizite-setup
    ;download installer
    NSISdl::download "$VCRedistDownload" $TEMP\chorizite-setup\vcppredist.exe
    ;exec installer
    ExecWait "$TEMP\chorizite-setup\vcppredist.exe"
  ${EndIf}


  VSRedistInstalled:
  ;jumped from message box, nothing to do here
!macroend