using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using prac1.Models;

namespace prac1.Controls
{
    public partial class ProductSearchControl : UserControl
    {
        public event EventHandler<Product>? ProductSelected;

        public ProductSearchControl()
        {
            InitializeComponent();
            LoadProducts();
        }

        public void LoadProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                var products = context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Manufacture)
                    .Include(p => p.Supplier)
                    .ToList();

                ProductsListBox.Items.Clear();
                foreach (var product in products)
                {
                    var card = new ProductControl();
                    card.SetData(product);
                    card.Tag = product; // Сохраняем модель для последующего получения
                    ProductsListBox.Items.Add(card);
                }
            }
        }

        private void ProductsListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is ProductControl selectedControl && selectedControl.Tag is Product product)
            {
                ProductSelected?.Invoke(this, product);
            }
        }

        private void SearchBox_TextChanged(object? sender, TextChangedEventArgs e)
        {
           
        }
    }
}