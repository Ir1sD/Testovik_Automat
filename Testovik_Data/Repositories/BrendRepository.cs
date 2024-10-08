﻿using Microsoft.EntityFrameworkCore;
using Testovik_Data.Context;
using Testovik_Core.Models;
using Testovik_Core.Abstractions;

namespace Testovik_Data.Repositories
{
	public class BrendRepository : IBrendRepository
	{
		private readonly TestovikContext _context;

		public BrendRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает список брендов
		/// </summary>
		/// <returns></returns>
		public async Task<List<Brend>> GetListAsync()
		{
			return await _context.Brends
				.AsNoTracking()
				.Select(c => Brend.New(c.Id, c.Name))
				.ToListAsync();
		}

	}
}
