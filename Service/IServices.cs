using HRMS.Models;

namespace HRMS.Service
{
    public interface IServices
    {   
        public bool SendInterviewEmail(string email, Interview obj);
    }
}
