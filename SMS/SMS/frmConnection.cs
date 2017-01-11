
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using GsmComm.GsmCommunication;

namespace SMS
{
	/// <summary>
	/// Summary description for frmConnection.
	/// </summary>
	public class frmConnection : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTimeout;
		private System.Windows.Forms.Label lblBaudRate;
		private System.Windows.Forms.ComboBox cboTimeout;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.ComboBox cboPort;
		private System.Windows.Forms.ComboBox cboBaudRate;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnTest;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int port;
		private int baudRate;
        private PictureBox pictureBox1;
		private int timeout;

		public frmConnection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnection));
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cboTimeout = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimeout
            // 
            this.lblTimeout.Location = new System.Drawing.Point(12, 106);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(79, 23);
            this.lblTimeout.TabIndex = 4;
            this.lblTimeout.Text = "Ti&meout (ms):";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Location = new System.Drawing.Point(18, 83);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 23);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "&Baud rate:";
            this.lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTimeout
            // 
            this.cboTimeout.Location = new System.Drawing.Point(97, 108);
            this.cboTimeout.Name = "cboTimeout";
            this.cboTimeout.Size = new System.Drawing.Size(104, 21);
            this.cboTimeout.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(41, 59);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 23);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "&COM:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPort
            // 
            this.cboPort.Location = new System.Drawing.Point(97, 59);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(104, 21);
            this.cboPort.TabIndex = 1;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.Location = new System.Drawing.Point(97, 85);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(104, 21);
            this.cboBaudRate.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = global::SMS.Properties.Resources.connection;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(84, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 40);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "       Connect";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::SMS.Properties.Resources.disconnect;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(191, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Exit";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTest
            // 
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.Image = global::SMS.Properties.Resources.testconnection;
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(12, 140);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(64, 40);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "&Test";
            this.btnTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 55);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmConnection
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(260, 197);
            this.ControlBox = false;
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTimeout);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.cboTimeout);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void Getports()
        {
            // Display each port name to the console.
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cboPort.Items.Add(port.Replace("COM", ""));
            }
        }

		public void SetData(int port, int baudRate, int timeout)
		{
			this.port = port;
			this.baudRate = baudRate;
			this.timeout = timeout;
		}

		public void GetData(out int port, out int baudRate, out int timeout)
		{
			port = this.port;
			baudRate = this.baudRate;
			timeout = this.timeout;
		}

		private bool EnterNewSettings()
		{
			int newPort;
			int newBaudRate;
			int newTimeout;

			try
			{
				newPort = int.Parse(cboPort.Text);
			}
			catch(Exception)
			{
				MessageBox.Show(this, "Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboPort.Focus();
				return false;
			}

			try
			{
				newBaudRate = int.Parse(cboBaudRate.Text);
			}
			catch(Exception)
			{
				MessageBox.Show(this, "Invalid baud rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboBaudRate.Focus();
				return false;
			}

			try
			{
				newTimeout = int.Parse(cboTimeout.Text);
			}
			catch(Exception)
			{
				MessageBox.Show(this, "Invalid timeout value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboTimeout.Focus();
				return false;
			}

			SetData(newPort,newBaudRate,newTimeout);
			
			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!EnterNewSettings())
				DialogResult = DialogResult.None;
		}

		private void frmConnection_Load(object sender, System.EventArgs e)
		{

            
            Getports();
			cboPort.Text = port.ToString();

			cboBaudRate.Items.Add("9600");
			cboBaudRate.Items.Add("19200");
			cboBaudRate.Items.Add("38400");
			cboBaudRate.Items.Add("57600");
			cboBaudRate.Items.Add("115200");
			cboBaudRate.Text = baudRate.ToString();

			cboTimeout.Items.Add("150");
			cboTimeout.Items.Add("300");
			cboTimeout.Items.Add("600");
			cboTimeout.Items.Add("900");
			cboTimeout.Items.Add("1200");
			cboTimeout.Items.Add("1500");
			cboTimeout.Items.Add("1800");
			cboTimeout.Items.Add("2000");
            cboTimeout.Text = timeout.ToString();
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			if (!EnterNewSettings())
				return;

			Cursor.Current = Cursors.WaitCursor;
			GsmCommMain comm = new GsmCommMain(port, baudRate, timeout);
			try
			{
				comm.Open();
				while (!comm.IsConnected())
				{
					Cursor.Current = Cursors.Default;
					if (MessageBox.Show(this, "No modem connected.", "Connection setup",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
					{
						comm.Close();
						return;
					}
					Cursor.Current = Cursors.WaitCursor;
				}

				comm.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, "Connection error: " + ex.Message, "Connection setup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			MessageBox.Show(this, "Successfully connected to the modem.", "Connection setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
			
				
		}
	}
}
