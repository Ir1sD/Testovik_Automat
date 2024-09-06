
namespace Testovik_Data.Entities
{
	public class OrderWithUserEntity
	{
		public long Id { get; set; }
		public long IdOrder { get; set; }
		public long IdTovar { get; set; }
		public string NameTovar { get; set; } = string.Empty;
		public int Count { get; set; }
		public OrderEntity? Order { get; set; }
	}
}
