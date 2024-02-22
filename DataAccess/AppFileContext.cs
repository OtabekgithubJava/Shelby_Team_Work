using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.FileContext;
using System;
using FileBaseContext.Context.Models.Configurations;
using WebApplication2.Models;

namespace WebApplication2.DataAccess
{
    public class AppFileContext : FileContext, IDataContext
    {
        public IFileSet<User, Guid> Users { get; set; }

        public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions, IFileSet<User, Guid> users) : base(fileContextOptions)
        {
            Users = users;
        }
    }
}