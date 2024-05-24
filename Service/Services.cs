using HRMS.Models;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace HRMS.Service
{
    public class Services : IServices
    {
        public bool SendInterviewEmail(string email, Interview obj)
        {
            var fromEmail = new MailAddress("yadneshchaudhari2323@gmail.com", "Sumago");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "otywohuxwaqzpikr"; // This should be replaced with your actual email password
            string subject = "Interview Invitation";

            string body = $"<br/>Dear {obj.CandidateName},<br/><br/>" +
                          $"Congratulations! You have been selected for an interview with SUMAGO.<br/><br/>" +
                          $"<b>Interview Details:</b><br/>" +
                          $"<b>Round:</b> {obj.Type}<br/>" +
                          $"<b>Date:</b> {obj.Date:dddd, MMMM dd, yyyy}<br/>" +
                          $"<b>Time:</b> {obj.Date: h:mm tt}<br/>" +
                          $"<b>Interview Venue:</b> {obj.place}<br/><br/>" +
                          $"We are looking forward to meeting you. Please make sure to bring all the necessary documents and be prepared to discuss your qualifications and experiences.<br/><br/>" +
                          $"Should you have any questions or need further assistance, feel free to contact us.<br/><br/>" +
                          $"Best regards,<br/>SUMAGO";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587, // Gmail SMTP port
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception (optional)
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
