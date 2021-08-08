using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Conversor_Temp
{
    public partial class MainPage : ContentPage
    {
        double temperature;

        public void Converter(object sender, EventArgs e)
        {
            if (FieldTemperature.Text is null)
            {
                DisplayAlert("Não Foi Possivel Converter", "Campo Vazio!", "OK");
                FieldTemperature.Text = null;
            }
           
            if(FieldTemperature.Text != null)
            {
                temperature = Convert.ToDouble(FieldTemperature.Text);

                if (RdButton01.IsChecked == true)
                {
                    string resultOption1 = Convert.ToString((temperature * 9 / 5) + 32);
                    LabelResult.Text = String.Format("{0:0,00}", resultOption1) + "°C";
                }

                if (RdButton02.IsChecked == true)
                {
                    string resultOption2 = Convert.ToString(temperature + 273.15);

                    LabelResult.Text = String.Format("{0:0,00}", resultOption2) + " K";
                }
            }

            //(0 °C × 9/5) + 32 = 32 °F

            //0 °C + 273,15 = 273,15 K


        }

        public void Clear(object sender, EventArgs e)
        {
            FieldTemperature.Text = null;
            RdButton01.IsChecked = true;
            LabelResult.Text = "...";
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
