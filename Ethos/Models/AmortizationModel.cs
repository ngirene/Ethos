using System;
using System.ComponentModel.DataAnnotations;

namespace Ethos
{
	public class AmortizationModel
	{
		//we add a property for monthly pay because this is a fixed value.
		[Required]
		[Display(Name="Principal")]
		public decimal PrincipalAmount { get; set; }

		[Required]
		[Display(Name="Terms")]
		public int Terms { get; set; }

		[Required]
		[Display(Name="Interest Rate")]
		[Range(0.00, 100.00)]
		public decimal InterestRate { get; set; }

		[Display(Name="Monthly Payment")]
		public decimal MonthlyPay { get; set; }

		public AmortizationModel(decimal principal, int terms, decimal interest)
		{
			MonthlyPay = principal / terms;
		}

		//we will return an instance of the AmortizationModel for every month's calculation.
		public AmortizationModel Calculate(decimal principal, int terms, decimal interest)
		{
			decimal interestPay = (principal * interest) / (100 * 12);
			decimal newPrincipal = principal - (MonthlyPay - interestPay);
			return new AmortizationModel(newPrincipal, terms, interest); 
		}
	}
}
