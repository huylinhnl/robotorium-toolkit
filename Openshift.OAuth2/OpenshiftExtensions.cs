
using System;
using Microsoft.AspNetCore.Authentication;
using Discord.OAuth2;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiscordAuthenticationOptionsExtensions
    {
        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder)
            => builder.AddDiscord(OpenshiftDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder, Action<OpenshiftOptions> configureOptions)
            => builder.AddDiscord(OpenshiftDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder, string authenticationScheme, Action<OpenshiftOptions> configureOptions)
            => builder.AddDiscord(authenticationScheme, OpenshiftDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<OpenshiftOptions> configureOptions)
            => builder.AddOAuth<OpenshiftOptions, OpenshiftHandler>(authenticationScheme, displayName, configureOptions);
    }
}