using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class AddressCrudFactory : CrudFactory
    {
        AddressMapper mapper;

        //Constructor: instancia del mapper correspondiente e instancia del Dao

        public AddressCrudFactory() : base()
        {
            mapper = new AddressMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var address = (Address)entity;
            var sqlOperation = mapper.GetCreateStatement(address);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (result != null)
            {
                Console.WriteLine(result);
                dic = result[0];
                var obj = mapper.getIdAddress(dic);
                Console.WriteLine(obj);
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }

        public int RetrieveObjId(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (result != null)
            {
                dic = result[0];
                var obj = mapper.getIdAddress(dic);
                return obj;
            }
            else
            {
                return 0;
            }
            return default;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAddress = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAddress.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAddress;
        }

        public override void Update(BaseEntity entity)
        {
            var address = (Address)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(address));
        }

        public override void Delete(BaseEntity entity)
        {
            var address = (Address)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(address));
        }
    }
}