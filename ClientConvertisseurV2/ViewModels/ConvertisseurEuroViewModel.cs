using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ObservableObject
    {
        private ObservableCollection<Devise> lesDevises;
        private double input;
        private double resultat;
        private Devise selectedDevise;

        public static WSService service = new WSService("https://localhost:7038/api/");

        public IRelayCommand BtnSetConversion { get; }
        

        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public void ActionSetConversion()
        {
            if (SelectedDevise == null || Input == 0)
            {
                DisplayshowAsync("Erreur", "Veuillez saisir un montant et sélectionner une devise.");
            }
            else
                Resultat = Math.Round(Input * SelectedDevise.Taux, 2);
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

        private async void DisplayshowAsync(string title, string desc)
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
