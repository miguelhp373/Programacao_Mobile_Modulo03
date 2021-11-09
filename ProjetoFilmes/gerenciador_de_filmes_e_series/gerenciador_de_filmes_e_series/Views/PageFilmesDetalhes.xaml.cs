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
    public partial class PageFilmesDetalhes : ContentPage
    {
        public PageFilmesDetalhes()
        {
            CarregaPlataformas();
            InitializeComponent();
            StatusEntry(true);
        }

        async void CarregaPlataformas()
        {
            var nomesplataformas = await App.Banco_de_dados.GetPlataformas();
            foreach (var itemnome in nomesplataformas)
            {
                pikerPlataformaFilmes.Items.Add(itemnome.NomePlataforma.ToString());
            }
        }

        public void StatusEntry(bool status)
        {
            txtNome.IsReadOnly = status;
            txtGenero.IsReadOnly = status;
            txtDuracao.IsReadOnly = status;
            pikerPlataformaFilmes.IsEnabled = !status;
            txtURLCapaFilme.IsReadOnly = status;
        }

        public void Editar(object sender, EventArgs e)
        {
            StatusEntry(false);
        }

        async void SalvarFilme(object sender, EventArgs e)
        {
            var f = (Filmes)BindingContext;
            f.NomeFilme = txtNome.Text;
            f.GeneroFilme = txtGenero.Text;
            f.DuracaoFilme = Convert.ToInt16(txtDuracao.Text);
            f.PlataformaFilme = pikerPlataformaFilmes.SelectedItem.ToString();
            f.URLCapaFilme = txtURLCapaFilme.Text;
            await App.Banco_de_dados.SalvarFilme(f);
            await Navigation.PopAsync();
        }

        async void ExcluirFilme(object sender, EventArgs e)
        {
            var f = (Filmes)BindingContext;
            await App.Banco_de_dados.ApagarFilme(f);
            await Navigation.PopAsync();
        }

        public void VisualizarCapaFilme(object sender, EventArgs e)
        {
            imgFilme.Source = txtURLCapaFilme.Text;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var f = (Filmes)BindingContext;
            txtNome.Text = f.NomeFilme;
            txtGenero.Text = f.GeneroFilme;
            txtDuracao.Text = Convert.ToString(f.DuracaoFilme);
            pikerPlataformaFilmes.SelectedItem = f.PlataformaFilme;
            txtURLCapaFilme.Text = f.URLCapaFilme;
            imgFilme.Source = f.URLCapaFilme;

        }
    }

}
    
