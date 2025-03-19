using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
	public class VillaNumberController : Controller
	{
		public readonly IVillaNumberService _villaNumberService;
		public readonly IMapper _mapper;

		public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
		{
			_villaNumberService = villaNumberService;
			_mapper = mapper;
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
	}
}
