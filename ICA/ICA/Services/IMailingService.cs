namespace ICA.Services
{
    public interface IMailingService
    {
        Task<bool> SendEmailAsync(string mailTo, string subject, string body);

    }
}
