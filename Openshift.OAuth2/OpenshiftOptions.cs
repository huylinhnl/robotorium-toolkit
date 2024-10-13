using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RoboToolkit.Components.Pages;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;
using System.Web.Helpers;
using System.Xml.Linq;
using System.Xml;

namespace Discord.OAuth2
{
    /// <summary> Configuration options for <see cref="OpenshiftHandler"/>. </summary>
    public class OpenshiftOptions : OAuthOptions
    {
        /// <summary> Initializes a new <see cref="OpenshiftOptions"/>. </summary>
        public OpenshiftOptions()
        {
            CallbackPath = new PathString("/signin-openshift");
            AuthorizationEndpoint = OpenshiftDefaults.AuthorizationEndpoint;
            TokenEndpoint = OpenshiftDefaults.TokenEndpoint;
            UserInformationEndpoint = OpenshiftDefaults.UserInformationEndpoint;
            //Scope.Add("identify");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id", ClaimValueTypes.UInteger64);
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username", ClaimValueTypes.String);
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email", ClaimValueTypes.Email);
            //ClaimActions.MapJsonKey("urn:discord:discriminator", "discriminator", ClaimValueTypes.UInteger32);
            //ClaimActions.MapJsonKey("urn:discord:avatar", "avatar", ClaimValueTypes.String);
            //ClaimActions.MapJsonKey("urn:discord:verified", "verified", ClaimValueTypes.Boolean);

            //The provided identity of type 'System.Security.Claims.ClaimsIdentity' is marked IsAuthenticated = true but does not have a value for Name.By default, the antiforgery system requires that all authenticated identities have a unique Name.If it is not possible to provide a unique Name for this identity, consider extending IAntiforgeryAdditionalDataProvider by overriding the DefaultAntiforgeryAdditionalDataProvider or a custom type that can provide some form of unique identifier for the current user.


        }

        /// <summary> Gets or sets the Discord-assigned appId. </summary>
        public string AppId { get => ClientId; set => ClientId = value; }
        /// <summary> Gets or sets the Discord-assigned app secret. </summary>
        public string AppSecret { get => ClientSecret; set => ClientSecret = value; }
    }
}
