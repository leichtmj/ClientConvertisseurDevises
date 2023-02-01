using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel : ConvertisseurViewModel
    {
        public ConvertisseurDeviseViewModel() : base()
        { }

        public override void ActionSetConversion()
        {
            if (SelectedDevise == null || Input == 0)
            {
                DisplayshowAsync("Erreur", "Veuillez saisir un montant et sélectionner une devise.");
            }
            else
                Resultat = Math.Round(Input / SelectedDevise.Taux, 2);
        }
    }
}
