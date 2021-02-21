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
    /// Логика взаимодействия для ServiceAddPage.xaml
    /// </summary>
    public partial class ServiceAddPage : Page
    {
        private static Service _currentService;
        public ServiceAddPage()
        {
            InitializeComponent();
            _currentService = new Service();
            DataContext = _currentService;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (TextBoxTitle.Text == "")
            {
                errors.AppendLine("Вы не ввели наименование услуги");
            }
            if (TextBoxCost.Text == "")
            {
                errors.AppendLine("Вы не ввели стоимость услуги");
            }
            if (TextBoxDurTime.Text == "")
            {
                errors.AppendLine("Вы не ввели время выполнения услуги");
            }
            if (TextBoxDiscount.Text == "")
            {
                errors.AppendLine("Вы не ввели скидку на услугу");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                AutoserviceBaseEntities.GetContext().Service.Add(_currentService);
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
