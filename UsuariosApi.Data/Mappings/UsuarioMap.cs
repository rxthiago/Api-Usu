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
    /// Classe de mapeamento para a entidade Usuario
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Nome da tabela
            builder.ToTable("USUARIO");

            //chave primária
            builder.HasKey(u => u.IdUsuario);

            //mapeamento dos campos
            builder.Property(u => u.IdUsuario)
                .HasColumnName("IDUSUARIO");

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            //definindo o campo Email como UNIQUE
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();

            builder.Property(u => u.IdPerfil)
                .HasColumnName("IDPERFIL");

            //mapeamento a chave estrangeira
            builder.HasOne(u => u.Perfil) //Usuário TEM 1 Perfil
                .WithMany(p => p.Usuarios) //Perfil TEM Muitos Usuários
                .HasForeignKey(u => u.IdPerfil); //Chave estrangeira do relacionamento
        }
    }
}
