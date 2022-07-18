using System;

namespace GeoPractice.Models
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateBirthday { get; set; }
        public string RFC { get; set; }
    }
}
