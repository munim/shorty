using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Shorty.Data.Managers;

namespace Shorty.Mvc.Controllers
{
    public class ShortnerController : AsyncController
    {
        //
        // GET: /Shortner/
        public async Task<ActionResult> Redirect(string shortUrl)
        {
            var urlManager = new UrlManager();

            var longUrl = await urlManager.GetLongUrl(shortUrl);

            if (string.IsNullOrWhiteSpace(longUrl))
            {
                var result = RedirectToAction("Index", "Home");
                result.ExecuteResult(ControllerContext);
                return null;
            }

            var redirectPermanent = RedirectPermanent(longUrl);
            redirectPermanent.ExecuteResult(ControllerContext);
            return null;
        }
	}
}