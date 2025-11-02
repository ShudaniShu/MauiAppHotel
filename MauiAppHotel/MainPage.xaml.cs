using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // -----------------------------
        // BOTÃO PADRÃO (MANTIDO)
        // -----------------------------
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }


        // -----------------------------
        // NAVEGAÇÃO → SOBRE
        // -----------------------------
        private async void OnSobreClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SobrePage));
        }


        // -----------------------------
        // HÓSPEDES: ADULTOS + CRIANÇAS
        // -----------------------------
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
                {
                    AdultsStepper.Value = Math.Max(1, maxTotal - children);
                }
                else
                {
                    ChildrenStepper.Value = Math.Max(0, maxTotal - adults);
                }

                adults = (int)AdultsStepper.Value;
                children = (int)ChildrenStepper.Value;
                total = adults + children;
            }

            GuestsSummaryLabel.Text =
                $"Total de hóspedes: {total} (Adultos: {adults}, Crianças: {children})";
        }


        // -----------------------------
        // TIPO DE QUARTO
        // -----------------------------
        private void OnRoomTypeChanged(object sender, EventArgs e)
        {
            if (RoomTypePicker.SelectedIndex >= 0)
            {
                string selected = RoomTypePicker.SelectedItem.ToString();
                RoomTypeLabel.Text = $"Tipo de quarto: {selected}";
            }
            else
            {
                RoomTypeLabel.Text = "Nenhum tipo selecionado";
            }
        }
    }
}
