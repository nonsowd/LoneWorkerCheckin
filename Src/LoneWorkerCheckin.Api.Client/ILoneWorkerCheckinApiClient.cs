using LoneWorkerCheckin.Api.Controllers;
using Refit;

namespace LoneWorkerCheckin.Api.Client;

public interface ILoneWorkerCheckinApiClient
{
    [Get("/user")]
    Task<UserResponse> GetUser(string email);
}
