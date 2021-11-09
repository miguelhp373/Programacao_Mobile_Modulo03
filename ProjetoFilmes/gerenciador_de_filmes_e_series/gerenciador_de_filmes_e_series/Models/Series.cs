using System;
using SQLite;
namespace gerenciador_de_filmes_e_series.Models
{
    public class Series
    {
        [PrimaryKey, AutoIncrement]
        public int IDSerie { get; set; }
        public string NomeSerie { get; set; }
        public string GeneroSerie { get; set; }
        public int TemporadasSerie { get; set; }
        public string PlataformaSerie { get; set; }
        public string URLCapaSerie { get; set; }
    }
}

