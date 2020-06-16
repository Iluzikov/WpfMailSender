using Microsoft.Extensions.DependencyInjection;

namespace WpfMailSender.ViewModels
{
    internal class ViewModelLocator
    {
        public WpfMailSenderViewModel WpfMailSenderModel => App.Host.Services.GetRequiredService<WpfMailSenderViewModel>();
        public EmailInfoViewModel EmailInfoModel => App.Host.Services.GetRequiredService<EmailInfoViewModel>();
    }
}
