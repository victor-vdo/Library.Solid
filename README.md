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

<strong> DataAccess </strong>
<p align="justify">This directory contains data access implementations, such as repositories (BookRepository, LoanRepository, UserRepository), and the database context (DataContext). Each of these files is responsible for handling specific operations related to data access for their respective entities. For instance, BookRepository is responsible solely for operations related to books in the database, such as creating, reading, updating, or deleting books.</p>

<strong> Interfaces </strong>
<p align="justify">This directory contains abstractions (interfaces) for different parts of the system, such as repositories (IBookRepository, ILoanRepository, IUserRepository), and presentations (IBookPresentation, ILoanPresentation, IUserPresentation). Each of these interfaces represents an abstract contract defining a specific set of responsibilities to be implemented by concrete classes.</p>

<strong> Models </strong>
<p align="justify">This directory holds domain entities, such as the Book, Loan, and User classes. These classes represent the system's data and should not contain complex business logic. Their responsibility is primarily to store entity-related data.</p>

<strong> Services </strong>
<p align="justify">This directory contains classes responsible for domain services. For instance, BookService is responsible for orchestrating operations related to books, utilizing the book repository to access data.</p>

<strong> Presentation </strong>
<p align="justify">This directory encompasses presentation classes like BookPresentation, which handle user interaction or the exposure of data specific to a certain interface type (e.g., console, web).</p>

When following the SRP:
- Each class or component should have a well-defined single responsibility.
- Changes in one responsibility should not affect other responsibilities within the system.
- Classes should be cohesive, meaning all methods and attributes should be related to the class's single responsibility.

### O: Open/Closed Principle (OCP)
- <p align="justify"> Classes that inherit from Model can override the GenerateId method to implement custom Id generation strategies, keeping the Model class open for extension, without the need to directly modify the base class. Therefore, this model respects the Open/Closed Principle (OCP): </p>

```c#
        protected virtual void GenerateId()
        {
            Id = Guid.NewGuid();
        }
```


### L: Liskov Substitution Principle (LSP)
<p align="justify">The Liskov Substitution Principle (LSP) states that objects of a derived class should be usable wherever objects of its base class are expected, without altering the expected behavior of the program. This means that derived classes should be substitutable for base classes without causing unintended side effects or violating preconditions, post-conditions, and invariants established by the base classes, thus maintaining system consistency.</p>

- <p align="justify">In this project, all data access, service, and presentation classes inherit from an interface. They implement the methods defined in the interface and maintain the expected semantics of these methods, ensuring that objects of types like BookRepository, for instance, can be used instead of the IBookRepository interface without altering the system's behavior.</p>

```c#
    public interface IBookRepository
    {
        Book GetById(Guid id);
        ...
    }

    public class BookRepository : IBookRepository
    {
        ...
        public Book GetById(Guid id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);
            return book;
        }
        ....
    }
```



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


