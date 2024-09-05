﻿using System.ComponentModel;

namespace App_Application.Concretes.VMs
{
    public class ProfileVM
    {
        public string Email { get; set; }

        [DisplayName("Ad")]
        public string? FirstName { get; set; }
        [DisplayName("Soyad")]
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
