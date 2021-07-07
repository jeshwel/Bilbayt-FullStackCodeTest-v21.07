using AutoMapper;
using FullStackCodeTest.BLL.Contracts;
using FullStackCodeTest.BLL.DTOs;
using FullStackCodeTest_v21_07.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace FullStackCodeTest_v21_07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService UserService, IMapper Mapper)
        {
            userService = UserService;
            mapper = Mapper;
        }
       
        /// <summary>
        /// Get user info.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = userService.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="User"></param>
        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Post(UserVM user)
        {
            var result = userService.Register(mapper.Map<UserDTO>(user));
            return Ok(result);
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginVM user)
        {
            var result = userService.Login(user.UserName, user.Password);
            return Ok(result);
        }
    }
}
