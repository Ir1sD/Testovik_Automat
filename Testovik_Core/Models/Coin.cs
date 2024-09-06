
namespace Testovik_Core.Models
{
	public class Coin
	{
		public int Id { get; set; }
		public int Num { get; set; }
		public int Count { get; set; }

		private Coin() { }

		public static Coin New(int id, int num , int count)
		{
			return new Coin()
			{
				Id = id,
				Num = num,
				Count = count
			};
		}
	}

	
}
