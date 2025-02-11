﻿using Common.Models;
using Repository.Repositories.Base;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class UserRepoService(IRepository<User> repository) : BaseRepoService<User>(repository)
    {
    }
}
