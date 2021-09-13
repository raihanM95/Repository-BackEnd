using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Controllers
{
	[Route("")]
	[Route("Home")]
	[ApiController]
	//[Authorize]
	public class HomeController : ControllerBase
	{
		private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
		public HomeController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
		{
			_actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
		}

		[Route("")]
		[Route("Index")]
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			// get all available routes
			var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(ad => ad.AttributeRouteInfo != null).OrderBy(x => x.AttributeRouteInfo.Template).ToList();

			// build response content
			var sb = new StringBuilder();
			sb.Append($@"<html><head><meta charset='utf-8'><title>Routes</title>
				<style>
				p, li {{
					font-family: 'Verdana', sans-serif;
					font-weight: 600;
				}}
				.val {{
						font-family: 'Courier New', Courier, monospace;
						margin:10;
				}}
                table {{
                        border-collapse: collapse;
                }}
                table, th, td {{
                        border: 1px solid black;
                }}
				</style>
				</head><body>");
			sb.Append($"<p>{routes.Count} routes found<p>");
			sb.Append("<table><tr><th> URL Endponits </th><th> Controller </th><th> Action </th><th> Allowed Methods </th> </tr>");
			foreach (var route in routes)
			{
				var allowedMethods = string.Empty;
				foreach (var actionConstraintMetadata in route.ActionConstraints)
				{
					if (actionConstraintMetadata is HttpMethodActionConstraint acm)
					{
						allowedMethods = string.Join(", ", acm.HttpMethods);
					}
				}
				route.RouteValues.TryGetValue("action", out var action);
				route.RouteValues.TryGetValue("controller", out var controller);
				sb.Append($" <tr><td> {route.AttributeRouteInfo.Template} </td><td> {controller} </td><td> {action} </td><td> {allowedMethods} </td> </tr>");

			}

			sb.Append("</table></body></html>");

			var content = sb.ToString();

			return new ContentResult
			{
				Content = content,
				ContentType = "text/html"
			};
		}
	}
}
