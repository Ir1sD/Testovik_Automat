using Microsoft.AspNetCore.Mvc;
using Testovik_Automat.Requests;
using Testovik_Automat.Responses;
using Testovik_Core.Abstractions;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using Testovik_Automat.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Testovik_Automat.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IBrendService _brendService;
		private readonly IOrderWithUserService _orderWithUserService;
		private readonly ITovarService _tovarService;
		private readonly ICoinService _coinService;
		private readonly IUserService _userService;

		public HomeController(IOrderService orderService , 
			IBrendService brendService , 
			IOrderWithUserService orderWithUserService , 
			ITovarService tovarService , 
			ICoinService coinService , 
			IUserService userService)
		{
			_orderService = orderService;
			_brendService = brendService;
			_orderService = orderService;
			_tovarService = tovarService;
			_coinService = coinService;
			_userService = userService;
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

		public async Task<FileStreamResult> SaveExcel(int idBrend = 0)
		{
			var list = await _tovarService.GetListWithFilterAsync(idBrend);
			#region NPOI
			var fileName = "Каталог.xls";
			var memory = new MemoryStream();
			
			IWorkbook workbook;
			IRow row_n;
			ICell cell;
			IFont font, font_link;
			workbook = new HSSFWorkbook();
			var excelSheet1 = workbook.CreateSheet("Статистика");
			var ch = workbook.GetCreationHelper();
			excelSheet1.DefaultColumnWidth = 14;

			int cellIndex = 0;
			int countrow = 0;
			#endregion

			cellIndex = 0;
			row_n = excelSheet1.CreateRow(countrow++);

			cell = row_n.CreateCell(cellIndex++);
			cell.SetCellValue("Название");

			cell = row_n.CreateCell(cellIndex++);
			cell.SetCellValue("Бренд");

			cell = row_n.CreateCell(cellIndex++);
			cell.SetCellValue("Цена");

			cell = row_n.CreateCell(cellIndex++);
			cell.SetCellValue("Количетство");

			foreach (var item in list)
			{
				var brend = await _brendService.GetById(item.IdBrend);
				cellIndex = 0;
				row_n = excelSheet1.CreateRow(countrow++);

				cell = row_n.CreateCell(cellIndex++);
				cell.SetCellValue(item.Name);

				cell = row_n.CreateCell(cellIndex++);
				cell.SetCellValue(brend.Name);

				cell = row_n.CreateCell(cellIndex++);
				cell.SetCellValue(item.Price);

				cell = row_n.CreateCell(cellIndex++);
				cell.SetCellValue(item.Count);
			}

			workbook.Write(memory);
			memory.Position = 0;

			return File(memory, "application/vnd.ms-excel", fileName);
		}

		public IActionResult LoginView()
		{
			return View("Login");
		}

		public async Task<IActionResult> Login(string Login , string Password)
		{
			if(await _userService.Get(Login , HashHelper.Hash(Password)) != null)
			{
				var claims = new List<Claim> { new Claim(ClaimTypes.Email, Login) };
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
				return RedirectToAction("Index", "Admin");
			}

			return View("Login");
		}
	}
}
