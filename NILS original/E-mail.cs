using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    class E_mail
    {
       

        public static void send(string sender,string body,string subject, List<string> recievers, List<string> filepaths=null)
        {
            //string to = reciepnts; //To address        
            string from = sender; //From address     
            string[] Multiple = recievers.ToArray();
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);

            try
            {
                foreach (string multiple_email in Multiple)
                {
                    message.Bcc.Add(new MailAddress(multiple_email));
                    
                }
                if (filepaths != null)//Attaching document    
                {
                    string[] attachs = filepaths.ToArray();
                    for (int i = 0; i < attachs.Length; i++)
                    {
                        if (attachs[i].Contains(".rtf"))
                        {
                            continue;
                        }
                        else
                        {
                            message.Attachments.Add(new Attachment(attachs[i]));
                        }
                    }

                }
            }
            catch (System.FormatException f)
            {
                MessageBox.Show("Some emails are invalid","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            /*message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;*/
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp 
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            /*System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("thaveesha222@gmail.com", "112922305");*/
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("thaveesha222@gmail.com", "112922305");
                    smtp.EnableSsl = true;
                    smtp.Send(message);

                }
            }
            catch (System.Net.Mail.SmtpException)
            {
                MessageBox.Show("Make sure you are connected to the internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           // client.Credentials = basicCredential1;
            
        }
    }
}
