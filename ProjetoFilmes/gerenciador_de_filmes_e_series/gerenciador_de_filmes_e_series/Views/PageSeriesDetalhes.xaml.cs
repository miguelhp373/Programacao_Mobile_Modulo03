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
    public partial class PageSeriesDetalhes : ContentPage
    {
        public PageSeriesDetalhes()
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
                pikerPlataformaSeries.Items.Add(itemnome.NomePlataforma.ToString());
            }
        }

        public void StatusEntry(bool status)
        {
            txtNome.IsReadOnly = status;
            txtGenero.IsReadOnly = status;
            txtTemporadas.IsReadOnly = status;
            pikerPlataformaSeries.IsEnabled = !status;
            txtURLCapaSerie.IsReadOnly = status;
        }

        public void Editar(object sender, EventArgs e)
        {
            StatusEntry(false);
        }

        async void SalvarSerie(object sender, EventArgs e)
        {
            var s = (Series)BindingContext;
            s.NomeSerie = txtNome.Text;
            s.GeneroSerie = txtGenero.Text;
            s.TemporadasSerie = Convert.ToInt16(txtTemporadas.Text);
            s.PlataformaSerie = pikerPlataformaSeries.SelectedItem.ToString();
            s.URLCapaSerie = txtURLCapaSerie.Text;
            await App.Banco_de_dados.SalvarSerie(s);
            await Navigation.PopAsync();
        }

        async void ExcluirSerie(object sender, EventArgs e)
        {
            var s = (Series)BindingContext;
            await App.Banco_de_dados.ApagarSerie(s);
            await Navigation.PopAsync();
        }

        public void VisualizarCapaSerie(object sender, EventArgs e)
        {
            imgSerie.Source = txtURLCapaSerie.Text;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var s = (Series)BindingContext;
            txtNome.Text = s.NomeSerie;
            txtGenero.Text = s.GeneroSerie;
            txtTemporadas.Text = Convert.ToString(s.TemporadasSerie);
            pikerPlataformaSeries.SelectedItem = s.PlataformaSerie;
            txtURLCapaSerie.Text = s.URLCapaSerie;
            imgSerie.Source = s.URLCapaSerie;

        }
    }
}
