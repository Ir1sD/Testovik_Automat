namespace Testovik_Automat.Responses
{
    public class TovarAdminResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long IdBrend { get; set; }
        public string LogoPath { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
