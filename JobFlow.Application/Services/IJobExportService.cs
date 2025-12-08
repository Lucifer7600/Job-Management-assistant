using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFlow.Application.Services
{
    public interface IJobExportService
    {
        Task<byte[]> ExportJobsToExcelAsync();
    }
}
