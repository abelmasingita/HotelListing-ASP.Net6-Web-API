using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
using HotelListing.Models.Country;
using AutoMapper;
using HotelListing.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
    
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController( IMapper mapper,ICountriesRepository countriesRepository)
        {
           
            _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllsync();

            var countryMap = _mapper.Map<List<GetCountryDto>>(countries);

            return Ok(countryMap);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryMap = _mapper.Map<CountryDto>(country);
            return Ok(countryMap);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updatecountry)
        {
            if (id != updatecountry.Id)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country = await _countriesRepository.GetAsync(id); 
            if (country == null)
            {
                return NotFound();
            }
            _mapper.Map(updatecountry, country);
           // var countryMap = _mapper.Map<Country>(updatecountry);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {

            var countryMap = _mapper.Map<Country>(createCountry);
            //_context.Countries.Add(countryMap);
            //await _context.SaveChangesAsync();
            await _countriesRepository.AddAsync(countryMap);

            return CreatedAtAction("GetCountry", new { id = countryMap.Id }, countryMap);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrator")]

        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id); 
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
