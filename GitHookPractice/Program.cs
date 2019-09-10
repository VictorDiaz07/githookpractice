using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Net.Mail;

namespace GitHookPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail("KLK");
        }

        static void SendEmail(string message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("victordiazwepsys@gmail.com");
            mail.To.Add("victordiazmateo@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = message;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("victordiazwepsys@gmail.com", "m4m4n3m4");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        static void getCommits()
        {
            using (PowerShell powershell = PowerShell.Create())
            {
                string directory = "C:/Users/victo/Documents/Software Projects/Git Hook Practice/githookpractice";
                // this changes from the user folder that PowerShell starts up with to your git repository
                powershell.AddScript(String.Format(@"cd {0}", directory));

                powershell.AddScript(@"git log origin/master..HEAD");

                Collection<PSObject> results = powershell.Invoke();
            }
        }


    }
}
