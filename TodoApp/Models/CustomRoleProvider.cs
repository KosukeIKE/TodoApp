using System;
using System.Linq;
using System.Web.Security;

namespace TodoApp.Models
{
    //役割をグループ化するためのもの
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










        //指定されたRole(役割)を配列にして返す
        public override string[] GetRolesForUser(string username)
        {
            using (var db = new TodoesContext())
            {
                var user = db.Users.Where(u => u.UserName == username).FirstOrDefault();

                if(user != null)
                {
                    //select, toarray
                    return user.Roles.Select(role => role.RoleName).ToArray();
                }
            }
            return new string[] { };

            //if ("administrator".Equals(username))
            //{
            //    return new string[]
            //    {
            //        "Administrators"
            //    };
            //}
            //else
            //{
            //    return new string[]
            //    {
            //        "Users"
            //    };
            //}

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        //引数に所属していたusernameがroleに所属しているかを確かめる
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = this.GetRolesForUser(username);
            return roles.Contains(roleName);//containsとは
            //if ("administrator".Equals(username) && "Administrators".Equals(roleName))
            //{
            //    return true;      
            //}
            //else if("user".Equals(username) && "Users".Equals(roleName))
            //{
            //    return true;
            //}else
            //{
            //    return false;
            //}
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