using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class ProductsMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Produto");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("IdProduto")
				.UseIdentityColumn();

			builder.Property(_ => _.Name)
				.HasColumnName("Nome");

			builder.Property(_ => _.CodErp)
				.HasColumnName("CodErp");

			builder.Property(_ => _.Price)
				.HasColumnName("Preço");

			builder.HasMany(_ => _.Purchases)
				.WithOne(_ => _.Product)
				.HasForeignKey(_ => _.ProductId);
		}
	}
}
