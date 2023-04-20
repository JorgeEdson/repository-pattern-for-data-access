using Domain.Entities.Base;


namespace Domain.Entities
{
    public class ThirdEntity : BaseEntity
    {
        public List<MainEntity> MainEntities { get; set; }
        public decimal SpecificProperty { get; set; }
    }
}
