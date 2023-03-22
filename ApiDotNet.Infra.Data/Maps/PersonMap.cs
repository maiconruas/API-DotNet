using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class PersonMap : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable("Pessoa");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("Idpessoa")
				.UseIdentityColumn();

			builder.Property(_ => _.Document)
				.HasColumnName("Documento");

			builder.Property(_ => _.Name)
				.HasColumnName("Nome");

			builder.Property(_ => _.Phone)
				.HasColumnName("Celular");

			builder.HasMany(_ => _.Purchases)
				.WithOne(_ => _.Person)
				.HasForeignKey(_ => _.PersonId);
		}
	}
}
