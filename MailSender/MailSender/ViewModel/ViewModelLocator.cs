using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using MailSender.lib.Services.Linq2SQL;
using MailSender.lib.Services.InMemory;


namespace MailSender.ViewModel
{
    /// <summary>������� �������-�������������</summary>
    public class ViewModelLocator
    {
        /// <summary>����������� �������� ������� �������������. ����� �� ������������ ��� ��������� ������ ������������</summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region ������ �� ������������� MVVM Light
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////} 
            #endregion

            if (!SimpleIoc.Default.IsRegistered<MailSenderDBContext>())
                SimpleIoc.Default.Register(() => new MailSenderDBContext());

            var services = SimpleIoc.Default;
            //services.Register<IRecipientsDataService, RecipientsDataServiceLinq2SQL>();
            services.Register<IRecipientsDataService, RecipientsDataServiceInMemory>();
            services.Register<ISendersDataService, SendersDataInMemory>();
            services.Register<IServerDataService, ServersDataInMemory>();
            services.Register<IMailMessageDataService, MailMessagesDataInMemory>();

            services.Register<IMailSenderService, SmtpMailSenderService>();

            services.Register<MainWindowViewModel>();
        }

        /// <summary>������-������������� �������� ����</summary>
        public MainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        /// <summary>������ ����� ����� ������ ����� ������� ��������� ���������. ����� ���� ����������� ��� ������� ������.</summary>
        public static void Cleanup() { }
    }
}