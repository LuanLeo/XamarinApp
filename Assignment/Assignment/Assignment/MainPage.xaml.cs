using Assignment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.mySQL.GetAllHike();
            }
            catch 
            {

            }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHike());
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Hike;
            
           await Navigation.PushAsync(new AddHike(emp));
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Hike;
            var result = await DisplayAlert("Delete", $"Delete {emp.Name} from the database", "Yes", "No");
            if(result)
            { 
                await App.mySQL.DeleteHike(emp);
                myCollectionView.ItemsSource = await App.mySQL.GetAllHike();
            }
        }
    }
}
