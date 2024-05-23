using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork unitofworks;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IUnitOfWork unitofworks, IWebHostEnvironment _webHostEnvironment)
        {
            this.unitofworks = unitofworks;
            this._webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpGet]
        public IActionResult CreateRole()
        {
            var roles = unitofworks.Roles.GetAll().ToList();

            return View(roles);
        }


        [HttpPost]
        public IActionResult CreateRole(Roles role)
        {
            if (ModelState.IsValid)
            {
                var newRole = new Roles
                {
                    RoleName = role.RoleName,
                    Description = role.Description
                };

                unitofworks.Roles.Add(newRole);
                unitofworks.Save();
                return RedirectToAction("CreateRole");
            }
            return View();
        }


        [HttpGet]
        public IActionResult AssignRoles()
        {
            var users = unitofworks.Users.GetAll().ToList();

            return View(users);
       
        }

        [HttpGet]
        public IActionResult AssignUserRoles(int id)
        {
            var roles = unitofworks.Roles.GetAll().ToList();
            var user = unitofworks.Users.GetById(id);
               

            ViewBag.Roles = roles;

            return View(user);
        }


        [HttpPost]
        public IActionResult AssignUserRoles(UserRole userRole)
        {
            if (ModelState.IsValid)
            {

                var existingUserRole = unitofworks.UserRole.GetByEmail(userRole.Email);
               
                if (existingUserRole != null)
                {
                    existingUserRole.RoleType = userRole.RoleType;
                    unitofworks.UserRole.Update(existingUserRole);
                }
                else
                {
                    unitofworks.UserRole.Add(userRole);
                }

                unitofworks.Save();
                return RedirectToAction("AssignRoles");
            }
            return View(userRole);
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


        /*---------------------------------------------Project-----------------------------------------------------*/


        /*---------------------------------------------Recrutiment-----------------------------------------------------*/

        [HttpGet]
        public IActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCandidate(Rec_Candidate obj, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string candidateName = obj.Firstname + "_" + obj.Lastname;
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string extension = Path.GetExtension(file.FileName);
                    string filename = candidateName + "_" + timestamp + extension;
                    string ResumePath = Path.Combine(wwwRootPath, @"Resume");

                    using (var fileStream = new FileStream(Path.Combine(ResumePath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    var cand = new Rec_Candidate
                    {
                        Firstname = obj.Firstname,
                        Lastname = obj.Lastname,
                        Email = obj.Email,
                        Resumeurl = @"\Resume\" + filename,
                        Address = obj.Address,
                        Phone = obj.Phone,
                        Experince = obj.Experince
                    };


                    unitofworks.Candidate.Add(cand);
                    unitofworks.Save();


                    return RedirectToAction("Index", "Home");

                }

            }
            return View();
        }

    }
}
