﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing;
using System.Threading;

namespace Inwentaryzacja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanItemPage : ContentPage
    {
        private ZXing.Result prev=null;

        public ScanItemPage()
        {
            InitializeComponent();

            var zXingOptions = new MobileBarcodeScanningOptions()
            {
                DelayBetweenContinuousScans = 1800, // msec
                UseFrontCameraIfAvailable = false,
                PossibleFormats = new List<BarcodeFormat>(new[]
                {
                     BarcodeFormat.EAN_8,
                     BarcodeFormat.EAN_13,
                     BarcodeFormat.CODE_128,
                     BarcodeFormat.QR_CODE
                }),
                TryHarder = false //Gets or sets a flag which cause a deeper look into the bitmap.
            };
            _scanner.Options = zXingOptions;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _scanner.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            _scanner.IsScanning = false;
            base.OnDisappearing();
        }

        async private void Cancel(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Anulować skanowanie?", "Czy na pewno chcesz anulować skanowanie?", "Tak", "Nie");

            if(response)
            {
                await Navigation.PopAsync();
            }
        }

        private async void EndScanning(object sender, EventArgs e)
        {
            await ShowPopup();
        }

        private async Task ShowPopup(string message = "Zeskanowano!")
        {
            await Task.Run(() => 
            { 
                Device.BeginInvokeOnMainThread(() => 
                { 
                    _contentPopup.IsVisible = true; 
                }); 
            });

            await Task.Run(() => 
            { 
                Device.BeginInvokeOnMainThread(() => 
                { 
                    _contentPopup.Text = message; 
                }); 
            });

            await Task.Run(() => 
            { 
                Device.BeginInvokeOnMainThread(() => 
                { 
                    _backColorPopup.WidthRequest = _contentPopup.Width; 
                }); 
            });
            
            await _popup.FadeTo(1, 150);
            await Task.Delay(600);
            await _popup.FadeTo(0, 400);


            await Task.Run(() => 
            { 
                Device.BeginInvokeOnMainThread(() => 
                { 
                    _contentPopup.IsVisible = false; 
                }); 
            });

        }


        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            if(prev == null || result.Text!=prev.Text)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    prev = result;
                    await ShowPopup();
                    //await DisplayAlert("Wynik skanowania", result.Text, "OK");
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await ShowPopup("Już zeskanowano ten przedmiot!");
                });
            }
        }
    }
}