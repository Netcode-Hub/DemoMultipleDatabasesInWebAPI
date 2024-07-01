namespace DemoMultipleDatabasesInWebAPI.Context
{
    public class CompositeDbContext(ProductDbContext productDbContext, UserDbContext userDbContext)
    {
        public readonly ProductDbContext ProductDbContext = productDbContext;
        public readonly UserDbContext UserDbContext = userDbContext;
    }
}
