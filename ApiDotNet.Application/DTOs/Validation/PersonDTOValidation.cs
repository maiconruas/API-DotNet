using FluentValidation;

namespace ApiDotNet.Application.DTOs.Validation
{
	public class PersonDTOValidation : AbstractValidator<PersonDTO>
	{
		public PersonDTOValidation()
		{
			RuleFor(_ => _.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Documento deve ser informado");

			RuleFor(_ => _.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Nome deve ser informado");

			RuleFor(_ => _.Phone)
				.NotEmpty()
				.NotNull()
				.WithMessage("Celular deve ser informado");
		}
	}
}
