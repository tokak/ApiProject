﻿using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult SendChatWithAI()
        {
            return View();
        }
    }
}
