using FluentValidation;

namespace ApiDotNet.Application.DTOs.Validation
{
	public class PurchaseDTOValidation : AbstractValidator<PurchaseDTO>
	{
		public PurchaseDTOValidation()
		{
			RuleFor(x => x.CodErp)
				.NotEmpty()
				.NotNull()
				.WithMessage("CodErp deve ser informado!");

			RuleFor(x => x.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Document deve ser informado!");

		}
	}
}
