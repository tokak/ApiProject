using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _HeadAdminLayoutComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
