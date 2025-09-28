using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarForInlineAdminLayoutComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
