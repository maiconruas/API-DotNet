using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class PersonMap : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable("pessoa");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("idpessoa")
				.UseIdentityColumn();

			builder.Property(_ => _.Document)
				.HasColumnName("documento");

			builder.Property(_ => _.Name)
				.HasColumnName("nome");

			builder.Property(_ => _.Phone)
				.HasColumnName("celular");

			builder.HasMany(_ => _.Purchases)
				.WithOne(_ => _.Person)
				.HasForeignKey(_ => _.PersonId);
		}
	}
}
