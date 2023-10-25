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

        async void SwipeItem_Invoked(object send, EventArgs e)
        {
            var i = send as SwipeItem;
            var em = i.CommandParameter as Hike;
            
           await Navigation.PushAsync(new AddHike(em));
        }

        async void SwipeItem_Invoked_1(object send, EventArgs e)
        {
            var i = send as SwipeItem;
            var em = i.CommandParameter as Hike;
            var result = await DisplayAlert("Delete", $"Delete {em.Name} from the database", "Yes", "No");
            if(result)
            { 
                await App.mySQL.DeleteHike(em);
                myCollectionView.ItemsSource = await App.mySQL.GetAllHike();
            }
        }
    }
}
