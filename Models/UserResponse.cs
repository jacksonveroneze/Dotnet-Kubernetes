using System;

namespace DotnetRedis.Models
{
    public class UserResponse
    {
        public string Login { get; set; }

        public int Id { get; set; }

        public string AvatarUrl { get; set; }

        public string GravatarId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public object Email { get; set; }

        public string Bio { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}