# SOLID

<p align="justify">The SOLID principles represent a set of five software design principles aimed at creating more flexible, extensible, and maintainable systems. The acronym stands for each of these principles: S for Single Responsibility Principle, O for Open/Closed Principle, L for Liskov Substitution Principle, I for Interface Segregation Principle, and D for Dependency Inversion Principle.</p>
<p align="justify">SOLID encourages modularity, cohesion, abstraction, and low dependency among system components, promoting reusable, testable, and easily maintainable code.</p>

### S: Single Responsibility Principle (SRP)

### O: Open/Closed Principle (OCP)
<p align="justify"> Classes that inherit from Model can override the GenerateId method to implement custom Id generation strategies, keeping the Model class open for extension, without the need to directly modify the base class. Therefore, this model respects the Open/Closed Principle (OCP). </p>

```c#
    public abstract class Model
    {
        public Guid Id { get; protected set; }

        protected Model()
        {
            GenerateId();
        }

        protected virtual void GenerateId()
        {
            Id = Guid.NewGuid();
        }
    }
```


### L: Liskov Substitution Principle (LSP)

### I: Interface Segregation Principle (ISP)

### D: Dependency Inversion Principle (DIP)
