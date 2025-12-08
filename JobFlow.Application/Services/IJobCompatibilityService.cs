using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobFlow.Domain.Entities;

namespace JobFlow.Application.Services
{
    public interface IJobCompatibilityService
    {
        void Evaluate(Job job);
    }
}
