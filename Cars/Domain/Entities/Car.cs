using Cars.Domain.Base;
using Cars.Domain.Enums;
using Cars.Domain.Interfaces;

namespace Cars.Domain.Entities
{
    public class Car : EntityId, IUpdatable<Car>
    {
        public string PlateNumber { get; set; }

        public MakeEnum Make { get; set; }
        public string Model { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

        public void Update(Car entity)
        {
            Make = entity.Make;
            Model = entity.Model;
            UserId = entity.UserId;
        }
    }
}