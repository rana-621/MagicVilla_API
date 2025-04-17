using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace MagicVilla_VillaAPI.Controllers.v2
{
    [Route("api/v{Version:apiVersion}/VillaNumberAPI")]
    //[Route("/api/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class VillaNumberAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IMapper mapper, IVillaRepository dbVilla)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _response = new();
            _dbVilla = dbVilla;
        }

        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}