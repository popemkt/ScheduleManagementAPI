using AutoMapper;
using ColdSchedulesData.Global;
using ColdSchedulesData.Models;
using ColdSchedulesData.Models.Repositories;
using ColdSchedulesData.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface IAuthorizationDomain
    {
        EmployeesViewModel Login(string username, string password);
    }

    public class AuthorizationDomain : BaseDomain, IAuthorizationDomain
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;



        public AuthorizationDomain(IOptions<AppSettings> appSettings, IMapper mapper, IUnitOfWork uow) : base(uow)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public EmployeesViewModel Login(string username, string password)
        {
            var empRepo = _uow.GetService<IEmployeesRepository>();
            var emp = empRepo.GetActive(q => q.Username == username && q.Password == password).FirstOrDefault();
            var empModel = _mapper.Map<EmployeesViewModel>(emp);

            var ems = new Employees();

            // return null if user not found
            if (emp == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, empModel.Username),
                    new Claim(ClaimTypes.Role, empModel.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            empModel.Token = tokenHandler.WriteToken(token);

            return empModel;
        }
    }
}
