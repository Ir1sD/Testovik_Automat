using Microsoft.AspNetCore.Mvc;
using Testovik_Automat.Requests;
using Testovik_Automat.Responses;
using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Automat.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICoinService _coinService;
        private readonly IOrderService _orderService;
        private readonly IOrderWithUserService _orderWithUserService;
        private readonly ITovarService _tovarService;
        private readonly IBrendService _brendService;


		public AdminController(ICoinService coinService , 
            IOrderService orderService , 
            IOrderWithUserService orderWithUserService , 
            ITovarService tovarService , 
            IBrendService brendService) 
        { 
            _coinService = coinService;
            _orderService = orderService;
            _tovarService = tovarService;
            _brendService = brendService;
            _orderWithUserService = orderWithUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Coins ()
        {
            var model = await _coinService.GetListAsync();
			return View("Coins" , model);
        }

        public async Task<IActionResult> SaveCoins(CoinResponse[] response)
        {
            var list = response
                .Select(c => Coin.New(c.Id, c.Num, c.Count))
                .ToList();

            await _coinService.Update(list);
            return await Coins();
        }

        public async Task<IActionResult> Orders ()
        {
            var model = new List<OrdersRequest>();

            var list = _orderService.GetListAsync().Result;

            foreach (var order in list)
            {
                var items = await _orderWithUserService.GetByIdOrder(order.Id);
                var modelItem = new OrdersRequest()
                {
                    Date = order.DateCreate,
                    Sum = order.Sum,
                    Items = items.Select(c => new OrderItemRequest()
                    {
                        NameTovar = c.NameTovar,
                        Count = c.Count
                    }).ToList()
                };

                model.Add(modelItem);
            }

            return View("Orders", model);
        }

        public async Task<IActionResult> TovarList()
        {
            var model = new TovarAdminRequest()
            {
                Brends = await _brendService.GetListAsync(),
                Tovars = await _tovarService.GetListAsync()
            };

            return View("TovarList", model);
        }

        public async Task<IActionResult> UpdateTovar (TovarAdminResponse[] response)
        {
            foreach (var tovar in response)
            {
                var item = Tovar.New(tovar.Id, tovar.Name, tovar.IdBrend, tovar.LogoPath, tovar.Price, tovar.Count);

                await _tovarService.Update(item);
            }

            return await TovarList();
        }

        public async Task<IActionResult> CreateTovarView()
        {
            var model = await _brendService.GetListAsync();
            return View("AddTovar", model);
        }
        public async Task<IActionResult> CreateTovar(TovarAdminResponse response)
        {
            var item = Tovar.New(0, response.Name, response.IdBrend, response.LogoPath, response.Price, response.Count);
            await _tovarService.Add(item);
            return await TovarList();
        }
    }
}
