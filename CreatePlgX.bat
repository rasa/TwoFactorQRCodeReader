@echo off
cd %~dp0

echo Deleting existing PlgX folder
rmdir /s /q PlgX

echo Creating PlgX folder
mkdir PlgX

echo Copying files
xcopy TwoFactorQRCodeReader PlgX /s /e /exclude:PlgXExclude.txt
xcopy TwoFactorQRCodeReader\packages\ZXing.Net.0.16.6\lib\net47\*.dll PlgX\packages\ZXing.Net.0.16.6\lib\net47\

echo Compiling PlgX
"../KeePass/KeePass.exe" /plgx-create "%~dp0PlgX" --plgx-prereq-kp:2.47

echo Releasing PlgX
move /y PlgX.plgx "Releases\Build Outputs\TimeOtpQRCodeReader.plgx"

echo Cleaning up
rmdir /s /q PlgX
