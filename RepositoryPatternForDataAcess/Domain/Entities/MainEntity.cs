using Domain.Entities.Base;

namespace Domain.Entities
{
    public class MainEntity : BaseEntity
    {
        public Guid SecondEntityId { get; private set; }
        public SecondEntity SecondEntity { get; private set; }
        public Guid ThirdEntityId { get; set; }
        public ThirdEntity ThirdEntity { get; set; }
        public List<FourthEntity> FourthEntities { get; private set; }
        public int SpecificProperty { get; private set; }

        public MainEntity(int paramSpecificProperty, string paramName):base(Guid.NewGuid())
        {
            SetName(paramName);
            SetCreationDate();
            SpecificProperty = paramSpecificProperty;
        }

        public void SetSecondEntity(SecondEntity paramSecondEntity) 
        {
            SecondEntityId = paramSecondEntity.Id;
            SecondEntity = paramSecondEntity;
        }

        public void SetThirdEntity(ThirdEntity paramThirdEntity)
        {
            ThirdEntityId = paramThirdEntity.Id;
            ThirdEntity = paramThirdEntity;
        }

        public void AddFourthEntity(FourthEntity paramFourthEntity) 
        {
            FourthEntities.Add(paramFourthEntity);            
        }

        public void RemoveFourthEntity(FourthEntity paramFourthEntity) 
        { 
            FourthEntities.Remove(paramFourthEntity);
        }
    }
}
