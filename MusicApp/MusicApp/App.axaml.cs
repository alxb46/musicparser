using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MusicApp.Models;
using MusicApp.ViewModels;
using MusicApp.Views;

namespace MusicApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var parcer = new MusicParcer();


                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(parcer),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
