using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CRM.Models
{
    public class UserDAL
    {
        static string conn = ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString;
        CRMDBDataContext context = new CRMDBDataContext(conn);
        public CRMUser GetUser(string email)
        {
            CRMUser user;
            try
            {
                user = (from u in context.CRMUsers where u.email == email  select u).Single();
                return user;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
        public CRMUser Adduser(CRMUser user)
        {
            try
            {
                context.CRMUsers.InsertOnSubmit(user);
                context.SubmitChanges();
                user = (from u in context.CRMUsers where u.email == user.email select u).Single();
                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}