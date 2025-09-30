using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace ApiProject.WebUI.Controllers
{
    public class AIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string GeminiApiKey = "AIzaSyASzw9tH5uUM5jMZk-olxYnzAk1Goe50tM";
        private readonly string GeminiModel = "gemini-2.5-flash";
        private readonly string GeminiApiBaseUrl = "https://generativelanguage.googleapis.com/v1beta/models";

        public AIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

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

            var requestUrl = $"{GeminiApiBaseUrl}/{GeminiModel}:generateContent?key={GeminiApiKey}";
            var client = _httpClientFactory.CreateClient();

            var requestData = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = $"Şu malzemelerle bir yemek tarifi oluştur: {prompt}" }
                        }
                    }
                }
            };

            try
            {
                var response = await client.PostAsJsonAsync(requestUrl, requestData);

                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    var json = JsonNode.Parse(resultJson);

                    var text = json?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                    ViewBag.RecipeResult = text ?? "Yanıt alınamadı.";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ViewBag.RecipeResult = $"API Hatası: {response.StatusCode}\nDetay: {errorContent}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.RecipeResult = $"İstek sırasında bir hata oluştu: {ex.Message}";
            }

            return View();
        }
    }
}
