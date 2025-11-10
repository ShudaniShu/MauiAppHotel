using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppHotel
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        // MAPEAMENTO: quarto -> arquivo da imagem (PNG)
        private readonly Dictionary<string, string> _roomImages = new()
        {
            { "Recanto dos Pássaros", "recanto_passaros.png" },
            { "Recanto das Araras",   "recanto_araras.png" },
            { "Recanto dos Sabiás",   "recanto_sabias.png" },
            { "Floresta Encantada",   "floresta_encantada.png" }
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            CounterBtn.Text = count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";
            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnSobreClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SobrePage));
        }

        private void OnGuestStepperChanged(object sender, ValueChangedEventArgs e)
        {
            const int maxTotal = 6;

            int adults = (int)AdultsStepper.Value;
            int children = (int)ChildrenStepper.Value;
            int total = adults + children;

            if (total > maxTotal)
            {
                Stepper changed = (Stepper)sender;

                if (changed == AdultsStepper)
                    AdultsStepper.Value = Math.Max(1, maxTotal - children);
                else
                    ChildrenStepper.Value = Math.Max(0, maxTotal - adults);

                adults = (int)AdultsStepper.Value;
                children = (int)ChildrenStepper.Value;
                total = adults + children;
            }

            GuestsSummaryLabel.Text =
                $"Total de hóspedes: {total} (Adultos: {adults}, Crianças: {children})";
        }

        // Seleção do quarto -> atualiza texto + imagem
        private void OnRoomTypeChanged(object sender, EventArgs e)
        {
            if (RoomTypePicker.SelectedIndex >= 0)
            {
                string selected = RoomTypePicker.SelectedItem.ToString();
                RoomTypeLabel.Text = $"Tipo de quarto: {selected}";

                if (_roomImages.TryGetValue(selected, out var img))
                {
                    RoomImage.Source = img;
                    RoomImage.IsVisible = true;
                }
                else
                {
                    RoomImage.IsVisible = false;
                }
            }
            else
            {
                RoomTypeLabel.Text = "Nenhum tipo selecionado";
                RoomImage.IsVisible = false;
            }
        }
    }
}
