using System.Linq;
using System;
using System.Net.Mail;
using System.IO;
using System.Text;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Services.Email
{
    public class EmailService 
    {
       public void sendEmail(string email,string Body,string username)
        {
            
            var ServiceEmail = new Connect().executeAd<ServiceEmail>($"Select *from ServiceEmail").FirstOrDefault(); 
            
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(ServiceEmail.Email, ServiceEmail.Password);
            smtp.Host = ServiceEmail.Host;
            smtp.Port = ServiceEmail.Port;

            /*  
                var html = System.IO.File.ReadAllText(@"Services/Email/template/Libongo.html");
                var html = System.IO.File.ReadAllText(@"C:\Users\Administrator\Documents\Template\Libongo.html");
                html = html.Replace("[*nam-user]",email);
                html = html.Replace("[*pas-user]",Body);
                html = html.Replace("[*Cliente-title] [*Name]",username);
            */
            
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ServiceEmail.Email);
            mail.To.Add(email);
            mail.Subject = "your access credentials to LinbongoGetWay";
            mail.Body=$"your Password: {Body} \n\n\n your email :{email}";
           // mail.Body = html;
            
            mail.IsBodyHtml = true;
            smtp.Send(mail);
        }

        public void sendEmailalert(string email,string Body,string username)
        {
            
            var ServiceEmail = new Connect().executeAd<ServiceEmail>($"Select *from ServiceEmail").FirstOrDefault(); 
            
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(ServiceEmail.Email, ServiceEmail.Password);
            smtp.Host = ServiceEmail.Host;
            smtp.Port = ServiceEmail.Port;

           
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ServiceEmail.Email);
            mail.To.Add(email);
            mail.Subject = $"Alert LinbongoGetWay";
            mail.Body=$"Ola sr/a {username}: \n\n\n {Body}";
           // mail.Body = html;
            
            mail.IsBodyHtml = true;
            smtp.Send(mail);
        }
    }
}