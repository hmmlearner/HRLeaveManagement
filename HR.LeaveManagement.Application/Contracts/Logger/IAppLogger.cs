using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Logger
{
    public interface IAppLogger<T>  
    {
        void LogWarning(string message, params object[] args);
        void LogInformation(string message, params object[] args);

    }
}
