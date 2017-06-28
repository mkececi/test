using DP.Common;
using DP.DAL;
using DP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.DataServices.DataServices
{
    public class UserDataService : IDataMethod<User, List<User>>
    {
        UserRepository ur = new UserRepository();
        public Result<User> Save(User instance)
        {
            Result<User> result = new Result<User>();
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

        public Result<User> Edit(User instance)
        {
            Result<User> result = new Result<User>();
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

        public Result<User> Delete(int instanceId)
        {
            Result<User> result = new Result<User>();
            try
            {
                ur.Delete(instanceId);
                result.İsSucceeded = true;
                result.TransactionResult = default(User);
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }

        public Result<List<User>> SelectAll()
        {
            Result<List<User>> result = new Result<List<User>>();
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

        public Result<User> SelectOne(int instanceId)
        {
            Result<User> result = new Result<User>();
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
