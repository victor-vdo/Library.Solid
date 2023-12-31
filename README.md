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
<p align="justify">The Open/Closed Principle (OCP) states that software entities (classes, modules, functions, etc.) should be open for extension but closed for modification. This principle encourages designing systems in a way that allows new functionalities to be added through extension, without altering existing code. By relying on abstraction, inheritance, and polymorphism, the OCP aims to promote code that can be easily extended with new features or behaviors, reducing the need for changes in the existing codebase.</p>

- <p align="justify"> Classes that inherit from Model can override the GenerateId method to implement custom Id generation strategies, keeping the Model class open for extension, without the need to directly modify the base class. Therefore, this model respects the Open/Closed Principle (OCP): </p>

```c#
        protected virtual void GenerateId()
        {
            Id = Guid.NewGuid();
        }
```

- <p align="justify"> A repository class, for example, can be extended for new functionalities without modifying its existing source code. This can be achieved by adding new methods to the repository interface and implementing these methods in a new class, thereby keeping the current class closed for modifications.</p>

- <p align="justify">When discussing extensibility without modifying existing code, it typically means that changes are made in a way that doesn’t alter the functioning of existing methods or affect existing classes that depend on that interface.</p>

- <p align="justify">In the context of extensibility, the idea would be that if new methods were added to the interface, other classes relying on that interface wouldn’t immediately need changes to keep functioning as before. They would still be able to use the existing methods without modifications but would have the option to implement the new interface methods as needed.</p>

- <p align="justify">So, while adding methods to an interface does require changes in the classes implementing it, the idea of extensibility is more about ensuring that changes don’t negatively impact existing code, allowing for the introduction of new behaviors or functionalities without breaking the already implemented code</p>


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
        ...
    }
```


### I: Interface Segregation Principle (ISP)
<p align="justify">The Interface Segregation Principle (ISP) emphasizes that clients should not be forced to depend on interfaces they do not use entirely. It advocates breaking down larger interfaces into smaller, more specific ones, each catering to a distinct set of functionalities. This principle aims to prevent unnecessary dependencies by providing tailored interfaces, allowing clients to interact with only the methods relevant to their needs. By doing so, it promotes a more cohesive and adaptable design, enabling easier maintenance and reducing the impact of changes in the system.</p>

- <p align="justify">By dividing responsibilities into separate interfaces such as IBookRepository and ILoanRepository, each interface encapsulates a specific set of methods related to handling particular functionalities within the system. This segregation enables clients to selectively depend on interfaces that cater to their specific requirements. As a result, clients are not compelled to implement or rely on functionalities they do not need. This practice aligns with the Interface Segregation Principle (ISP), promoting a more focused, cohesive, and adaptable design. It facilitates the creation of interfaces tailored to distinct responsibilities, allowing for easier maintenance, extension, and usage across various parts of the system without unnecessary dependencies or implementations.</p>

- <p align="justify">In the project context, all methods within the interfaces are utilized within the same flow of each repository. 
 However, if at any point in the system, a client requires only a specific subset of these methods, they would be compelled to depend on the complete interface, including methods that are irrelevant to their needs. 
 In this scenario, it might be advantageous to divide this interface into smaller, more specific interfaces, each with a more cohesive purpose related to a specific set of operations. For example:</p>

```c#
public interface IBookQueryRepository
{
    Book GetById(Guid id);
    List<Book> GetByAuthor(string author);
    Book GetByTitle(string title);
    List<Book> GetByYear(string year);
    List<Book> GetAll();
    List<Book> GetAllActive();
}

public interface IBookCommandRepository
{
    bool Add(Book book);
    bool Update(Book book);
    bool RemoveById(Guid id);
}
```
For the scope of this project, it wasn't necessary to perform this division, but it's a potential separation to be done in other contexts and/or architectures. 
### D: Dependency Inversion Principle (DIP)
<p align="justify">The Dependency Inversion Principle (DIP) advocates that high-level modules/classes should not depend on low-level modules/classes directly. Instead, both should depend on abstractions. This principle promotes the use of interfaces or abstract classes to decouple modules and create flexible systems. By relying on abstractions, it allows for easier modification, extension, and testing, fostering a more adaptable and maintainable codebase while reducing tight coupling between different parts of the system.</p>

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


