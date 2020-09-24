using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using ViewModels.RoleManager;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index(int page = 1, int row = 10)
        {
            var Roles = _roleManager.Roles.Select(r => new RolesViewModel { RoleID = r.Id, Name = r.Name }).ToList();
            var PagingModel = PagingList.Create(Roles, row, page);
            PagingModel.RouteValue = new RouteValueDictionary
            {
                {"row",row }
            };

            return View(PagingModel);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RolesViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                var Result = await _roleManager.CreateAsync(new IdentityRole(ViewModel.Name));
                if (Result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Error = "در ذخیره اطلاعات خطایی رخ داده است.";
                return View(ViewModel);
            }

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Role = await _roleManager.FindByIdAsync(id);
            if (Role == null)
            {
                return NotFound();
            }

            RolesViewModel RoleVM = new RolesViewModel
            {
                RoleID = Role.Id,
                Name = Role.Name,
            };

            return View(RoleVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(RolesViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                var Role = await _roleManager.FindByIdAsync(ViewModel.RoleID);
                if (Role == null)
                {
                    return NotFound();
                }

                Role.Name = ViewModel.Name;
                var Result = await _roleManager.UpdateAsync(Role);
                if (Result.Succeeded)
                {
                    ViewBag.Message = "alert-success";
                    return View(ViewModel);
                }

                ViewBag.Message = "alert-danger";
                return View(ViewModel);
            }

            return View(ViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Role = await _roleManager.FindByIdAsync(id);
            if (Role == null)
            {
                return NotFound();
            }

            RolesViewModel ViewModel = new RolesViewModel()
            {
                RoleID = Role.Id,
                Name = Role.Name,
            };

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteRole")]
        public async Task<IActionResult> DeletedRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Role = await _roleManager.FindByIdAsync(id);
            if (Role == null)
            {
                return NotFound();
            }

            var Result = await _roleManager.DeleteAsync(Role);
            if (Result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "در حذف اطلاعات خطایی رخ داده است.";

            RolesViewModel ViewModel = new RolesViewModel()
            {
                RoleID = Role.Id,
                Name = Role.Name,
            };

            return View(ViewModel);
        }
    }
}
