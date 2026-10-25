using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace SSO_POC
{
    /// <summary>
    /// Signs a user in interactively with Microsoft Entra ID (Azure AD) through MSAL and returns an access token.
    /// A public client: no client secret is used or needed for the interactive flow.
    /// </summary>
    public class SSOUtility
    {
        private readonly IPublicClientApplication _client;
        private readonly string[] _scopes;

        public SSOUtility(string clientId, string tenantId, string redirectUri, string[] scopes)
        {
            _client = PublicClientApplicationBuilder.Create(clientId)
                .WithTenantId(tenantId)
                .WithRedirectUri(redirectUri)
                .Build();

            _scopes = scopes;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var result = await _client.AcquireTokenInteractive(_scopes).ExecuteAsync();
            Console.WriteLine(result.AccessToken);
            return result.AccessToken;
        }
    }
}
