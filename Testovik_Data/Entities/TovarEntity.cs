
namespace Testovik_Data.Entities
{
	public class TovarEntity
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public long IdBrend {  get; set; }
		public string LogoPath { get; set; } = string.Empty;
		public int Price { get; set; }
		public BrendEntity? Brend { get; set; }
	}
}
