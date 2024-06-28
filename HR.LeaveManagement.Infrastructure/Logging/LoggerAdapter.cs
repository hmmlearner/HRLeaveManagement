using HR.LeaveManagement.Application.Contracts.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _loggerFactory;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
                _loggerFactory = loggerFactory.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args)
        {
            _loggerFactory.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _loggerFactory.LogWarning(message, args);
        }
    }
}
