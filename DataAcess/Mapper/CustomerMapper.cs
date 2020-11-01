using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CustomerMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_LAST_NAME = "LAST_NAME";
        private const string DB_COL_BIRTH_DATE = "BIRTH_DATE";
        private const string DB_COL_AGE = "AGE";
        private const string DB_COL_CIVIL_STATUS = "CIVIL_STATUS";
        private const string DB_COL_GENDER = "GENDER";
        private const string DB_COL_ADDRESS_ID = "ADDRESS_ID";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CUSTOMER_PR" };

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_LAST_NAME, c.LastName);
            operation.AddVarcharParam(DB_COL_BIRTH_DATE, Convert.ToString(c.BirthDate));
            operation.AddIntParam(DB_COL_AGE, c.Age);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, Convert.ToString(c.CivilStatus));
            operation.AddVarcharParam(DB_COL_GENDER, Convert.ToString(c.Gender));
            operation.AddIntParam(DB_COL_ADDRESS_ID, c.AddressId);


            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CUSTOMER_PR" };

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CUSTOMER_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CUSTOMER_PR" };

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_LAST_NAME, c.LastName);
            operation.AddVarcharParam (DB_COL_BIRTH_DATE, Convert.ToString(c.BirthDate));
            operation.AddIntParam(DB_COL_AGE, c.Age);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, Convert.ToString(c.CivilStatus));
            operation.AddVarcharParam(DB_COL_GENDER, Convert.ToString(c.Gender));

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUSTOMER_PR" };

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new Customer
            {
               Id = GetStringValue(row, DB_COL_ID),
               Name = GetStringValue(row, DB_COL_NAME),
               LastName = GetStringValue(row, DB_COL_LAST_NAME),
               BirthDate = GetDateValue(row, DB_COL_BIRTH_DATE),
               Age = GetIntValue(row, DB_COL_AGE),
               CivilStatus = char.Parse(GetStringValue(row, DB_COL_CIVIL_STATUS)),
               Gender = char.Parse(GetStringValue(row, DB_COL_GENDER)),
               Provincia = GetStringValue(row, DB_COL_PROVINCIA),
               Canton = GetStringValue(row, DB_COL_CANTON),
               Distrito = GetStringValue(row, DB_COL_DISTRITO)
            };

            return customer;
        }

    }
}

