using KeePass.Plugins;
using KeePass.UI;
using KeePassLib;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace TwoFactorQRCodeReader
{
	public sealed class TwoFactorQRCodeReaderExt : Plugin
	{
		private IPluginHost _host;
		private Bitmap _icon;
		public override string UpdateUrl
		{
			get { return "sourceforge-version://TwoFactorQRCodeReader/twofactorqrcodereader?-v(%5B%5Cd.%5D%2B)%5C.zip"; }
		}

		public override Image SmallIcon
		{
			get
			{
				if (_icon == null)
				{
					using(var baseImage = Properties.Resources.ScanQR.ToBitmap())
					{
						_icon = (Bitmap)DpiUtil.ScaleImage(baseImage, true);
					}
				}
				return _icon;
			}
		}

		public override bool Initialize(IPluginHost host)
		{
			_host = host;
			return true;
		}

		public override ToolStripMenuItem GetMenuItem(PluginMenuType menuType)
		{
			if (menuType == PluginMenuType.Entry)
			{
				var readQRCode = new ToolStripMenuItem
				{
					Text = Properties.Resources.ReadQRCode,
					Image = SmallIcon,
				};
				readQRCode.Click += ReadQRcode_Click;

				return readQRCode;
			}

			return null;
		}

		private void ReadQRcode_Click(object sender, EventArgs e)
		{
			var entry = _host.MainWindow.GetSelectedEntry(true);
			if (entry == null)
			{
				return;
			}

			var initialOpacity = _host.MainWindow.Opacity;
			_host.MainWindow.Opacity = 0;
			try
			{
				using (var qrInput = new QRInput())
				{
					if (qrInput.ShowDialog(_host.MainWindow) == DialogResult.OK)
					{
						entry.CreateBackup(_host.Database);

						var parameters = qrInput.GetOtpParamerters();

						switch (parameters["_type"])
						{
							case "hotp":
								CreateField(entry, parameters, "secret", "HmacOtp-Secret-Base32");
								CreateField(entry, parameters, "counter", "HmacOtp-Counter", s => s ?? "0");
								break;
							case "totp":
								CreateField(entry, parameters, "secret", "TimeOtp-Secret-Base32");
								CreateField(entry, parameters, "digits", "TimeOtp-Length");
								CreateField(entry, parameters, "period", "TimeOtp-Period");
								CreateField(entry, parameters, "algorithm", "TimeOtp-Algorithm", ConvertAlgorithm);
								break;
							default:
								MessageBox.Show(_host.MainWindow, "Unknown OTP type: " + parameters["_type"] + "\n\nNo changes have been made to the entry", "TwoFactorQRCodeReader", MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
						}

						entry.Touch(true);
						_host.MainWindow.UpdateUI(false, null, false, null, true, null, true);
					}
				}
			}
			finally
			{
				_host.MainWindow.Opacity = initialOpacity;
			}
		}

		private string ConvertAlgorithm(string urlAlgorithmName)
		{
			switch (urlAlgorithmName)
			{
				case "SHA1":
					return "HMAC-SHA-1";
				case "SHA256":
					return "HMAC-SHA-256";
				case "SHA512":
					return "HMAC-SHA-512";
				default:
					return urlAlgorithmName;
			}
		}

		private void CreateField(PwEntry entry, NameValueCollection parameters, string parameterName, string fieldName, Func<string, string> transform = null)
		{
			var value = parameters[parameterName];
			if (transform != null)
			{
				value = transform(value);
			}

			if (value == null)
			{
				entry.Strings.Remove(fieldName);
			}
			else
			{
				entry.Strings.Set(fieldName, new KeePassLib.Security.ProtectedString(true, value));
			}
		}
	}
}
