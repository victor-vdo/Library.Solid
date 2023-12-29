# SOLID
<p align="justify">The SOLID principles encompass a set of five software design principles intended to foster the development of more flexible, extensible, and maintainable systems. The acronym represents each principle: S for Single Responsibility Principle, O for Open/Closed Principle, L for Liskov Substitution Principle, I for Interface Segregation Principle, and D for Dependency Inversion Principle.</p>

<p align="justify">SOLID emphasizes modularity, cohesion, abstraction, and reduced interdependency among system components. It promotes the creation of reusable, testable, and easily maintainable code.</p>

<p align="justify">This project aims to refactor an older codebase, aiming to rewrite it while adhering to the SOLID principles:</p>

[Library Console Project](https://github.com/victor-vdo/Library) 
 

### S: Single Responsibility Principle (SRP)
<p align="justify"> The Single Responsibility Principle (SRP) is one of the fundamental principles of SOLID. It emphasizes that a class should have only one reason to change, meaning it should have only one responsibility.</p>

- <p align="justify"> The Model class follow SRP as its primary responsibility is to generate an Id for the classes that inherit from it. It doesn't assume multiple responsibilities beyond that. </p>

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

- <p align="justify"> The project structure reflects the separation of responsibilities into different areas: DataAccess, Interfaces, Models, Presentation, Services, and Utils. Each folder has a specific set of responsibilities, which is aligned with the Single Responsibility Principle (SRP).</p>

```
LibrarySolid
└── DataAccess
└── Interfaces
└── Models
└── Presentation
└── Services
└── Utils
└── Program.cs
```

- - DataAccess
<p align="justify">This directory contains data access implementations, such as repositories (BookRepository, LoanRepository, UserRepository), and the database context (DataContext). Each of these files is responsible for handling specific operations related to data access for their respective entities. For instance, BookRepository is responsible solely for operations related to books in the database, such as creating, reading, updating, or deleting books.</p>

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


