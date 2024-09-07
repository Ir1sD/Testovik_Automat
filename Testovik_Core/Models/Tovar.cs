
namespace Testovik_Core.Models
{
	public class Tovar
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public long IdBrend { get; set; }
		public string LogoPath { get; set; } = string.Empty;
		public int Price { get; set; }
		public int Count { get; set; }

		private Tovar() { }

		public static Tovar New(long id , string name , long idBrend , string logoPath , int price , int count)
		{
			return new Tovar()
			{
				  Id = id ,
				  Name = name ,
				  IdBrend = idBrend ,
				  LogoPath = logoPath ,
				  Price = price,
				  Count = count
			};
		}
	}
}
