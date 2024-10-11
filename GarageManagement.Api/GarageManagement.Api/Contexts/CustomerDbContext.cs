
using Castle.Core.Resource;
using GarageManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Api.Contexts
{
    public class CustomerDbContext : ICustomerDbContext
    {
        public async Task<bool> AddUser(CustomerDetail customer)
        {
            using (var dbContext = new GarageManagementSystemContext())
            {
                try
                {
                    if(customer!= null)
                    {
                        var data = await dbContext.Customers.FirstOrDefaultAsync(u => u.Nid == customer.Nid);
                        if(data == null)
                        {
                            data = new Customer()
                            {
                                Name = customer.Name,
                                PhoneNo = customer.PhoneNO,
                                Address = customer.Address,
                                Nid = customer.Nid,


                            };
                            dbContext.Customers.Add(data);
                            int addRowCount = await dbContext.SaveChangesAsync();
                            if (addRowCount > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }else
                    {
                        return false;
                    }
                }catch (Exception) 
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteUser(string NID)
        {
            using (var dbContext = new GarageManagementSystemContext())
            {
                try
                {
                    if(NID!= null)
                    {
                        var customer = await dbContext.Customers.FirstOrDefaultAsync(u => u.Nid == NID);
                        if (customer != null)
                        {
                            dbContext.Customers.Remove(customer);
                            int deletedRowCount = await dbContext.SaveChangesAsync();
                            if (deletedRowCount > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }catch(Exception) { return false; }
            }
        }

        public async Task<CustomerDetail> GetUser(string NID)
        {
            using (var dbContext= new GarageManagementSystemContext())
            {
                try
                {
                    if (NID!= null)
                    {
                        var user = await dbContext.Customers.FirstOrDefaultAsync(u => u.Nid == NID);
                        if(user!= null)
                        {
                            var results = new CustomerDetail();
                            results.CustomerID = user.CustomerId;
                            results.Name = user.Name;
                            results.PhoneNO = user.PhoneNo;
                            results.Address = user.Address;
                            results.Nid = user.Nid;
                            return results;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<bool> UpdateUser(CustomerDetail customer)
        {
            using (var dbContext = new GarageManagementSystemContext())
            {
                try
                {
                    if (customer!= null)
                    {
                        var data = await dbContext.Customers.FirstOrDefaultAsync(u => u.Nid == customer.Nid);
                        if (data != null)
                        {
                            data.PhoneNo = customer.PhoneNO;
                            data.Address = customer.Address;
                            data.Name = customer.Name;

                            int addRowCount = await dbContext.SaveChangesAsync();
                            if (addRowCount > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }else { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
