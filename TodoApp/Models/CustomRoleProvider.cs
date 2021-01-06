﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TodoApp.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        //指定されたRoleを配列にして返す
        public override string[] GetRolesForUser(string username)
        {
            if ("administrator".Equals(username))
            {
                return new string[]
                {
                    "Administrators"
                };
            }
            else
            {
                return new string[]
                {
                    "Users"
                };
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        //引数に所属していたusernameがroleに所属しているかを確かめる
        public override bool IsUserInRole(string username, string roleName)
        {
            if ("administrator".Equals(username) && "Administrators".Equals(roleName))
            {
                return true;      
            }
            else if("user".Equals(username) && "Users".Equals(roleName))
            {
                return true;
            }else
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}