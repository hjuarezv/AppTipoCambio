using AppTipoCambio.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppTipoCambio.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private TipoCambio dolar1;

        public TipoCambio dolar
        {
            get => dolar1; 
            set
            {
                dolar1 = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            GetTipoCambio();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void GetTipoCambio()
        {
            string url = "https://api.apis.net.pe/v1/tipo-cambio-sunat";
            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            var json = await respuesta.Content.ReadAsStringAsync();
            //Debug.WriteLine(json);
            dolar = JsonConvert.DeserializeObject<TipoCambio>(json);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
