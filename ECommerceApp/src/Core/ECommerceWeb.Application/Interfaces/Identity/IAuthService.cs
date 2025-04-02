using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Models.Identity;

namespace ECommerceWeb.Application.Interfaces.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    }
}
