using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Models
{
    public class Devise
    {
        private int id;
        private string nomdevise;
        private double taux;

        public int Id { get => id; set => id = value; }
        public string Nomdevise { get => nomdevise; set => nomdevise = value; }
        public double Taux { get => taux; set => taux = value; }

    }
}
