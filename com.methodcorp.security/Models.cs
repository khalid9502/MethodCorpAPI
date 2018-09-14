using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace com.methodcorp.security
{
    public class Serailize
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Group : Serailize
    {
        public long id;
        public string name;
        public string description;

        public Group(long GroupID, string GroupName)
        {
            this.id = GroupID;
            this.name = GroupName;
        }
    }


    public class Role : Serailize
    {
        public long id;
        public string name;
        public string description;

        public Role(long RoleID, string RoleName)
        {
            this.id = RoleID;
            this.name = RoleName;
        }
    }
    public class User : Serailize
    {
        public long id;
        public string name;
        public string fullName;

        public User(long id, string uname, string fname)
        {
            this.id = id;
            this.name = uname;
            this.fullName = fname;
        }
    }
    //public class PolicySecurity : Serailize
    //{
    //    public string name;
    //    public bool allow;
    //    public string data;
    //    public PolicySecurity(string Name, bool Allow, string Data)
    //    {
    //        this.name = Name;
    //        this.allow = Allow;
    //        this.data = Data;
    //    }
    //}
    public class PolicySecurityModel : Serailize
    {
        public string id;
        public string name;
        public bool allow;
        public string data;
        public PolicySecurityModel(string Id, string Name, bool Allow, string Data)
        {
            this.id = Id;
            this.name = Name;
            this.allow = Allow;
            this.data = Data;
        }
    }
    public class DomainModel : Serailize
    {
        public long id;
        public string name;
        public List<Group> groups;
        public List<Role> roles;

    }
    public class GroupModel : Serailize
    {
        public long id;
        public string name;
        public string description;
        public List<User> members;
        public List<PolicySecurityModel> policies;
    }

    public class GroupsModel : Serailize
    {
        public long id;
        public string name;
        public string description;

    }

    public class ObjectModel : Serailize
    {
        public long id;
        public long ownerId;
        public List<Group> groups;
    }
    public class PolicyModel : Serailize
    {
        public long parentId;
        public long id;
        public string name;
        public string description;
        public List<PolicySecurityModel> groups;
        public List<PolicySecurityModel> roles;
    }
    public class PoliciesModel : Serailize
    {
        public long parentId;
        public long id;
        public string name;
        public string description;
    }
    public class RoleModel : Serailize
    {
        public long id;
        public string name;
        public string description;
        public List<User> members;
        public List<PolicySecurityModel> policies;
    }
    public class RolesModel : Serailize
    {
        public long id;
        public string name;
        public string description;

    }
    public class UserModel : Serailize
    {
        public long id;
        public string name;
        public string fullName;
        public long ownerof;
        public bool canDelete;
        public List<Group> groups;
        public List<Role> roles;

    }
    public class UsersModel : Serailize
    {
        public long id;
        public string name;
        public string fullName;
        public long ownerof;
        public bool canDelete;
        public long ownership;

    }
    public class CreateGroupModel
    {
        public string domainName;
        public string groupName;
        public List<string> userNames;
    }

    public class UpdateGroupModel
    {
        public long groupId;
        public string groupName;
        public string desc;
        public List<string> userNames;
    }
    public class CreatePolicyModel
    {
        public string domainName;
        public string parentPolicyName;
        public string policyName;
        public List<policySecurity> groups;
        public List<policySecurity> roles;
    }
    public class UpdatePolicyModel
    {
        public string domainName;
        public string parentPolicyName;
        public long policyId;
        public List<policySecurity> groups;
        public List<policySecurity> roles;
    }
    public class CreateRoleModel
    {
        public string domainName;
        public string roleName;
        public List<string> userNames;
    }
    public class UpdateRoleModel
    {
        public long roleId;
        public string roleName;
        public string desc;
        public List<string> userNames;
    }
    public class CreateObjectModel
    {
        public string domainName { get; set; }
        public long ownerId { get; set; }
        public List<objectSecurity> roles { get; set; }
        public List<objectSecurity> groups { get; set; }
    }
    public class UpdateObjectModel
    {
        public long objectId { get; set; }
        public long ownerId { get; set; }
        public List<objectSecurity> roles { get; set; }
        public List<objectSecurity> groups { get; set; }
    }
    public class CreateUserModel
    {
        public string domainName { get; set; }
        public string userName { get; set; }
        public List<string> roleNames { get; set; }
        public List<string> groupNames { get; set; }
    }
    public class UpdateUserModel
    {
        public long userId { get; set; }
        public string userName { get; set; }
        public List<string> roleNames { get; set; }
        public List<string> groupNames { get; set; }
    }














}
