using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class PurchaseMap : IEntityTypeConfiguration<Purchase>
	{
		public void Configure(EntityTypeBuilder<Purchase> builder)
		{
			builder.ToTable("compra");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("idcompra")
				.UseIdentityColumn();

			builder.Property(_ => _.PersonId)
				.HasColumnName("idpessoa");

			builder.Property(_ => _.ProductId)
				.HasColumnName("idproduto");

			builder.Property(_ => _.Date)
				.HasColumnType("date")
				.HasColumnName("datacompra");

			builder.HasOne(_ => _.Person)
				.WithMany(_ => _.Purchases);

			builder.HasOne(_ => _.Product)
				.WithMany(_ => _.Purchases);
		}
	}
}
