using ApiDotNet.Domain.Validations;

namespace ApiDotNet.Domain.Entities
{
	public sealed class Person
	{
        public int Id { get; private set; }
		public string Name { get; private set; }	
		public string Document { get; private set; }
		public string Phone { get; private set; }
		public ICollection<Purchase> Purchases { get; private set; }

		public Person(string name, string document, string phone)
		{
			Validation(document, name, phone);
		}

		public Person(int id, string name, string document, string phone)
		{
			DomainValidationException.When(id < 0, "O ID deve exitir");
			Id = id;
			Validation(document, name, phone);
		}

		private void Validation(String document,  string phone, string name) 
		{
			DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
			DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
			DomainValidationException.When(string.IsNullOrEmpty(phone), "Celular deve ser informado!");

			Name = name;
			Document = document;
			Phone = phone;
		}
	}
}
