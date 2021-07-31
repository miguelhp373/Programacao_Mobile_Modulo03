using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Primeiro_App_em_Xamarin
{
    public partial class MainPage : ContentPage
    {
        double kmh, ms, mph;

        private void Calcular(object sender, EventArgs e)
        {
            kmh = Convert.ToDouble(txtKm.Text);
            ms = kmh / 3.6;
            mph = kmh / 1.609;
            lblMetrosResp.Text = ms.ToString("0.00") + " m/s";
            lblMilhasResp.Text = mph.ToString("0.00") + " mph";
        }
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
