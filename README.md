# SOLID

<p align="justify">The SOLID principles represent a set of five software design principles aimed at creating more flexible, extensible, and maintainable systems. The acronym stands for each of these principles: S for Single Responsibility Principle, O for Open/Closed Principle, L for Liskov Substitution Principle, I for Interface Segregation Principle, and D for Dependency Inversion Principle.</p>
<p align="justify">SOLID encourages modularity, cohesion, abstraction, and low dependency among system components, promoting reusable, testable, and easily maintainable code.</p>

<p align="justify">This project aims to refactor an old project with the goal of rewriting it using the SOLID principles:</p>

[Library Console Project](https://github.com/victor-vdo/Library) 
 

### S: Single Responsibility Principle (SRP)
- <p align="justify"> The Model class follow SRP as its primary responsibility is to generate an Id for the classes that inherit from it. It doesn't assume multiple responsibilities beyond that. </p>

https://github.com/orgs/community/discussions/57207

E-commerce
└── my-app
    └── components 
    └── data
    └── pages
    └── public
    └── ...more

### O: Open/Closed Principle (OCP)
- <p align="justify"> Classes that inherit from Model can override the GenerateId method to implement custom Id generation strategies, keeping the Model class open for extension, without the need to directly modify the base class. Therefore, this model respects the Open/Closed Principle (OCP): </p>

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
- <p align="justify">Subclasses that inherit from Model do not have concrete dependencies on low-level modules that directly violate DIP. The dependency is on the generation of the Id, but this is abstracted by calling the GenerateId() method in the Model base class.</p>
- <p align="justify">Initially, the context class was implemented as a parameter in the repository classes. This approach violates the Dependency Inversion Principle, so an interface was created for the context. This approach allows the repository dependencies to be maintained in the IDataContext interface and for the use of custom methods defined in the interface, preserving flexibility and separation between layers.</p>

```c#
  //private readonly DataContext _context;
  private readonly IDataContext _context;
  public BookRepository(IDataContext context)
  {
      _context = context;
  }
```
<p align="justify"> For this, it was necessary to create a new method, SaveChanges, which will be accessed by the repositories. </p>

```c#
  public class DataContext : DbContext, IDataContext
  { 
      void IDataContext.SaveChanges()
      {
          base.SaveChanges();
      }
  ...
```


