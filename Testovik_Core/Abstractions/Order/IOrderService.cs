using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IOrderService
    {
        Task<List<Order>> GetListAsync();
    }
}