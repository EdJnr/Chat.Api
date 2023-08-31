using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Dtos.ActiveUser
{
    public class UpdateActiveUserDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime LastActive { get; set; }
    }
}
