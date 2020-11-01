using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataAcess.Mapper
{
    public class AccountMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ACCOUNT_NUM = "ACC_NUM";
        private const string DB_COL_CUSTOMER_ID = "ACC_HOLDER_ID";
        private const string DB_COL_TYPE = "ACCOUNT_TYPE";
        private const string DB_COL_CURRENCY = "CURRENCY";
        private const string DB_COL_BALANCE = "BALANCE";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ACCOUNT_PR" };

            var a = (Account)entity;
            operation.AddIntParam(DB_COL_ACCOUNT_NUM, a.AccountNum);
            operation.AddVarcharParam(DB_COL_CUSTOMER_ID, a.UserId);
            operation.AddVarcharParam(DB_COL_TYPE, a.Type);
            operation.AddVarcharParam(DB_COL_CURRENCY, a.Currency);
            operation.AddIntParam(DB_COL_BALANCE, a.Balance);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCOUNT_PR" };

            var a = (Account)entity;
            operation.AddVarcharParam(DB_COL_CUSTOMER_ID, a.UserId);
            operation.AddIntParam(DB_COL_ACCOUNT_NUM, a.AccountNum);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ACCOUNTS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ACCOUNT_PR" };

            var a = (Account)entity;
            operation.AddIntParam(DB_COL_ACCOUNT_NUM, a.AccountNum);
            operation.AddVarcharParam(DB_COL_CUSTOMER_ID, a.UserId);
            operation.AddVarcharParam(DB_COL_TYPE, a.Type);
            operation.AddVarcharParam(DB_COL_CURRENCY, a.Currency);
            operation.AddIntParam(DB_COL_BALANCE, a.Balance);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ACCOUNT_PR" };

            var a = (Account)entity;
            operation.AddIntParam(DB_COL_ACCOUNT_NUM, a.AccountNum);
            operation.AddVarcharParam(DB_COL_CUSTOMER_ID, a.UserId);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var account = BuildObject(row);
                lstResults.Add(account);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var account = new Account
            {
                AccountNum = GetIntValue(row, DB_COL_ACCOUNT_NUM),
                UserId = GetStringValue(row, DB_COL_CUSTOMER_ID),
                Type = GetStringValue(row, DB_COL_TYPE),
                Currency = GetStringValue(row, DB_COL_CURRENCY),
                Balance = GetIntValue(row, DB_COL_BALANCE)
            };

            return account;
        }

    }
}
