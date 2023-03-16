using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double num1, double num2, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    ViewBag.Message = "Invalid operation";
                    break;
            }
            ViewBag.Result = result;

            return View();

        }
    }
}
