using AutoMapper;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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

		public IActionResult Index()
		{
			return View();
		}
	}
}
