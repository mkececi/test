using DP.Common;
using DP.DAL;
using DP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.DataServices.DataServices
{    
    public class ProjectDataService : IDataMethod<Project, List<Project>>
    {
        ProjectRepository ur = new ProjectRepository();
        public Result<Project> Save(Project instance)
        {
            Result<Project> result = new Result<Project>();
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

        public Result<Project> Edit(Project instance)
        {
            Result<Project> result = new Result<Project>();
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

        public Result<Project> Delete(int instanceId)
        {
            Result<Project> result = new Result<Project>();
            try
            {
                ur.Delete(instanceId);
                result.İsSucceeded = true;
                result.TransactionResult = default(Project);
            }
            catch (Exception ex)
            {
                result.İsSucceeded = false;
                result.TransactionException = ex;
            }
            return result;
        }

        public Result<List<Project>> SelectAll()
        {
            Result<List<Project>> result = new Result<List<Project>>();
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

        public Result<Project> SelectOne(int instanceId)
        {
            Result<Project> result = new Result<Project>();
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
