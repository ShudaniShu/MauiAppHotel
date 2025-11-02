using Microsoft.Maui.Controls;
using MauiAppHotel;   // garante acesso ao namespace do projeto

namespace MauiAppHotel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // registra rota para a tela Sobre
            Routing.RegisterRoute(nameof(SobrePage), typeof(SobrePage));
        }
    }
}
