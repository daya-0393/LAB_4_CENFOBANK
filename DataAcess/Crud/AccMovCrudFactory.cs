using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class AccMovCrudFactory : CrudFactory
    {
        AccountMovMapper mapper;

        public AccMovCrudFactory() : base()
        {
            mapper = new AccountMovMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var accMovement = (AccountMovement)entity;
            var sqlOperation = mapper.GetCreateStatement(accMovement);
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
            var lstAccountMovements = new List<T>();

            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAccountMovements.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAccountMovements;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAccountMovements = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAccountMovements.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAccountMovements;
        }

        public override void Update(BaseEntity entity)
        {
            var accMovement = (AccountMovement)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(accMovement));
        }

        public override void Delete(BaseEntity entity)
        {
            var accMovement = (AccountMovement)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(accMovement));
        }
    }
}


