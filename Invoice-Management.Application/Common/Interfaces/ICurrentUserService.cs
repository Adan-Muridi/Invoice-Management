using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public string UserId { get; }
    }
}
