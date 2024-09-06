
namespace Testovik_Core.Models
{
	public class OrderWithUser
	{
		public long Id { get; set; }
		public long IdOrder { get; set; }
		public long IdTovar { get; set; }
		public string NameTovar { get; set; } = string.Empty;
		public int Count { get; set; }

		private OrderWithUser() { }

		public static OrderWithUser New(long id , long idOrder , long idTovar , string nameTovar , int count)
		{
			return new OrderWithUser()
			{
				Id = id,
				IdOrder = idOrder,
				IdTovar = idTovar,
				NameTovar = nameTovar,
				Count = count
			};
		}
	}
}
