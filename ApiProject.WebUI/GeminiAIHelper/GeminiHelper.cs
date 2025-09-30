using System.Text.Json.Nodes;

namespace ApiProject.WebUI.GeminiAIHelper
{
    public static class GeminiHelper
    {
        private static readonly string GeminiApiKey = "AIzaSyAmRq43QdrKevLKjieb6jQ9elVS20sVZ0o";
        private static readonly string GeminiModel = "gemini-2.5-flash";
        private static readonly string GeminiApiBaseUrl = "https://generativelanguage.googleapis.com/v1beta/models";
        /// <summary>
        /// Verilen malzemelerle bir yemek tarifi oluşturur (HTML formatında kısa ve adım adım).
        /// </summary>
        public static async Task<string> GenerateRecipeAsync(string prompt)
        {
            var requestUrl = $"{GeminiApiBaseUrl}/{GeminiModel}:generateContent?key={GeminiApiKey}";
            using var client = new HttpClient();

            var requestData = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = $" {prompt}"
                            }
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

                    return text ?? "Yanıt alınamadı.";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return $"<p><strong>API Hatası:</strong> {response.StatusCode}</p><pre>{errorContent}</pre>";
                }
            }
            catch (Exception ex)
            {
                return $"<p><strong>İstek sırasında bir hata oluştu:</strong> {ex.Message}</p>";
            }
        }
    }
}

