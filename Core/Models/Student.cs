using System;

namespace Core.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime Started { get; set; }

        public ProjectStatus Status { get; set; }
        
    }
    
    public enum ProjectStatus
    {
        Active,
        Inactive,
        Completed
    }
}