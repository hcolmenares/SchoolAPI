﻿using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string District { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? SecureType { get; set; }
        public string EPS { get; set; }
        public string SisbenNumber { get; set; }
        public string DocumentNumber { get; set; }
        public string? Email { get; set; }
        public string TutorId { get; set; }
        public string SchoolId { get; set; }
    }
}
