namespace Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }

        public BaseEntity(Guid paramId)
        {
            Id = paramId;            
        }

        public void SetName(string paramName) 
        { 
            Name = paramName;
        }

        public void SetCreationDate() 
        {
            CreationDate = DateTime.Now;
        }
    }
}