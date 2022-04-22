using System.Diagnostics;

namespace QuartzExamples.Services
{
    public interface IEmailService
    {
        void Send(string receiver, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void Send(string receiver, string subject, string body)
        {
            Debug.WriteLine($"Sending email to {receiver} with subject {subject} and body {body}");
        }
    }
}
