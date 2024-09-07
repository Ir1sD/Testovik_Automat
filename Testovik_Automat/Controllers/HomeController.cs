using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Testovik_Automat.Requests;
using Testovik_Automat.Responses;
using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Automat.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IBrendService _brendService;
		private readonly IOrderWithUserService _orderWithUserService;
		private readonly ITovarService _tovarService;
		private readonly ICoinService _coinService;

		public HomeController(IOrderService orderService , IBrendService brendService , IOrderWithUserService orderWithUserService , ITovarService tovarService , ICoinService coinService )
		{
			_orderService = orderService;
			_brendService = brendService;
			_orderService = orderService;
			_tovarService = tovarService;
			_coinService = coinService;
		}

		public async Task<IActionResult> Index()
		{
			var model = new CatalogRequest();
			model.Brends = await _brendService.GetListAsync();
			return View("Index" , model);
		}

		public IActionResult GetTovarList(int brendId , int[] ids)
		{
			return ViewComponent("TovarList", new { BrendId = brendId , Ids = ids});
		}

		public async Task<IActionResult> Step2(long[] ids)
		{
			var list = await _tovarService.GetListWithListId(ids);
			
			return View("Order" , list);
		}

		private static OrderResponse[] tov; // Временно сохраняем данные о заказе

		public async Task<IActionResult> Step3(OrderResponse[] tovars)
		{
			tov = tovars; // Вот тут это и делаем

			return View("Step3" , await GetSumOrder(tovars));
		}

		public async Task<int> GetSumOrder(OrderResponse[] tovars)
		{
			var tovar = await _tovarService.GetListWithListId(tovars.Select(c => c.Id).ToArray());
			int result = 0;

			for(int i = 0; i < tovar.Count; i++)
			{
				result += tovar[i].Price * tovars[i].Count;
			}

			return result;
		}

		public async Task<IActionResult> Step4(int i1 , int i2, int i5 , int i10 , int sum)
		{
			var tovars = await _tovarService.GetListWithListId(tov.Select(c => c.Id).ToArray());
			
			await _orderService.Add(sum , tovars , tov.Select(c => c.Count).ToArray());
			tov = null;
			await _coinService.AddRange(i1, i2, i5, i10);

			var total = (i1 + i2 * 2 + i5 * 5 + i10 * 10) - sum;
			var model = await GetTotal(total);
			model.Sum = total;
			return View("Step4" , model);
		}

		public async Task<Step4Request> GetTotal(int t)
		{
			var list = await _coinService.GetListAsync();
			list = list
				.OrderByDescending(c => c.Num)
				.ToList();

			var total = t;
			var model = new int[list.Count];

			for(int i = 0; i < list.Count; i++)
			{
				var size = total / list[i].Num;

				if(size <= 0)
				{
					continue;
				}
				else if (list[i].Count < size)
				{
					continue;
				}
				else
				{
					model[i] = size;
					total = total % list[i].Num;
				}
			}

			var result = new Step4Request
			{
				i1 = model[3],
				i2 = model[2],
				i5 = model[1],
				i10 = model[0]
			};

			return result;
		}


	}
}
