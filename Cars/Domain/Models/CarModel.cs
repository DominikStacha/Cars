using Cars.Domain.Base;
using Cars.Domain.Enums;
using Cars.Repository.Validators;

namespace Cars.Domain.Models
{
    public class CarModel : ModelId
    {
        [PlateValidator]
        public string PlateNumber { get; set; }
        public MakeEnum Make { get; set; }
        public string Model { get; set; }
        public long UserId { get; set; }
        public UserModel? User { get; set; }
    }
}