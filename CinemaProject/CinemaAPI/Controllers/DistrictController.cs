using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictInterface _districtInterface;
        private readonly IMapper _mapper;

        public DistrictController(IDistrictInterface districtInterface, IMapper mapper)
        {
            _districtInterface = districtInterface;
            _mapper = mapper;
        }

        [Route("GetDistricts")]
        [HttpGet]
        public ActionResult<List<District>> GetDistricts()
        {
            var districts = _districtInterface.GetDistricts();

            if (districts != null && districts.Any())
            {
                return Ok(districts);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
