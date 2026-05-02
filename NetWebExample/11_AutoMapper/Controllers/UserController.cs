using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _11_AutoMapper.Controllers
{
    public class UserController:Controller
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            User user = new User()
            {
                Id = 1,
                FirstName = "Erkan",
                LastName = "Türk",
                Email = "erkanturk@gmail.com"
            };
            var userDto = _mapper.Map<UserDto>(user);
            return View(userDto);//DataTransferObject
        }
    }
}
