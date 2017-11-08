using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoRespect.WebApp.Components
{
    public class Header : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
