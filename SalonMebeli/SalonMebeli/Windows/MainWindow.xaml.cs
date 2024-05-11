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
using SalonMebeli.Models;
using SalonMebeli.Pages;


namespace SalonMebeli
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CatalogPage());
            Manager.MainFrame = MainFrame;

        }
        

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                // показываем кнопку назад
                BtnBack.Visibility = Visibility.Visible;
                // скрываем кнопку товары 
                BtnEditGoods.Visibility = Visibility.Collapsed;
            }
            else
            {
                // скрываем кнопку назад
                BtnBack.Visibility = Visibility.Collapsed;
                // показываем кнопку товары 
                BtnEditGoods.Visibility = Visibility.Visible;


            }
        }

        private void BtnEditGoods_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти?",
               "Выйти", MessageBoxButton.OKCancel,
               MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
