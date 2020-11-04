// File:    LocationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:08:07
// Purpose: Definition of Class LocationService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend.Exceptions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.MySQLRepository.MiscRepository;

namespace Backend.Service.MiscService
{
    public class LocationService : IService<Location, long>
    {

        private LocationRepository _locationRepository;

        public LocationService(LocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetLocationByCountry(string country)
            => _locationRepository.GetLocationByCountry(country);

        public IEnumerable<string> GetAllCountries()
            => _locationRepository.GetAllCountries();

        public IEnumerable<Location> GetAll()
            => _locationRepository.GetAll();

        public Location GetByID(long id)
            => _locationRepository.GetByID(id);

        public Location Create(Location entity)
        {
            Validate(entity);
            return _locationRepository.Create(entity);
        }

        public void Update(Location entity)
        {
            Validate(entity);
            _locationRepository.Update(entity);
        }

        public void Delete(Location entity)
            => _locationRepository.Delete(entity);

        public void Validate(Location entity)
        {
            string namingPattern = @"[a-zA-Z\\- ]*";
            if (!Regex.Match(entity.City, namingPattern).Success)
            {
                throw new LocationServiceException("City contains illegal characters!");
            }

            if (!Regex.Match(entity.Country, namingPattern).Success)
            {
                throw new LocationServiceException("Country contains illegal characters!");
            }
        }
    }
}