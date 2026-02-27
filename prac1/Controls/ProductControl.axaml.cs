using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using prac1.Models;

namespace prac1.Controls
{
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
        }

        public void SetData(Product product)
        {
           
            NameText.Text = product.Category != null
                ? $"{product.Category.CategoryName} {product.ProductName}"
                : product.ProductName;

            DescriptionText.Text = product.Description ?? "";

            CategoryText.Text = product.Category != null
                ? $"Категория: {product.Category.CategoryName}"
                : "Категория: не указана";

            ManufacturerText.Text = product.Manufacture != null
                ? $"Производитель: {product.Manufacture.ManufactureName}"  
                : "Производитель: не указан";

            SupplierText.Text = product.Supplier != null
                ? $"Поставщик: {product.Supplier.SuplierName}"
                : "Поставщик: не указан";

            // Цена и скидка
            decimal price = product.Price;
            if (product.Discount > 0)
            {
                decimal discountedPrice = price * (1 - (decimal)product.Discount / 100);
                OldPriceText.Text = $"{price:C}";
                PriceText.Text = $"{discountedPrice:C}";
                DiscountBorder.IsVisible = true;
                DiscountText.Text = $"Скидка {product.Discount}%";
            }
            else
            {
                OldPriceText.Text = string.Empty;
                PriceText.Text = $"{price:C}";
                DiscountBorder.IsVisible = false;
            }

            UnitText.Text = $"Ед. изм.: {product.Unit}";
            StockText.Text = $"Остаток: {product.Quantity}";

           
            if (product.Quantity == 0)
                StockText.Foreground = Brushes.Blue;
            else
                StockText.Foreground = Brushes.Black;

            
            

            // Загрузка изображения
            LoadImage(product.PhotoPath);
        }

        private void LoadImage(string? photoPath)
        {
            string imagesFolder = Path.Combine(AppContext.BaseDirectory, "Resources", "Images");
            string defaultImage = Path.Combine(imagesFolder, "picture.png");

            if (!string.IsNullOrEmpty(photoPath))
            {
                string fullPath = Path.Combine(imagesFolder, photoPath);
                if (File.Exists(fullPath))
                {
                    ProductImage.Source = new Bitmap(fullPath);
                    return;
                }
            }

            // Если нет фото или файл не найден, ставим заглушку
            if (File.Exists(defaultImage))
                ProductImage.Source = new Bitmap(defaultImage);
            else
                ProductImage.Source = null;
        }
    }
}