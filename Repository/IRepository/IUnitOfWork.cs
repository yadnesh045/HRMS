﻿namespace HRMS.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IProjectRepository project { get; set; }
        IRolesRepository Roles { get; set; }
        IUsersRepository Users { get; set; }
        IUserRoleRepository UserRole { get; set; }
        void Save();
    }
}
