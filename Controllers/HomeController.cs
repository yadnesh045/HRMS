using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

            if (obj is not null)
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


                return RedirectToAction("ViewProject", "Home");
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

            if (project is not null)
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


        //---------------------------------------Adding user -------------------------------------------------//

        [HttpGet]
        public IActionResult AddUser()
        {
            var roles = unitofworks.Roles.GetAll().ToList();
            ViewBag.Roles = roles;

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    EmployeeId = GenerateEmployeeID(),
                    FullName = user.FullName,
                    Contact = user.Contact,
                    DateOfBirth = user.DateOfBirth,
                    AadharNumber = user.AadharNumber,
                    PancardNumber = user.PancardNumber,
                    Email = user.Email,
                    Address = user.Address,


                    PreviousCompanyName = user.PreviousCompanyName,
                    PreviousCompanyJobTitle = user.PreviousCompanyJobTitle,
                    PreviousCompanyJoiningDate = user.PreviousCompanyJoiningDate,
                    PreviousCompanyLeavingDate = user.PreviousCompanyLeavingDate,
                    PreviousCompanyCTC = user.PreviousCompanyCTC,


                    MastersEducation = user.MastersEducation,
                    MastersUniversity = user.MastersUniversity,
                    BachelorsEducation = user.BachelorsEducation,
                    BachelorsUniversity = user.BachelorsUniversity,

                    Role = user.Role,
                    JobDescription = user.JobDescription,
                    CurrentCTC = user.CurrentCTC,
                    HouseRentAllowance = user.HouseRentAllowance,
                    TravelAllowance = user.TravelAllowance,
                    SpecialAllowance = user.SpecialAllowance,

                    BankName = user.BankName,
                    AccountHolderName = user.AccountHolderName,
                    AccountNumber = user.AccountNumber,
                    IFSCCode = user.IFSCCode,
                    BranchName = user.BranchName,

                    Password = GeneratePassword(),
                    ConfirmPassword= user.Password
                };



                if (user.MastersCertificate != null)
                {

                    var file = user.MastersCertificate;
                    var fileName = Guid.NewGuid().ToString() + file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Db_Images", "MastersCertificates", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    newUser.MastersCertificateURL = Path.Combine("/Db_Images", "MastersCertificates", fileName).Replace("\\", "/"); ;


                }
                if (user.BachelorsCertificate != null)
                {
                    var file = user.BachelorsCertificate;
                    var fileName = Guid.NewGuid().ToString() + file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Db_Images", "BachelorsCertificates", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    newUser.BachelorsCertificateURL = Path.Combine("/Db_Images", "BachelorsCertificates", fileName).Replace("\\", "/"); ;

                }
                if (user.Resume != null)
                {
                    var file = user.Resume;
                    var fileName = Guid.NewGuid().ToString() + file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Db_Images", "Resumes", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    newUser.ResumeURL = Path.Combine("/Db_Images", "Resumes", fileName).Replace("\\", "/"); ;

                }
                if (user.AadharCard != null)
                {
                    var file = user.AadharCard;
                    var fileName = Guid.NewGuid().ToString() + file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Db_Images", "AadharCards", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    newUser.AadharCardURL = Path.Combine("/Db_Images", "AadharCards", fileName).Replace("\\", "/"); ;

                }
                if (user.Photo != null)
                {
                    var file = user.Photo;
                    var fileName = Guid.NewGuid().ToString() + file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Db_Images", "Photos", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    newUser.PhotoURL = Path.Combine("/Db_Images", "Photos", fileName).Replace("\\", "/"); ;

                }


                var userRole = new UserRole
                {
                    Email = user.Email,
                    RoleType = user.Role
                };




                unitofworks.Users.Add(newUser);
                unitofworks.UserRole.Add(userRole);
                unitofworks.Save();
                return Json(new
                {
                    success = true,
                    message = "User added successfully"
                });

            }



            return View();
        }

        private int GenerateEmployeeID()
        {
            Random random = new Random();
            int id = random.Next(1000000000, 2000000000);
            return id;
        }

        private string GeneratePassword()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            Random random = new Random();

            // Ensure at least one character from each category
            char[] password = new char[10];
            password[0] = alphabet[random.Next(alphabet.Length)];
            password[1] = numbers[random.Next(numbers.Length)];
            password[2] = symbols[random.Next(symbols.Length)];

            // Fill the rest of the password with random characters from all categories
            string allChars = alphabet + numbers + symbols;
            for (int i = 3; i < password.Length; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle the array to ensure random order
            for (int i = 0; i < password.Length; i++)
            {
                int swapIndex = random.Next(password.Length);
                char temp = password[i];
                password[i] = password[swapIndex];
                password[swapIndex] = temp;
            }

            // Convert to string and trim to the desired length (between 6 and 10)
            int passwordLength = random.Next(6, 11);
            return new string(password).Substring(0, passwordLength);
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

        [HttpGet]
        public IActionResult ManageCandidates()
        {

            var candiates = unitofworks.Candidate.GetAll().ToList();
            return View(candiates);
        }



        [HttpPost]
        public IActionResult ShortList(int id)
        {


            return RedirectToAction("ManageCandidates" , "Home");
        }






    }
}
