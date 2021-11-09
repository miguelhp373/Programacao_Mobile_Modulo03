using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace gerenciador_de_filmes_e_series.Models
{
    public class BancoDeDados
    {
        readonly SQLiteAsyncConnection banco_de_dados;

        public BancoDeDados(string dbPath)
        {
            banco_de_dados = new SQLiteAsyncConnection(dbPath);
            //criação das tabelas
            banco_de_dados.CreateTableAsync<Filmes>().Wait();
            banco_de_dados.CreateTableAsync<Series>().Wait();
            banco_de_dados.CreateTableAsync<Plataformas>().Wait();
        }

        // ---------------- Listagem
        public Task<List<Filmes>> GetFilmes()
        {
            return banco_de_dados.Table<Filmes>().ToListAsync();
        }

        public Task<List<Series>> GetSeries()
        {
            return banco_de_dados.Table<Series>().ToListAsync();
        }

        public Task<List<Plataformas>> GetPlataformas()
        {
            return banco_de_dados.Table<Plataformas>().ToListAsync();
        }

        // ---------------- Searchbar
        public Task<List<Filmes>> GetFilmeNome(string nome)
        {
            return banco_de_dados.Table<Filmes>().Where(i => i.NomeFilme.ToLower().Contains(nome.ToLower())).ToListAsync();

        }
        public Task<List<Series>> GetSerieNome(string nome)
        {
            return banco_de_dados.Table<Series>().Where(i => i.NomeSerie.ToLower().Contains(nome.ToLower())).ToListAsync();

        }
        public Task<List<Plataformas>> GetPlataformaNome(string nome)
        {
            return banco_de_dados.Table<Plataformas>().Where(i => i.NomePlataforma.ToLower().Contains(nome.ToLower())).ToListAsync();

        }

        // ---------------- Salvar
        public Task<int> SalvarFilme(Filmes f)
        {
            if (f.IDFilme != 0)
            {
                return banco_de_dados.UpdateAsync(f);
            }
            else
            {
                return banco_de_dados.InsertAsync(f);
            }
        }

        public Task<int> SalvarSerie(Series s)
        {
            if (s.IDSerie != 0)
            {
                return banco_de_dados.UpdateAsync(s);
            }
            else
            {
                return banco_de_dados.InsertAsync(s);
            }
        }

        public Task<int> SalvarPlataforma(Plataformas p)
        {
            if (p.IDPlataforma != 0)
            {
                return banco_de_dados.UpdateAsync(p);
            }
            else
            {
                return banco_de_dados.InsertAsync(p);
            }
        }

        // ---------------- Excluir
        public Task<int> ApagarFilme(Filmes f)
        {
            return banco_de_dados.DeleteAsync(f);
        }

        public Task<int> ApagarSerie(Series s)
        {
            return banco_de_dados.DeleteAsync(s);
        }

        public Task<int> ApagarPlataforma(Plataformas p)
        {
            return banco_de_dados.DeleteAsync(p);
        }
    }
}
