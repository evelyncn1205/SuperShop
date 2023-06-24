﻿using Microsoft.EntityFrameworkCore;
using SuperShop.Data;
using SuperShop2.Data.Entities;
using SuperShop2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop2.Data
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddCityAsync(CityViewModel model)
        {
            var country = await this.GetCountryWithCitiesAsync(model.CountryId);
            if (country == null)
            {
                return;
            }

            country.Cities.Add(new City { Name = model.Name });
            _context.Country.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCityAsync(City city)
        {
            var country = await _context.Country
                .Where(c => c.Cities.Any(ci => ci.Id == city.Id))
                .FirstOrDefaultAsync();
            if (country == null)
            {
                return 0;
            }

            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return country.Id;
        }

        public IQueryable GetCountriesWithCities()
        {
            return _context.Country
                .Include(c => c.Cities)
                .OrderBy(c => c.Name);
        }

        public async Task<Country> GetCountryWithCitiesAsync(int id)
        {
            return await _context.Country
                .Include(c => c.Cities)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }


        public async Task<int> UpdateCityAsync(City city)
        {
            var country = await _context.Country
                .Where(c => c.Cities.Any(ci => ci.Id == city.Id)).FirstOrDefaultAsync();
            if (country == null)
            {
                return 0;
            }

            _context.City.Update(city);
            await _context.SaveChangesAsync();
            return country.Id;
        }


        public async Task<City> GetCityAsync(int id)
        {
            return await _context.City.FindAsync(id);
        }


        public async Task<Country> GetCountryAsync(City city)
        {
            return await _context.Country
                .Where(c => c.Cities.Any(ci => ci.Id == city.Id))
                .FirstOrDefaultAsync();
        }
    }
}