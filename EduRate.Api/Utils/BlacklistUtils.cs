namespace EduRate.Api.Utils
{
    public static class BlacklistUtils
    {
        public static readonly HashSet<string> BlacklistedTokens = new HashSet<string>();

        public static void BlacklistToken(string token)
        {
            BlacklistedTokens.Add(token);
        }
    }
}