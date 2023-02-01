using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public interface IConvertisseurViewModel
    {
        void ActionSetConversion();
        void GetDataOnLoadAsync();
        void DisplayshowAsync(string title, string desc);
    }
}
