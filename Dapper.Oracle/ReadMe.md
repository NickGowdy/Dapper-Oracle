This is a class library I've written with Dapper for communicating with Oracle. All you have to do is create a new repo like this:

    public class RepoName : IRepoName
    {
        private readonly IQueryFactory _queryFactory;

        public FooRepo(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }
    }

and you can create methods to get a single record or IEnumerable<T>

	
        public async Task<SomeEntityPocoClass> GetSingleRecord(int fooId)
        {
            var param = new OracleDynamicParameters();
            param.Add("FOOID", fooId, OracleDbType.Int32, ParameterDirection.Input);
            param.Add("cursor_", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            var record = await _queryFactory.QueryFirstOrDefaultAsync<Foo>(UrlConfigurations.GetSingle, param, null, null,
                CommandType.StoredProcedure);
            return record;
        }

      
        public async Task<IEnumerable<SomeEntityPocoClass>> GetIEnumerable<T>()
        {
            var param = new OracleDynamicParameters();
            param.Add("cursor_", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            var record = await _queryFactory.QueryAsync<Foo>(UrlConfigurations.GetAll, param, null, null,
                CommandType.StoredProcedure);
            return record;
        }

The connection string is referenced in the command factory:

		// Replace MyConnectionString with your connection string in web.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

Change "MyConnectionString" to your connection string in web.config or equivalent

:D
