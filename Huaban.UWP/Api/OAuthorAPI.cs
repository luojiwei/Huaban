﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Huaban.UWP.Api
{
    using Models;

    public class OAuthorAPI : APIBase
    {
        public OAuthorAPI(IClient client)
            : base(client) { }

        public string RequestToken(SNSType type)
        {
            String url = $"https://huaban.com/oauth/{type.strType}/?auth_callback={Client.OAuthCallback}&client_id={Client.ClientID}&md={Client.MD}";
            return url;
        }

        public override HttpRequestMessage CreateRequest(HttpMethod method, Uri uri, params KeyValuePair<string, string>[] valueNameConnection)
        {
            var request = base.CreateRequest(method, uri, valueNameConnection);
            request.Headers.Add(Client.X_Client_ID, Client.ClientInfo);
            request.Headers.Add(Client.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(Client.ClientInfo)));
            return request;
        }
        public async Task<AuthToken> GetToken(string userName, string password)
        {
            var resphonse = await
                Post(
                    Client.API_TOKEN,
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password)
                );
            return AuthToken.Parse(resphonse);
        }

        public async Task<AuthToken> RefreshToken(AuthToken token)
        {
            try
            {
                var resphonse = await
                    Post(
                        Client.API_TOKEN,
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                        new KeyValuePair<string, string>("refresh_token", token.refresh_token)
                );
                return AuthToken.Parse(resphonse);
            }
            catch { }
            return null;
        }
    }
}
