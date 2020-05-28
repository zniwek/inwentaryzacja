﻿using Inwentaryzacja.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inwentaryzacja.views.view_allReports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportDetailsView : ContentPage
    {
        public ReportDetailsView(string headerText, string roomText, string createDate, string createTime, string ownerText, string listedItems)
        {
            InitializeComponent();
            RoomText.Text = "Nazwa sali: " + roomText;
            CreateDate.Text = "Data utworzenia: " + createDate;
            CreateTime.Text = "Godzina utworzenia: " + createTime;
            OwnerText.Text = "Wykonał: " + ownerText;
            HeaderText.Text = headerText;
            ListedItems.Text = listedItems;
        }

        private void return_ChooseRoom(object o, EventArgs e)
        {
            App.Current.MainPage = new AllReportsPage();
        }
    }
}