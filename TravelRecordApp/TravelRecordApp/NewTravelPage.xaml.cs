﻿using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync();

            var venues = VenueLogic.GetVenue(position.Latitude, position.Longitude);

            //venueListView.ItemSource = venues;



        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {

                //var selectedVenue = venueListView.SelectedItem as Venue;
                //var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post newPost = new Post()
                {
                    Experience = ExperienceEntry.Text,

                    //CategorId = firstCategory.id
                    //CategoryName = firstCategory.name,
                    //Address = selectedVenue.location.address,
                    //Distance = 



                };

                using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
                {
                    con.CreateTable<Post>();

                    int rows = con.Insert(newPost);



                    if (rows >= 1)
                    {
                        DisplayAlert("Success", "Experience Successfully Inserted", "OK");
                    }
                    else
                    {
                        DisplayAlert("Failure", "Failed to insert Experience", "OK");
                    }

                }
            }
            catch(NullReferenceException ere)
            {

            }
            catch (Exception ex)
            {

            }

        }
    }
}