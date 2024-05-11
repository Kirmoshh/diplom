using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SalonMebeli.Models;

namespace SalonMebeli.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProductPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {

                //загрузка обновленных данных
                SalonMebeliEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Product> goods = SalonMebeliEntities.GetContext().Products.OrderBy(p => p.Namee).ToList();
                DataGridGood.ItemsSource = null;
                DataGridGood.ItemsSource = goods;
                
            }
        }
        private void DataGridGood_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        

        
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedGoods = DataGridGood.SelectedItems.Cast<Product>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Product x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Orders.Count > 0)
                        throw new Exception("Есть записи в продажах");

                    SalonMebeliEntities.GetContext().Products.Remove(x);
                    //сохраняем изменения
                    SalonMebeliEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Product> goods = SalonMebeliEntities.GetContext().Products.OrderBy(p => p.Namee).ToList();
                    DataGridGood.ItemsSource = null;
                    DataGridGood.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProductPage((sender as Button).DataContext as Product));
        }
    }
}
