using Domain.Entities.Base;

namespace Domain.Entities
{
    public class SecondEntity : BaseEntity
    {
        public Guid MainEntityId { get; set; }
        public string SpecificProperty { get; set; }
    }
}
