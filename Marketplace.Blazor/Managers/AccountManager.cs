using Blazored.LocalStorage;
using Marketplace.Blazor.Models.Account;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Marketplace.Blazor.Managers;

public class AccountManager
{
    private CreateUserModel? _crateUserModel = new CreateUserModel();
    private LoginUserModel? _loginUserModel = new LoginUserModel();
    private HttpClient _httpClient;
    private ILocalStorageService _storage;
    private NavigationManager _navigationManager;



    public AccountManager(HttpClient httpClient, ILocalStorageService storage, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _storage = storage;
        _navigationManager = navigationManager;
    }

    private async Task Register()
    {
        var response = await _httpClient.PostAsJsonAsync("/account/register", _crateUserModel);

        if (response.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/index");
        }
    }

    private async Task Login()
    {
        var response = await _httpClient.PostAsJsonAsync("/account/login", _loginUserModel);
        var token = await response.Content.ReadAsStringAsync();
        await _storage.SetItemAsStringAsync("token", token);
        if (response.IsSuccessStatusCode)
        {

            var result = await response.Content.ReadFromJsonAsync<LoginResult>();
            if (!string.IsNullOrEmpty(result?.Token))
            {
                await _storage.SetItemAsStringAsync("token", result.Token);
                _navigationManager.NavigateTo("/index");
            }
        }

    }


    //User user = new User();
    //protected override async Task OnInitializedAsync()
    //{
    //    var token = await _storage.GetItemAsStringAsync("token");
    //    var request = new HttpRequestMessage(HttpMethod.Get, "/account/profile");
    //    request.Headers.Add("Authorization", $"Bearer {token}");
    //    var respones = await _httpClient.SendAsync(request);
    //    user = await respones.Content.ReadFromJsonAsync<User>();
    //}



}
public class LoginResult
{
    public string Token { get; set; }
}