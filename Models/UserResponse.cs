using System;

namespace DotnetRedis.Models
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string AvatarUrl { get; set; }

        public string GravatarId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public object Email { get; set; }

        public string Bio { get; set; }

        public DateTime UreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}