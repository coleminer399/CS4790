using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDelivery.Pages.Admin.Categories
{
    public class upsertModel : PageModel
    {
        private readonly IUnitofWork _unitofWork;
        [BindProperty]
        public Category CategoryObj { get; set; }
        public upsertModel(IUnitofWork unitofWork) => _unitofWork = unitofWork;
        
        public IActionResult OnGet(int ? id)
        {
            CategoryObj = new Category();

            if (id != 0)
            {//edit
                CategoryObj = _unitofWork.Category.Get(u => u.Id == id);

                if (CategoryObj == null)
                {
                    return NotFound();
                }
            }
            return Page();//assume insert new mode
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //if new
            if (CategoryObj.Id == 0)
            {
                _unitofWork.Category.Add(CategoryObj);
            }
            else //existing
            {
                _unitofWork.Category.Update(CategoryObj);
            }
            _unitofWork.commit();
            return RedirectToPage("./Index");
        }
    }
}
