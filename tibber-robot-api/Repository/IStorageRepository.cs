using tibber_robot_api.Data;
using tibber_robot_api.Models;

namespace tibber_robot_api.Repository
{
    /// <summary>
    /// Interface for Storage to DB
    /// </summary>
    public interface IStorageRepository
    {
        bool StoreExecutionToDb(ResultDbContext context, ref CleaningCommandResponse response);

        bool StoreExecutionToDb();
    }
}
