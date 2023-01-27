using ClientConvertisseurV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Services
{
    public class WSService : IService
    {
        static HttpClient client = new HttpClient();

        public WSService(string url)
        {
            //pour accéder à l'API REST
            client.BaseAddress = new Uri(url); //L’adresse à indiquer devra être celle de votre API, construite de la façon suivante: https://localhost:PORT/api/
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public double CalculEurosVersDevise(double saisie, Devise d)
        {
            return Math.Round(saisie*d.Taux,2);
        }
    }
}
