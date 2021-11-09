using gerenciador_de_filmes_e_series.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gerenciador_de_filmes_e_series.Droid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePlataformasDetalhes : ContentPage
    {
        public PagePlataformasDetalhes()
        {
            InitializeComponent();
            StatusEntry(true);
        }
        public void StatusEntry(bool status)
        {
            txtNome.IsReadOnly = status;
            txtAssinatura.IsReadOnly = status;
            txtURLLogoPlataforma.IsReadOnly = status;
        }

        public void Editar(object sender, EventArgs e)
        {
            StatusEntry(false);
        }

        async void SalvarPlataforma(object sender, EventArgs e)
        {
            var p = (Plataformas)BindingContext;
            p.NomePlataforma = txtNome.Text;
            p.ValorAssinaturaPlataforma = Convert.ToDouble(txtAssinatura.Text);
            p.URLLogoPlataforma = txtURLLogoPlataforma.Text;
            await App.Banco_de_dados.SalvarPlataforma(p);
            await Navigation.PopAsync();
        }

        async void ExcluirPlataforma(object sender, EventArgs e)
        {
            var p = (Plataformas)BindingContext;
            await App.Banco_de_dados.ApagarPlataforma(p);
            await Navigation.PopAsync();
        }

        public void VisualizarLogoPlataforma(object sender, EventArgs e)
        {
            imgPlataforma.Source = txtURLLogoPlataforma.Text;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Esse código armazena uma instância c, que representa um único filme, no BindingContext da página.
            var p = (Plataformas)BindingContext;

            txtNome.Text = p.NomePlataforma;
            txtAssinatura.Text = Convert.ToString(p.ValorAssinaturaPlataforma);
            txtURLLogoPlataforma.Text = p.URLLogoPlataforma;
            imgPlataforma.Source = p.URLLogoPlataforma;
        }
    }
}
