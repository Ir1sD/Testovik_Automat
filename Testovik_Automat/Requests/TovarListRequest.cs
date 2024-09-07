namespace Testovik_Automat.Requests
{
	public class TovarListRequest
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string LogoPath { get; set; } = string.Empty;
		public int Price { get; set; }
		public bool IsActive {  get; set; }
		public int Count {  get; set; }
	}
}
