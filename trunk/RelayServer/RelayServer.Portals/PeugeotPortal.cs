using Newtonsoft.Json;
//using RelayServer.DataContext;
using RelayServer.Helpers;
using RelayServer.Interfaces;
using RequestHandlers;
using RequestHandlers.Extensions;
using RequestHandlers.Handlers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RelayServer.Portals
{
	public class PeugeotPortal : BrandPortal
    {
        private static readonly object AutorizeLock;

        private static readonly CookieContainer CookieContainer;

        static PeugeotPortal()
		{
            PeugeotPortal.AutorizeLock = new object();
            PeugeotPortal.CookieContainer = new CookieContainer();
        }

		public override void OpenSession(string url, long providerId, bool forceSession)
		{
            string url_session = url;
            int validateSession = -1;

            if (!((validateSession = GetValidateSession(url_session, forceSession, PeugeotPortal.CookieContainer)) == 0)) {
			    string login = string.Empty
			        , password = string.Empty;

                if (validateSession < 0) {
                    using (AvtoritetEntities ae = new AvtoritetEntities()) {
                        string sql =
                            //string.Format("SELECT TOP (1) dbo.ProviderAccount.Login, dbo.ProviderAccount.Password{0}"
                            //    + " FROM dbo.Provider{0}"
                            //    + " INNER JOIN dbo.ProviderAccount ON dbo.Provider.ProviderId = dbo.ProviderAccount.ProviderId{0}"
                            //    + " WHERE(dbo.Provider.Uri LIKE N'%peugeot%') AND(dbo.ProviderAccount.Enable = 1)"
                            //    , "\r\n")
                            GetQueryCreditionals(providerId)
                            ;

                        ProvAcc provider = ae.Database.SqlQuery<ProvAcc>(sql, new object[0]).FirstOrDefault<ProvAcc>();
                        login = provider.Login;
                        password = provider.Password;
                    }

                    this.m_requestHandler = RequestHandlerFactory.Create(url_session, login, password, null);
                } else
                    ;
            } else
                ;

            HttpResponseMessage responseMessage = this.GetResponse(url_session, providerId, validateSession, this.m_requestHandler, PeugeotPortal.CookieContainer);
            if (responseMessage != null) {
                this.m_requestHandler.GetSessionResultAsync(responseMessage);
            } else
                ;
		}

        //public override void CloseSession()
        //{
        //    CloseSession(/*CatalogApi.UrlConstants.PeugeotLogoutTo, m_requestHandler,*/ CookieContainer);
        //}

        public override void CloseSession()
        {
            CloseSession(/*url, m_requestHandler,*/ CookieContainer);
        }

        public override HttpResponseMessage GetResponse(string url, long providerId, int validateSession, IRequestHandler reqHandler, CookieContainer container)
		{
            HttpResponseMessage resHttpResponseMessage;
            string url_session = string.Empty;
            bool error_session = false;

            lock (PeugeotPortal.AutorizeLock) {
                ConsoleHelper.Debug("CITROEN");

                url_session = url;

                if (validateSession == 1) {
                    CloseSession();
                } else
                    ;

                if (!(validateSession == 0)) {
                    resHttpResponseMessage = reqHandler.OpenSessionAsync(url_session, container);

                    error_session = this.SessionHasError(resHttpResponseMessage);

                    if (error_session == false) {
                        ConsoleHelper.Info(string.Format("Url Navigation to open session: {0}, RequestUri={1}, StatusCode={2}"
                            , url_session
                            , resHttpResponseMessage.RequestMessage.RequestUri.AbsoluteUri
                            , resHttpResponseMessage.StatusCode));

                        base.OpenSession(url_session, providerId, validateSession == 1);

                        return resHttpResponseMessage;
                    } else
                        ;

                    ConsoleHelper.Error(string.Format("Open session error: url={0}, StatusCode={1}"
                        , resHttpResponseMessage.RequestMessage.RequestUri.AbsoluteUri
                        , resHttpResponseMessage.StatusCode));
                } else
                {

                // ��� ������� force ��� �� force, �� ������ ���������� ����!
                //if (forceSession == true) {
                    // url ��� ������������� ������
                    url_session =
                        // "http://public.servicebox.peugeot.com/docpr/"
                        url
                        ;

                    Task<HttpResponseMessage> session2 = reqHandler.GetSessionAsync(url_session, container);
                    session2.Wait();
                    resHttpResponseMessage = session2.Result;

                    error_session = this.SessionHasError(resHttpResponseMessage);

                    if (error_session == false) {
                        ConsoleHelper.Info(string.Format("Url Navigation to confirmed session: {0}, RequestUri={1}, StatusCode={2}"
                            , url_session
                            , resHttpResponseMessage.RequestMessage.RequestUri.AbsoluteUri
                            , resHttpResponseMessage.StatusCode));

                        return resHttpResponseMessage;
                    } else
                        ;

                    ConsoleHelper.Warning(string.Format("Confirmed session error: url={0}, RequestUri={1}, StatusCode={2}"
                        , url_session
                        , resHttpResponseMessage.RequestMessage.RequestUri.AbsoluteUri
                        , resHttpResponseMessage.StatusCode));

                    CloseSession();

                    // url ��� �����-��������� ������ - ��������� ��� (��. ����, ��� ���������� �����������)
                    url_session = url;

                    resHttpResponseMessage = reqHandler.OpenSessionAsync(url_session, container);

                    error_session = this.SessionHasError(resHttpResponseMessage);

                    if (error_session == false) {
                        ConsoleHelper.Info(string.Format("Url Navigation to reopen-forced session: {0}, RequestUri={1}, StatusCode={2}"
                            , url_session
                            , resHttpResponseMessage.RequestMessage.RequestUri.AbsoluteUri
                            , resHttpResponseMessage.StatusCode));

                        base.OpenSession(url_session, providerId, false);

                        return resHttpResponseMessage;
                    } else
                        ;

                    ConsoleHelper.Error(string.Format("Reopen-forced session error: url={0}, StatusCode={1}"
                        , resHttpResponseMessage.RequestMessage.RequestUri.AbsoluteUri
                        , resHttpResponseMessage.StatusCode));
                }
                //else
                //    ;

                ConsoleHelper.Error("Session obtained faulty");
            }

            return null;
        }

        protected override bool SessionHasError(HttpResponseMessage responseMessage)
		{
			HttpStatusCode statusCode = responseMessage.StatusCode;
			return statusCode != HttpStatusCode.OK
                || responseMessage.RequestMessage.RequestUri.AbsoluteUri.Contains("index.jsp");
		}

        public override string GetCookies(string url)
        {
            return BrandPortal.GetCookies(url, CookieContainer, false);
        }
    }
}
