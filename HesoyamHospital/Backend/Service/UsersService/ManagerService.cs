// File:    ManagerService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class ManagerService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend.Exceptions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Util;

namespace Backend.Service.UsersService
{
    public class ManagerService : IService<Manager, long>
    {
        ManagerRepository _managerRepository;
        UserValidation _userValidation;

        public ManagerService(ManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
            _userValidation = new UserValidation();
        }

        public Manager Create(Manager entity)
        {
            Validate(entity);
            return _managerRepository.Create(entity);
        }

        public void Delete(Manager entity)
            => _managerRepository.Delete(entity);

        public IEnumerable<Manager> GetAll()
            => _managerRepository.GetAll();

        public Manager GetByID(long id)
            => _managerRepository.GetByID(id);

        public void Validate(Manager user)
            => _userValidation.Validate(user);

        public void Update(Manager entity)
        {
            Validate(entity);
            _managerRepository.Update(entity);
        }
    }
}