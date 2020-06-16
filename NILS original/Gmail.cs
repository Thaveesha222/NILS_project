using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MimeKit;

namespace NILS_original
{

    class Gmail
    {
        static string[] Scopes = {GmailService.Scope.GmailSend};
        static string ApplicationName = "NILS_original";
        public static string createEmail(string mail, List<string> recipients, string subject, string[] attchment = null)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Thaveesha", "thaveesha222@gmail.com"));
            //message.To.Add(new MailboxAddress("Thaveesha", "thaveesha222@gmail.com"));
            string[] receps = recipients.ToArray();
            foreach (string recpient in receps)
            {
                message.To.Add(new MailboxAddress("Thaveesha", recpient));

            }
           /* for (int i = 0; i < receps.Length; i++)
            {
                message.To.Add(new MailboxAddress("Thaveesha",receps[i]));
            }*/
            message.Subject = subject;
            var builder = new BodyBuilder();

            builder.TextBody = mail;
            if (attchment != null)
            {
                for (int i = 0; i < attchment.Length; i++)
                {
                    builder.Attachments.Add(attchment[i]);
                }
            }
            message.Body = builder.ToMessageBody();
            return message.ToString();
            
        }



        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            System.Windows.Forms.MessageBox.Show(returnValue);

            return returnValue;
        }
        




        public static void sendmail(string msg,List<string> receps,string sub,string[] attachs=null)
        {

            UserCredential credential;

            using (var stream =
                new FileStream("client_secret_526728548470-8q6raufa2qvng71j7vrcart69slh3320.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            Message m = new Message();
            if (attachs == null)
            {
                m.Raw = EncodeTo64(createEmail(msg, receps, sub));
            }
            else
            {
                m.Raw = EncodeTo64(createEmail(msg, receps, sub, attachs));
            }
            service.Users.Messages.Send(m, "me").Execute();
            //SendMessage(service, "thaveesha222@gmail.com", m);
            System.Windows.Forms.MessageBox.Show("done");
        }
    }
}
