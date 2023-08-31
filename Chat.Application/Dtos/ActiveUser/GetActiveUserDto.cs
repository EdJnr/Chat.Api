using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Dtos.ActiveUser
{
    public class GetActiveUserDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime LastActive { get; set; }
    }
}
