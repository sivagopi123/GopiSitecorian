using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {

        private ILogger<PointsOfInterestController> _logger;
        private IMailService _mailservice;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailservice = mailService;
        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                    return NotFound();

                var pointsOfInterest = city.PointsOfInterest.ToList();
                return Ok(pointsOfInterest);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{pId}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int pId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                _logger.LogInformation($"City wiht id {cityId} wasn't found when accessing points of interest");
                return NotFound();
            }

            var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == pId);

            if (poi == null)
            {
                _logger.LogInformation($"Point of Interest wiht id {pId} wasn't found when accessing points of interest with city id {cityId}");
                return NotFound();
            }

            return Ok(poi);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterestForCreationDto)
        {
            if (pointOfInterestForCreationDto == null)
            {
                _logger.LogInformation($"The request body sent is not valid");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                _logger.LogInformation($"City wiht id {cityId} wasn't found when accessing points of interest");
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities
                                            .SelectMany(c => c.PointsOfInterest)
                                            .Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterestForCreationDto.Name,
                Description = pointOfInterestForCreationDto.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute(
                "GetPointOfInterest",
                new { cityId = cityId, pId = finalPointOfInterest.Id },
                finalPointOfInterest);

        }

        [HttpPut("{cityId}/pointsofinterest/{pId}")]
        public IActionResult UpdatePointOfInterest(int cityId, int pId,
            [FromBody] PointOfInterestForUpdatingDto pointOfInterestForUpdating)
        {
            if (pointOfInterestForUpdating == null)
            {
                _logger.LogInformation($"The request body sent is not valid");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"The Model State is not valid");
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                _logger.LogInformation($"City wiht id {cityId} wasn't found when accessing points of interest");
                return NotFound(new { cityId });
            }

            var pointOfInterest = city.PointsOfInterest
                                        .FirstOrDefault(p => p.Id == pId);

            if (pointOfInterest == null)
            {
                _logger.LogInformation($"Point of Interest wiht id {pId} wasn't found when accessing points of interest with city id {cityId}");
                return NotFound(new { pId });
            }

            pointOfInterest.Name = pointOfInterestForUpdating.Name;
            pointOfInterest.Description = pointOfInterestForUpdating.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointsOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdatingDto> patchdoc)
        {
            if (patchdoc == null)
            {
                _logger.LogInformation($"The request body sent is not valid");
                return BadRequest();
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                _logger.LogInformation($"City wiht id {cityId} wasn't found when accessing points of interest");
                return NotFound();
            }

            var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (poi == null)
            {
                _logger.LogInformation($"Point of Interest wiht id {id} wasn't found when accessing points of interest with city id {cityId}");
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdatingDto()
            {
                Name = poi.Name,
                Description = poi.Description
            };


            patchdoc.ApplyTo(pointOfInterestToPatch, ModelState);

            TryValidateModel(pointOfInterestToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"The request model sent is not valid");
                return BadRequest();
            }

            poi.Name = pointOfInterestToPatch.Name;
            poi.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
        [HttpDelete("{cityId}/pointsofinterest/{id}")]

        public IActionResult DeletePointsOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                _logger.LogInformation($"City wiht id {cityId} wasn't found when accessing points of interest");
                return NotFound();
            }

            var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (poi == null)
            {
                _logger.LogInformation($"Point of Interest wiht id {id} wasn't found when accessing points of interest with city id {cityId}");
                return NotFound();
            }

            city.PointsOfInterest.Remove(poi);

            _mailservice.Send("POI Deletion", "The POI is deleted");

            return NoContent();
        }
    }
}