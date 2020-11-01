using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataAcess.Mapper
{
    public class CreditMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CREDIT_ID = "CREDIT_ID";
        private const string DB_COL_USER_ID = "USER_ID";
        private const string DB_COL_AMOUNT = "AMOUNT";
        private const string DB_COL_INTEREST_RATE = "INTEREST_RATE";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_FEE = "FEE";
        private const string DB_COL_START_DATE = "START_DATE";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_BALANCE = "BALANCE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDIT_PR" };

            var c = (Credit)entity;
            operation.AddVarcharParam(DB_COL_USER_ID, c.UserId);
            operation.AddDoubleParam(DB_COL_AMOUNT, c.Amount);
            operation.AddDoubleParam(DB_COL_INTEREST_RATE, c.InterestRate);
            operation.AddVarcharParam(DB_COL_NAME, c.CreditLine);
            operation.AddDoubleParam(DB_COL_FEE, c.Fee);
            operation.AddVarcharParam(DB_COL_START_DATE, Convert.ToString(c.StartDate));
            operation.AddVarcharParam(DB_COL_STATUS, Convert.ToString(c.Status));

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDIT_PR" };

            var c = (Credit)entity;
            operation.AddVarcharParam(DB_COL_USER_ID, c.UserId);
            operation.AddIntParam(DB_COL_CREDIT_ID, c.CreditId);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDITS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDIT_PR" };

            var c = (Credit)entity;
            operation.AddIntParam(DB_COL_CREDIT_ID, c.CreditId);
            operation.AddVarcharParam(DB_COL_USER_ID, c.UserId);
            operation.AddDoubleParam(DB_COL_INTEREST_RATE, c.InterestRate);
            operation.AddVarcharParam(DB_COL_NAME, c.CreditLine);
            operation.AddDoubleParam(DB_COL_FEE, c.Fee);
            operation.AddVarcharParam(DB_COL_START_DATE, Convert.ToString(c.StartDate));
            operation.AddVarcharParam(DB_COL_STATUS, Convert.ToString(c.Status));

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDIT_PR" };

            var c = (Credit)entity;
            operation.AddVarcharParam(DB_COL_USER_ID, c.UserId);
            operation.AddIntParam(DB_COL_CREDIT_ID, c.CreditId);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var credit = BuildObject(row);
                lstResults.Add(credit);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var credit = new Credit
            {
                CreditId = GetIntValue(row, DB_COL_CREDIT_ID),
                UserId = GetStringValue(row, DB_COL_USER_ID),
                Amount = GetIntValue(row, DB_COL_AMOUNT),
                InterestRate = GetDoubleValue(row, DB_COL_INTEREST_RATE),
                CreditLine = GetStringValue(row, DB_COL_NAME),
                Fee = GetDoubleValue(row, DB_COL_FEE),
                StartDate = GetDateValue(row, DB_COL_START_DATE),
                Status = Convert.ToChar(GetStringValue(row, DB_COL_STATUS)),
                Balance = GetDoubleValue(row, DB_COL_BALANCE)
            };

            return credit;
        }

    }
}
