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
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        private static User _currentUser;
        public UserEditPage(User selectedUser)
        {
            InitializeComponent();
            _currentUser = new User();
            if (selectedUser != null)
            _currentUser = selectedUser;
            DataContext = _currentUser;                 
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
            if (TxtBoxLogin.Text == "")
            {
                errors.AppendLine("Вы не ввели логин");
            }
            if (TxtBoxPassword.Text == "")
            {
                errors.AppendLine("Вы не ввели пароль");
            }            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            { 
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
