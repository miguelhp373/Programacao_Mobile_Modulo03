using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace gerenciador_de_filmes_e_series.Models
{
    public class Filmes
    {
        [PrimaryKey, AutoIncrement]
        public int IDFilme { get; set; }
        public string NomeFilme { get; set; }
        public string GeneroFilme { get; set; }
        public int DuracaoFilme { get; set; }
        public string PlataformaFilme { get; set; }
        public string URLCapaFilme { get; set; }
    }
}
