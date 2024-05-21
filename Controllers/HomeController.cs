using HRMS.Models;
using HRMS.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork unitofworks;
        public HomeController(IUnitOfWork unitofworks)
        {
            this.unitofworks = unitofworks;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

        /*---------------------------------------------Project-----------------------------------------------------*/
        public IActionResult ViewProject()
        {
            var Project = unitofworks.project.GetAll().ToList();
            return View(Project);
        }


        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProject(Project obj)
        {

            if(obj is not null)
            {

                var Pj = new Project()
                {

                    ProjectName = obj.ProjectName,
                    ProjectDescription = obj.ProjectDescription,
                    ProjectProgress = 0,
                    ProjectLeader = obj.ProjectLeader,
                    Estimatedbudget = obj.Estimatedbudget,
                    Totalamountspent = obj.Totalamountspent,
                    Estimatedprojectduration = obj.Estimatedprojectduration,
                    Status = obj.Status,
                    ClientCompany = obj.ClientCompany,
                    CreatedDate = DateTime.Now



                };

                unitofworks.project.Add(Pj);
                unitofworks.Save();


                return RedirectToAction("ViewProject","Home");
            }


            return View();
        }


        public IActionResult Editproject(int id)
        {
            var project = unitofworks.project.GetById(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult Editproject(Project OBJ)
        {
            var project = unitofworks.project.GetById(OBJ.id);

            if(project is not null)
            {

                project.ProjectName = OBJ.ProjectName;
                project.ProjectDescription = OBJ.ProjectDescription;
                project.ProjectLeader = OBJ.ProjectLeader;
                project.Status = OBJ.Status;
                project.Estimatedbudget = OBJ.Estimatedbudget;
                project.Totalamountspent = OBJ.Totalamountspent;
                project.ClientCompany = OBJ.ClientCompany;
                project.CreatedDate = project.CreatedDate;
                project.ProjectProgress = OBJ.ProjectProgress;



                unitofworks.project.Update(project);
                unitofworks.Save();

                return RedirectToAction("ViewProject", "Home");

            }

            return View();
        }

        [HttpGet]
        public IActionResult ProjectDetail(int id)
        {
            var project = unitofworks.project.GetById(id);
            return View(project);
        }
    }
}
