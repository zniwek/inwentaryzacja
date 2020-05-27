﻿using Inwentaryzacja.Controllers.Api;
using Inwentaryzacja.views.view_chooseRoom;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inwentaryzacja
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseRoomPage : ContentPage
	{
		RoomEntity[] rooms;
		BuildingEntity[] buildings;

		APIController api = new APIController();

		public ChooseRoomPage()
		{
			InitializeComponent();
			api.ErrorEventHandler += onApiError;
			GetBuildings();
		}

		private void BuildingPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			string choosenBuildingName = BuildingPicker.Items[BuildingPicker.SelectedIndex];
			GetBuildingRooms(choosenBuildingName);
		}

		public void AddBuildingClicked(object o, EventArgs e)
		{
			App.Current.MainPage = new AddBuildingView();
		}

		private void GetBuildingRooms(string name)
		{
			BuildingEntity buildingItem = null;

			foreach (BuildingEntity item in buildings)
			{
				if (name == item.name)
				{
					buildingItem = item;
					break;
				}
			}

			if (buildingItem != null) GetRooms(buildingItem.id);
		}

		private async void GetRooms(int buildingId)
		{
			int pickerCount = RoomPicker.Items.Count;

			rooms = await api.getRooms(buildingId);

			if (rooms == null) return;

			if (pickerCount > 0) RoomPicker.Items.Clear();

			foreach (RoomEntity item in rooms)
			{
				RoomPicker.Items.Add(item.name);
			}

			if (pickerCount > 0) RoomPicker.IsEnabled = true;
			else RoomPicker.IsEnabled = false;
		}
		
		public void AddRoom_clicked(object o, EventArgs args)
		{
			App.Current.MainPage = new NavigationPage(new AddRoom());
		}

		private async void GetBuildings()
		{
			buildings = await api.getBuildings();

			if (buildings == null) return;

			foreach (BuildingEntity item in buildings)
			{
				BuildingPicker.Items.Add(item.name);
			}

			if (BuildingPicker.Items.Count > 0)
			{
				BuildingPicker.SelectedItem = BuildingPicker.Items[BuildingPicker.Items.Count - 1];
			}
		}

		private async void Contionue_Clicked(object o, EventArgs args) {
			if(RoomPicker.SelectedIndex < 0)
			{
				await DisplayAlert("Pomieszczenie", "Wybierz pomieszczenie", "OK");
				return;
			}

			RoomEntity selectedRoom = null;
			string selectedName = RoomPicker.Items[RoomPicker.SelectedIndex];

			foreach (var room in rooms)
      {
				if(room.name == selectedName)
        {
					selectedRoom = room;
					break;
				}
      }

			if(selectedRoom != null)
			{
				App.Current.MainPage = new NavigationPage(new ScanItemPage(selectedRoom));
			}
			else
			{
				await DisplayAlert("Błąd", "Błąd niespodzianka, nie znaleziono wybranego pomieszczenia", "OK");
			}
		}

		private async void onApiError(object o, ErrorEventArgs error)
		{
			await DisplayAlert("Błąd", error.MessageForUser, "Wyjdz");
		}

		private void Return_button_clicked(object o, EventArgs e)
		{
			App.Current.MainPage = new WelcomeViewPage();
		}
	}
}