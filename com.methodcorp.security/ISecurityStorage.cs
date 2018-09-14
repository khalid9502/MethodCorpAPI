using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.methodcorp.security
{
    interface ISecurityStorage
    {
        //Create
        long createDomain(string domainName);//@domainId	bigint out
        long createGroup(string domainName, string groupName, List<string> userNames);//@groupId	bigint out
        long createObject(string domainName, long ownerId, List<objectSecurity> roles, List<objectSecurity> groups);//@objectId	bigint out
        long createPolicy(string domainName, string parentPolicyName, string policyName, List<policySecurity> groups, List<policySecurity> roles);//@policyId			bigint out
        long createRole(string domainName, string roleName, List<string> userNames);//@roleId		bigint out
        long createUser(string domainName, string userName, List<string> roleNames, List<string> groupNames);//@userId		bigint out


        DomainModel getDomain(string domainName);//@output		json out
        GroupModel getGroup(string domainName, long groupId);//@output		json out
        List<GroupsModel> getGroups(string domainName); //@output json out
        ObjectModel getObject(long objectId);//@output		json out
        List<PoliciesModel> getPolicies(string domainName);//@output json out
        PolicyModel getPolicy(long policyId);//@output		json out
        RoleModel getRole(string domainName, long roleId);//@output		json out
        List<RolesModel> getRoles(string domainName);//@output		json out
        UserModel getUser(string domainName, long userId);//@output		json out
        List<UsersModel> getUsers(string domainName);//@output		json out


        long updateDomain(long domainId, string domainName);
        long updateGroup(long groupId, string groupName, string desc, List<string> userNames);
        long updateObject(long objectId, long ownerId, List<objectSecurity> roles, List<objectSecurity> groups);
        long updatePolicy(string domainName, string parentPolicyName, long policyId, List<policySecurity> groups, List<policySecurity> roles);
        long updateRole(long roleId, string roleName, string desc, List<string> userNames);
        long updateUser(long userId, string userName, List<string> roleNames, List<string> groupNames);

        
        long deleteDomain(string domainName);//@httpStatus	int		out
        long deleteGroup(string domainName, string groupName);
        long deleteObject(long objectId);
        long deletePolicy(string domainName, string policyName);
        long deleteRole(string domainName, string roleName);
        long deleteUser(string domainName, string userName);

        
        long validateGroupNames(int domainId, List<string> groupNames);
        long validatePolicyNames(long domainId, List<string> policyNames);
        long validateRoleNames(long domainId, List<string> roleNames);
        long validateUserNames(long domainId, List<string> userNames);
        long validateDomainName(string domainName);//@domainId	bigint out


        long headDomain(string domainName);//@httpStatus	int		out
    }
}
