TwoFactorQRCodeReader
=====================
http://sourceforge.net/projects/twofactorqrcodereader

This is a plugin to KeePass <http://www.KeePass.info> to easily create the two-factor authentication
parameters used by the KeePass placeholders {HMACOTP} and {TIMEOTP}

Installation
------------
Place TwoFactorQRCodeReader.plgx in your KeePass Plugins folder.


Usage
-----
Right click on any entry and select "Read 2FA QR Code...". Display the 2FA QR code visible anywhere
on your screen and it will read the otpauth:// url from it. The main window will be hidden to make
this easier. You can also take a screenshot of it, or copy the QR code to the clipboard by any other
means, and it will also be read.

Alternatively, if you have an otpauth:// url already, you can just enter it in the box provided.

When you click the OK button, new fields will be created on the entry. These are:

For HMAC-based one-type passwords {HMACOTP}:
* HmacOtp-Secret-Base32
* HmacOtp-Counter

For TOTP-based one-time passwords {TIMEOTP}:
* TimeOtp-Secret-Base32
* TimeOtp-Length (if specified)
* TimeOtp-Period (if specified)
* TimeOtp-Algorithm (if specified)

These values are used by KeePass when autotyping the placeholders {HMACOTP} and {TIMEOTP}, see
https://keepass.info/help/base/placeholders.html#otp


Uninstallation
--------------
Delete TwoFactorQRCodeReader.plgx from your KeePass Plugins folder.


Checking for updates
--------------------
If you want to use the KeePass Check for Updates function to check for updates to this plugin
then it requires the SourceForgeUpdateChecker plugin to be installed too:
http://sourceforge.net/projects/kpsfupdatechecker


KeePassOTP
==========
This project owes a debt of gratitute and inspiration to https://github.com/Rookiestyle/KeePassOTP
That is a much more powerful and fully featured plugin which you may wish to use in preference to
this one. The important difference between the two is the KeePassOTP handles OTP generation itself,
and provides various entry points for generating them, such as context menu commands.

In contrast, this plugin, TwoFactorQRCodeReader, does not generate OTP codes itself, it only
populates the values that are used by the native KeePass OTP generation functionality. It is a
convenient way of entering the necessary data from a QR code, rather than a replacement for the
whole OTP functionality.


Bug Reporting, Questions, Comments, Feedback
--------------------------------------------
Please use the SourceForge project page: <http://sourceforge.net/projects/twofactorqrcodereader>
Bugs can be reported using the issue tracker, for anything else, a discussion forum is available.


Changelog
---------
v0.1 Initial release
