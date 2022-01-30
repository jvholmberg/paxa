namespace Paxa.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        // Refresh token time to live (in days), inactive tokens are
        // automatically deleted from the database after this time
        public int RefreshTokenTTL { get; set; }
    }
}
