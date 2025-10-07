using AttendanceManagementSystem.Shared.Dtos;
using AttendanceManagementSystem.Shared.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceManagementSystem.Web.Controllers;

public class UserController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public UserController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient("AttendanceApi");
        var response = await client.GetAsync("User/all");
        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Error = "Unable to fetch users.";
            return View();
        }
        var result = await response.Content.ReadFromJsonAsync<
            ServiceResponseDto<IEnumerable<UserDto>>
        >();

        if (result == null || !result.IsSuccess || result.Data == null)
        {
            ViewBag.Error = result?.Message;
            return View();
        }

        return View(result.Data);
    }
}
