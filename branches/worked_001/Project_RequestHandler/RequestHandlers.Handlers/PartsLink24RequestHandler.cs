using RequestHandlers.Helpers;
using RequestHandlers.Requests;
using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestHandlers.Handlers
{
	public class PartsLink24RequestHandler : IRequestHandler
	{
		public const string Pl24Sessionid = "PL24SESSIONID";

		public const string Pl24LoggedInTrail = "pl24LoggedInTrail";

		private readonly string login;

		private readonly string password;

		public PartsLink24RequestHandler(string login, string password)
		{
			this.login = login;
			this.password = password;
		}

		public bool SessionHasEnded(string url, CookieContainer cookieContainer)
		{
			return this.NeedAuthorization(url, cookieContainer);
		}

		public bool NeedAuthorization(string url, CookieContainer cookieContainer)
		{
			CookieCollection cookies = cookieContainer.GetCookies(new Uri(url));
			if (cookies.Count > 0)
			{
				PartsLink24RequestHandler.PrintCookies(cookies);
			}
			return cookies.Count == 0 || cookies["pl24LoggedInTrail"] == null;
		}

		public async Task Close(CookieContainer cookieContainer)
		{
			await HttpProxyServer.SendRequest(PartsLink24RequestFactory.CreateLogoutRequest(), cookieContainer);
		}

		public async Task<string> GetSessionResultAsync(HttpResponseMessage responseMessage)
		{
			return await responseMessage.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
		}

		public async Task<HttpResponseMessage> GetSessionAsync(string url, CookieContainer cookieContainer)
		{
			return await HttpProxyServer.SendRequest(RequestFactory.CreateGetRequest(url), cookieContainer);
		}

		public async Task<HttpResponseMessage> OpenSessionAsync(CookieContainer cookieContainer)
		{
			return await HttpProxyServer.SendRequest(PartsLink24RequestFactory.CreateLoginRequest(this.login, this.password), cookieContainer);
		}

		private static void PrintCookies(IEnumerable cookies)
		{
			foreach (Cookie cookie in cookies)
			{
				ConsoleHelper.Trace(string.Format("Cookie {0}={1}", cookie.Name, cookie.Value));
			}
		}
	}
}
