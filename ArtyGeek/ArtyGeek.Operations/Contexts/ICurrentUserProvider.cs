using ArtyGeek.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Operations.Contexts
{
    public interface ICurrentUserProvider
    {
        int CurrentUserId { get; }
        string CurrentUserEmail { get; }
        Role CurrentUserRole { get; }
    }
}
