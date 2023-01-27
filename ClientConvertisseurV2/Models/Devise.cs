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

        public Devise(int id, string nomdevise, double taux)
        {
            this.Id = id;
            this.Nomdevise = nomdevise;
            this.Taux = taux;
        }

        public int Id { get => id; set => id = value; }
        public string Nomdevise { get => nomdevise; set => nomdevise = value; }
        public double Taux { get => taux; set => taux = value; }

        public override bool Equals(object obj)
        {
            return obj is Devise devise &&
                   this.Id == devise.Id &&
                   this.Nomdevise == devise.Nomdevise &&
                   this.Taux == devise.Taux;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Nomdevise, this.Taux);
        }
    }
}
