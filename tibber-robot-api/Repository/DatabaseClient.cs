using System;
using tibber_robot_api.Data;
using tibber_robot_api.Models;

namespace tibber_robot_api.Repository
{
    /// <summary>
    /// Client for communication with the DB
    /// </summary>
    public class DatabaseClient
    {

        private readonly ResultDbContext _context;

        public DatabaseClient(ResultDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Store the response data to DB and return ID in the referenced response
        /// Testing could e.g. be done by adding Moq, to mock stubs of the Context
        /// </summary>
        public bool StoreExecutionToDb(ref CleaningCommandResponse response)
        {
            try
            {
                Executions newExecution = new Executions {
                    timestamp = System.DateTime.Now,
                    commmands = response.commmands,
                    result = response.result,
                    duration = response.duration
                };

                _context.executions.Add(newExecution);
                _context.SaveChanges(); 

                response.id = newExecution.id;
                response.timestamp = newExecution.timestamp;

                return true;
            } catch(Exception ex)
            {
                //Log failure in proper fashion instead of console
                 Console.WriteLine($"Failed StoreExecutionToDb: {ex.Message}");
                return false;
            }
        }
    }
}
