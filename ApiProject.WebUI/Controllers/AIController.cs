using ApiProject.WebUI.GeminiAIHelper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace ApiProject.WebUI.Controllers
{
    public class AIController : Controller
    {


        [HttpGet]
        public IActionResult CreateRecipeWithGemini()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeWithGemini([FromForm] string prompt)
        {
            // Eğer kullanıcı boş gönderirse uyar
            if (string.IsNullOrWhiteSpace(prompt))
            {
                ViewBag.RecipeResult = "Lütfen bir tarif isteği giriniz.";
                return View();
            }
            prompt = $"Cevap adım adım olsun, kısa ve öz, HTML formatında geri dön. Şu malzemelerle bir yemek tarifi oluştur:{prompt}";
            var geminiMessage = await GeminiHelper.GenerateRecipeAsync(prompt);
            ViewBag.RecipeResult = geminiMessage;
            return View();
        }
    }
}
