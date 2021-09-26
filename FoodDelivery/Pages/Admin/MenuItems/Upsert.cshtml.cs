using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodDelivery.Pages.Admin.MenuItems
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitofWork _unitofWork;
        [BindProperty]
        public MenuItemVM MenuItemObj { get; set; }
        public UpsertModel(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult OnGet(int? id)
        {
            var categories = _unitofWork.Category.List();
            var foodTypes = _unitofWork.FoodType.List();

            MenuItemObj = new MenuItemVM
            {
                MenuItem = new MenuItem(),
                CategoryList = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }),
                FoodTypeList = foodTypes.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString()
                }),

            };
            if (id != 0)
            {
                MenuItemObj.MenuItem = _unitofWork.MenuItem.Get(u => u.Id == id, true);
                if (MenuItemObj == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }
    }
}