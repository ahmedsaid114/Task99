using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
