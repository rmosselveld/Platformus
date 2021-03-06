﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Platformus.Security.Data.Entities;

namespace Platformus.Security.Data.EntityFramework.PostgreSql
{
  public class EntityRegistrar : IEntityRegistrar
  {
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id).ValueGeneratedOnAdd();
          etb.Property(e => e.Name).IsRequired().HasMaxLength(64);
          etb.ForNpgsqlToTable("Users");
        }
      );

	  modelBuilder.Entity<CredentialType>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id).ValueGeneratedOnAdd();
          etb.Property(e => e.Code).IsRequired().HasMaxLength(32);
          etb.Property(e => e.Name).IsRequired().HasMaxLength(64);
          etb.ForNpgsqlToTable("CredentialTypes");
        }
      );

      modelBuilder.Entity<Credential>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id).ValueGeneratedOnAdd();
          etb.Property(e => e.Identifier).IsRequired().HasMaxLength(64);
          etb.Property(e => e.Secret).HasMaxLength(1024);
          etb.ForNpgsqlToTable("Credentials");
        }
      );

	  modelBuilder.Entity<Role>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id).ValueGeneratedOnAdd();
          etb.Property(e => e.Code).IsRequired().HasMaxLength(32);
          etb.Property(e => e.Name).IsRequired().HasMaxLength(64);
          etb.ForNpgsqlToTable("Roles");
        }
      );

	  modelBuilder.Entity<UserRole>(etb =>
        {
          etb.HasKey(e => new { e.UserId, e.RoleId });
          etb.ForNpgsqlToTable("UserRoles");
        }
      );

      modelBuilder.Entity<Permission>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id).ValueGeneratedOnAdd();
          etb.Property(e => e.Code).IsRequired().HasMaxLength(32);
          etb.Property(e => e.Name).IsRequired().HasMaxLength(64);
          etb.ForNpgsqlToTable("Permissions");
        }
      );

      modelBuilder.Entity<RolePermission>(etb =>
        {
          etb.HasKey(e => new { e.RoleId, e.PermissionId });
          etb.ForNpgsqlToTable("RolePermissions");
        }
      );
    }
  }
}