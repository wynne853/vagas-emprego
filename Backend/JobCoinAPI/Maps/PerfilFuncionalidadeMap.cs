﻿using JobCoinAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCoinAPI.Maps
{
	public static class PerfilFuncionalidadeMap
	{
		public static void Map(this EntityTypeBuilder<PerfilFuncionalidade> entity)
		{
			entity.ToTable("PERFIL_FUNCIONALIDADE");

			entity.HasKey(perfilFuncionalidade => new { perfilFuncionalidade.IdPerfil, perfilFuncionalidade.IdFuncionalidade });

			entity.HasOne(perfilFuncionalidade => perfilFuncionalidade.Perfil)
				.WithMany(perfil => perfil.Funcionalidades)
				.HasForeignKey(perfilFuncionalidade => perfilFuncionalidade.IdPerfil);

			entity.HasOne(perfilFuncionalidade => perfilFuncionalidade.Funcionalidade)
				.WithMany(funcionalidade => funcionalidade.Perfis)
				.HasForeignKey(perfilFuncionalidade => perfilFuncionalidade.IdFuncionalidade);

			entity.Property(perfilFuncionalidade => perfilFuncionalidade.IdPerfil)
				.HasColumnName("IdPerfil")
				.IsRequired();

			entity.Property(perfilFuncionalidade => perfilFuncionalidade.IdFuncionalidade)
				.HasColumnName("IdFuncionalidade")
				.IsRequired();
		}
	}
}