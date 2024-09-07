using Microsoft.AspNetCore.Mvc;
using Testovik_Automat.Requests;
using Testovik_Core.Abstractions;

namespace Testovik_Automat.Components
{
	public class TovarListViewComponent(ITovarService tovarService) : ViewComponent
	{
		private readonly ITovarService _tovarService = tovarService;

		public async Task<IViewComponentResult> InvokeAsync(int BrendId , int[] Ids)
		{
			var list = await _tovarService.GetListWithFilterAsync(BrendId);
			var model = list.Select(c => new TovarListRequest()
			{
				Id = c.Id,
				LogoPath = c.LogoPath,
				Name = c.Name,
				Price = c.Price,
				IsActive = false,
				Count = c.Count
			}).ToList();

			foreach (var id in Ids)
			{
				var item = model.FirstOrDefault(c => c.Id == id);

				if(item != null)
				{
					item.IsActive = true;
				}
			}

			return View("Default", model);
		}
	}
}
