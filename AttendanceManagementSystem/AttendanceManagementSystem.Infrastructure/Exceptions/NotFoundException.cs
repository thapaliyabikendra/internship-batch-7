using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Infrastructure.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "Requested resource is not found")
        : base(message) { }
}
