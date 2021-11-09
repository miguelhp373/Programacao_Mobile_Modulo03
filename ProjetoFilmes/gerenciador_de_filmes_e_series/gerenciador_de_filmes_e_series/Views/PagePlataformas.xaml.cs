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
    public partial class PagePlataformas : ContentPage
    {
        public PagePlataformas()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Banco_de_dados.GetPlataformas();
        }

        async void AdicionarPlataforma(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagePlataformasDetalhes { BindingContext = new Plataformas() });
        }

        async void OnListViewSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PagePlataformasDetalhes { BindingContext = e.SelectedItem as Plataformas });
            }
        }

        async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var texto = PlataformaSearchBar.Text;
            listView.ItemsSource = await App.Banco_de_dados.GetPlataformaNome(texto);
        }
    }
}
