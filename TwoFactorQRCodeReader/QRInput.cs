using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using ZXing;
using System.Collections.Specialized;

namespace TwoFactorQRCodeReader
{
	public partial class QRInput : Form
	{
		private BarcodeReader _barcodeReader = new BarcodeReader
		{
			Options = new ZXing.Common.DecodingOptions
			{
				PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE }
			}
		};

		public QRInput()
		{
			InitializeComponent();
		}

		protected override void OnClosed(EventArgs e)
		{
			mCheckTimer.Enabled = false;
			base.OnClosed(e);
		}

		private void mCheckTimer_Tick(object sender, EventArgs e)
		{
			if (mOTPUrl.Focused)
			{
				return;
			}

			string result = null;

			// Check clipboard
			try
			{
				var bitmap = Clipboard.GetImage() as Bitmap;
				if (bitmap != null)
				{
					result = ParseBitmap(bitmap);
				}
			}
			catch (ExternalException)
			{
				// Could not get image from clipboard, ignore it.
			}

			if (result == null)
			{
				// Check whole screen
				var bitmap = GetScreenBitmap();
				result = ParseBitmap(bitmap);
			}

			if (result != null)
			{
				mOTPUrl.Text = result;
			}
		}

		private Bitmap GetScreenBitmap()
		{
			var bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, PixelFormat.Format32bppArgb);

			// Create a graphics object from the bitmap.
			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, SystemInformation.VirtualScreen.Size, CopyPixelOperation.SourceCopy);
			}

			return bitmap;
		}

		private string ParseBitmap(Bitmap bitmap)
		{
			var result = _barcodeReader.Decode(bitmap);
			if (result == null)
			{
				return null;
			}
			return result.Text;
		}

		private void mOTPUrl_TextChanged(object sender, EventArgs e)
		{
			m_btnOK.Enabled = mOTPUrl.Text.Length > 0 && GetOtpParamerters()["secret"] != null;
			if (m_btnOK.Enabled && m_btnCancel.Focused)
			{
				m_btnOK.Focus();
			}
		}

		/// <summary>
		/// Gets all the parameters of the OTP URL, plus an additional parameter called _type that may be hotp or totp
		/// </summary>
		/// <returns></returns>
		public NameValueCollection GetOtpParamerters()
		{
			Uri uri;
			if (Uri.TryCreate(mOTPUrl.Text, UriKind.Absolute, out uri) && uri.Scheme == "otpauth")
			{
				var type = uri.Host.ToLowerInvariant();
				if (type == "hotp" ||
					type == "totp")
				{
					var result = HttpUtility.ParseQueryString(uri.Query);
					result.Add("_type", type);
					return result;
				}
			}

			return new NameValueCollection();
		}
	}
}
