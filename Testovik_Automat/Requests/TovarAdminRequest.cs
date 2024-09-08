using Testovik_Core.Models;

namespace Testovik_Automat.Requests
{
    public class TovarAdminRequest
    {
        public List<Brend> Brends { get; set; }
        public List<Tovar> Tovars { get; set; }
    }

}
