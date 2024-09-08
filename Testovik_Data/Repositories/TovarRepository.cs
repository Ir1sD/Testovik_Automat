using Microsoft.EntityFrameworkCore;
using Testovik_Core.Abstractions;
using Testovik_Core.Models;
using Testovik_Data.Context;
using Testovik_Data.Entities;

namespace Testovik_Data.Repositories
{
	public class TovarRepository : ITovarRepository
	{
		private readonly TestovikContext _context;

		public TovarRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает список товаров
		/// </summary>
		/// <returns></returns>
		public async Task<List<Tovar>> GetListAsync()
		{
			return await _context.Tovars
				.AsNoTracking()
				.Select(c => Tovar.New(c.Id, c.Name, c.IdBrend, c.LogoPath, c.Price , c.Count))
				.ToListAsync();
		}

        public async Task Update(Tovar tovar)
        {
			var entity = await _context.Tovars
				.AsNoTracking()
				.FirstOrDefaultAsync(c => c.Id == tovar.Id);

			if (entity != null)
			{
                entity.Name = tovar.Name;
                entity.IdBrend = tovar.IdBrend;
				entity.LogoPath = tovar.LogoPath;
				entity.Price = tovar.Price;
				entity.Count = tovar.Count;

				_context.Tovars.Update(entity);
            }

			await _context.SaveChangesAsync();
        }

		public async Task Add(Tovar tovar)
		{
			var entity = new TovarEntity
			{
				Name = tovar.Name,
				Count = tovar.Count,
				LogoPath = tovar.LogoPath,
				Price = tovar.Price,
				IdBrend = tovar.IdBrend
			};

			await _context.Tovars.AddAsync(entity);
			await _context.SaveChangesAsync();
		}
    }
}
