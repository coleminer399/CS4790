using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public MenuItemController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitofWork.MenuItem.List(null,null,"Category,FoodType") });
        }
    }
}
