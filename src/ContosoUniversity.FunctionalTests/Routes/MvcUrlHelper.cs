using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using ContosoUniversity.FunctionalTests.Fakes;

namespace ContosoUniversity.FunctionalTests.Routes
{
    public class MvcUrlHelper
    {
        private readonly RouteCollection _routeCollection;

        public MvcUrlHelper(RouteCollection routeCollection)
        {
            _routeCollection = routeCollection;
        }

        /// <summary>
        /// Gets the relative URL for the specified controller action.
        /// </summary>
        /// <param name="action">The controller action
        /// The action.
        /// </param>
        /// <typeparam name="TController">The generic parameter for the Controller class.
        /// </typeparam>
        /// <returns>
        /// The relative URL in the form '/Home/About'>.
        /// </returns>
        public string GetRelativeUrlFor<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            var requestContext = new RequestContext(FakeHttpContext.Root(), new RouteData());

            var actionRouteValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action);
            var urlHelper = new UrlHelper(requestContext, _routeCollection);
            var relativeUrl = urlHelper.RouteUrl(new RouteValueDictionary(actionRouteValues));

            return relativeUrl;
        }
    }
}
