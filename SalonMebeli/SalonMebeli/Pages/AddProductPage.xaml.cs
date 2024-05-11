using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using SalonMebeli.Models;
using System.IO;
using Microsoft.Win32;

namespace SalonMebeli.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        private Product _currentProduct = new Product();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // флаг меняется, если фото товара поменялось
        private bool _photoChanged = false;
        // текущая папка приложения
        private static string _currentDirectory =
            Directory.GetCurrentDirectory() + @"\Images\";
        public AddProductPage(Product selectedProduct)
        {
            InitializeComponent();
            LoadAndInitData(selectedProduct);
        }
        void LoadAndInitData(Product selectedProduct)
        {     // если передано null, то мы добавляем новый товар
            if (selectedProduct != null)
            {
                _currentProduct = selectedProduct;
                _filePath = _currentDirectory + _currentProduct.Photo;
            }
            // контекст данных текущий товар
            DataContext = _currentProduct;
            _photoName = _currentProduct.Photo;
            //загрузка в выпалдающие списки
            // категории товаров
           
            // производители товаров
            ComboManufacturer.ItemsSource = SalonMebeliEntities.GetContext().ProductManufacturers.ToList();
           
            // поставщики товаров
            ComboSupplier.ItemsSource = SalonMebeliEntities.GetContext().ProductSuppliers.ToList();
            
            // единицы измерения товаров
           
        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            
            if (string.IsNullOrWhiteSpace(_currentProduct.Namee))
                s.AppendLine("Поле название пустое");
            
            if (_currentProduct.ProductManufacturers == null)
                s.AppendLine("Выберите производителя");
            if (_currentProduct.ProductSuppliers == null)
                s.AppendLine("Выберите поставщика");
          
            if (string.IsNullOrWhiteSpace(TextBoxProductCost.Text))
                s.AppendLine("Поле стоимость пустое");
            if (string.IsNullOrWhiteSpace(_currentProduct.Descriptionn))
                s.AppendLine("Поле описание пустое");

            
            if (string.IsNullOrWhiteSpace(TextBoxProductDiscountAmount.Text))
                s.AppendLine("Поле скидка пустое");
            if (string.IsNullOrWhiteSpace(TextBoxProductDiscountAmountMax.Text))
                s.AppendLine("Поле максимальная скидка пустое");

            // если поле стоимость не пустое,
            // проверяем данные на корректность
            if (!string.IsNullOrWhiteSpace(TextBoxProductCost.Text))
            {
                double x = 0;
                if (!double.TryParse(TextBoxProductCost.Text, out x))
                    s.AppendLine("Стоимость только число");
                else if (x < 0)
                {
                    s.AppendLine("Стоимость не может быть отрицательной");
                }
            }
            // если поле количество не пустое,
            // проверяем данные на корректность
            

            // если поле скидка не пустое,
            // проверяем данные на корректность
            if (!string.IsNullOrWhiteSpace(TextBoxProductDiscountAmount.Text))
            {
                int x = 0;
                if (!int.TryParse(TextBoxProductDiscountAmount.Text, out x))
                    s.AppendLine("Скидка только число");
                else if (x < 0)
                {
                    s.AppendLine("Скидка не может быть отрицательной");
                }
            }

            // если поле максимальная скидка не пустое,
            // проверяем данные на корректность
            if (!string.IsNullOrWhiteSpace(TextBoxProductDiscountAmountMax.Text))
            {
                int x = 0;
                if (!int.TryParse(TextBoxProductDiscountAmountMax.Text, out x))
                    s.AppendLine("Максимальная скидка только число");
                else if (x < 0)
                {
                    s.AppendLine("Максимальная скидка не может быть отрицательной");
                }
            }
            // максимальная скидка не может быть меньше, чем текущая скидка
            if (!string.IsNullOrWhiteSpace(TextBoxProductDiscountAmount.Text) && !string.IsNullOrWhiteSpace(TextBoxProductDiscountAmountMax.Text))
            {
                int x, y;
                if (int.TryParse(TextBoxProductDiscountAmountMax.Text, out x) && int.TryParse(TextBoxProductDiscountAmount.Text, out y))
                {
                    if (x < y)
                    {
                        s.AppendLine("Максимальная скидка не может быть меньше действующей скидки");
                    }
                }
            }
            return s;
        }
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                    _photoChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            // проверка полей прошла успешно
            // если товар новый, то его ID == 0
            if (_currentProduct.ProductID == 0)
            {
                // добавление нового товара, 
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    // путь куда нужно скопировать файл
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentProduct.Photo = photo;
                }
                // добавляем товар в БД
                SalonMebeliEntities.GetContext().Products.Add(_currentProduct);
            }
            try
            { // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentProduct.Photo = photo;
                }
                SalonMebeliEntities.GetContext().SaveChanges();  // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                Manager.MainFrame.GoBack();  // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
