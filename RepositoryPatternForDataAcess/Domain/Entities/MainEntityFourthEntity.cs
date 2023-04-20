namespace Domain.Entities
{
    public class MainEntityFourthEntity 
    {
        public Guid MainEntityId { get; set; }
        public MainEntity MainEntity { get; set; }
        public Guid FourthEntityId { get; set; }
        public FourthEntity FourthEntity { get; set; }
        public bool SpecificProperty { get; set; }
    }
}
