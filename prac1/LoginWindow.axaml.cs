using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using prac1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace prac1
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        
            Error.IsVisible = false;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из полей
            var email = Email.Text;
            var password = Password.Text; 

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                Error.Text = "Заполните все поля";
                Error.IsVisible = true;
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                // Ищем пользователя по email
                var user = context.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    Error.Text = "Неверный логин или пароль";
                    Error.IsVisible = true;
                    return;
                }

                
                if (user.Password != password)
                {
                    Error.Text = "Неверный логин или пароль";
                    Error.IsVisible = true;
                    return;
                }

                // Успешный вход
                Error.IsVisible = false; 
                App.CurrentUser = user;

                

                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            var guestWindow = new GuestWindow();
            guestWindow.Show();
            this.Close();
        }

    }
}