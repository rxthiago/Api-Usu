using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Historico
    /// </summary>
    public class HistoricoMap : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            //Nome da tabela
            builder.ToTable("HISTORICO");

            //Chave primária
            builder.HasKey(h => h.IdHistorico);

            //Mapeamento dos campos da tabela
            builder.Property(h => h.IdHistorico)
                .HasColumnName("IDHISTORICO");

            builder.Property(h => h.DataHoraOperacao)
                .HasColumnName("DATAHORAOPERACAO")
                .IsRequired();

            builder.Property(h => h.TipoOperacao)
                .HasColumnName("TIPOOPERACAO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(h => h.IdUsuario)
                .HasColumnName("IDUSUARIO")
                .IsRequired();

            //Mapeamento dos relacionamentos e FKs
            builder.HasOne(h => h.Usuario) //Histórico TEM 1 Usuário
                .WithMany(u => u.Historicos) //Usuário TEM MUITOS Históricos
                .HasForeignKey(h => h.IdUsuario); //Chave estrangeira
        }
    }
}
