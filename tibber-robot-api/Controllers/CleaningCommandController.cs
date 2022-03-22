using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using tibber_robot_api.Data;
using tibber_robot_api.Models;
using tibber_robot_api.Repository;

namespace tibber_robot_api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("tibber-developer-test")]
    public class CleaningCommandController : ControllerBase
    {
        private readonly ILogger<CleaningCommandController> _logger;
        private readonly ResultDbContext _context;

        public CleaningCommandController(ILoggerFactory _loggerFactory, ResultDbContext resultDbContext)
        {
            _logger = _loggerFactory.CreateLogger<CleaningCommandController>();
            _context = resultDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok("Welcome to the Robot API!");
        }

        [HttpPost]
        [Route("enter-path")]
        public IActionResult Post([FromBody] CleaningCommandRequest cleaningCommandRequest)
        {
             /* 
               Skipping input validations as stated in 3. Notes:
               "All input should be considered well formed and syntactically correct. There is no need,
               therefore, to implement elaborate input validation."     
             */
            _logger.LogDebug("Incoming request made");
            try
            {
                CleaningCommandResponse response = ExecuteRobotCommands(cleaningCommandRequest.Start, cleaningCommandRequest.Commmands);
    
                StorageRepository storageRepository = new StorageRepository();
                if (!storageRepository.StoreExecutionToDb(_context, ref response))
                {
                    // Depending on use case and error handling.
                    // Ignore DB storage failure and return data? Handle error backend?
                    // Could also result in error result being returned to calling service
                    response.id = -1;
                    response.timestamp = DateTime.Now;
                }

                return Ok(response);
            } catch (Exception ex)
            {
                _logger.LogError("Failed handling incoming request", ex);
                return BadRequest(ex);
            }
                                   
            
        }


       


        public static CleaningCommandResponse ExecuteRobotCommands(Point startPoint, List<Command> commands)
        {
            CleaningCommandResponse response = new CleaningCommandResponse();

            /*  
                Keeping it simple with List<>
                To increase performance for example a HashSet might be more proficient 
                
                Lines/Rows could be used instead of using points to lower memory usage.
                Then calculations could be made on intersections instead, removing these intersecting positions from the line data would
                result in the unique visited points.
             
             */
            
            HashSet<Point> uniqueOfficePoints = new HashSet<Point>(new PointComparer());
            uniqueOfficePoints.Add(startPoint);

            //Implementing robot as an actual robot that takes commands, instead of pure calculation. Simulating movements that could be expanded with more logic.
            Robot robot = new Robot
            {
                CurrentPosition = new Point { X = startPoint.X, Y = startPoint.Y },
                RobotSteps = 0
            };
            DateTime startTime = DateTime.Now;
            foreach (Command cmd in commands)
            {
                robot.CommandRobot(cmd, ref uniqueOfficePoints);
            }
            DateTime endTime = DateTime.Now;

            response.duration = endTime.Subtract(startTime).TotalSeconds;
            response.commmands = commands.Count;
            response.result = uniqueOfficePoints.Count;
           

            return response;
        }

        /// <summary>
        /// Simple test function reading stored file
        /// http://localhost:5248/tibber-developer-test/test?test={1,2,3}
        /// </summary>
        //[HttpGet]
        //[Route("test")]
        //public IActionResult Get(int test)
        //{
        //    System.IO.FileInfo tFile = new System.IO.FileInfo($".\\Json\\{test}.json");
        //    if (tFile.Exists)
        //    {
        //        CleaningCommandRequest req;
        //        using (System.IO.StreamReader r = new System.IO.StreamReader(tFile.FullName))
        //        {
        //            string json = r.ReadToEnd();                    
                    
        //            req = Newtonsoft.Json.JsonConvert.DeserializeObject<CleaningCommandRequest>(json);

        //        }

        //        CleaningCommandResponse response = ExecuteRobotCommands(req.Start, req.Commmands);

        //        return Ok(response);
        //    }

        //    return Ok("No file to process");
        //}
    }
}
