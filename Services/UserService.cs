using System.Linq.Expressions;
using FileBaseContext.Abstractions.Models.FileSet;
using WebApplication2.DataAccess;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class UserService: IUserService
{
    private readonly IDataContext _dataContext;

    public UserService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return _dataContext.Users.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids)
    {
        var users = _dataContext.Users.Where(user => ids.Contains(user.Id));
        return new ValueTask<ICollection<User>>(users.ToList());
    }

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = _dataContext.Users.FirstOrDefault(user => user.Id == id);
        return new ValueTask<User?>(user);
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.Users.AddAsync(user);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = _dataContext.Users.FirstOrDefault(searchingUser => searchingUser.Id == user.Id);

        if (user is null)
            throw new InvalidOperationException("User Not Found");

        foundUser.Firstname = user.Firstname;
        foundUser.Lastname = user.Lastname;
        foundUser.Age = user.Age;

        await _dataContext.SaveChangesAsync();
        return foundUser;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(user.Id);
        if (foundUser is null)
            throw new InvalidOperationException();

        await _dataContext.SaveChangesAsync();
        return foundUser;
    }

    public IFileSet<User, Guid> Users { get; set; }
    public async ValueTask SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}