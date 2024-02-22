using System.Linq.Expressions;
using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid>ids);
    
    ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    
}