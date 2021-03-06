﻿using AdvocatApp.BL.Authorization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvocatApp.BL.Authorization.DTO;
using AdvocatApp.BL.Authorization.Infrastructure;
using System.Security.Claims;
using AdvocatApp.DAL.Interfaces;
using AdvocatApp.DAL.Authorization.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AutoMapper;

namespace AdvocatApp.BL.Authorization.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<AdminDTO> GetUser(string email)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(email);
            return new AdminDTO
            {
                Address = user.AboutAdmin.Address,
                AboutMe = user.AboutAdmin.AboutMe,
                TextForContacts = user.AboutAdmin.TextForContacts
            };
        }

        public async Task<ClaimsIdentity> Authenticate(AdminDTO adminDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(adminDto.Email, adminDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task SetInitialData(AdminDTO adminDto)
        {
            await Create(adminDto);
        }

        public async Task<OperationDetails> Create(AdminDTO adminDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(adminDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = adminDto.Email, UserName = adminDto.Email };
                var result = await Database.UserManager.CreateAsync(user, adminDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // создаем профиль клиента
                Mapper.Initialize(cfg => cfg.CreateMap<AdminDTO, AboutAdmin>());
                AboutAdmin clientProfile = Mapper.Map<AdminDTO, AboutAdmin>(adminDto);
                clientProfile.Id = user.Id;
                Database.AdminManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public AdminDTO GetInfo()
        {
            var v = Database.AdminManager.GetInfo();
            if (v != null)
            {
                AdminDTO adm = new AdminDTO
                {
                    NameOfSite = v.NameOfSite,
                    AboutMe = v.AboutMe,
                    Address = v.Address,
                    Email = v.Email,
                    Phone = v.Phone,
                    AnotherPhone = v.AnotherPhone,
                    Vk = v.Vk,
                    Youtube = v.Youtube,
                    Twitter = v.Twitter,
                    Facebook = v.Facebook,
                    GooglePl = v.GooglePl,
                    TextForContacts = v.TextForContacts,
                    Map1 = v.Map1,
                    Map2 = v.Map2,
                    Map3 = v.Map3,
                    Map1M = v.Map1M,
                    Map2M = v.Map2M,
                    Map3M = v.Map3M,
                    ForMap1 = v.ForMap1,
                    ForMap2 = v.ForMap2,
                    ForMap3 = v.ForMap3,
                    VideoURL = v.VideoURL
                };
                return adm;
            }
            else return null;
        }

        public async Task Update(AdminDTO admin,string email)
        {
            ApplicationUser user = Database.UserManager.FindByEmail(email);
            if (admin.Password != null)
            {
                if (admin.Password.Length > 4)
                {
                    Database.AdminManager.Delete();
                    await Database.UserManager.DeleteAsync(user);
                    await Create(admin);
                }
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AdminDTO, AboutAdmin>());
                AboutAdmin clientProfile = Mapper.Map<AdminDTO, AboutAdmin>(admin);
                Database.AdminManager.Delete();
                clientProfile.Id = user.Id;
                Database.AdminManager.Create(clientProfile);
                await Database.SaveAsync();
            }
        }
    }
}
