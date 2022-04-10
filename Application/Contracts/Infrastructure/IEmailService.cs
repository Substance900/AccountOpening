using Application.Models;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
  public interface IEmailService
    {
        Task<BaseResponse> SendEmail(Email email);
    }
}
