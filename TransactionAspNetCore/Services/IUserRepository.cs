namespace TransactionAspNetCore.Services
{
    public interface IUserRepository
    {
        string GetGithubSearchUsersEndpoint(string location, string sort, string order);
        string GetMostContributedUsers(string url);
    }
}
