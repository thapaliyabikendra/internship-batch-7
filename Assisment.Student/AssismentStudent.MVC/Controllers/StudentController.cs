using AssismentStudent.MVC.Models;
using Microsoft.AspNetCore.Mvc;


using Newtonsoft.Json;
using System.Reflection;
using System.Text;
namespace AssismentStudent.MVC.Controllers;


public class StudentController : Controller
{
    Uri baseAddress = new Uri("https://localhost:7056/api");

    private readonly HttpClient _client;

    public StudentController()
    {
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;
        _client.DefaultRequestHeaders.Add("X-Api-Key", "MySecretApiKey");
    }
    public IActionResult Index()
    {
        List<StudentViewModel> students = new List<StudentViewModel>();
        HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/student/Get").Result;

       

        if (respone.IsSuccessStatusCode)
        {
            string data=respone.Content.ReadAsStringAsync().Result;
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<StudentViewModel>>>(data);
            if (apiResponse != null && apiResponse.Success)
            {
                students = apiResponse.Data;
            }

        }
        return View(students);


    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateStudentViewModel model)
    {
        try
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/student/Create", content).Result;

            if (respone.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Student Created";
                return RedirectToAction("Index");

            }
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            throw;
        }
       
        return View();
    }


    [HttpGet]
    public IActionResult Delete(int id) 
    
    {
        try
        {
            StudentViewModel student=new StudentViewModel();
            

            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress+"/student/GetStudentById/"+id).Result;

            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<StudentViewModel>>(data);
                if (apiResponse != null && apiResponse.Success)
                {
                    student = apiResponse.Data;
                }

            }
            return View(student);
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            throw;
        }
        
    }

    [HttpPost,ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)

    {
        try
        {
            
            HttpResponseMessage respone = _client.DeleteAsync(_client.BaseAddress + "/student/Delete/" + id).Result;

            if (respone.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Successfullt deleted";
                return RedirectToAction("Index");

            }
            return View();
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            throw;
        }

    }
}
