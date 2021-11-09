using System;
using SQLite;
namespace gerenciador_de_filmes_e_series.Models
{
    public class Plataformas
    {
        [PrimaryKey, AutoIncrement]
        public int IDPlataforma { get; set; }
        public string NomePlataforma { get; set; }
        public double ValorAssinaturaPlataforma { get; set; }
        public string URLLogoPlataforma { get; set; }
    }
}

