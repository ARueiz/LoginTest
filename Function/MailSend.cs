using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace LoginTest.Function
{
    public class MailSend
    {
        public MailSend()
        {

        }

        public static bool sendGmail(string emailTo, string content)
        {
            //create  a new mime message object which we are going to use to fill the message data.
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Tester", "choupin546@gmail.com"));

            message.To.Add(MailboxAddress.Parse(emailTo));

            message.Subject = "Email測試!";

            string link = "https://www.mozilla.com/";

            message.Body = new TextPart("html")
            {
                Text = $"<h1>歡迎註冊!請點擊下列連結</h1>" +
                       $"<a href=\"{link}\">External Link</a>" +
                       $"<p>{content}</p>"
            };

            SmtpClient client = new SmtpClient();

            try 
	        {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("choupin546@gmail.com", "cindy55433");
                client.Send(message);

                return true;
	        }
	        catch (Exception ex)
	        {
                return false;
	        }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}