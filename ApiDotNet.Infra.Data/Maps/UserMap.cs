using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("usuario");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("idusuario");

			builder.Property(_ => _.Email)
				.HasColumnName("email");

			builder.Property(_ => _.Password)
				.HasColumnName("senha");
		}
	}
}
