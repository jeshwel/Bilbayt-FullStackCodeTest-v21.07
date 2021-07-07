using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FullStackCodeTest.BLL.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        [JsonIgnore] //attribute prevents the password property from being serialized and returned in api responses.
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
