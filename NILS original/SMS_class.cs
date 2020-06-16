using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace NILS_original
{
    static class SMS_class
    {
        public static void string_sms(List<string> list,string words)
        {
            string[] x=words.Split(' ');
            string msgbody = null;
            foreach (string c in x)
            {
                msgbody = msgbody + c + "+";
            }
            MessageBox.Show(msgbody);


            string[] nos=list.ToArray();
            string no=null;
            for (int c = 0; c < nos.Length; c++)
            {
                no = no + nos[c]+",";
            }

            Uri target = new Uri("http://www.textit.biz/sendmsg/index.php?id=94762725395&password=4089&text="+msgbody.Remove(msgbody.Length-1,1)+"&to="+ no.Remove(no.Length - 1,1));
            WebRequest request = WebRequest.Create(target);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.GetResponse().ToString();   
        }
    }
}
