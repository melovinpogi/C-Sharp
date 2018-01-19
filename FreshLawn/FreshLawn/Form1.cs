using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FreshLawn.Model;
using System.Data.Entity;


namespace FreshLawn
{
    public partial class Form1 : Form
    {
        freshlawnContainer db = new freshlawnContainer();
        private static string smtp = ConfigurationManager.AppSettings["MailServer"];
        private static string mailfrom = ConfigurationManager.AppSettings["EmailFromAddress"];
        private static string user = ConfigurationManager.AppSettings["MailAuthUser"];
        private static string pw = ConfigurationManager.AppSettings["MailAuthPass"];
        private static int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
       
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ProcessEmail(); 
            System.Threading.Thread.Sleep(3000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        public bool Send(string mailto,string subject,string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);

                mail.From = new MailAddress(mailfrom);
                mail.To.Add(mailto);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(user, pw);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public void ProcessEmail()
        {
            status.Visible = true;
            try
            {
                var email = db.sys_email.Where(x => x.status == 0).OrderBy(x => x.date_created).FirstOrDefault();

                if (email != null)
                {
                    if (Send(email.recipient, email.subject, email.message))
                    {
                        email.date_sent = DateTime.Now;
                        email.status = 1;
                        db.SaveChanges();


                        richTextBox2.AppendText("Email sent successfully to " + email.recipient + " " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt"));
                        richTextBox2.AppendText("\r\n");
                    }
                    else
                    {
                        richTextBox2.AppendText("Email sending failed to " + email.recipient + ". Resending... " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt"));
                        richTextBox2.AppendText("\r\n");
                    }
                }
                
            }
            catch (Exception ex)
            {
                richTextBox2.AppendText("System Error" + ex.Message.ToString() + ". " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt"));
                richTextBox2.AppendText("\r\n");
            }
            richTextBox2.ScrollToCaret();
            status.Visible = false;
        }
    }
}
