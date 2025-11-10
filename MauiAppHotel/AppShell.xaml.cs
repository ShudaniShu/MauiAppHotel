using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registra a rota para navegação por código (GoToAsync)
            Routing.RegisterRoute(nameof(SobrePage), typeof(SobrePage));
        }

        // Handler do MenuItem "Sobre" no XAML
        private async void OnSobreClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SobrePage));
        }
    }
}
