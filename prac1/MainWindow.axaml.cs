using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using prac1.Controls;
using prac1.Models;

namespace prac1
{
    public partial class MainWindow : Window
    {
        private Product? _selectedProduct;

        public MainWindow()
        {
            InitializeComponent();
            ProductSearchControl.ProductSelected += OnProductSelected;
            
        }

        private void OnProductSelected(object? sender, Product product)
        {
            _selectedProduct = product;
            SelectedProductName.Text = $"{product.Category?.CategoryName} {product.ProductName}";
            CurrentDiscount.Text = product.Discount?.ToString() ?? "0%";
        }
            

        private async void ApplyDiscountButton_Click(object sender, RoutedEventArgs e)
        {
           

            

            // Обновляем список товаров
            ProductSearchControl.LoadProducts();

            // Очищаем выбор
            _selectedProduct = null;
            SelectedProductName.Text = "Товар не выбран";
            CurrentDiscount.Text = "0%";
            
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            // Уже на странице товаров – можно ничего не делать,
            // либо сбросить выделение и перезагрузить список
            ProductSearchControl.LoadProducts();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            // Заглушка для заказов
            var ordersWindow = new Window
            {
                Title = "Заказы",
                Content = new TextBlock { Text = "", Margin = new Thickness(20) },
                Width = 600,
                Height = 400
            };
            ordersWindow.ShowDialog(this);
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Заглушка для добавления товара
            var addProductWindow = new Window
            {
                Title = "Добавить товар",
                Content = new TextBlock { Text = "", Margin = new Thickness(20) },
                Width = 500,
                Height = 400
            };
            addProductWindow.ShowDialog(this);
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Заглушка для добавления заказа
            var addOrderWindow = new Window
            {
                Title = "Добавить заказ",
                Content = new TextBlock { Text = "", Margin = new Thickness(20) },
                Width = 500,
                Height = 400
            };
            addOrderWindow.ShowDialog(this);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = null;
            new LoginWindow().Show();
            this.Close();
        }
    }
}