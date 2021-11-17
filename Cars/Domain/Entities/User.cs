using System.Collections.Generic;
using Cars.Domain.Base;
using Cars.Domain.Interfaces;

namespace Cars.Domain.Entities
{
    public class User : EntityId, IUpdatable<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Car> Cars { get; set; }

        public void Update(User entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Email = entity.Email;
        }
    }
}