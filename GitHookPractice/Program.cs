using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Net.Mail;
using System.IO;

namespace GitHookPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail();
        }

        static void SendEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("victordiazwepsys@gmail.com");
            mail.To.Add("victordiazmateo@gmail.com");
            mail.Subject = "Commit Report";
            mail.Body = "El siguiente archivo contiene los commits que se van a subir";
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment("C:/log.log"));

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("victordiazwepsys@gmail.com", "m4m4n3m4");
            SmtpServer.EnableSsl = true;
            
            SmtpServer.Send(mail);
        }
        
        //    string message = "<table>< thead >< th >< h3 > Author </ h3 ></ th >< th >< h3 > Message </ h3 ></ th >< th >< h3 > Date </ h3 ></ th ></ thead >< tbody > ";
        //    string[] commits = unpushedCommits.Split(new string[] { "\\n" }, StringSplitOptions.None);
        //    for (int i = 0; i < commits.Length; i++)
        //    {
        //        message += commits[i];
        //    }

        //    message += "</tbody></ table >";
        //    return message;
        //}
    }
}
