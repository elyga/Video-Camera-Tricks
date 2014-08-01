@Echo off

REM
REM Configuration test
REM 
REM set CONF_COMPILER=C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\csc.exe
set CONF_COMPILER=C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe

REM
REM Compile
REM 

REM Copy required libraries:
REM ========================
REM xcopy "%~dp0Source\AForge\AForge.Video.dll" "%~dp0" 1>nul 2>nul
REM xcopy "%~dp0Source\AForge\AForge.Video.DirectShow.dll" "%~dp0" 1>nul 2>nul
xcopy "%~dp0Source\AForge\*.dll" "%~dp0" 1>nul 2>nul

REM Compile main application:
REM =========================
%CONF_COMPILER% /unsafe /target:winexe /reference:AForge.Vision.dll /reference:AForge.dll /reference:AForge.Math.dll /reference:AForge.Imaging.dll /reference:AForge.Video.dll /reference:AForge.Video.DirectShow.dll /out:"Video Camera.exe" /win32icon:Ico\web-camera.ico /resource:Source\Resources\FormsResources.resources Source\Main.cs Source\Properties\AssemblyInfo.cs Source\CommPort.cs Source\Settings.cs Source\Tool_13DiodesFormEvents.cs Source\Tool_HddEngineControlForm.cs Source\Tool_SingleWebCamManager.cs Source\AppForm.cs Source\ES.Software.Video\Camera.cs Source\ES.Software.Video\MotionDetection.cs Source\Static_Variables.cs Source\WMP_Control.cs Source\ES.Software.Video\ImageMatric.cs Source\ES.Software.Video\UnSafeBitmap.cs

REM
REM Release
REM 
del "%~dp0Release\*.exe" 1>nul 2>nul
del "%~dp0Release\*.dll" 1>nul 2>nul
del "%~dp0Release\*.xsd" 1>nul 2>nul
del "%~dp0Release\*.xml" 1>nul 2>nul

mkdir "%~dp0Release\Ico" 1>nul 2>nul
xcopy "%~dp0\Ico\*.ico" "%~dp0Release\Ico" /R /Y  1>nul 2>nul

xcopy "%~dp0*.exe" "%~dp0Release"  1>nul 2>nul
xcopy "%~dp0*.dll" "%~dp0Release"  1>nul 2>nul
REM xcopy "%~dp0DLL_.NET_3.5\*.dll" "%~dp0Release"  1>nul 2>nul
xcopy "%~dp0DB\*.xsd" "%~dp0Release"  1>nul 2>nul
xcopy "%~dp0DB\*.xml" "%~dp0Release"  1>nul 2>nul

REM /E /Q /I

REM
REM Clean
REM
del *.exe 1>nul 2>nul
del *.dll 1>nul 2>nul

REM
REM Run program
REM 
REM "%~dp0Release\NT.exe"
pause