using Domain.Entities.Base;

namespace Domain.Entities
{
    public class FourthEntity : BaseEntity
    {
        public List<MainEntity> MainEntities { get; set; }
        public byte SpecificProperty { get; set; }
    }
}
