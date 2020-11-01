using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class AccountCrudFactory : CrudFactory
    {
        AccountMapper mapper;

        public AccountCrudFactory() : base()
        {
            mapper = new AccountMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var account = (Account)entity;
            var sqlOperation = mapper.GetCreateStatement(account);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveById<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var lstAccounts = new List<T>();

            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAccounts.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAccounts;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAccounts = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAccounts.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAccounts;
        }

        public override void Update(BaseEntity entity)
        {
            var account = (Account)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(account));
        }

        public override void Delete(BaseEntity entity)
        {
            var account = (Account)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(account));
        }
    }
}
