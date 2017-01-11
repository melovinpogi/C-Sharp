using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;

using GsmComm.PduConverter;
using GsmComm.GsmCommunication;


namespace SMS
{
	/// <summary>
	/// Summary description for Send.
	/// </summary>
	public class AutoReply : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public TextBox txt_destination_numbers;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_text_remaining;
        public Button btnSendMessage;
        private System.Windows.Forms.Button BtnClear;
        public TextBox txt_message;
        private System.Windows.Forms.TextBox txtOutput;
        private Label label3;
        private Label label4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Timer timer1;
        private IContainer components;
        private PictureBox pictureBox2;
        private ToolStripProgressBar toolStripProgressBar1;
        private erpDataSet erpDataSet;
        private BindingSource textsendBindingSource;
        private erpDataSetTableAdapters.text_sendTableAdapter text_sendTableAdapter;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        		
		private delegate void SetTextCallback(string text);

        int ticktime;

		public AutoReply()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoReply));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_destination_numbers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.txt_text_remaining = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.erpDataSet = new SMS.erpDataSet();
            this.textsendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.text_sendTableAdapter = new SMS.erpDataSetTableAdapters.text_sendTableAdapter();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textsendBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mobile Number :";
            // 
            // txt_destination_numbers
            // 
            this.txt_destination_numbers.Location = new System.Drawing.Point(3, 383);
            this.txt_destination_numbers.MaxLength = 11;
            this.txt_destination_numbers.Name = "txt_destination_numbers";
            this.txt_destination_numbers.Size = new System.Drawing.Size(224, 20);
            this.txt_destination_numbers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compose Message :";
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(3, 405);
            this.txt_message.Multiline = true;
            this.txt_message.Name = "txt_message";
            this.txt_message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_message.Size = new System.Drawing.Size(286, 141);
            this.txt_message.TabIndex = 4;
            this.txt_message.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_text_remaining
            // 
            this.txt_text_remaining.BackColor = System.Drawing.SystemColors.Control;
            this.txt_text_remaining.Enabled = false;
            this.txt_text_remaining.Location = new System.Drawing.Point(249, 555);
            this.txt_text_remaining.Name = "txt_text_remaining";
            this.txt_text_remaining.Size = new System.Drawing.Size(40, 20);
            this.txt_text_remaining.TabIndex = 5;
            this.txt_text_remaining.Text = "160";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSendMessage.Location = new System.Drawing.Point(89, 552);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(80, 24);
            this.btnSendMessage.TabIndex = 16;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnClear.Location = new System.Drawing.Point(3, 552);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(80, 24);
            this.BtnClear.TabIndex = 17;
            this.BtnClear.Text = "Clear";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(0, 199);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(406, 120);
            this.txtOutput.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 60;
            this.label3.Text = "Logs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Auto Reply and Email Blasting Module";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 330);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(413, 22);
            this.statusStrip1.TabIndex = 62;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "Please Wait...";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(406, 151);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(202, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 40);
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // erpDataSet
            // 
            this.erpDataSet.DataSetName = "erpDataSet";
            this.erpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textsendBindingSource
            // 
            this.textsendBindingSource.DataMember = "text_send";
            this.textsendBindingSource.DataSource = this.erpDataSet;
            // 
            // text_sendTableAdapter
            // 
            this.text_sendTableAdapter.ClearBeforeFill = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AutoReply Commander";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // AutoReply
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(413, 352);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txt_text_remaining);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_destination_numbers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AutoReply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Reply";
            this.Load += new System.EventHandler(this.AutoReply_Load);
            this.Move += new System.EventHandler(this.AutoReply_Move_1);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textsendBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

      
        private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			int remaining=int.Parse(txt_text_remaining.Text.Trim());
			remaining-=1;
			txt_text_remaining.Text=remaining.ToString();
		}

		private void BtnClear_Click(object sender, System.EventArgs e)
		{
			txt_message.Text="";
			txt_message.Focus();
		}

		public void btnSendMessage_Click(object sender, System.EventArgs e)
		{
			try
			{
                Form1 main = new Form1();
                // Send an SMS message
				SmsSubmitPdu pdu;
                pdu = new SmsSubmitPdu(txt_message.Text, txt_destination_numbers.Text.Trim(), "");  // "" indicate SMSC No
				// Send the message the specified number of times
                CommSetting.comm.SendMessage(pdu);
                toolStripProgressBar1.Value = 100;
                Output("SENT MESSAGE");
                Output("Recipient: " + txt_destination_numbers.Text);
                Output("Sent: " + DateTime.Now);
                Output("Message text: " + txt_message.Text);
                Output("-------------------------------------------------------------------");
                Output("");
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
			}
			catch(Exception ex)
			{
                Form1 main = new Form1();
                main.DatabaseConnection();
                main.InsertFailedSMS(ex.Message, Convert.ToInt64(main.dreader.GetValue(2)), txt_destination_numbers.Text);
				MessageBox.Show(ex.Message,"SendMessage");
			}
		}


        private void Send(long id,string phone,string msg)
        {
            // Send an SMS message
            SmsSubmitPdu pdu;
            pdu = new SmsSubmitPdu(msg.Trim(), phone.Trim(), "");  // "" indicate SMSC No
            CommSetting.comm.SendMessage(pdu);
            toolStripProgressBar1.Value = 100;

            // CommSetting.comm.MessageSendComplete += comm_SendingSuccess;
            // CommSetting.comm.MessageSendFailed += comm_SendFailed;

           
            Output("SENT MESSAGE");
            Output("Recipient: " + phone);
            Output("Sent: " + DateTime.Now);
            Output("Message text: " + msg);
            Output("-------------------------------------------------------------------");
            Output("");
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
            text_sendTableAdapter.UpdateMsg(id);

            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.ShowBalloonTip(1000, "Sent Msg", "Sent to: " + phone, ToolTipIcon.Info);
            }
        }

        public void comm_SendingSuccess(object sender, GsmComm.GsmCommunication.MessageEventArgs e)
        {
            MessageBox.Show("success");
        }
        public void comm_SendFailed(object sender, GsmComm.GsmCommunication.MessageEventArgs e)
        {
            MessageBox.Show("failed");
        }

        private void SMSSchedule()
        {
            try
            {
                timer1.Stop();
                DataTable pendingsms = text_sendTableAdapter.GetData();
                long id;
                string message;
                string phonenumber;

                foreach (DataRow rows in pendingsms.Rows)
                {
                    //timer1.Stop();
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Value = 50;

                    id          = long.Parse(rows.ItemArray[0].ToString());
                    message     = rows.ItemArray[1].ToString();
                    phonenumber = rows.ItemArray[2].ToString();
                    Send(id, phonenumber, message);

                    System.Threading.Thread.Sleep(1000);
                }
                System.Threading.Thread.Sleep(1000);
                timer1.Start();

                //SMSSchedule2();

            }
            catch(Exception ex ){
                MessageBox.Show(ex.ToString());
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
            }
        }


        private void EmailSending()
        {
            string SMTP     = ConfigurationManager.AppSettings["smtp"].ToString();
            string Email    = ConfigurationManager.AppSettings["email"].ToString();
            string EmailPw  = ConfigurationManager.AppSettings["emailpw"].ToString();

            Form1 main = new Form1();
            main.DatabaseConnection();
            main.conn.Open();

            string emailid;
            string subject;
            string message;
            string to;
            string sql = "pr_sms_email_schedule";

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP);

                main.cmd = new SqlCommand(sql, main.conn);
                main.cmd.CommandType = CommandType.StoredProcedure;
                main.dreader = main.cmd.ExecuteReader();
               
                while( main.dreader.Read() )
                {
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Value = 50;

                    to = main.dreader.GetValue(0).ToString();
                    message = main.dreader.GetValue(1).ToString();
                    emailid = main.dreader.GetValue(2).ToString();
                    subject = main.dreader.GetValue(3).ToString();

                    mail.From = new MailAddress(Email);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = message;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(Email, EmailPw);
                    SmtpServer.EnableSsl = false;
                    SmtpServer.Send(mail);
                    toolStripProgressBar1.Value = 100;

                    Output("SENT EMAIL");
                    Output("Recipient: " + to);
                    Output("Sent: " + DateTime.Now);
                    Output("Subject: " + subject);
                    Output("Message: " + message);
                    Output("-------------------------------------------------------------------");
                    Output("");

                    // Update Status
                    string sqlupdate = "update email set status = 1 where id = cast(" + emailid + " as bigint)";
                    SqlCommand updatecmd = new SqlCommand(sqlupdate);
                    updatecmd.Connection = main.conn;
                    updatecmd.CommandText = sqlupdate;

                        try
                        {
                            updatecmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
            finally
            {
                main.dreader.Close();
                main.conn.Close();
                toolStripProgressBar1.Visible = false;
            }
        }

		private void Output(string text)
		{
			if (this.txtOutput.InvokeRequired)
			{
				SetTextCallback stc = new SetTextCallback(Output);
				this.Invoke(stc, new object[] { text });
			}
			else
			{
				txtOutput.AppendText(text);
				txtOutput.AppendText("\r\n");
			}
		}

		private void AutoReply_Load(object sender, System.EventArgs e)
		{
            timer1.Enabled = true;
           timer1.Interval = 5000;
           
		}

		private void Output(string text, params object[] args)
		{
			string msg = string.Format(text, args);
			Output(msg);
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            ticktime = ticktime + 1;

            
            if (ticktime == 5)
            {
                SMSSchedule();
                //SMSSchedule2();
                ticktime = 0;
                //System.Threading.Thread.Sleep(5000);
            }
        }

        #region Systray
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }        

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AutoReply_Move_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        #endregion

       

       

      

        

	}
}
