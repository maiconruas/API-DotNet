using FluentValidation;

namespace ApiDotNet.Application.DTOs.Validation
{
	public class PersonDTOValidation : AbstractValidator<PersonDTO>
	{
		public PersonDTOValidation()
		{
			RuleFor(x => x.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Document deve ser informado!");

			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Name deve ser informado!");

			RuleFor(x => x.Phone)
				.NotEmpty()
				.NotNull()
				.WithMessage("Phone deve ser informado!");
		}
	}
}
