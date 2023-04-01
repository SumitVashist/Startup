using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Models;
using System.Text.RegularExpressions;

namespace StartupMachinia.Controllers
{
    // Define the controller that will handle the HTTP requests
    [ApiController]
    [Route("[controller]")]
    public class TrainingCentersController : ControllerBase
    {
        private readonly TrainingCenterDbContext _dbContext;

        public TrainingCentersController(TrainingCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST API to create a new TrainingCenter

            [HttpPost]
            public IActionResult CreateTrainingCenter([FromBody] TrainingCenter trainingCenter)
            {
                if (trainingCenter == null)
                {
                    return BadRequest("Invalid input");
                }



                if (string.IsNullOrEmpty(trainingCenter.CenterName) || trainingCenter.CenterName.Length > 40)
                {
                    return BadRequest("CenterName is required and should be less than 40 characters");
                }



                if (string.IsNullOrEmpty(trainingCenter.CenterCode) || !Regex.IsMatch(trainingCenter.CenterCode, "^[a-zA-Z0-9]{12}$"))
                {
                    return BadRequest("CenterCode is required and should be exactly 12 character alphanumeric");
                }



                if (trainingCenter.Address == null || string.IsNullOrEmpty(trainingCenter.Address.DetailedAddress) ||
                string.IsNullOrEmpty(trainingCenter.Address.City) || string.IsNullOrEmpty(trainingCenter.Address.State) ||
                string.IsNullOrEmpty(trainingCenter.Address.Pincode) || !Regex.IsMatch(trainingCenter.Address.Pincode, "^[0-9]{6}$"))
                {
                    return BadRequest("Address is required and should contain DetailedAddress, City, State, and Pincode (6 digit)");
                }



                if (trainingCenter.ContactPhone == null || !Regex.IsMatch(trainingCenter.ContactPhone, "^[0-9]{10}$"))
                {
                    return BadRequest("ContactPhone is required and should be a valid 10 digit phone number");
                }



                if (!string.IsNullOrEmpty(trainingCenter.ContactEmail) && !Regex.IsMatch(trainingCenter.ContactEmail, @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
                {
                    return BadRequest("ContactEmail should be a valid email address");
                }






                // Set the CreatedOn field to the current server time
                trainingCenter.CreatedOn = DateTime.Now;

                // Add the TrainingCenter to the database
                _dbContext.TrainingCenters.Add(trainingCenter);
                _dbContext.SaveChanges();

                // Return the newly saved TrainingCenter information in JSON format
                return Ok(trainingCenter);


            }

        // GET API to get a list of all stored TrainingCenters
        [HttpGet]
        public IActionResult GetTrainingCenters()
        {
            var trainingCenters = _dbContext.TrainingCenters.ToList();
            return Ok(trainingCenters);
        }
    }

}