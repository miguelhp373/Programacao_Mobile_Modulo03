using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


//Packages
using Newtonsoft.Json;
using System.Net.Http;
using ConversorDeMoedas.Models;

namespace ConversorDeMoedas
{
    public partial class MainPage : ContentPage
    {
        private ExchangeRates exchangeRates;
        double valor, taxaOrigem, TaxaDestino, ValorConvertido;
        public MainPage()
        {
            InitializeComponent();
            CarregaMoedasPickers();
            CarregaTaxas();
        }

        private async  void CarregaTaxas()
        {
            waitActivityIndicator.IsRunning = true;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://openexchangerates.org");
                
                var url = "/api/latest.json?app_id=f490efbcd52d48ee98fd62cf33c47b9e";
                var response = await cliente.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Erro", response.StatusCode.ToString(), "OK");
                    waitActivityIndicator.IsRunning = false;
                    btnCalcular.IsEnabled = false;
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();
                exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>(result);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
                waitActivityIndicator.IsRunning = false;
                btnCalcular.IsEnabled = false;
                return;
            }
            waitActivityIndicator.IsRunning = false;
            btnCalcular.IsEnabled = true;
        }

        private void  CarregaPicker(Picker picker)
        {
            picker.Items.Add("Real (R$)");
            picker.Items.Add("BitCoin (BTC)");
            picker.Items.Add("Euro (€)");
            picker.Items.Add("Dólar ($)");
            picker.Items.Add("Yene (¥)");
            picker.Items.Add("Dólar Canadense ($)");
            picker.Items.Add("Dinar macedónio (ден)");
            picker.Items.Add("Rublo russo (руб. / р.)");

        }

        private void CarregaMoedasPickers()
        {
            CarregaPicker(moedaOrigemPick);
            CarregaPicker(MoedaDestinoPick);
        }

        public void LimparCampos(object sender, EventArgs e)
        {
            txtValor.Text = "";
            moedaOrigemPick.SelectedIndex = -1;
            MoedaDestinoPick.SelectedIndex = -1;
            lblMsg1.Text = "";
            lblMsg2.Text = "";
        }

        private double GetTaxa(int index)
        {
            switch (index)
            {
                case 0: return exchangeRates.rates.BRL;
                case 1: return exchangeRates.rates.BTC;
                case 2: return exchangeRates.rates.EUR;
                case 3: return exchangeRates.rates.USD;
                case 4: return exchangeRates.rates.JPY;
                case 5: return exchangeRates.rates.CAD;
                case 6: return exchangeRates.rates.MKD;
                case 7: return exchangeRates.rates.RUB;
                default: return 1;
            }
        }

        private async void Converter(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtValor.Text)){
                await DisplayAlert("Erro", "Informar o Valor a Converter", "OK");
                return;
            }

            if (moedaOrigemPick.SelectedIndex == -1)
            {
                await DisplayAlert("Erro", "Selecione Moeda de Origem", "OK");
                return;
            }

            if (MoedaDestinoPick.SelectedIndex == -1)
            {
                await DisplayAlert("Erro", "Selecione Moeda de Destino", "OK");
                return;
            }

            valor = Convert.ToDouble(txtValor.Text);
            
            taxaOrigem = GetTaxa(moedaOrigemPick.SelectedIndex);
            TaxaDestino = GetTaxa(MoedaDestinoPick.SelectedIndex);

            ValorConvertido = valor / taxaOrigem * TaxaDestino;

            lblMsg1.Text = string.Format("{0:N2} {1}", valor, moedaOrigemPick.Items[moedaOrigemPick.SelectedIndex]);
            lblMsg2.Text = string.Format("{0:N2} {1}", ValorConvertido, MoedaDestinoPick.Items[MoedaDestinoPick.SelectedIndex]);

        }

    }
}
