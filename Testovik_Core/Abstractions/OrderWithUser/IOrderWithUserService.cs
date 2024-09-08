﻿using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IOrderWithUserService
    {
        Task<List<OrderWithUser>> GetListAsync();
        Task<List<OrderWithUser>> GetByIdOrder(long orderId);
    }
}