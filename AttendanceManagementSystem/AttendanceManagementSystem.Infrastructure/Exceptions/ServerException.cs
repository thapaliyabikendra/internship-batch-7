using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Infrastructure.Exceptions;

public class ServerException : Exception
{
    public ServerException(string message = "server is not responding, sorry for the inconvenience")
        : base(message) { }
}
