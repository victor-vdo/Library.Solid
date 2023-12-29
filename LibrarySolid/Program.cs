using LibrarySolid.DataAccess;
using LibrarySolid.DataAccess.Repositories;
using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Presentations;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Models;
using LibrarySolid.Presentation;
using LibrarySolid.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
           .AddDbContext<IDataContext, DataContext>()
           
           .AddSingleton<IBookPresentation, BookPresentation>()
           .AddTransient<IBookService, BookService>()
           .AddTransient<IBookRepository, BookRepository>()

           //.AddSingleton<ILoanPresentation, LoanPresentation>()
           //.AddTransient<ILoanService, LoanService>()
           //.AddTransient<ILoanRepository, LoanRepository>()

           //.AddSingleton<IUserPresentation, UserPresentation>()
           //.AddTransient<IUserService, UserService>()
           //.AddTransient<IUserRepository, UserRepository>()

           .BuildServiceProvider();

// Resolvendo a dependência
var bookPresentation = serviceProvider.GetService<IBookPresentation>();
var loanPresentation = serviceProvider.GetService<ILoanPresentation>();
var userPresentation = serviceProvider.GetService<IUserPresentation>();

var main = new Main(bookPresentation, loanPresentation, userPresentation);
main.Start();