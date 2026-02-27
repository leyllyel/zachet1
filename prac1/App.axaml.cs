using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using prac1.Models;  

namespace prac1
{
    public partial class App : Application
    {
        // Хранит текущего пользователя после входа
        public static User? CurrentUser { get; set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new LoginWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}