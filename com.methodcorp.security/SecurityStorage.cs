using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient; 

namespace com.methodcorp.security
{
    public class SecurityStorage : ISecurityStorage
    {
        private string connectionString = "Data Source=WIN-GIAHROVUOT5;Initial Catalog=MethodCorpSecurity;Integrated Security=True";
            
         public long updateDomain(long domainId, string domainName)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "[dbo].[updateDomain]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId",domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Direction = ParameterDirection.Input;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//updateDomain

        public long deleteGroup(string domainName, string groupName)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "[security].[deleteGroup]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter GroupName = Command.Parameters.AddWithValue("@groupName", groupName);
            GroupName.SqlDbType = SqlDbType.NVarChar;
            GroupName.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//deleteGroup

        public long deleteObject(long objectId)
        {
            
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "[security].[deleteObject]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter ObjectId = Command.Parameters.AddWithValue("@objectId", objectId);
            ObjectId.SqlDbType = SqlDbType.BigInt;
            ObjectId.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//deleteObject

        public long deletePolicy(string domainName, string policyName)
        {

            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[deletePolicy]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter PolicyName = Command.Parameters.AddWithValue("@policyName", policyName);
            PolicyName.SqlDbType = SqlDbType.NVarChar;
            PolicyName.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
            
        }//deletePolicy

        public long deleteRole(string domainName, string roleName)
        {
            
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[deleteRole]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter RoleName = Command.Parameters.AddWithValue("@roleName", roleName);
            RoleName.SqlDbType = SqlDbType.NVarChar;
            RoleName.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//deleteRole

        public long deleteUser(string domainName, string userName)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[deleteUser]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter UserName = Command.Parameters.AddWithValue("@userName", userName);
            UserName.SqlDbType = SqlDbType.NVarChar;
            UserName.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
            
        }//deleteUer

        //-----list<string> in parameter list
         
        public long updateGroup(long groupId, string groupName, string desc, List<string> userNames)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[updateGroup]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter GroupId = Command.Parameters.AddWithValue("@groupId", groupId);
            GroupId.SqlDbType = SqlDbType.BigInt;
            GroupId.Direction = ParameterDirection.Input;

            SqlParameter GroupName = Command.Parameters.AddWithValue("@groupName", groupName);
            GroupName.SqlDbType = SqlDbType.NVarChar;
            GroupName.Direction = ParameterDirection.Input;

            SqlParameter Desc = Command.Parameters.AddWithValue("@desc", desc);
            Desc.SqlDbType = SqlDbType.NVarChar;
            Desc.Direction = ParameterDirection.Input;

            DataTable TableUserNames = new DataTable();
            TableUserNames.Columns.Add("userName", typeof(string));
            foreach(string username in userNames)
            {
                TableUserNames.Rows.Add(username);
            }
            SqlParameter UserNames = Command.Parameters.AddWithValue("@userNames", TableUserNames);
            UserNames.TypeName = "dbo.strings";
            UserNames.SqlDbType = SqlDbType.Structured;
            UserNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;//dbo.strings

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;

        }//updateGroup

        public long updateRole(long rolesId, string roleName, string desc, List<string> userNames)
        { 
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[updateRole]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter RolesId = Command.Parameters.AddWithValue("@rolesId", rolesId);
            RolesId.SqlDbType = SqlDbType.BigInt;
            RolesId.Direction = ParameterDirection.Input;

            SqlParameter RoleName = Command.Parameters.AddWithValue("@roleName", roleName);
            RoleName.SqlDbType = SqlDbType.NVarChar;
            RoleName.Direction = ParameterDirection.Input;

            SqlParameter Desc = Command.Parameters.AddWithValue("@desc", desc);
            Desc.SqlDbType = SqlDbType.NVarChar;
            Desc.Direction = ParameterDirection.Input;

            DataTable TableUserNames = new DataTable();
            TableUserNames.Columns.Add("userName", typeof(string));

            foreach (string username in userNames)
            {
                TableUserNames.Rows.Add(username);
            }
            SqlParameter UserNames = Command.Parameters.AddWithValue("@userNames", TableUserNames);
            UserNames.TypeName = "dbo.strings";
            UserNames.SqlDbType = SqlDbType.Structured;
            UserNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//updateRole

        public long updateUser(long userId, string userName, List<string> roleNames, List<string> groupNames)
        { 
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[updateUser]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter UserId = Command.Parameters.AddWithValue("@userId", userId);
            UserId.SqlDbType = SqlDbType.BigInt;
            UserId.Direction = ParameterDirection.Input;

            SqlParameter UserName = Command.Parameters.AddWithValue("@userName", userName);
            UserName.SqlDbType = SqlDbType.NVarChar;
            UserName.Direction = ParameterDirection.Input;

            DataTable TableroleNames = new DataTable();
            TableroleNames.Columns.Add("roleNames", typeof(string));
            foreach (string rolename in roleNames)
            {
                TableroleNames.Rows.Add(rolename);
            }
            SqlParameter RoleNames = Command.Parameters.AddWithValue("@roleNames", TableroleNames);
            RoleNames.TypeName = "dbo.strings";
            RoleNames.SqlDbType = SqlDbType.Structured;
            RoleNames.Direction = ParameterDirection.Input;

            DataTable TablegroupNames = new DataTable();
            TablegroupNames.Columns.Add("groupNames", typeof(string));
            foreach (string groupname in groupNames)
            {
                TablegroupNames.Rows.Add(groupname);
            }
            SqlParameter GroupNames = Command.Parameters.AddWithValue("@groupNames", TablegroupNames);
            GroupNames.TypeName = "dbo.strings";
            GroupNames.SqlDbType = SqlDbType.Structured;
            GroupNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//updateUser

       public long validateGroupNames(int domainId, List<string> groupNames)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[validateGroupNames]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId", domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Direction = ParameterDirection.Input;

            DataTable TablegroupNames = new DataTable();
            TablegroupNames.Columns.Add("groupNames", typeof(string));
            foreach (string groupname in groupNames)
            {
                TablegroupNames.Rows.Add(groupname);
            }
            SqlParameter GroupNames = Command.Parameters.AddWithValue("@groupNames", TablegroupNames);
            GroupNames.TypeName = "dbo.strings";
            GroupNames.SqlDbType = SqlDbType.Structured;
            GroupNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//validateGroupNames
        public long validatePolicyNames(long domainId, List<string> policyNames)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[validatePolicyNames]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId", domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Direction = ParameterDirection.Input;

            DataTable TablepolicyNames = new DataTable();
            TablepolicyNames.Columns.Add("policyNames", typeof(string));
            foreach (string policyname in policyNames)
            {
                TablepolicyNames.Rows.Add(policyname);
            }
            SqlParameter PolicyNames = Command.Parameters.AddWithValue("@policyNames", TablepolicyNames);
            PolicyNames.TypeName = "dbo.strings";
            PolicyNames.SqlDbType = SqlDbType.Structured;
            PolicyNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//validatePolicyNames

        public long validateRoleNames(long domainId, List<string> roleNames)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[validateRoleNames]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId", domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Direction = ParameterDirection.Input;

            DataTable TableroleNames = new DataTable();
            TableroleNames.Columns.Add("roleNames", typeof(string));
            foreach (string rolename in roleNames)
            {
                TableroleNames.Rows.Add(rolename);
            }
            SqlParameter RoleNames = Command.Parameters.AddWithValue("@roleNames", TableroleNames);
            RoleNames.TypeName = "dbo.strings";
            RoleNames.SqlDbType = SqlDbType.Structured;
            RoleNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//validateRoleNames
        public long validateUserNames(long domainId, List<string> userNames)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[validateUserNames]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId", domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Direction = ParameterDirection.Input;

            DataTable TableUserNames = new DataTable();
            TableUserNames.Columns.Add("userName", typeof(string));

            foreach (string username in userNames)
            {
                TableUserNames.Rows.Add(username);
            }

            SqlParameter UserNames = Command.Parameters.AddWithValue("@userNames", TableUserNames);
            UserNames.TypeName = "dbo.strings";
            UserNames.SqlDbType = SqlDbType.Structured;
            UserNames.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//validateUserNames
        public long createDomain(string domainName)
        {
            int domainId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[dbo].[createDomain]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId", domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Size = -1;
            DomainId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(DomainId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;

        }//createDomain
        public long validateDomainName(string domainName)
        {

            int domainId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[dbo].[validateDomainName]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter DomainId = Command.Parameters.AddWithValue("@domainId", domainId);
            DomainId.SqlDbType = SqlDbType.BigInt;
            DomainId.Size = -1;
            DomainId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(DomainId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//validateDomainName
        public long deleteDomain(string domainName)
        {
            int httpStatus = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[deleteDomain]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter HttpStatus = Command.Parameters.AddWithValue("@httpStatus", httpStatus);
            HttpStatus.SqlDbType = SqlDbType.Int;
            HttpStatus.Size = -1;
            HttpStatus.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(HttpStatus.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//deleteDomain
        public long headDomain(string domainName)
        {
            int httpStatus = -1;//default value for output(httpStatus)
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[headDomain]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter HttpStatus = Command.Parameters.AddWithValue("@httpStatus", httpStatus);
            HttpStatus.SqlDbType = SqlDbType.Int;
            HttpStatus.Size = -1;
            HttpStatus.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(HttpStatus.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//headDomain

        public DomainModel getDomain(string domainName)
        {
            string output = "";//default value for output(type json) before deserialising  
            DomainModel returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getDomain]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            var Domain = JsonConvert.DeserializeObject<DomainModel>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Domain;
            }
            catch
            {
                returnValue = new DomainModel();
            }


            Connection.Close();

            return returnValue;
        }//DomainModel

        public GroupModel getGroup(string domainName, long groupId)
        {
            string output = "";//default value for output(type json) before deserialising
            GroupModel Group;
            GroupModel returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getGroup]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter GroupId = Command.Parameters.AddWithValue("@groupId", groupId);
            GroupId.SqlDbType = SqlDbType.BigInt;
            GroupId.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Group = JsonConvert.DeserializeObject<GroupModel>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Group;
            }
            catch
            {
                returnValue = new GroupModel();
            }


            Connection.Close();

            return returnValue;
        }//getGroup

        public ObjectModel getObject(long objectId)
        {
            string output = "";//default value for output(type json) before deserialising
            ObjectModel Object;
            ObjectModel returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getObject]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter ObjectId = Command.Parameters.AddWithValue("@objectId", objectId);
            ObjectId.SqlDbType = SqlDbType.BigInt;
            ObjectId.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Object = JsonConvert.DeserializeObject<ObjectModel>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Object;
            }
            catch
            {
                returnValue = new ObjectModel();
            }
            return new ObjectModel();
        }//getObject

        public PolicyModel getPolicy(long policyId)
        {
            string output = "";//default value for output(type json) before deserialising
            PolicyModel Policy;
            PolicyModel returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getPolicy]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter PolicyId = Command.Parameters.AddWithValue("@policyId", policyId);
            PolicyId.SqlDbType = SqlDbType.BigInt;
            PolicyId.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Policy = JsonConvert.DeserializeObject<PolicyModel>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Policy;
            }
            catch
            {
                returnValue = new PolicyModel();
            }
            return new PolicyModel();
        }//getPolicy

        public RoleModel getRole(string domainName, long roleId)
        {
            string output = "";//default value for output(type json) before deserialising
            RoleModel Role;
            RoleModel returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getRole]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter RoleId = Command.Parameters.AddWithValue("@roleId", roleId);
            RoleId.SqlDbType = SqlDbType.BigInt;
            RoleId.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Role = JsonConvert.DeserializeObject<RoleModel>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Role;
            }
            catch
            {
                returnValue = new RoleModel();
            }


            Connection.Close();

            return returnValue;
        }//getRole

        public UserModel getUser(string domainName, long userId)
        {
            string output = "";//default value for output(type json) before deserialising
            UserModel User;
            UserModel returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getUser]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter UserId = Command.Parameters.AddWithValue("@userId", userId);
            UserId.SqlDbType = SqlDbType.BigInt;
            UserId.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            User = JsonConvert.DeserializeObject<UserModel>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = User;
            }
            catch
            {
                returnValue = new UserModel();
            }


            Connection.Close();

            return returnValue;
            
        }

        public List<GroupsModel> getGroups(string domainName)
        {
            string output = "";//default value for output(type json) before deserialising
            List<GroupsModel> Groups;
            List<GroupsModel> returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getGroups]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Groups = JsonConvert.DeserializeObject<List<GroupsModel>>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Groups;
            }
            catch
            {
                returnValue = new List<GroupsModel>();
            }


            Connection.Close();

            return returnValue;
        }//getGroups
        public List<PoliciesModel> getPolicies(string domainName)
        {
            string output = "";//default value for output(type json) before deserialising
            List<PoliciesModel> Policies;
            List<PoliciesModel> returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getPolicies]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Policies = JsonConvert.DeserializeObject<List<PoliciesModel>>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Policies;
            }
            catch
            {
                returnValue = new List<PoliciesModel>();
            }


            Connection.Close();

            return returnValue;
        }//getPolicies

        public List<RolesModel> getRoles(string domainName)
        {
            string output = "";//default value for output(type json) before deserialising
            List<RolesModel> Roles;
            List<RolesModel> returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getRoles]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Roles = JsonConvert.DeserializeObject<List<RolesModel>>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Roles;
            }
            catch
            {
                returnValue = new List<RolesModel>();
            }


            Connection.Close();

            return returnValue;
        }//getRoles

        public List<UsersModel> getUsers(string domainName)
        {
            string output = "";//default value for output(type json) before deserialising
            List<UsersModel> Users;
            List<UsersModel> returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[http].[getUsers]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter Output = Command.Parameters.AddWithValue("@output", output);
            Output.SqlDbType = SqlDbType.NVarChar;
            Output.Size = -1;
            Output.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            output = Output.Value.ToString();
            Users = JsonConvert.DeserializeObject<List<UsersModel>>(output, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            try
            {
                returnValue = Users;
            }
            catch
            {
                returnValue = new List<UsersModel>();
            }


            Connection.Close();

            return returnValue;
        }//getUsers
        public long createObject(string domainName, long ownerId, List<objectSecurity> roles, List<objectSecurity> groups)
        {
            long objectId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[createObject]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter OwnerId = Command.Parameters.AddWithValue("@ownerId", ownerId);
            OwnerId.SqlDbType = SqlDbType.BigInt;
            OwnerId.Direction = ParameterDirection.Input;
            

            Type roleType = roles.GetType().GetGenericArguments()[0];
            IList roleVariables = (IList)roles;
            DataTable TableRoles = new DataTable();
            foreach (PropertyInfo info in roleType.GetProperties())
            {
                TableRoles.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in roleVariables)
            {
                DataRow row = TableRoles.NewRow();
                foreach (PropertyInfo info in roleType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableRoles.Rows.Add(row);
            }
            SqlParameter Roles = Command.Parameters.AddWithValue("@roles", TableRoles);
            Roles.TypeName = "security.objectSecurityList";
            Roles.SqlDbType = SqlDbType.Structured;
            Roles.Direction = ParameterDirection.Input;

            Type groupType = roles.GetType().GetGenericArguments()[0];
            IList groupVariables = (IList)roles;
            DataTable TableGroups = new DataTable();
            foreach (PropertyInfo info in groupType.GetProperties())
            {
                TableGroups.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in groupVariables)
            {
                DataRow row = TableGroups.NewRow();
                foreach (PropertyInfo info in groupType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableGroups.Rows.Add(row);
            }
            SqlParameter Groups = Command.Parameters.AddWithValue("@groups", TableGroups);
            Groups.TypeName = "security.objectSecurityList";
            Groups.SqlDbType = SqlDbType.Structured;
            Groups.Direction = ParameterDirection.Input;

            SqlParameter ObjectId = Command.Parameters.AddWithValue("@objectId", objectId);
            ObjectId.SqlDbType = SqlDbType.BigInt;
            ObjectId.Size = -1;
            ObjectId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(ObjectId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//createObject
        public long createPolicy(string domainName, string parentPolicyName, string policyName, List<policySecurity> groups, List<policySecurity> roles)
        {
            long policyId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[createPolicy]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter ParentPolicyName = Command.Parameters.AddWithValue("@parentPolicyName", parentPolicyName);
            ParentPolicyName.SqlDbType = SqlDbType.NVarChar;
            ParentPolicyName.Direction = ParameterDirection.Input;

            SqlParameter PolicyName = Command.Parameters.AddWithValue("@policyName", policyName);
            PolicyName.SqlDbType = SqlDbType.NVarChar;
            PolicyName.Direction = ParameterDirection.Input;

            Type groupType = roles.GetType().GetGenericArguments()[0];
            IList groupVariables = (IList)roles;
            DataTable TableGroups = new DataTable();
            foreach (PropertyInfo info in groupType.GetProperties())
            {
                TableGroups.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in groupVariables)
            {
                DataRow row = TableGroups.NewRow();
                foreach (PropertyInfo info in groupType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableGroups.Rows.Add(row);
            }
            SqlParameter Groups = Command.Parameters.AddWithValue("@groups", TableGroups);
            Groups.TypeName = "security.policySecurityList";
            Groups.SqlDbType = SqlDbType.Structured;
            Groups.Direction = ParameterDirection.Input;

            Type roleType = roles.GetType().GetGenericArguments()[0];
            IList roleVariables = (IList)roles;
            DataTable TableRoles = new DataTable();
            foreach (PropertyInfo info in roleType.GetProperties())
            {
                TableRoles.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in roleVariables)
            {
                DataRow row = TableRoles.NewRow();
                foreach (PropertyInfo info in roleType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableRoles.Rows.Add(row);
            }
            SqlParameter Roles = Command.Parameters.AddWithValue("@roles", TableRoles);
            Roles.TypeName = "security.policySecurityList";
            Roles.SqlDbType = SqlDbType.Structured;
            Roles.Direction = ParameterDirection.Input;

            SqlParameter PolicyId = Command.Parameters.AddWithValue("@policyId", policyId);
            PolicyId.SqlDbType = SqlDbType.BigInt;
            PolicyId.Size = -1;
            PolicyId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(PolicyId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//createPolicy
        public long updateObject(long objectId, long ownerId, List<objectSecurity> roles, List<objectSecurity> groups)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[updateObject]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter ObjectId = Command.Parameters.AddWithValue("@objectId", objectId);
            ObjectId.SqlDbType = SqlDbType.BigInt;
            ObjectId.Direction = ParameterDirection.Input;

            SqlParameter OwnerId = Command.Parameters.AddWithValue("@ownerId", ownerId);
            OwnerId.SqlDbType = SqlDbType.BigInt;
            OwnerId.Direction = ParameterDirection.Input;


            Type roleType = roles.GetType().GetGenericArguments()[0];
            IList roleVariables = (IList)roles;
            DataTable TableRoles = new DataTable();
            foreach (PropertyInfo info in roleType.GetProperties())
            {
                TableRoles.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in roleVariables)
            {
                DataRow row = TableRoles.NewRow();
                foreach (PropertyInfo info in roleType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableRoles.Rows.Add(row);
            }
            SqlParameter Roles = Command.Parameters.AddWithValue("@roles", TableRoles);
            Roles.TypeName = "security.objectSecurityList";
            Roles.SqlDbType = SqlDbType.Structured;
            Roles.Direction = ParameterDirection.Input;

            Type groupType = roles.GetType().GetGenericArguments()[0];
            IList groupVariables = (IList)roles;
            DataTable TableGroups = new DataTable();
            foreach (PropertyInfo info in groupType.GetProperties())
            {
                TableGroups.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in groupVariables)
            {
                DataRow row = TableGroups.NewRow();
                foreach (PropertyInfo info in groupType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableGroups.Rows.Add(row);
            }
            SqlParameter Groups = Command.Parameters.AddWithValue("@groups", TableGroups);
            Groups.TypeName = "security.objectSecurityList";
            Groups.SqlDbType = SqlDbType.Structured;
            Groups.Direction = ParameterDirection.Input;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//updateObject
        public long updatePolicy(string domainName, string parentPolicyName, long policyId, List<policySecurity> groups, List<policySecurity> roles)
        {
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[updatePolicy]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter ParentPolicyName = Command.Parameters.AddWithValue("@parentPolicyName", parentPolicyName);
            ParentPolicyName.SqlDbType = SqlDbType.NVarChar;
            ParentPolicyName.Direction = ParameterDirection.Input;

            SqlParameter PolicyId = Command.Parameters.AddWithValue("@policyId", policyId);
            PolicyId.SqlDbType = SqlDbType.BigInt;
            PolicyId.Direction = ParameterDirection.Input;

            Type groupType = roles.GetType().GetGenericArguments()[0];
            IList groupVariables = (IList)roles;
            DataTable TableGroups = new DataTable();
            foreach (PropertyInfo info in groupType.GetProperties())
            {
                TableGroups.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in groupVariables)
            {
                DataRow row = TableGroups.NewRow();
                foreach (PropertyInfo info in groupType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableGroups.Rows.Add(row);
            }
            SqlParameter Groups = Command.Parameters.AddWithValue("@groups", TableGroups);
            Groups.TypeName = "security.policySecurityList";
            Groups.SqlDbType = SqlDbType.Structured;
            Groups.Direction = ParameterDirection.Input;

            Type roleType = roles.GetType().GetGenericArguments()[0];
            IList roleVariables = (IList)roles;
            DataTable TableRoles = new DataTable();
            foreach (PropertyInfo info in roleType.GetProperties())
            {
                TableRoles.Columns.Add(info.Name, info.PropertyType);
            }
            foreach (var variable in roleVariables)
            {
                DataRow row = TableRoles.NewRow();
                foreach (PropertyInfo info in roleType.GetProperties())
                {
                    if (Utils.GetPropertyValue(row, info.Name) != null)
                    {
                        row[info.Name] = Utils.GetPropertyValue(row, info.Name);
                    }
                }
                TableRoles.Rows.Add(row);
            }
            SqlParameter Roles = Command.Parameters.AddWithValue("@roles", TableRoles);
            Roles.TypeName = "security.policySecurityList";
            Roles.SqlDbType = SqlDbType.Structured;
            Roles.Direction = ParameterDirection.Input;
            
            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(sqlReturnParam.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//updatePolicy

        public long createGroup(string domainName, string groupName, List<string> userNames)
        {
            long groupId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[createGroup]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter GroupName = Command.Parameters.AddWithValue("@groupName", groupName);
            GroupName.SqlDbType = SqlDbType.NVarChar;
            GroupName.Direction = ParameterDirection.Input;

            DataTable TableUserNames = new DataTable();
            TableUserNames.Columns.Add("userName", typeof(string));

            foreach (string username in userNames)
            {
                TableUserNames.Rows.Add(username);
            }

            SqlParameter UserNames = Command.Parameters.AddWithValue("@userNames", TableUserNames);
            UserNames.TypeName = "dbo.strings";
            UserNames.SqlDbType = SqlDbType.Structured;
            UserNames.Direction = ParameterDirection.Input;

            SqlParameter GroupId = Command.Parameters.AddWithValue("@groupId", groupId);
            GroupId.SqlDbType = SqlDbType.BigInt;
            GroupId.Size = -1;
            GroupId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(GroupId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//createGroup

        public long createRole(string domainName, string roleName, List<string> userNames)
        {
            long roleId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[createRole]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter RoleName = Command.Parameters.AddWithValue("@roleName", roleName);
            RoleName.SqlDbType = SqlDbType.NVarChar;
            RoleName.Direction = ParameterDirection.Input;

            DataTable TableUserNames = new DataTable();
            TableUserNames.Columns.Add("userName", typeof(string));

            foreach (string username in userNames)
            {
                TableUserNames.Rows.Add(username);
            }

            SqlParameter UserNames = Command.Parameters.AddWithValue("@userNames", TableUserNames);
            UserNames.TypeName = "dbo.strings";
            UserNames.SqlDbType = SqlDbType.Structured;
            UserNames.Direction = ParameterDirection.Input;

            SqlParameter RoleId = Command.Parameters.AddWithValue("@roleId", roleId);
            RoleId.SqlDbType = SqlDbType.BigInt;
            RoleId.Size = -1;
            RoleId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(RoleId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }//createRole
        public long createUser(string domainName, string userName, List<string> roleNames, List<string> groupNames)
        {
            long userId = -1;
            long returnValue;
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.CommandText = "[security].[createUser]";
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter DomainName = Command.Parameters.AddWithValue("@domainName", domainName);
            DomainName.SqlDbType = SqlDbType.NVarChar;
            DomainName.Direction = ParameterDirection.Input;

            SqlParameter UserName = Command.Parameters.AddWithValue("@userName", userName);
            UserName.SqlDbType = SqlDbType.NVarChar;
            UserName.Direction = ParameterDirection.Input;

            DataTable TableroleNames = new DataTable();
            TableroleNames.Columns.Add("roleNames", typeof(string));
            foreach (string rolename in roleNames)
            {
                TableroleNames.Rows.Add(rolename);
            }
            SqlParameter RoleNames = Command.Parameters.AddWithValue("@roleNames", TableroleNames);
            RoleNames.TypeName = "dbo.strings";
            RoleNames.SqlDbType = SqlDbType.Structured;
            RoleNames.Direction = ParameterDirection.Input;

            DataTable TablegroupNames = new DataTable();
            TablegroupNames.Columns.Add("groupNames", typeof(string));
            foreach (string groupname in groupNames)
            {
                TablegroupNames.Rows.Add(groupname);
            }
            SqlParameter GroupNames = Command.Parameters.AddWithValue("@groupNames", TablegroupNames);
            GroupNames.TypeName = "dbo.strings";
            GroupNames.SqlDbType = SqlDbType.Structured;
            GroupNames.Direction = ParameterDirection.Input;

            SqlParameter UserId = Command.Parameters.AddWithValue("@roleId", userId);
            UserId.SqlDbType = SqlDbType.BigInt;
            UserId.Size = -1;
            UserId.Direction = ParameterDirection.Output;

            SqlParameter sqlReturnParam = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            sqlReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.ExecuteNonQuery();

            try
            {
                returnValue = Convert.ToInt64(UserId.Value);
            }
            catch
            {
                returnValue = -1;
            }


            Connection.Close();
            return returnValue;
        }






    }
}
