using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace MagicVilla_VillaAPI.Controllers
{
    [Route("/api/VillaNumberAPI")]
    [ApiController]
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
            this._response = new();
            _dbVilla = dbVilla;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumbers = await _dbVillaNumber.GetAllAsyc(includeProperties: "Villa");
                _response.Result = _mapper.Map<List<VillaNumberDto>>(villaNumbers);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.MessageErrors = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villaNumber = await _dbVillaNumber.GetAsyc(x => x.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.MessageErrors =
                    new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberCreateDto)
        {
            try
            {
                if (await _dbVillaNumber.GetAsyc(u => u.VillaNo == villaNumberCreateDto.VillaNo) != null)
                {
                    ModelState.AddModelError("MessageErrors", "Villa already Exists");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                }

                if (await _dbVilla.GetAsyc(u => u.Id == villaNumberCreateDto.VillaId) == null)
                {
                    ModelState.AddModelError("MessageErrors", "Villa does not exist or villa id is not valid");
                    return BadRequest(ModelState);
                }


                if (villaNumberCreateDto == null)
                {
                    return BadRequest(villaNumberCreateDto);
                }
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaNumberCreateDto);
                await _dbVillaNumber.CreateAsyc(villaNumber);

                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaNumber", new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.MessageErrors = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{villaNo:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int villaNo, [FromBody] VillaNumberUpdateDto villaUpdateDto)
        {
            try
            {
                if (villaUpdateDto == null || villaNo != villaUpdateDto.VillaNo)
                {
                    return BadRequest();
                }
                if (await _dbVilla.GetAsyc(u => u.Id == villaUpdateDto.VillaId) == null)
                {
                    ModelState.AddModelError("MessageErrors", "Villa does not exist or villa id is not valid");
                    return BadRequest(ModelState);
                }


                VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaUpdateDto);
                await _dbVillaNumber.UpdateAsync(villaNumber);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.MessageErrors =
                    new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{villaNo:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int villaNo)
        {
            try
            {
                if (villaNo == 0)
                {
                    return BadRequest();
                }
                var villaNumber = await _dbVillaNumber.GetAsyc(u => u.VillaNo == villaNo);
                if (villaNumber == null)
                {
                    return NotFound();
                }
                _dbVillaNumber.RemoveAsyc(villaNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.MessageErrors =
                    new List<string> { ex.ToString() };
            }
            return _response;
        }


    }
}