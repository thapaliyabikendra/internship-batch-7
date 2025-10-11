using System.Reflection;
using AttendanceManagementSystem.Shared.Dtos;
using AttendanceManagementSystem.Shared.Dtos.User;
using AttendanceManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceManagementSystem.Web.Controllers;

public class UserController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public UserController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(UserDto user)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Please provide valid data";
            return View();
        }

        var client = _clientFactory.CreateClient("AttendanceApi");
        var jsonContent = System.Text.Json.JsonSerializer.Serialize(user);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("user", content);
        if (!response.IsSuccessStatusCode)
        {
            TempData["Error"] = "User not created";
            return View(user);
        }
        TempData["Success"] = "User created successfully";
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber)
    {
        var client = _clientFactory.CreateClient("AttendanceApi");

        int pageSize = 4;
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }

        int skipCount = (pageNumber - 1) * pageSize;
        var response = await client.GetAsync(
            $"user/list?SkipCount={skipCount}&MaxResultCount={pageSize}"
        );
        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Error = "Unable to fetch users.";
            return View(new List<GetUserDto>());
        }
        var result = await response.Content.ReadFromJsonAsync<
            ServiceResponseDto<PagedResponseDto<GetUserDto>>
        >();

        if (result == null || !result.IsSuccess || result.Data == null)
        {
            ViewBag.Error = result?.Message;
            return View(new List<GetUserDto>());
        }
        //viewmodel
        var PagedResult = new UserViewModel
        {
            User = result.Data.Items,
            TotalItems = result.Data.TotalCount,
            TotalPages = (int)Math.Ceiling((double)result.Data.TotalCount / pageSize),
            PageIndex = pageNumber,
            PageSize = pageSize
        };

        return View(PagedResult);
    }

    private async Task<ServiceResponseDto<GetUserDto>> Details(string id)
    {
        var client = _clientFactory.CreateClient("AttendanceApi");
        var response = await client.GetAsync($"User/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return new ServiceResponseDto<GetUserDto>
            {
                IsSuccess = false,
                Message = $"API request failed with status code: {response.StatusCode}"
            };
        }

        var result = await response.Content.ReadFromJsonAsync<ServiceResponseDto<GetUserDto>>();
        if (result == null || !result.IsSuccess || result.Data == null)
        {
            return new ServiceResponseDto<GetUserDto>
            {
                IsSuccess = false,
                Message = result?.Message ?? "Unable to fetcch User Details."
            };
        }

        return result;
    }

    public async Task<IActionResult> Delete(string id)
    {
        var userDetail = await Details(id);
        if (!userDetail.IsSuccess)
        {
            TempData["Error"] = userDetail.Message;
            return RedirectToAction(nameof(Index));
        }

        return View(userDetail.Data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var client = _clientFactory.CreateClient("AttendanceApi");

        var response = await client.DeleteAsync($"user/{id}");
        if (!response.IsSuccessStatusCode)
        {
            TempData["Error"] = "Unable to delete user";
            return RedirectToAction(nameof(Index));
        }
        var result = await response.Content.ReadFromJsonAsync<ServiceResponseDto<bool>>();
        if (result == null || !result.IsSuccess)
        {
            TempData["Error"] = result?.Message ?? "Unable to delete user";
            return RedirectToAction(nameof(Index));
        }
        TempData["Success"] = result?.Message ?? "User Deleted Successfully";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(string id)
    {
        var response = await Details(id);
        if (!response.IsSuccess || response.Data == null)
        {
            TempData["Error"] = response.Message;
            return RedirectToAction(nameof(Index));
        }
        var userDetail = new UpdateUserDto
        {
            Name = response.Data.Name,
            PhoneNumber = response.Data.PhoneNumber,
            Id = response.Data.Id,
        };

        return View(userDetail);
    }

    [HttpPost, ActionName("Update")]
    public async Task<IActionResult> UpdateConfirm(UpdateUserDto model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Please provide valid data";
            return View();
        }
        var client = _clientFactory.CreateClient("AttendanceApi");
        var user = new UserDto { Name = model.Name, PhoneNumber = model.PhoneNumber, };
        var jsonContent = System.Text.Json.JsonSerializer.Serialize(user);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"user/{model.Id}", content);

        if (!response.IsSuccessStatusCode)
        {
            TempData["Error"] = "Unable to update user";
            return RedirectToAction(nameof(Index));
        }
        var result = await response.Content.ReadFromJsonAsync<ServiceResponseDto<bool>>();
        if (result == null || !result.IsSuccess)
        {
            TempData["Error"] = result?.Message ?? "Unable to update user";
            return RedirectToAction(nameof(Index));
        }
        TempData["Success"] = result?.Message ?? "User Updated Successfully";
        return RedirectToAction(nameof(Index));
    }
}
