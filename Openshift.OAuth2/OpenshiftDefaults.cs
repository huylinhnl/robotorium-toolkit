namespace Discord.OAuth2
{
    public static class OpenshiftDefaults
    {
        public const string AuthenticationScheme = "Discord";
        public const string DisplayName = "Discord";
        
        public static readonly string AuthorizationEndpoint = "https://oauth-openshift.apps-crc.testing/oauth/authorize";
        public static readonly string TokenEndpoint = "https://oauth-openshift.apps-crc.testing/oauth/token";
        public static readonly string UserInformationEndpoint = "https://api.crc.testing:6443/apis/user.openshift.io/v1/users/~";
    }
}
