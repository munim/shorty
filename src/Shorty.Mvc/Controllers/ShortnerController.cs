using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Shorty.Core.Services;
using Shorty.Data;
using Shorty.Data.Managers;

namespace Shorty.Mvc.Controllers
{
    public class ShortnerController : AsyncController
    {
        private readonly ShortUrlService _shortUrlService;

        public ShortnerController(ShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        //
        // GET: /Shortner/
        public async Task<ActionResult> Redirect(string shortUrl)
        {

            var longUrl = await _shortUrlService.GetLongUrl(shortUrl);

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