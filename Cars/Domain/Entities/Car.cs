using Cars.Domain.Base;
using Cars.Domain.Enums;
using Cars.Repository.Validators;

namespace Cars.Domain.Entities
{
    public class Car : EntityId
    {
        [PlateValidator] public string PlateNumber { get; set; }

        public MakeEnum Make { get; set; }
        public string Model { get; set; }
        public User User { get; set; }
    }
}