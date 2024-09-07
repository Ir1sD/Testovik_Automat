using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IOrderService
    {
        Task<List<Order>> GetListAsync();
        Task Add(int sum, List<Tovar> tovars, int[] counts);

	}
}