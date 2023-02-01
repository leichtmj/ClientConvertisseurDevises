using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public abstract class ConvertisseurViewModel : ObservableObject
    {
        private ObservableCollection<Devise> lesDevises;
        private double input;
        private double resultat;
        private Devise selectedDevise;

        public static WSService service = new WSService("https://localhost:7038/api/");

        public ConvertisseurViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public IRelayCommand BtnSetConversion { get; }


        public virtual void ActionSetConversion()
        {
            
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public Devise SelectedDevise
        {
            get
            {
                return selectedDevise;
            }

            set
            {
                selectedDevise = value;
                OnPropertyChanged();
            }
        }

        public async void GetDataOnLoadAsync()
        {
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
            {
                DisplayshowAsync("Erreur", "API non disponible");
            }
            else
                LesDevises = new ObservableCollection<Devise>(result);
        }

        public async void DisplayshowAsync(string title, string desc)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = title,
                Content = desc,
                PrimaryButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await contentDialog.ShowAsync();
        }

    }
}
