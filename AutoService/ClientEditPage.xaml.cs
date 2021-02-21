using AutoService.Data;
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

namespace AutoService
{
    /// <summary>
    /// Логика взаимодействия для ClientEditPage.xaml
    /// </summary>
    public partial class ClientEditPage : Page
    {
        private static Client _currentClientEdit = new Client();
        public ClientEditPage(Client selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
            _currentClientEdit = selectedClient;
            DataContext = _currentClientEdit;  
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (TxtBoxLastName.Text == "")
            {
                errors.AppendLine("Вы не ввели имя");
            }
            if (TxtBoxFirstName.Text == "")
            {
                errors.AppendLine("Вы не ввели фамилию");
            }
            if (TxtBoxPatronymic.Text == "")
            {
                errors.AppendLine("Вы не ввели отчество");
            }
            if (DatePick.SelectedDate == null)
            {
                errors.AppendLine("Вы не выбрали дату рождения");
            }
            if (TxtBoxPhone.Text == "")
            {
                errors.AppendLine("Вы не ввели E-mail");
            }
            if (TxtBoxEmail.Text == "")
            {
                errors.AppendLine("Вы не ввели телефон");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                _currentClientEdit.Birthday = (DateTime)DatePick.SelectedDate;
                AutoserviceBaseEntities.GetContext().Client.Add(_currentClientEdit);
                AutoserviceBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация обновлена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
