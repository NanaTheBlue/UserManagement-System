namespace WebApplication1.Repository
{
    public interface ISteamRepository
    {

        Task TrackSteamAccount(string userId, string steamId64);
    }
}
