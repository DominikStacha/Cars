using System.Collections.Generic;
using Cars.Domain.Base;

namespace Cars.Domain.Entities
{
    public class User : EntityId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}