using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registration_Form.Data;
using Registration_Form.Ioc.Repository;
using Registration_Form.Models;

namespace Registration_Form.Controllers
{
    public class SignupController : Controller
    {
        private IUserRepository _userRepository;
        public SignupController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(User signup)
        {
            if (!ModelState.IsValid)
            {
                return View(signup);
            }
            if (_userRepository.IsExistByUserName(signup.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "This username account had been registered");
                return View(signup);
            }
            if (_userRepository.IsExistByEmail(signup.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "This email account had been registered");
                return View(signup);
            }

            User user = new User()
            {
                UserName = signup.UserName.ToLower(),
                Email = signup.Email.ToLower(),
                Password = signup.Password,
                RePassword = signup.RePassword,
                RegisterDate = DateTime.Now,
            };
            _userRepository.AddUser(user);

            return Redirect("/Signup/Signup");
        }
    }
}
