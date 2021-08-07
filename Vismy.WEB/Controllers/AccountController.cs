using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Vismy.Application.DTOs;
using Vismy.Application.Interfaces;
using Vismy.WEB.Models;

namespace Vismy.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> FollowUser(string followingId = null, string followingNickname = null)
        {
            var userId = await _userService.GetUserIdAsync(this.User);

            if ((followingId == null) ||
                (followingNickname == null))
                return RedirectToAction("Index", "Home");

            await _userService.FollowUserAsync(userId, followingId);

            return RedirectToAction("UserInfo", "Home", new { nickname = followingNickname });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditPost(string postId)
        {
            var isSuccess = await _userService.IsUserOwnPostAsync(this.User.Identity.Name, postId);

            if (!isSuccess)
                return RedirectToAction("Index", "Home");

            var post = await _userService.GetPostInfoAsync(postId);

            var model = new PostCreateVM()
            {
                Id = post.Id, 
                Title = post.Title, 
                Description = post.Description, 
                Tags = string.Join(' ', post.Tags)
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPost(PostCreateVM model)
        {
            var postDto = new PostInfoDTO()
            {
                Id = model.Id,
                AuthorId = (await _userService.GetUserIdAsync(this.User)),
                Title = model.Title,
                Description = model.Description,
                Tags = model.Tags.Split()
            };

            var isSuccess = await _userService.UpdatePostAsync(postDto);

            if (isSuccess)
                return RedirectToAction("PostInfo", "Home", new {postId = model.Id});

            ModelState.AddModelError("", "Error with post updating.");

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userService.GetUserInfoAsync(this.User.Identity.Name);

            var model = new UserInfoVM()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Nickname = user.Nickname,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(UserInfoVM model)
        {
            var userDto = new UserInfoDTO()
            {
                Id = await _userService.GetUserIdAsync(this.User),
                Name = model.Name,
                Surname = model.Surname,
                IconPath = model.IconPath,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Nickname = model.Nickname,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber
            };

            var isSuccess = await _userService.UpdateProfileAsync(userDto);

            if (isSuccess)
                return RedirectToAction("UserInfo", "Home", new { nickname = this.User.Identity.Name});

            ModelState.AddModelError("", "Error with user updating.");

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult PostCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCreate(PostCreateVM model)
        {
            var postDto = new PostInfoDTO()
            {
                Id = Guid.NewGuid().ToString(),
                AuthorId = (await _userService.GetUserIdAsync(this.User)),
                Title = model.Title,
                Description = model.Description,
                Tags = model.Tags.Split()
            };

            var isSuccess = await _userService.AddPostAsync(postDto);

            if (isSuccess)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Error with post adding.");

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var userDto = new UserInfoDTO ()
            {
                Id = Guid.NewGuid().ToString(), 
                Email = model.Email, 
                Password = model.Password, 
                Nickname = model.Email, 
                RoleName = "User", 
                IconPath = "default-avatar.jpg"
            };

            var result = await _userService.AddUserAsync(userDto, model.RememberMe);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var identityError in result.Errors)
            {
                ModelState.AddModelError(string.Empty, identityError.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "All fields have to be filled!");
            }

            if (!ModelState.IsValid) return View(model);

            var userDto = new UserInfoDTO() {Email = model.Email, Nickname = model.Email, Password = model.Password, RememberMe = model.RememberMe};

            var result = await _userService.Login(userDto);
                
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorrect data!");

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> ChangeRole(string email, string oldRole, string newRole)
        {
            await _userService.ChangeRole(email, oldRole, newRole);

            return RedirectToAction("Index", "Home");
        }
    }
}
