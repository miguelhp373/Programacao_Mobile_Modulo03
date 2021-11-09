using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
using gerenciador_de_filmes_e_series.Models;

namespace gerenciador_de_filmes_e_series
{
    public partial class App : Application
    {
        static BancoDeDados banco_de_dados;

        public static BancoDeDados Banco_de_dados
        {
            get
            {
                if (banco_de_dados == null)
                {
                    banco_de_dados = new BancoDeDados(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BDFilmesSeries.db3"));
                }
                return banco_de_dados;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
