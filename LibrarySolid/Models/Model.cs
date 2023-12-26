namespace LibrarySolid.Models
{
    public abstract class Model
    {
        public Guid Id { get; protected set; }

        protected Model()
        {
            GenerateId();
        }

        // Classes that inherit from Model can override the GenerateId 
        // method to implement custom Id generation strategies,
        // keeping the Model class open for extension, 
        // without the need to directly modify the base class. 
        // Therefore, this model respects the Open/Closed Principle(OCP)
        protected virtual void GenerateId()
        {
            Id = Guid.NewGuid();
        }
    }
}