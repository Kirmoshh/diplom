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


namespace SalonMebeli.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        int _itemcount = 0; // 
        Product _selectedProduct = null;
        public CatalogPage()
        {
            InitializeComponent();
        }
        void LoadAndInitData()
        {
            // загрузка данных в listview сортируем по названию
            ListBoxProducts.ItemsSource = SalonMebeliEntities.GetContext().Products.OrderBy(p => p.Namee).ToList();
            _itemcount = ListBoxProducts.Items.Count;
            // скрываем кнопки корзины
            
            TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SalonMebeliEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListBoxProducts.ItemsSource = SalonMebeliEntities.GetContext().Products.OrderBy(p => p.Namee).ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            // получаем текущие данные из бд
            var currentGoods = SalonMebeliEntities.GetContext().Products.OrderBy(p => p.Namee).ToList();
            // выбор только тех товаров, по определенному диапазону скидки
            if (ComboDiscont.SelectedIndex == 1)
                currentGoods = currentGoods.Where(p => p.ProductDiscountAmount < 10).ToList();
            if (ComboDiscont.SelectedIndex == 2)
                currentGoods = currentGoods.Where(p => (p.ProductDiscountAmount >= 10 && p.ProductDiscountAmount < 15)).ToList();
            if (ComboDiscont.SelectedIndex == 3)
                currentGoods = currentGoods.Where(p => p.ProductDiscountAmount >= 15).ToList();
            // выбор тех товаров, в названии которых есть поисковая строка
            currentGoods = currentGoods.Where(p => p.Namee.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.Price).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.Price).ToList();
            }
            // В качестве источника данных присваиваем список данных
            ListBoxProducts.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
        }

        private void ComboDiscont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedProduct = null;
            var selected = ListBoxProducts.SelectedItems.Cast<Product>().ToList();
            if (selected.Count == 0) return;
            _selectedProduct = selected[0];
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            
        }
    }
}
