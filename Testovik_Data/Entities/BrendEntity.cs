
namespace Testovik_Data.Entities
{
	public class BrendEntity
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public List<TovarEntity>? Tovars { get; set; }
	}
}
