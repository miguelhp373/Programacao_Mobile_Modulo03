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
    public partial class PageFilmes : ContentPage
    {
        public PageFilmes()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Banco_de_dados.GetFilmes();
        }

        async void AdicionarFilme(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageFilmesDetalhes { BindingContext = new Filmes() });
        }

        async void OnListViewSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PageFilmesDetalhes { BindingContext = e.SelectedItem as Filmes });
            }
        }

        async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var texto = FilmeSearchBar.Text;
            listView.ItemsSource = await App.Banco_de_dados.GetFilmeNome(texto);
        }
    }

}
