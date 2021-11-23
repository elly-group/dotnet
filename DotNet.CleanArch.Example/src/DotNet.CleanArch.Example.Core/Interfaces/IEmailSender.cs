using System.Threading.Tasks;

namespace DotNet.CleanArch.Example.Core.Interfaces;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
