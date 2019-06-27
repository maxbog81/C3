using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Linq2SQL;


namespace MailSender.ViewModel
{
    /// <summary>������� �������-�������������</summary>
    public class ViewModelLocator
    {
        /// <summary>����������� �������� ������� �������������. ����� �� ������������ ��� ��������� ������ ������������</summary>
        public ViewModelLocator()
        {
            // ������������ ���������� ���������� �������� ���������� � ��������� �����������
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

            // ��������� - ��������������� �� ��� � ���������� ������ - "�������� �� Linq2SQL"?
            if (!SimpleIoc.Default.IsRegistered<MailSenderDBContext>())      // ���� ���, �� ������������
                SimpleIoc.Default.Register(() => new MailSenderDBContext()); // ������������ �������� � ������� ���������� ������

            // ����� ������������ ��� ������ ������ ������� � ������
            //SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceLinq2SQL>();
            // ������ ������ ����������� ����� ������� ��� ����� ������ � ������������ MailSenderDBContext! � �� ��������������� � ��� ����

            // ����� ������������ ��� ������������ ���� ������-�������������. �� � ���������� ����� ���� ����, � ����� ���� 1000. ���������� �� ����� ��������.
            SimpleIoc.Default.Register<MainWindowViewModel>(); // MainWindowViewModel � ������������ ������� IRecipientsDataService, � �� � ��� ��������������� � ����������.

            // ���� �� ������� ���������������� ���� �� ������������ � ������-�� ������, �� �� ������� ������ ������� ���������� ��� ������� ������� ��������� ����� ������!

            SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceInMemory>(); //������ � ���� ���� ������ ������� � ������

        }

        /// <summary>������-������������� �������� ����</summary>
        public MainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        /// <summary>������ ����� ����� ������ ����� ������� ��������� ���������. ����� ���� ����������� ��� ������� ������.</summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}