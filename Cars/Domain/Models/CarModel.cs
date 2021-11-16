using Cars.Domain.Base;
using Cars.Domain.Enums;

namespace Cars.Domain.Models
{
    public class CarModel : ModelId
    {
        public string PlateNumber { get; set; }
        public MakeEnum Make { get; set; }
        public string Model { get; set; }
        public UserModel User { get; set; }
    }
}