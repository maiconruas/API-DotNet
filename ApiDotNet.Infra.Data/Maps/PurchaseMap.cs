using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class PurchaseMap : IEntityTypeConfiguration<Purchase>
	{
		public void Configure(EntityTypeBuilder<Purchase> builder)
		{
			builder.ToTable("Compra");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("IdCompra")
				.UseIdentityColumn();

			builder.Property(_ => _.PersonId)
				.HasColumnName("IdPessoa");

			builder.Property(_ => _.ProductId)
				.HasColumnName("IdProduto");

			builder.Property(_ => _.Date)
				.HasColumnName("DataCompra");

			builder.HasOne(_ => _.Person)
				.WithMany(_ => _.Purchases);

			builder.HasOne(_ => _.Product)
				.WithMany(_ => _.Purchases);
		}
	}
}
