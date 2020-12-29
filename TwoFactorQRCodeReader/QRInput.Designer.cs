
namespace TwoFactorQRCodeReader
{
	partial class QRInput
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRInput));
			this.mInstructions = new System.Windows.Forms.Label();
			this.mOTPUrl = new System.Windows.Forms.TextBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.mCheckTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// mInstructions
			// 
			this.mInstructions.AutoSize = true;
			this.mInstructions.Location = new System.Drawing.Point(13, 13);
			this.mInstructions.MaximumSize = new System.Drawing.Size(500, 0);
			this.mInstructions.Name = "mInstructions";
			this.mInstructions.Size = new System.Drawing.Size(500, 26);
			this.mInstructions.TabIndex = 0;
			this.mInstructions.Text = "Ensure the QR Code is visible somewhere on-screen, or copy it to the clipboard. A" +
    "lternatively, if you have a URL starting otpauth:// you can enter that directly " +
    "below:";
			// 
			// mOTPUrl
			// 
			this.mOTPUrl.Location = new System.Drawing.Point(16, 55);
			this.mOTPUrl.Name = "mOTPUrl";
			this.mOTPUrl.Size = new System.Drawing.Size(500, 20);
			this.mOTPUrl.TabIndex = 2;
			this.mOTPUrl.TextChanged += new System.EventHandler(this.mOTPUrl_TextChanged);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(447, 89);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "&Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnOK
			// 
			this.m_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(366, 89);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 0;
			this.m_btnOK.Text = "&OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			// 
			// mCheckTimer
			// 
			this.mCheckTimer.Enabled = true;
			this.mCheckTimer.Interval = 200;
			this.mCheckTimer.Tick += new System.EventHandler(this.mCheckTimer_Tick);
			// 
			// QRInput
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(534, 124);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.mOTPUrl);
			this.Controls.Add(this.mInstructions);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "QRInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Read 2FA QR Code";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mInstructions;
		private System.Windows.Forms.TextBox mOTPUrl;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Timer mCheckTimer;
	}
}