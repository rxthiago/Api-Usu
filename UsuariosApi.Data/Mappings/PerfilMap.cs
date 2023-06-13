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
    /// Classe de mapeamento para a entidade Perfil
    /// </summary>
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            //Nome da tabela
            builder.ToTable("PERFIL");

            //chave primária
            builder.HasKey(p => p.IdPerfil);

            //mapeamento os campos da tabela
            builder.Property(p => p.IdPerfil)
                .HasColumnName("IDPERFIL");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            //definindo o campo Nome como único
            builder.HasIndex(p => p.Nome)
                .IsUnique();
        }
    }
}
