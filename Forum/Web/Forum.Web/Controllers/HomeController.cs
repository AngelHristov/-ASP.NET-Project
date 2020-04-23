namespace Forum.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Net.Mail;

    using Forum.Services.Data;
    using Forum.Web.ViewModels;
    using Forum.Web.ViewModels.ContactUs;
    using Forum.Web.ViewModels.Home;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>(null);

            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult ContactUs(ContactViewModel vm)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email); // Email which you are getting from contact us page

                    msz.To.Add("emailaddrss@gmail.com"); // Where mail will be sent
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential(
                    "youremailid@gmail.com", "password");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    this.ModelState.Clear();
                    this.ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    this.ModelState.Clear();
                    this.ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
