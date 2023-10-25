using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHike : ContentPage
    {
        public AddHike()
        {
            InitializeComponent();
        }

        Model.Hike _h;

        public AddHike(Model.Hike h)
        {
            InitializeComponent();

            Title = "Edit Hike";
            _h = h;

            nameEntry.Text = h.Name;
            locationEntry.Text = h.Location;
            dateEntry.Text = h.Date;
            parkingEntry.Text = h.Parking;
            lengthEntry.Text = h.Length;
            levelEntry.Text = h.Level;
            quantityEntry.Text = h.FQuantity;
            durationEntry.Text = h.Duration;
            descriptionEntry.Text = h.Description;

            nameEntry.Focus();
        }

        async void Button_Clicked(object send, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text) || string.IsNullOrEmpty(locationEntry.Text)
                || string.IsNullOrEmpty(dateEntry.Text) || string.IsNullOrEmpty(parkingEntry.Text)
                || string.IsNullOrEmpty(lengthEntry.Text) || string.IsNullOrEmpty(levelEntry.Text)
                || string.IsNullOrEmpty(quantityEntry.Text) || string.IsNullOrEmpty(durationEntry.Text))
            {
                await DisplayAlert("Invalid", "Lack of information", "OK");
            }
            else if (_h != null)
            {
                EditHike();
            }
            else
            {
                AddNewHike();
            }
        }


        async void AddNewHike()
        {
            await App.mySQL.CreateHike(new Model.Hike
            {
                Name = nameEntry.Text,
                Location = locationEntry.Text,
                Date = dateEntry.Text,
                Parking = parkingEntry.Text,
                Length = lengthEntry.Text,
                Level = levelEntry.Text,
                FQuantity = quantityEntry.Text,
                Duration = durationEntry.Text,
                Description = descriptionEntry.Text,
            });
            await Navigation.PopAsync();
        }

        async void EditHike()
        {
            _h.Name = nameEntry.Text;
            _h.Location = locationEntry.Text;
            _h.Date = dateEntry.Text;
            _h.Parking = parkingEntry.Text;
            _h.Length = lengthEntry.Text;
            _h.Level = levelEntry.Text;
            _h.FQuantity = quantityEntry.Text;
            _h.Duration = durationEntry.Text;
            _h.Description = descriptionEntry.Text;

            await App.mySQL.UpdateHike(_h);
            await Navigation.PopAsync();
        }
    }
}