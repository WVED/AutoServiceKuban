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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            TxtBlockFirstName.Text += Manager.firstName;
            TxtBlockLastName.Text += Manager.lastName;
            TxtBlockRole.Text += Manager.role;
            if (Manager.role == "admin")
            {
                RoleImage.Source = new BitmapImage(new Uri($"Resources/АдмМенеджер.png", UriKind.Relative));
            }
            else if (Manager.role == "manager")
            {
                RoleImage.Source = new BitmapImage(new Uri($"Resources/Менеджер.png", UriKind.Relative));
            }
            else if (Manager.role == "booker")
            {
                RoleImage.Source = new BitmapImage(new Uri($"Resources/Бухгалтер.png", UriKind.Relative));
            }
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.role == "manager" || Manager.role == "booker")
            {
                if (TxtBlockFirstName.IsVisible == true && TxtBlockLastName.IsVisible == true && TxtBlockRole.IsVisible == true && RoleImage.IsVisible == true)
                { 
                    TxtBlockFirstName.Visibility = Visibility.Hidden;
                    TxtBlockLastName.Visibility = Visibility.Hidden;
                    TxtBlockRole.Visibility = Visibility.Hidden;
                    RoleImage.Visibility = Visibility.Hidden;
                    Manager.MainFrame.Navigate(new ServicePage());
                }
                else
                {
                    Manager.MainFrame.Navigate(new ServicePage());
                }
            } 
            else
            {
                MessageBox.Show("Недостаточно прав!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Authorize authorize = new Authorize();
            authorize.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClientService_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.role == "manager" || Manager.role == "booker")
            {
                if (TxtBlockFirstName.IsVisible == true && TxtBlockLastName.IsVisible == true && TxtBlockRole.IsVisible == true && RoleImage.IsVisible == true)
                {
                    TxtBlockFirstName.Visibility = Visibility.Hidden;
                    TxtBlockLastName.Visibility = Visibility.Hidden;
                    TxtBlockRole.Visibility = Visibility.Hidden;
                    RoleImage.Visibility = Visibility.Hidden;
                    Manager.MainFrame.Navigate(new ClientServicePage());
                }
                else
                {
                    Manager.MainFrame.Navigate(new ClientServicePage());
                }
            }
           else
            {
                MessageBox.Show("Недостаточно прав!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.role == "manager")
            {
                if (TxtBlockFirstName.IsVisible == true && TxtBlockLastName.IsVisible == true && TxtBlockRole.IsVisible == true && RoleImage.IsVisible == true)
                {

                    TxtBlockFirstName.Visibility = Visibility.Hidden;
                    TxtBlockLastName.Visibility = Visibility.Hidden;
                    TxtBlockRole.Visibility = Visibility.Hidden;
                    RoleImage.Visibility = Visibility.Hidden;
                    Manager.MainFrame.Navigate(new ClientPage());
                }
                else
                {
                    Manager.MainFrame.Navigate(new ClientPage());
                }
            }
            else
            {
                MessageBox.Show("Недостаточно прав!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.role == "admin")
            {
                if (TxtBlockFirstName.IsVisible == true && TxtBlockLastName.IsVisible == true && TxtBlockRole.IsVisible == true && RoleImage.IsVisible == true)
                {

                    TxtBlockFirstName.Visibility = Visibility.Hidden;
                    TxtBlockLastName.Visibility = Visibility.Hidden;
                    TxtBlockRole.Visibility = Visibility.Hidden;
                    RoleImage.Visibility = Visibility.Hidden;
                    Manager.MainFrame.Navigate(new UsersPage());
                }
                else
                {
                    Manager.MainFrame.Navigate(new UsersPage());
                }
            }
            else 
            {
                MessageBox.Show("Недостаточно прав!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.role == "admin")
            {
                if (TxtBlockFirstName.IsVisible == true && TxtBlockLastName.IsVisible == true && TxtBlockRole.IsVisible == true && RoleImage.IsVisible == true)
                {

                    TxtBlockFirstName.Visibility = Visibility.Hidden;
                    TxtBlockLastName.Visibility = Visibility.Hidden;
                    TxtBlockRole.Visibility = Visibility.Hidden;
                    RoleImage.Visibility = Visibility.Hidden;
                    Manager.MainFrame.Navigate(new HistoryPage());
                }
                else
                {
                    Manager.MainFrame.Navigate(new HistoryPage());
                }
            }
            else
            {
                MessageBox.Show("Недостаточно прав!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
