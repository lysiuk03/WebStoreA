﻿using Microsoft.AspNetCore.Identity;

namespace WebStoreA.Data.Entities.Identity
{
    public class UserRoleEntity : IdentityUserRole<long>
    {
        public virtual UserEntity User { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
