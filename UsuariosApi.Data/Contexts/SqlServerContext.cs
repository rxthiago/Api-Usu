using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Mappings;

namespace UsuariosApi.Data.Contexts
{
    /// <summary>
    /// Classe para conexão com o BD e contexto do EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //método para adicionar a connectionstring do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5063.site4now.net;Initial Catalog=db_a92348_apiusuarios;User Id=db_a92348_apiusuarios_admin;Password=coti123456");
        }

        //método para adicionar cada classe de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new HistoricoMap());
        }

        //propriedades do tipo DbSet para cada entidade
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Perfil>? Perfil { get; set; }
        public DbSet<Historico>? Historico { get; set; }
    }
}
