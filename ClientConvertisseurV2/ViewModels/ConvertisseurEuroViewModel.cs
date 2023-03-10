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
    public class ConvertisseurEuroViewModel : ConvertisseurViewModel
    {

        public ConvertisseurEuroViewModel() : base()
        { }

        public override void ActionSetConversion()
        {
            if (SelectedDevise == null || Input == 0)
            {
                DisplayshowAsync("Erreur", "Veuillez saisir un montant et sélectionner une devise.");
            }
            else
                Resultat = Math.Round(Input * SelectedDevise.Taux, 2);
        }

    }
}
