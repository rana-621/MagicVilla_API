using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models.VM;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        public readonly IVillaNumberService _villaNumberService;
        public readonly IVillaService _villaService;
        public readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
            _villaService = villaService;
        }

        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDto> list = new();
            var response = await _villaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<ActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVM = new();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });

            }
            return View(villaNumberVM);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
        //        if (response != null && response.IsSuccess)
        //        {
        //            return RedirectToAction(nameof(IndexVillaNumber));
        //        }
        //        else
        //        {
        //            if (response.MessageErrors.Count > 0)
        //            {
        //                ModelState.AddModelError("MessageErrors", response.MessageErrors.FirstOrDefault());
        //            }
        //        }
        //    }

        //    var resp = await _villaService.GetAllAsync<APIResponse>();
        //    if (resp != null && resp.IsSuccess)
        //    {
        //        model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
        //            (Convert.ToString(resp.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.Name,
        //                Value = i.Id.ToString()
        //            }); ;
        //    }
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    // تحقق من رسائل الخطأ في MessageErrors
                    if (response.MessageErrors != null && response.MessageErrors.Count > 0)
                    {
                        ModelState.AddModelError("MessageErrors", response.MessageErrors.FirstOrDefault());
                    }
                    // تحقق من الـ Result لو فيه ModelState من الـ API
                    if (response.Result != null && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errorDetails = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(Convert.ToString(response.Result));
                        foreach (var error in errorDetails)
                        {
                            foreach (var message in error.Value)
                            {
                                ModelState.AddModelError(error.Key, message);
                            }
                        }
                    }
                }
            }

            // اعادة تعبئة VillaList
            var resp = await _villaService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(resp.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
            }
            return View(model);
        }
    }
}