using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Configuration;
using System.Data.SqlClient;

using GsmComm.GsmCommunication;
using GsmComm.PduConverter;


using System.Threading;

namespace SMS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label lbl_phone_status;
        public TextBox txtOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuItem mnu_send;
		private System.Windows.Forms.MenuItem mnu_read;
	
		private delegate void SetTextCallback(string text);
		private CommSetting comm_settings=new CommSetting();
        private System.Windows.Forms.MenuItem mnudelete;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private IContainer components;

        public SqlConnection conn;
        public SqlDataReader dreader;
        public SqlCommand cmd;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView DGSent;
        private DataGridView DGReceived;
        private DataGridViewTextBoxColumn sender;
        private DataGridViewTextBoxColumn receivemessage;
        private DataGridViewTextBoxColumn datereceived;
        private ToolStrip toolStrip1;
        private ToolStripButton TSSend;
        private ToolStripButton TSDelete;
        private ToolStripSeparator toolStripSeparator1;
        private Label lblCheck;
        private Label lblErr;
        
        int ticktime;
        private DataGridViewTextBoxColumn phonenumber;
        private DataGridViewTextBoxColumn message;
        private DataGridViewTextBoxColumn sent;
        private DataGridViewTextBoxColumn status;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton1;
        private DataGridViewTextBoxColumn sentby;
        private TabPage tabSP;
        private DataGridView DGCommand;
        private erpDataSet erpDataSet;
        private BindingSource textcommandsBindingSource;
        private erpDataSetTableAdapters.text_commandsTableAdapter text_commandsTableAdapter;
        private BindingSource textreceiveBindingSource;
        private erpDataSetTableAdapters.text_receiveTableAdapter text_receiveTableAdapter;
        private BindingSource autoReplyBindingSource;
        private erpDataSetTableAdapters.SPAutoReply sPAutoReply;
        private ProgressBar Signal;
        private Label label2;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private bool autoreplyfrm = true;

		public Form1()
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
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnu_send = new System.Windows.Forms.MenuItem();
            this.mnu_read = new System.Windows.Forms.MenuItem();
            this.mnudelete = new System.Windows.Forms.MenuItem();
            this.lbl_phone_status = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblErr = new System.Windows.Forms.Label();
            this.DGReceived = new System.Windows.Forms.DataGridView();
            this.sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivemessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datereceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGSent = new System.Windows.Forms.DataGridView();
            this.phonenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSP = new System.Windows.Forms.TabPage();
            this.DGCommand = new System.Windows.Forms.DataGridView();
            this.textcommandsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblCheck = new System.Windows.Forms.Label();
            this.erpDataSet = new SMS.erpDataSet();
            this.text_commandsTableAdapter = new SMS.erpDataSetTableAdapters.text_commandsTableAdapter();
            this.textreceiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.text_receiveTableAdapter = new SMS.erpDataSetTableAdapters.text_receiveTableAdapter();
            this.autoReplyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sPAutoReply = new SMS.erpDataSetTableAdapters.SPAutoReply();
            this.Signal = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGReceived)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGSent)).BeginInit();
            this.tabSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textcommandsBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textreceiveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoReplyBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnu_send,
            this.mnu_read,
            this.mnudelete});
            this.menuItem1.Text = "&File";
            // 
            // mnu_send
            // 
            this.mnu_send.Index = 0;
            this.mnu_send.Text = "Send SMS";
            this.mnu_send.Click += new System.EventHandler(this.mnu_send_click);
            // 
            // mnu_read
            // 
            this.mnu_read.Index = 1;
            this.mnu_read.Text = "Read";
            this.mnu_read.Click += new System.EventHandler(this.mnu_read_click);
            // 
            // mnudelete
            // 
            this.mnudelete.Index = 2;
            this.mnudelete.Text = "Delete SMS from SIM";
            this.mnudelete.Click += new System.EventHandler(this.mnudelete_Click);
            // 
            // lbl_phone_status
            // 
            this.lbl_phone_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_phone_status.BackColor = System.Drawing.Color.White;
            this.lbl_phone_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_phone_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_phone_status.Location = new System.Drawing.Point(696, 400);
            this.lbl_phone_status.Name = "lbl_phone_status";
            this.lbl_phone_status.Size = new System.Drawing.Size(196, 23);
            this.lbl_phone_status.TabIndex = 54;
            this.lbl_phone_status.Text = "NO MODEM CONNECTED";
            this.lbl_phone_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_phone_status.UseMnemonic = false;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(589, 63);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(303, 329);
            this.txtOutput.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(586, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "SMS Logs :";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.TabIndex = 57;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "Please Wait. . .";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabSP);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 364);
            this.tabControl1.TabIndex = 58;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblErr);
            this.tabPage3.Controls.Add(this.DGReceived);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(562, 338);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Received SMS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.Location = new System.Drawing.Point(239, 153);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(72, 13);
            this.lblErr.TabIndex = 61;
            this.lblErr.Text = "Checking...";
            this.lblErr.Visible = false;
            // 
            // DGReceived
            // 
            this.DGReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGReceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sender,
            this.receivemessage,
            this.datereceived});
            this.DGReceived.Location = new System.Drawing.Point(3, 3);
            this.DGReceived.Name = "DGReceived";
            this.DGReceived.Size = new System.Drawing.Size(559, 348);
            this.DGReceived.TabIndex = 0;
            // 
            // sender
            // 
            this.sender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sender.HeaderText = "Sender";
            this.sender.Name = "sender";
            // 
            // receivemessage
            // 
            this.receivemessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.receivemessage.HeaderText = "Message";
            this.receivemessage.Name = "receivemessage";
            // 
            // datereceived
            // 
            this.datereceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datereceived.HeaderText = "Date Received";
            this.datereceived.Name = "datereceived";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGSent);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sent SMS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGSent
            // 
            this.DGSent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGSent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phonenumber,
            this.message,
            this.sent,
            this.status,
            this.sentby});
            this.DGSent.Location = new System.Drawing.Point(3, 0);
            this.DGSent.Name = "DGSent";
            this.DGSent.Size = new System.Drawing.Size(556, 348);
            this.DGSent.TabIndex = 0;
            // 
            // phonenumber
            // 
            this.phonenumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phonenumber.HeaderText = "Phone Number";
            this.phonenumber.Name = "phonenumber";
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.message.HeaderText = "Message";
            this.message.MinimumWidth = 15;
            this.message.Name = "message";
            // 
            // sent
            // 
            this.sent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sent.HeaderText = "Date Sent";
            this.sent.Name = "sent";
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // sentby
            // 
            this.sentby.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sentby.HeaderText = "Sent By";
            this.sentby.Name = "sentby";
            // 
            // tabSP
            // 
            this.tabSP.Controls.Add(this.DGCommand);
            this.tabSP.Location = new System.Drawing.Point(4, 22);
            this.tabSP.Name = "tabSP";
            this.tabSP.Padding = new System.Windows.Forms.Padding(3);
            this.tabSP.Size = new System.Drawing.Size(562, 338);
            this.tabSP.TabIndex = 3;
            this.tabSP.Text = "Commands";
            this.tabSP.UseVisualStyleBackColor = true;
            // 
            // DGCommand
            // 
            this.DGCommand.AllowUserToDeleteRows = false;
            this.DGCommand.AutoGenerateColumns = false;
            this.DGCommand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGCommand.DataSource = this.textcommandsBindingSource;
            this.DGCommand.Location = new System.Drawing.Point(3, 0);
            this.DGCommand.Name = "DGCommand";
            this.DGCommand.ReadOnly = true;
            this.DGCommand.Size = new System.Drawing.Size(556, 335);
            this.DGCommand.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSend,
            this.toolStripSeparator1,
            this.TSDelete,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(892, 25);
            this.toolStrip1.TabIndex = 59;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // TSSend
            // 
            this.TSSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSSend.Image = ((System.Drawing.Image)(resources.GetObject("TSSend.Image")));
            this.TSSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSSend.Name = "TSSend";
            this.TSSend.Size = new System.Drawing.Size(23, 22);
            this.TSSend.Text = "Send SMS";
            this.TSSend.Click += new System.EventHandler(this.TSSend_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // TSDelete
            // 
            this.TSDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDelete.Image = ((System.Drawing.Image)(resources.GetObject("TSDelete.Image")));
            this.TSDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDelete.Name = "TSDelete";
            this.TSDelete.Size = new System.Drawing.Size(23, 22);
            this.TSDelete.Text = "Delete SMS from SIM";
            this.TSDelete.Visible = false;
            this.TSDelete.Click += new System.EventHandler(this.TSDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Hide AutoReply";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.Location = new System.Drawing.Point(661, 203);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(76, 13);
            this.lblCheck.TabIndex = 60;
            this.lblCheck.Text = "Receiving...";
            this.lblCheck.Visible = false;
            // 
            // erpDataSet
            // 
            this.erpDataSet.DataSetName = "erpDataSet";
            this.erpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // text_commandsTableAdapter
            // 
            this.text_commandsTableAdapter.ClearBeforeFill = true;
            // 
            // textreceiveBindingSource
            // 
            this.textreceiveBindingSource.DataMember = "text_receive";
            this.textreceiveBindingSource.DataSource = this.erpDataSet;
            // 
            // text_receiveTableAdapter
            // 
            this.text_receiveTableAdapter.ClearBeforeFill = true;
            // 
            // autoReplyBindingSource
            // 
            this.autoReplyBindingSource.DataMember = "AutoReply";
            this.autoReplyBindingSource.DataSource = this.erpDataSet;
            // 
            // sPAutoReply
            // 
            this.sPAutoReply.ClearBeforeFill = true;
            // 
            // Signal
            // 
            this.Signal.Location = new System.Drawing.Point(603, 8);
            this.Signal.Name = "Signal";
            this.Signal.Size = new System.Drawing.Size(162, 15);
            this.Signal.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(555, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Signal";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SMS Commander";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(892, 422);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Signal);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lbl_phone_status);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Innovative Packaging Industry Corporation";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGReceived)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGSent)).EndInit();
            this.tabSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGCommand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textcommandsBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textreceiveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoReplyBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        #region database functions

        // Database Connection
        public void DatabaseConnection()
        {
            string Database = ConfigurationManager.AppSettings["database"].ToString();
            string Server   = ConfigurationManager.AppSettings["server"].ToString();
            string Username = ConfigurationManager.AppSettings["username"].ToString();
            string Password = ConfigurationManager.AppSettings["password"].ToString();
            string sqlConn;

            sqlConn = "Initial Catalog=" + Database + ";" + "Data Source=" + Server + ";User ID=" + Username + ";Password=" + Password + "; MultipleActiveResultSets=True";
            conn = new SqlConnection(sqlConn);
        }

        public void InsertFailedSMS(string message, long text_send_id, string phone)
        {
            string sql = "INSERT INTO text_failed_log(message,text_send_id,timestamp,resend,cellphonenumber) SELECT @msg,@text_send_id,@schedule,@status,@phone";

            cmd = new SqlCommand(sql);
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@msg", message);
            cmd.Parameters.AddWithValue("@text_send_id", text_send_id);
            cmd.Parameters.AddWithValue("@schedule", DateTime.Now);
            cmd.Parameters.AddWithValue("@status", 0);
            cmd.Parameters.AddWithValue("@phone", phone);

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        // Insert Received
        public void InsertReceived(string phonenumber,string message,DateTime schedule,int status )
        {
            string sql = "INSERT INTO text_receive(sender,message,timestamp,processed) SELECT @phone,@msg,@schedule,@status";
            
            cmd = new SqlCommand(sql);
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@phone",phonenumber);
            cmd.Parameters.AddWithValue("@msg", message);
            cmd.Parameters.AddWithValue("@schedule", schedule);
            cmd.Parameters.AddWithValue("@status", status);

            try{
                 conn.Open();
                 cmd.ExecuteNonQuery();
            }
            catch (SqlException ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
               conn.Close();
            }
        }

        // Insert Sent
        public void InsertSent(string phonenumber, string message, DateTime schedule, int status)
        {
            string sql = "INSERT INTO text_send(cellphonenumber,message,schedule,timestamp,status) SELECT @phone,@msg,@schedule,@timestamp,@status";

            cmd = new SqlCommand(sql);
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@phone", phonenumber);
            cmd.Parameters.AddWithValue("@msg", message);
            cmd.Parameters.AddWithValue("@schedule", schedule);
            cmd.Parameters.AddWithValue("@timestamp",  DateTime.Now);
            cmd.Parameters.AddWithValue("@status", status);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Retrieve Sentmsgs
        public void RetrieveSent()
        {
            try
            {
                conn.Open();
                string sql = "SELECT cellphonenumber,message,timestamp,case when status = 1 then 'Sent' else 'Scheduled/Pending' end ,isnull(dbo.fn_username(sent_by),'Admin') from text_send order by id desc";

                cmd = new SqlCommand(sql,conn);
                cmd.CommandType = CommandType.Text;
                dreader = cmd.ExecuteReader();
                DGSent.Rows.Clear();

                while (dreader.Read())
                {
                    DGSent.Rows.Add(dreader.GetValue(0).ToString(), 
                                        dreader.GetValue(1).ToString(), 
                                        dreader.GetValue(2).ToString(), 
                                        dreader.GetValue(3).ToString());
                }
                DGSent.AutoResizeColumns();
                dreader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Retrieve Receivedmsgs
        public void RetrieveReceived()
        {
            try
            {
                DatabaseConnection();
                conn.Open();
                string sql = "SELECT sender,message,timestamp from text_receive order by id desc";

                cmd = new SqlCommand(sql,conn);
                cmd.CommandType = CommandType.Text;
                dreader = cmd.ExecuteReader();
                DGReceived.Rows.Clear();

                while (dreader.Read())
                {
                    DGReceived.Rows.Add(dreader.GetValue(0).ToString(),
                                        dreader.GetValue(1).ToString(),
                                        dreader.GetValue(2).ToString());
                }
                DGReceived.AutoResizeColumns();
                dreader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
         }
             
        #endregion

        private delegate void ConnectedHandler(bool connected);
				
		private void OnPhoneConnectionChange(bool connected)
		{
			lbl_phone_status.Text="CONNECTED";
		}

		
		public void comm_MessageReceived(object sender, GsmComm.GsmCommunication.MessageReceivedEventArgs e)
		{
			MessageReceived();
            //MessageBox.Show("x");
		}

		public void comm_PhoneConnected(object sender, EventArgs e)
		{
			this.Invoke(new ConnectedHandler(OnPhoneConnectionChange), new object[] { true });
		}


		private string GetMessageStorage()
		{
			string storage = string.Empty;
			storage = PhoneStorageType.Sim;
			
			if (storage.Length == 0)
				throw new ApplicationException("Unknown message storage.");
			else
				return storage;
		}


		private void MessageReceived()
		{
            try
            {
                string storage = GetMessageStorage();
                DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.ReceivedUnread, storage);
                foreach (DecodedShortMessage message in messages)
                {
                    lblCheck.Visible = true;
                    Output(string.Format("Message status = {0}, Location = {1}/{2}",
                        StatusToString(message.Status), message.Storage, message.Index));
                    ShowMessage(message.Data);
                    Output("");
                }
                if (messages.Length > 0)
                {
                    Output(string.Format("{0,9} messages read.", messages.Length.ToString()));
                    Output("");
                    // Delete all messages from phone memory
                    CommSetting.comm.DeleteMessages(DeleteScope.All, storage);
                }
            }
            catch(Exception ex)
            {
                DatabaseConnection();
                InsertFailedSMS(ex.ToString(), 0, "");
                MessageBox.Show(this, ex.ToString());
            }
            lblCheck.Visible = false;
		}

        private void GetUnprocess()
        {
            DataTable receivesms = text_receiveTableAdapter.GetData2();
            long id;

            string message;
            string phonenumber;

            foreach (DataRow rows in receivesms.Rows)
            {

                id = long.Parse(rows.ItemArray[2].ToString());
                message = rows.ItemArray[1].ToString();
                phonenumber = rows.ItemArray[0].ToString();

                ProcessUnprocess(message);
                text_receiveTableAdapter.UpdateMsg(id);
            }
        }

        private void ProcessUnprocess(string message)
        {
            DataTable receivesms = text_receiveTableAdapter.GetData(message);
            long id;
            string phonenumber;

            foreach (DataRow rows in receivesms.Rows)
            {

                id = long.Parse(rows.ItemArray[2].ToString());
                phonenumber = rows.ItemArray[0].ToString();

                sPAutoReply.GetData(phonenumber, message,id);
            }
        }



		private string StatusToString(PhoneMessageStatus status)
		{
			// Map a message status to a string
			string ret;
			switch(status)
			{
				case PhoneMessageStatus.All:
					ret = "All";
					break;
				case PhoneMessageStatus.ReceivedRead:
					ret = "Read";
					break;
				case PhoneMessageStatus.ReceivedUnread:
					ret = "Unread";
					break;
				case PhoneMessageStatus.StoredSent:
					ret = "Sent";
					break;
				case PhoneMessageStatus.StoredUnsent:
					ret = "Unsent";
					break;
				default:
					ret = "Unknown (" + status.ToString() + ")";
					break;
			}
			return ret;
		}

       

        public void Output(string text)
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


		public void ShowMessage(SmsPdu pdu)
		{
			if (pdu is SmsDeliverPdu)
			{
				// Received message
				SmsDeliverPdu data = (SmsDeliverPdu)pdu;
				Output("RECEIVED MESSAGE");
				Output("Sender: " + data.OriginatingAddress);
				Output("Sent: " + data.SCTimestamp.ToString());
				Output("Message text: " + data.UserDataText);

				Output("-------------------------------------------------------------------");
                try
                {
                    //Message
                    text_receiveTableAdapter.InsertReceived(data.OriginatingAddress.ToString(), data.UserDataText, data.SCTimestamp.ToDateTime(), 0);

                    DataTable receivesms = text_receiveTableAdapter.GetData(data.UserDataText);
                    long id;
                    string message;
                    string phonenumber;

                    foreach (DataRow rows in receivesms.Rows)
                    {
                        
                        id = long.Parse(rows.ItemArray[2].ToString());
                        message = rows.ItemArray[1].ToString();
                        phonenumber = rows.ItemArray[0].ToString();

                        sPAutoReply.GetData(phonenumber, message,id);
                        text_receiveTableAdapter.UpdateMsg(id);

                        if (this.WindowState == FormWindowState.Minimized)
                        {
                            notifyIcon1.ShowBalloonTip(1000, "Received Msg", "Message From: " + phonenumber, ToolTipIcon.Info);
                        }
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
				
                return;
			}
			if (pdu is SmsStatusReportPdu)
			{
				// Status report
				SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
				Output("STATUS REPORT");
				Output("Recipient: " + data.RecipientAddress);
				Output("Status: " + data.Status.ToString());
				Output("Timestamp: " + data.DischargeTime.ToString());
				Output("Message ref: " + data.MessageReference.ToString());
				Output("-------------------------------------------------------------------");
				return;
			}
			Output("Unknown message type: " + pdu.GetType().ToString());
		}

        #region menus

        private void mnu_send_click(object sender, System.EventArgs e)
		{
			Send send_sms=new Send();
			send_sms.Show();
		}


		private void mnu_read_click(object sender, System.EventArgs e)
		{
			Receive receice_sms=new Receive();
			receice_sms.Show();
		}

        private void mnudelete_Click(object sender, System.EventArgs e)
        {
           // Delete delete = new Delete();
           // delete.Show();
        }

        #endregion

        // Form Load
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Prompt user for connection settings
            int port = GsmCommMain.DefaultPortNumber;
            int baudRate = 9600; // We Set 9600 as our Default Baud Rate
            int timeout = GsmCommMain.DefaultTimeout;

            frmConnection dlg = new frmConnection();
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.SetData(port, baudRate, timeout);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                dlg.GetData(out port, out baudRate, out timeout);
                CommSetting.Comm_Port = port;
                CommSetting.Comm_BaudRate = baudRate;
                CommSetting.Comm_TimeOut = timeout;

                timer1.Enabled = true;
                timer1.Interval = 5000;

                //Retrieve Records
                RetrieveReceived();
                RetrieveSent();

                //Open autoreply
                AutoReply auto_send = new AutoReply();
                auto_send.Show();

                //Email
                //Email email = new Email();
                //email.Show();
            }
            else
            {
                Close();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            CommSetting.comm = new GsmCommMain(port, baudRate, timeout);
            Cursor.Current = Cursors.Default;
            CommSetting.comm.PhoneConnected += new EventHandler(comm_PhoneConnected);
            CommSetting.comm.MessageReceived += new MessageReceivedEventHandler(comm_MessageReceived);
            

            bool retry;
            do
            {
                retry = false;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CommSetting.comm.Open();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception)
                {
                    Cursor.Current = Cursors.Default;
                    if (MessageBox.Show(this, "Unable to open the port.", "Error",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                        retry = true;
                    else
                    {
                        Close();
                        return;
                    }
                }
            }
            while (retry);

        }

     
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Clean up comm object
			if (CommSetting.comm != null)
			{

				// Unregister events
				CommSetting.comm.PhoneConnected -= new EventHandler(comm_PhoneConnected);
				CommSetting.comm.MessageReceived -= new MessageReceivedEventHandler(comm_MessageReceived);
				
				// Close connection to phone
				if (CommSetting.comm != null && CommSetting.comm.IsOpen())
					CommSetting.comm.Close();

				CommSetting.comm = null;
			}
		}

		

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            ticktime = ticktime + 1;

            try
            {
               SignalQualityInfo info = CommSetting.comm.GetSignalQuality();
               Signal.Value = info.SignalStrength * 2; //show result
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


            if (ticktime == 10)
            {
                //Open autoreply
                //AutoReply auto_send = new AutoReply();
                //auto_send.BringToFront();

                MessageReceived();
                GetUnprocess();
                //RetrieveReceived();
                ticktime = 0;
            }
        }

        private void TSSend_Click(object sender, EventArgs e)
        {
            Send send_sms = new Send();
            send_sms.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           //
        }

        private void TSDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AutoReply auto = new AutoReply();
            if (autoreplyfrm)
            {
                autoreplyfrm = false;
                auto.Visible = false;
                
            }
            else
            {
                autoreplyfrm = true;
                auto.Visible = true;
            }
        }

        #region Systray
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        #endregion
    }
}
