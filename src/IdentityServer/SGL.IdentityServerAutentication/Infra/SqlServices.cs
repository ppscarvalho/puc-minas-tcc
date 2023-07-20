
namespace SGL.IdentityServerAutentication.Infra
{
    public class SqlServices
    {
        private readonly IDbInitializer? _dbInitializer;

        public SqlServices(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        public void Init()
        {
            _dbInitializer?.Initialize();
        }
    }
}
