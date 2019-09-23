using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Services.ViewComponents
{
    public class IdiomaViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem()
            {
                Value = "de-DE",
                Text = "Aleman"
            });
            idiomas.Add(new SelectListItem()
            {
                Value = "es-PE",
                Text = "Español"
            }

                );
            idiomas.Add(new SelectListItem()
            {
                Value = "en-US",
                Text = "Ingles"
            }

                );
            idiomas.Add(new SelectListItem()
            {
                Value = "fr-FR",
                Text = "Frances"
            }

                );
            var RequestCultura = HttpContext.Features.Get<IRequestCultureFeature>();
            ViewBag.Idiomas = RequestCultura.RequestCulture.UICulture.Name;
            return View(idiomas);
        }
    }
}
