# SSO-POC

A small .NET Framework console app that signs a user in with Microsoft Entra ID (Azure AD) through
MSAL (`Microsoft.Identity.Client`) and prints an access token for Microsoft Graph.

## Run

Register an app in Entra ID (public client, redirect URI `https://localhost:44387/signin-oidc`), then:

```
set SSO_CLIENT_ID=<application (client) id>
set SSO_TENANT_ID=<directory (tenant) id>
msbuild SSO-POC.sln -restore -p:RestorePackagesConfig=true
SSO-POC\bin\Debug\SSO-POC.exe
```

No secret is needed: the interactive flow uses a public client. Never put IDs, secrets or tokens in source.
