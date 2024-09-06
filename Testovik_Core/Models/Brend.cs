
namespace Testovik_Core.Models
{
	public class Brend
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;

		private Brend() { }

		public static Brend New(long id, string name)
		{
			return new Brend
			{
				Id = id ,
				Name = name
			};
		}

		

	}
}
