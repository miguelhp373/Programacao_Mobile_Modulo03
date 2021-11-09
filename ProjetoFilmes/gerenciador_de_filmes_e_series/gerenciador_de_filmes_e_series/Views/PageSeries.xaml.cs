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
    public partial class PageSeries : ContentPage
    {
        public PageSeries()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Banco_de_dados.GetSeries();
        }

        async void AdicionarSerie(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageSeriesDetalhes { BindingContext = new Series() });
        }

        async void OnListViewSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PageSeriesDetalhes { BindingContext = e.SelectedItem as Series });
            }
        }

        async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var texto = SerieSearchBar.Text;
            listView.ItemsSource = await App.Banco_de_dados.GetSerieNome(texto);
        }
    }
}
