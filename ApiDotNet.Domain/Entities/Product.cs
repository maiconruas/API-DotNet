using ApiDotNet.Domain.Validations;
namespace ApiDotNet.Domain.Entities
{
	public sealed class Product
	{
        public int Id { get; private set; }
		public string Name { get; private set; }	
		public string CodErp { get; private set; }
		public decimal Price { get; private set; }
		public ICollection<Purchase> Purchases { get; private set; }

		public Product(string name, string codErp, decimal price)
		{
			Validation(name, codErp, price);
		}

		public Product(int id, string name, string codErp, decimal price)
		{
			DomainValidationException.When(id < 0, "ID do produto deve ser informado!");
			Validation(name, codErp, price);
		}

		private void Validation(string name, string codErp, decimal price)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
			DomainValidationException.When(string.IsNullOrEmpty(codErp), "Codigo ERP deve ser informado!");
			DomainValidationException.When(price < 0, "Preço deve ser informado!");

			Name = name;
			Price = price;
			CodErp = codErp;
		}
	}


}
