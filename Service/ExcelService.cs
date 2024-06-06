using HRMS.Data;
using HRMS.Models;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace HRMS.Service
{
    public class ExcelService
    {
        private readonly ApplicationDbContext _context;

        public ExcelService(ApplicationDbContext _context)
        {
            this._context = _context;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task UploadExcelFile(string id, string name,Stream fileStream)
        {
            using (var package = new ExcelPackage(fileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Read Employee Code and Name from the first row
                var employeeCode = id;
                var employeeName = name;

                // Read Data starting from the third row
                for (int row = 3; row <= worksheet.Dimension.End.Row; row++)
                {
                    var employeeData = new EmployeeData
                    {
                        EmployeeCode = employeeCode,
                        EmployeeName = employeeName,
                        AttendanceDate = worksheet.Cells[row, 1].Text,
                        Shift = worksheet.Cells[row, 2].Text,
                        ScheduledInTime = worksheet.Cells[row, 3].Text,
                        ScheduledOutTime = worksheet.Cells[row, 4].Text,
                        ActualInTime = worksheet.Cells[row, 5].Text,
                        ActualOutTime = worksheet.Cells[row, 6].Text,
                        WorkDuration = worksheet.Cells[row, 7].Text,
                        Overtime = worksheet.Cells[row, 8].Text,
                        TotalDuration = worksheet.Cells[row, 9].Text,
                        LateBy = worksheet.Cells[row, 10].Text,
                        EarlyGoingBy = worksheet.Cells[row, 11].Text,
                        Status = worksheet.Cells[row, 12].Text,
                        PunchRecords = worksheet.Cells[row, 13].Text,
                        // Map additional columns as needed
                    };
                    _context.EmployeeDatas.Add(employeeData);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
