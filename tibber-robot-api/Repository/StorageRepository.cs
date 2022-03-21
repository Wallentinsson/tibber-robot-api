using tibber_robot_api.Data;
using tibber_robot_api.Models;

namespace tibber_robot_api.Repository
{
    /// <summary>
    /// Repository for handling the DB
    /// </summary>
    public class StorageRepository : IStorageRepository
    {
        public DatabaseClient _databaseClient { get; set; }

        /// <summary>
        /// Stores the executions to DB
        /// </summary>
        public bool StoreExecutionToDb(ResultDbContext context, ref CleaningCommandResponse response)
        {
            _databaseClient = new DatabaseClient(context);
            return _databaseClient.StoreExecutionToDb(ref response);
        }
        /// <summary>
        /// Empty storage that's not implemented
        /// </summary>
        public bool StoreExecutionToDb()
        {
            throw new System.NotImplementedException();
        }
    }
}
