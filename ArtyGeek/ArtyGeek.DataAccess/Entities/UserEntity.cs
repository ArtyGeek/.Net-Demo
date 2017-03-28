using ArtyGeek.DataAccess.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataAccess.Entities
{
    public class UserEntity : DeletablePersistentEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Guid ImageId { get; set; }

        public List<UserEntity> Friends { get; set; }
    }
}
