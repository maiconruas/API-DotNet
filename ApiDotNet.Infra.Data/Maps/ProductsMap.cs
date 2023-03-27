using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Infra.Data.Maps
{
	public class ProductsMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("produto");

			builder.HasKey(_ => _.Id);

			builder.Property(_ => _.Id)
				.HasColumnName("idproduto")
				.UseIdentityColumn();

			builder.Property(_ => _.Name)
				.HasColumnName("nome");

			builder.Property(_ => _.CodErp)
				.HasColumnName("coderp");

			builder.Property(_ => _.Price)
				.HasColumnName("preÇo");

			builder.HasMany(_ => _.Purchases)
				.WithOne(_ => _.Product)
				.HasForeignKey(_ => _.ProductId);
		}
	}
}
