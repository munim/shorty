using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Shorty.Mvc.Infrastructure
{
    public class ShortUrlConstraint : IRouteConstraint
    {
        private static readonly Regex _urlPattern = new Regex(@"[\w\-]+", RegexOptions.Compiled);

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.ContainsKey("shortUrl") && !string.IsNullOrWhiteSpace(values["shortUrl"] as string))
                return _urlPattern.IsMatch(values["shortUrl"] as string);
            return false;
        }
    }
}