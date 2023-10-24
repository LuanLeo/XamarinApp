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
        Model.Hike _hike;
        public AddHike(Model.Hike hike)
        {
            InitializeComponent();

            Title = "Edit Hike";
            _hike = hike;

            nameEntry.Text = hike.Name;
            locationEntry.Text = hike.Location;
            dateEntry.Text = hike.Date;
            parkingEntry.Text = hike.Parking;
            lengthEntry.Text = hike.Length;
            levelEntry.Text = hike.Level;
            quantityEntry.Text = hike.FQuantity;
            durationEntry.Text = hike.Duration;
            descriptionEntry.Text = hike.Description;

            nameEntry.Focus();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text) || string.IsNullOrEmpty(locationEntry.Text))
            {
                await DisplayAlert("Invalid", "Blank or whitespace value is Invalid", "OK");
            }
            else if (_hike != null)
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
            _hike.Name = nameEntry.Text;
            _hike.Location = locationEntry.Text;
            _hike.Date = dateEntry.Text;
            _hike.Parking = parkingEntry.Text;
            _hike.Length = lengthEntry.Text;
            _hike.Level = levelEntry.Text;
            _hike.FQuantity = quantityEntry.Text;
            _hike.Duration = durationEntry.Text;
            _hike.Description = descriptionEntry.Text;

            await App.mySQL.UpdateHike(_hike);
            await Navigation.PopAsync();
        }
    }
}