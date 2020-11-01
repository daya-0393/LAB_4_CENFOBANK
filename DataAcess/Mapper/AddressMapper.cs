using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class AddressMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ADDRESS_ID = "ADDRESS_ID";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ADDRESS_PR" };

            var a = (Address)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, a.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, a.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, a.Distrito);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADDRESS_ID_PR" };

            var a = (Address)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, a.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, a.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, a.Distrito);

            Console.WriteLine(operation);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ADDRESS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADDRESS_PR" };

            var a = (Address)entity;
            operation.AddIntParam(DB_COL_PROVINCIA, a.AddressId);
            operation.AddVarcharParam(DB_COL_PROVINCIA, a.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, a.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, a.Distrito);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ADDRESS_PR" };

            var a = (Address)entity;
            operation.AddIntParam(DB_COL_PROVINCIA, a.AddressId);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var address = BuildObject(row);
                lstResults.Add(address);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var address = new Address
            {
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
            };

            return address;
        }

        public int getIdAddress(Dictionary<string, object> row)
        {
            var address = new Address()
            {
                AddressId = GetIntValue(row, DB_COL_ADDRESS_ID)
            };

            return address.AddressId;
        }

    }
}
