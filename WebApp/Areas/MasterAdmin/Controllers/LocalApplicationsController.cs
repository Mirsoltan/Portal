using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HomeEntities;
using Data.UnitOfWork;
using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using ViewModels.DynamicAccess;
using ViewModels.HomeViewModels;
using System.IO;

namespace WebApp.Areas.MasterAdmin.Controllers
{
    [Area("MasterAdmin")]
    [DisplayName("مدیریت فاوا|لیست لینکهای صفحه اصلی")]

    public class LocalApplicationsController : Controller
    {
        private readonly IUnitOfWork _Uw;
        private readonly IWebHostEnvironment _env;

        public LocalApplicationsController(IUnitOfWork Uw, IWebHostEnvironment env)
        {
            _Uw = Uw;
            _env = env;
        }

        //[Authorize(Policy = ConstantPolicies.DynamicPermission)]
        [DisplayName("مشاهده لینکها ")]
        public async Task<IActionResult> Index()
        {
            var lp = await _Uw.BaseRepository<LocalApplications>().FindAllAsync();
            List<LocalApplicationsIndexedViewModels> model = new List<LocalApplicationsIndexedViewModels>();
            

            foreach (var item in lp)
            {
                LocalApplicationsIndexedViewModels lvm = new LocalApplicationsIndexedViewModels
                {
                    //DeleteBy = item.DeleteBy,
                    //Description = item.Description,
                    //DeleteDate = item.DeleteDate,
                    //InsertBy = item.InsertBy,
                    Id = item.LocalAppID,
                    //InsertDate = item.InsertDate,
                    //IsActive = item.IsActive,
                    IsLocalApp = item.IsLocalApp,
                    Title = item.Title,
                    //UpdateBy = item.UpdateBy,
                    //UpdateDate = item.UpdateDate,
                    ApplicationPath = item.ApplicationPath,

                };

                model.Add(lvm);
            }


            return View(model);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localApplications = await _Uw.BaseRepository<LocalApplications>().FindByIdAsync(id);
            if (localApplications == null)
            {
                return NotFound();
            }

            return View(localApplications);
        }

        //[Authorize(Policy = ConstantPolicies.DynamicPermission)]
        [DisplayName("ایجاد لینک")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocalApplicationsCreateViewModels vm)
        {
            //byte[] image = null;
            if (ModelState.IsValid)
            {
                string FileExtension = Path.GetExtension(vm.File.FileName);
                string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension);
                var path = $"{_env.WebRootPath}/images/LocalApplications/{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await vm.File.CopyToAsync(stream);
                }

                vm.ImageName = NewFileName;
                LocalApplications model = new LocalApplications
                {
                    Title = vm.Title.Trim(),
                    //InsertBy = "",
                    //InsertDate = DateTime.Now,
                    //Description = vm.Description,
                    //IsActive = true,
                    IsLocalApp = vm.IsLocalApp,
                    ApplicationPath = vm.ApplicationPath,
                };

                if (vm.ImageName != null)
                {
                    model.ImageName = vm.ImageName;
                }

                //if (vm.Image != null)
                //{
                //    using (var memorySteam = new MemoryStream())
                //    {
                //        await vm.Image.CopyTo(memorySteam);
                //        model.Image = memorySteam.ToArray();
                //    }
                //}

                await _Uw.BaseRepository<LocalApplications>().CreateAsync(model);
                await _Uw.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        //[Authorize(Policy = ConstantPolicies.DynamicPermission)]
        [DisplayName("ویرایش لینک")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lp = await _Uw.BaseRepository<LocalApplications>().FindByIdAsync(id);
            if (lp == null)
            {
                return NotFound();
            }
            LocalApplicationsEditViewModels vm = new LocalApplicationsEditViewModels
            {
                Title = lp.Title.Trim(),
                //InsertBy = lp.InsertBy,
                //InsertDate = lp.InsertDate,
                //Description = lp.Description,
                //IsActive = lp.IsActive,
                IsLocalApp = lp.IsLocalApp,
                ApplicationPath = lp.ApplicationPath,
            };

            

            return View(vm);
        }

        // POST: Fava/LocalApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LocalApplicationsEditViewModels model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var me = await _Uw.BaseRepository<LocalApplications>().FindByIdAsync(id);
            if (me == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //me.UpdateBy = User.ToString();
                    //me.UpdateDate = DateTime.Now;
                    //me.IsActive = model.IsActive;
                    me.Title = model.Title;
                    me.Description = model.Description;
                    me.IsLocalApp = model.IsLocalApp;
                    me.ApplicationPath = model.ApplicationPath;

                    _Uw.BaseRepository<LocalApplications>().Update(me);
                    await _Uw.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalApplicationsExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        //[Authorize(Policy = ConstantPolicies.DynamicPermission)]
        [DisplayName("حذف لینک")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localApplications = await _Uw.BaseRepository<LocalApplications>().FindByIdAsync(id);
            if (localApplications == null)
            {
                return NotFound();
            }

            return View(localApplications);
        }

        // POST: Fava/LocalApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localApplications = await _Uw.BaseRepository<LocalApplications>().FindByIdAsync(id);
            _Uw.BaseRepository<LocalApplications>().Delete(localApplications);
            await _Uw.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalApplicationsExists(int id)
        {
            if (_Uw.BaseRepository<LocalApplications>().FindByIdAsync(id) != null)
            {
                return true;
            }
            return false; ;
        }
    }
}
