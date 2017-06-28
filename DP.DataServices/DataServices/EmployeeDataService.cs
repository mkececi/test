using DP.Common;
using DP.DAL;
using DP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.DataServices.DataServices
{
    public class EmployeeDataService : IDataMethod<Employee, List<Employee>>
    {
        EmployeeRepository ur = new EmployeeRepository();
        public Result<Employee> Save(Employee instance)
        {
            Result<Employee> result = new Result<Employee>();
            try
            {
                ur.insert(instance);
                result.İsSucceeded = true;
                result.TransactionResult = instance;
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }

        public Result<Employee> Edit(Employee instance)
        {
            Result<Employee> result = new Result<Employee>();
            try
            {
                ur.Update(instance);
                result.İsSucceeded = true;
                result.TransactionResult = instance;
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }

        public Result<Employee> Delete(int instanceId)
        {
            Result<Employee> result = new Result<Employee>();
            try
            {
                ur.Delete(instanceId);
                result.İsSucceeded = true;
                result.TransactionResult = default(Employee);
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }

        public Result<List<Employee>> SelectAll()
        {
            Result<List<Employee>> result = new Result<List<Employee>>();
            try
            {
                result.İsSucceeded = true;
                result.TransactionResult = ur.SelectAll();
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }

        public Result<Employee> SelectOne(int instanceId)
        {
            Result<Employee> result = new Result<Employee>();
            try
            {
                result.İsSucceeded = true;
                result.TransactionResult = ur.SelectById(instanceId);
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }
    }
}
