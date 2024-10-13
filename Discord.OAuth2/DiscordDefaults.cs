namespace Discord.OAuth2
{
    public static class DiscordDefaults
    {
        public const string AuthenticationScheme = "Discord";
        public const string DisplayName = "Discord";
        
        public static readonly string AuthorizationEndpoint = "https://oauth-openshift.apps-crc.testing/oauth/authorize";
        public static readonly string TokenEndpoint = "https://oauth-openshift.apps-crc.testing/oauth/token";
        public static readonly string UserInformationEndpoint = "https://discordapp.com/api/users/@me";
    }
}
