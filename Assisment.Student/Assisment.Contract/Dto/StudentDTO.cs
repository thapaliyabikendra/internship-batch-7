﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Contract.DTOs;

public class StudentDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}
