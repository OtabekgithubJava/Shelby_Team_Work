using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileSet;
using WebApplication2.Models;

namespace WebApplication2.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; set; }

    ValueTask SaveChangesAsync();
}