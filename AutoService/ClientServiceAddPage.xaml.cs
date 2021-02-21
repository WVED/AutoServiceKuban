using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoService.Data;

namespace AutoService
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceAddPage.xaml
    /// </summary>
    public partial class ClientServiceAddPage : Page
    {
        private static ClientService _currentClientService;
        public ClientServiceAddPage()
        { 
            InitializeComponent();    
            _currentClientService = new ClientService();
            DataContext = _currentClientService;
            ComboService.ItemsSource = AutoserviceBaseEntities.GetContext().Service.ToList();
            ComboClient.ItemsSource = AutoserviceBaseEntities.GetContext().Client.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ComboClient.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали фамилию клиента");
            }
            if (ComboService.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали услугу");
            }
            if (DatePick.SelectedDate == null)
            {
                errors.AppendLine("Вы не выбрали дату");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                _currentClientService.StartTime = (DateTime)DatePick.SelectedDate;
                AutoserviceBaseEntities.GetContext().ClientService.Add(_currentClientService);
                AutoserviceBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация добавлена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }   
    }
}
