﻿using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/v{Version:apiVersion}/UserAuth")]
    [ApiController]
    [ApiVersionNeutral]


    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private APIResponse _response;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.MessageErrors.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = loginResponse;
            return Ok(_response);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
            bool isUniqueUser = _userRepo.isUniqueUser(model.UserName);
            if (!isUniqueUser)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.MessageErrors.Add("User already exists");
                return BadRequest(_response);
            }
            var user = await _userRepo.Register(model);
            if (user == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.MessageErrors.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
