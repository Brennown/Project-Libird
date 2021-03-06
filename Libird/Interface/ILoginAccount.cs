﻿using Libird.Models.Domain;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface ILoginAccount
    {
        Task<bool> LoginAccountAsync(Account account);
    }
}
