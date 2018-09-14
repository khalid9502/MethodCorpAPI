using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace com.methodcorp.security
{
    class Serailize
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
   
    class Group : Serailize
    {
        long groupId;
        string groupName;

        public Group(long GroupID,string GroupName)
        {
            this.groupId = GroupID;
            this.groupName = GroupName;
        }
    }
    
    
    class Role : Serailize
    {
        long roleId;
        string roleName;

        public Role(long RoleID, string RoleName)
        {
            this.roleId = RoleID;
            this.roleName = RoleName;
        }
    }
    class User : Serailize
    {
        long userId;
        string userName;
        string fullName;
        
        public User(long id,string uname,string fname)
        {
            this.userId = id;
            this.userName = uname;
            this.fullName = fname;
        }
    }
   
    class PolicySecurityModel : Serailize
    {
        long id;
        string name;
        bool allow;
        string data;
        public PolicySecurityModel(long Id,string Name,bool Allow,string Data)
        {
            this.id = Id;
            this.name = Name;
            this.allow = Allow;
            this.data = Data;
        }
    }
    class RolesModel : Serailize
    {
        long roleId;
        string roleName;
        string desc;

    }
    class DomainModel : Serailize
    {
        long domainId;
        string domainName;
        List<Group> groups;
        List<Role> roles;
        
    }
    class GroupModel : Serailize
    {
        long groupId;
        string groupName;
        string desc;
        List<User> members;
        List<PolicySecurityModel> policies;
    }

    class GroupsModel : Serailize
    {
        long groupId;
        string groupName;
        string desc;
        
    }

    class ObjectModel : Serailize
    {
        long objectId;
        long ownerId;
        List<Group> groups;
    }
    class PolicyModel : Serailize
    {
        long parentpolicyId;
        long policyId;
        string policyName;
        string desc;
        List<PolicySecurityModel> groups;
        List<PolicySecurityModel> roles;
    }
    class PoliciesModel : Serailize
    {
        long parentpolicyId;
        long policyId;
        string policyName;
        string desc;
    }
    class RoleModel : Serailize
    {
        long roleId;
        string roleName;
        string desc;
        List<User> members;
        List<PolicySecurityModel> policies;
    }
    class UserModel : Serailize
    {
        long userId;
        string userName;
        string fullName;
        long ownerof;
        bool canDelete;
        List<Group> groups;
        List<Role> roles;

    }
    class UsersModel : Serailize
    {
        long userId;
        string userName;
        string fullName;
        long ownerof;
        bool canDelete;
        long ownership;

    }
}
