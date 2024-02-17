
using System.Text;
using TradeXEcommerce.Client.Helper;
using TradeXEcommerce.Shared.DTO;

namespace TradeXEcommerce.Client.Services.ImplementationServices;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorageService;
    }

    public async Task<LoginStatus> Login(LoginModel loginModel)
    {
        var loginAsJson = JsonSerializer.Serialize(loginModel);
        var response = await _httpClient.PostAsync("api/authentication/Login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

        var loginResult = JsonSerializer.Deserialize<LoginStatus>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

        if (!response.IsSuccessStatusCode)
            return loginResult!;

        await _localStorage.SetItemAsync("autheToken", loginResult!.Token);
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult.Token!);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

        return loginResult;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<RegisterStatus> Register(RegisterModel registerModel)
    {
        var result = await _httpClient.PostAsJsonAsync("api/authentication/register", registerModel);
        if (!result.IsSuccessStatusCode)
            return new RegisterStatus { Successful = false, Errors = new List<string> { "Error occured"} };
        return new RegisterStatus { Successful = true, Errors = new List<string> { "Account created successfully" } };
    }
}
