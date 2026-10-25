using System;

namespace SSO_POC
{
    internal class Program
    {
        // Settings come from environment variables, never from source:
        //   SSO_CLIENT_ID     the Azure AD app registration's application (client) ID
        //   SSO_TENANT_ID     the directory (tenant) ID
        //   SSO_REDIRECT_URI  optional; defaults to the local sign-in callback below
        static void Main(string[] args)
        {
            string clientId = Required("SSO_CLIENT_ID");
            string tenantId = Required("SSO_TENANT_ID");
            string redirectUri = Environment.GetEnvironmentVariable("SSO_REDIRECT_URI") ?? "https://localhost:44387/signin-oidc";

            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
            SSOUtility ssoUtility = new SSOUtility(clientId, tenantId, redirectUri, scopes);
            string accessToken = ssoUtility.GetAccessTokenAsync().Result;
        }

        static string Required(string name)
        {
            return Environment.GetEnvironmentVariable(name)
                ?? throw new InvalidOperationException($"Set the environment variable {name}.");
        }
    }
}
