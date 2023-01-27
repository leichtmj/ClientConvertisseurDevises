// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Devise> lesDevises;
        private double input;
        private double resultat;

        public WSService service = new WSService("https://localhost:7038/api/");


        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        public ObservableCollection<Devise> LesDevises
        {
            get
            {
                return lesDevises;
            }

            set
            {
                lesDevises = value;
                OnPropertyChanged(nameof(LesDevises));
            }
        }

        public double Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
                OnPropertyChanged(nameof(Input));
            }
        }

        public double Resultat
        {
            get
            {
                return resultat;
            }

            set
            {
                resultat = value;
                OnPropertyChanged(nameof(Resultat));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private async void GetDataOnLoadAsync()
        {
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                throw new ArgumentException("API non disponible !", "Erreur");
            else
                LesDevises = new ObservableCollection<Devise>(result);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Resultat = Math.Round(Input * ((Devise)combox.SelectedItem).Taux, 2);

        }
    }
}