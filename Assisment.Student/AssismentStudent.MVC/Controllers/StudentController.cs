using AssismentStudent.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography;
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
    //public IActionResult Index()
    //{
    //    List<StudentViewModel> students = new List<StudentViewModel>();
    //    HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/student/Get").Result;



    //    if (respone.IsSuccessStatusCode)
    //    {
    //        string data = respone.Content.ReadAsStringAsync().Result;
    //        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<StudentViewModel>>>(data);
    //        if (apiResponse != null && apiResponse.Success)
    //        {
    //            students = apiResponse.Data;
    //        }

    //    }
    //    return View(students);


    //}


    //[HttpGet]
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult Create(CreateStudentViewModel model)
    //{
    //    try
    //    {
    //        string data = JsonConvert.SerializeObject(model);
    //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

    //        HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/student/Create", content).Result;

    //        if (respone.IsSuccessStatusCode)
    //        {
    //            TempData["successMessage"] = "Student Created";
    //            return RedirectToAction("Index");

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        TempData["errorMessage"] = ex.Message;
    //        throw;
    //    }

    //    return View();
    //}


    //[HttpGet]
    //public IActionResult Delete(int id)

    //{
    //    try
    //    {
    //        StudentViewModel student = new StudentViewModel();


    //        HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/student/GetStudentById/" + id).Result;

    //        if (respone.IsSuccessStatusCode)
    //        {
    //            string data = respone.Content.ReadAsStringAsync().Result;
    //            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<StudentViewModel>>(data);
    //            if (apiResponse != null && apiResponse.Success)
    //            {
    //                student = apiResponse.Data;
    //            }

    //        }
    //        return View(student);
    //    }
    //    catch (Exception ex)
    //    {
    //        TempData["errorMessage"] = ex.Message;
    //        throw;
    //    }

    //}

    //[HttpPost, ActionName("Delete")]
    //public IActionResult DeleteConfirmed(int id)

    //{
    //    try
    //    {

    //        HttpResponseMessage respone = _client.DeleteAsync(_client.BaseAddress + "/student/Delete/" + id).Result;

    //        if (respone.IsSuccessStatusCode)
    //        {
    //            TempData["successMessage"] = "Successfullt deleted";
    //            return RedirectToAction("Index");

    //        }
    //        return View();
    //    }
    //    catch (Exception ex)
    //    {
    //        TempData["errorMessage"] = ex.Message;
    //        throw;
    //    }

    //}

    protected string RenderPartialView(string viewName, ICompositeViewEngine _viewEngine, object model = null)
    {
        if (string.IsNullOrEmpty(viewName))
            viewName = ControllerContext.ActionDescriptor.ActionName;

        ViewData.Model = model;

        using (var writer = new StringWriter())
        {
            ViewEngineResult viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

            ViewContext viewContext = new ViewContext(
                ControllerContext,
                viewResult.View,
                ViewData,
                TempData,
                writer,
                new HtmlHelperOptions()
            );

            viewResult.View.RenderAsync(viewContext);

            return writer.GetStringBuilder().ToString();
        }
    }
    public IActionResult Index()
    {
        List<StudentViewModel> students = new List<StudentViewModel>();
        HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/student/Get").Result;



        if (respone.IsSuccessStatusCode)
        {
            string data = respone.Content.ReadAsStringAsync().Result;
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<StudentViewModel>>>(data);
            if (apiResponse != null && apiResponse.Success)
            {
                students = apiResponse.Data;
            }

        }
        return View(students);
    }


    [HttpGet]

    public IActionResult Get([FromServices] ICompositeViewEngine viewEngine)
    {
        try
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/student/Get").Result;
            if (response.IsSuccessStatusCode)
            {

                string data = response.Content.ReadAsStringAsync().Result;


                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<StudentViewModel>>>(data);


                if (apiResponse == null)
                    return Json(new { success = false, message = "Invalid API response." });

                if (!apiResponse.Success)
                    return Json(new { success = false, message = apiResponse.Message });

                
                string html = RenderPartialView("_student_list", viewEngine, apiResponse.Data);

                return Json(new
                {
                    success = true,
                    message = html 
                });
            }
            else
            {
               
                return Json(new { success = false, message = "Failed to fetch students from API." });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }

    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateStudentViewModel model)
    {
        if (model == null)
        {
            return Json(new { success = false, message = "Invalid data." });
        }
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
        catch (Exception ex)
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
            // Call your API to delete
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/student/Delete/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                // Return JSON success
                return Json(new { success = true, message = "Student deleted successfully!" });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete student." });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }


    [HttpGet]
    public IActionResult GetById(int id)
    {
        try
        {
           

            
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Student/GetStudentById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                
                string data = response.Content.ReadAsStringAsync().Result;

                
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<StudentViewModel>>(data);

                
                if (apiResponse != null && apiResponse.Success)
                    return Json(new { success = true, data = apiResponse.Data });
                else
                    return Json(new { success = false, message = apiResponse.Message });
            }
            else
            {
                return Json(new { success = false, message = "Failed to fetch student." });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Update([FromBody] StudentViewModel model)
    {
        try
        {
            var jsonData = new
            {
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                Gender = model.Gender
            };

            string data = JsonConvert.SerializeObject(jsonData);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var id = model.Id;
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Student/Update/" + id, content).Result;
            var respData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
               
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<StudentViewModel>>(respData);

                if (apiResponse != null && apiResponse.Success)
                    return Json(new { success = true, message = apiResponse.Message });

                return Json(new { success = false, message = apiResponse.Message});
            }

            return Json(new { success = false, message = respData});
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }


}
