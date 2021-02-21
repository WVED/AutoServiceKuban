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
using System.Windows.Shapes;
using AutoService.Data;

namespace AutoService
{
    /// <summary>
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    
    public partial class Authorize : Window
    {
        public Authorize()
        {
            InitializeComponent();
        }
        
       

        private void BtnCls_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void PasswdBx_Click(object sender, RoutedEventArgs e)
        {
            if (ChkBxPasswd.IsChecked == true)
            {
                TxtBxPasswd.Text = PasswdBx.Password;
                TxtBxPasswd.Visibility = Visibility.Visible;
                PasswdBx.Visibility = Visibility.Hidden;
                TxtBlckPasswd.Text = "Скрыть пароль";
            }
            else
            {
                PasswdBx.Password = TxtBxPasswd.Text;
                TxtBxPasswd.Visibility = Visibility.Hidden;
                PasswdBx.Visibility = Visibility.Visible;
                TxtBlckPasswd.Text = "Показать пароль";
            }
        }
        public int counter = 0;
        private void BtnLgn_Click(object sender, RoutedEventArgs e)
        {
            int userId = 0;
            int count = 0;
            AuthHistory userAuth = new AuthHistory();
            foreach (var User in AutoserviceBaseEntities.GetContext().User)
            {
                count++;
                if (TxtBxLgn.Text == User.Login && PasswdBx.Password == User.Password)
                {
                     count = 0;
                     userAuth.DateTime = DateTime.Now;
                     userAuth.Status = "Successful";
                     userAuth.UserId = User.Id;
                     Manager.firstName = User.FirstName;
                     Manager.lastName = User.LastName;
                     Manager.role = User.Role.Name;
                     MessageBox.Show("Вы успешно авторизованы!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                     MainWindow mainWindow = new MainWindow();
                     mainWindow.Show();
                     this.Close();
                     counter = 0;
                     break;
                }
                if (TxtBxLgn.Text == User.Login)
                {
                    userId = User.Id;
                }
            }
            if (count == 0)
            {
                try
                {
                    AutoserviceBaseEntities.GetContext().AuthHistory.Add(userAuth);
                    AutoserviceBaseEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            if (count != 0)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                counter++;
                if (count == 0)
                {
                    try
                    {
                        userAuth.DateTime = DateTime.Now;
                        userAuth.Status = "Access denied";
                        userAuth.UserId = userId;
                        AutoserviceBaseEntities.GetContext().AuthHistory.Add(userAuth);
                        AutoserviceBaseEntities.GetContext().SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            if (counter %3 == 0 && counter != 0)
            {
                MessageBox.Show("Превышен лимит попыток авторизации!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
