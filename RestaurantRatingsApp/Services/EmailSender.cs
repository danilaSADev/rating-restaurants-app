using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace RestaurantRatingsApp.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
    
    // TODO : figure out how to fix the issue
    public void SendEmail(string email, string subject, string htmlMessage)
    {
        SmtpClient client = new SmtpClient
        {
            Port = 587,
            Host = "smtp.gmail.com", //or another email sender provider
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("danilas21up@gmail.com", "password")
        };

        client.SendMailAsync("DanilaSADev Restaurants Rating App Confirmation mail", email, subject, htmlMessage);
    }
    
}