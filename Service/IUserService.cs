namespace OfficerEngagement.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}