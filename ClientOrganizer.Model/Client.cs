using System;
using System.ComponentModel.DataAnnotations;

namespace ClientOrganizer.Model
{
    public class Client
    {
        //[Key] ClientId
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = default!;
        [StringLength(50)]
        public string LastName { get; set; } = default!;
        [StringLength(65)]
        public string Email { get; set; } = default!;
    }
}
