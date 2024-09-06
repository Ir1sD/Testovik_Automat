
namespace Testovik_Core.Models
{
	public class Order
	{
		public long Id { get; set; }
		public DateTime DateCreate { get; set; }
		public int Sum { get; set; }

		private Order() { }

		public static Order New(long id, DateTime date, int sum)
		{
			return new Order()
			{
				Id = id,
				DateCreate = date,
				Sum = sum
			};
		}

	}
}
