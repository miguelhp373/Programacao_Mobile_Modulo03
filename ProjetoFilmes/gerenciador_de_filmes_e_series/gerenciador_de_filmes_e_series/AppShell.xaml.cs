using gerenciador_de_filmes_e_series.Droid.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gerenciador_de_filmes_e_series
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        void RegisterRoutes()
        {
            Routes.Add("filmesdetalhes", typeof(PageFilmesDetalhes));
            Routes.Add("seriesdetalhes", typeof(PageSeriesDetalhes));
            Routes.Add("palataformasdetalhes", typeof(PagePlataformasDetalhes));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }


        public AppShell()
        {
            InitializeComponent();
        }
    }
}