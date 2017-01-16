using System;
using System.ComponentModel.DataAnnotations;

namespace Ethos
{
	public class AmortizationModel
	{
		//we add a property for monthly pay because this is a fixed value.
		[Required]
		[Display(Name="Principal")]
		public decimal Principal { get; set; }

		[Required]
		[Display(Name="Terms")]
		public int Terms { get; set; }

		[Required]
		[Display(Name="Interest Rate")]
		[Range(0.00, 100.00)]
		public decimal InterestRate { get; set; }

		//let p = principal
		//let a = the monthly amortized payment
		//let r = interest rate
		//let n = terms in months
		//the formula is a = (p*r(1+r)^n))/((1+r^n)-1)
		public AmortizationResultModel Calculate(decimal principal, int terms, decimal interest, decimal originalBalance)
		{
			decimal rate = interest / (100 * 12);
			decimal interestPaid = originalBalance * rate;
			decimal compound = (decimal)Math.Pow((1 + (double)rate), terms);
			decimal payment = (interestPaid * compound) / (compound - 1);
			decimal principalPaid = payment - principal*rate;
			Principal = principal - principalPaid;
			return new AmortizationResultModel
			{
				Balance = principal - principalPaid,
				Payment = payment,
				PrincipalPaid = principalPaid
			};
		}

	}
}
