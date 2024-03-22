using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class CustomerDAL
    {
        static string conn = ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString;
        CRMDBDataContext context = new CRMDBDataContext(conn);
        public List<CRMCustomer> GetCustomers()
        {
            List<CRMCustomer> customers;
            try
            {
                customers = (from c in context.CRMCustomers select c).ToList();
                return customers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public CRMCustomer GetCustomer(int id)
        {
            CRMCustomer customer;
            try
            {
                customer = (from c in context.CRMCustomers  where c.ID==id select c).Single();
                return customer;
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }
        public void Addcustomer(CRMCustomer customer,string Userid)
        {
            try
            {
                customer.UserId = int.Parse(Userid);

                context.CRMCustomers.InsertOnSubmit(customer);
                context.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void updatecustomer(CRMCustomer customer)
        {
            try
            {
                CRMCustomer oldcustomer = context.CRMCustomers.Single(c => c.ID == customer.ID);
                oldcustomer.Name = customer.Name;
                oldcustomer.mobile = customer.Name;
                oldcustomer.email = customer.email;
                oldcustomer.city = customer.city;
                oldcustomer.phone_call = customer.phone_call;
                oldcustomer.email_answer = customer.email_answer;
                oldcustomer.call_timing = customer.call_timing;
                oldcustomer.open_issue = customer.open_issue;
                oldcustomer.communication_chhanel= customer.communication_chhanel;
                oldcustomer.total_sale = customer.total_sale;
                oldcustomer.return_cancellation = customer.return_cancellation;
                context.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
        public void DeleteCustomer(int id)
        {
            try
            {
                CRMCustomer customer = context.CRMCustomers.Single(c => c.ID == id);
                customer.Status = "inactive";
                context.SubmitChanges();

            }
            catch
            {

            }
        }
    }


}