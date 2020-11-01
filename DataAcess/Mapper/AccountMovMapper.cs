using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataAcess.Mapper
{
    public class AccountMovMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_DATE = "MOV_DATE";
        private const string DB_COL_TYPE = "MOV_TYPE";
        private const string DB_COL_AMOUNT = "MOV_AMOUNT";
        private const string DB_COL_ACC_NUM = "ACC_NUM";
        private const string DB_COL_MOV_ID = "MOV_ID";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ACCOUNT_MOV_PR" };

            var am = (AccountMovement)entity;
            operation.AddVarcharParam(DB_COL_DATE, Convert.ToString(am.Date));
            operation.AddVarcharParam(DB_COL_TYPE, Convert.ToString(am.MovType));
            operation.AddDoubleParam(DB_COL_AMOUNT, am.Amount);
            operation.AddIntParam(DB_COL_ACC_NUM, am.AccountNum);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCOUNT_MOV_PR" };

            var am = (AccountMovement)entity;
            operation.AddIntParam(DB_COL_ACC_NUM, am.AccountNum);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ACCOUNT_MOV_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ACCOUNT_MOV_PR" };

            var am = (AccountMovement)entity;
            operation.AddVarcharParam(DB_COL_DATE, Convert.ToString(am.Date));
            operation.AddVarcharParam(DB_COL_TYPE, Convert.ToString(am.MovType));
            operation.AddDoubleParam(DB_COL_AMOUNT, am.Amount);
            operation.AddIntParam(DB_COL_ACC_NUM, am.AccountNum);
            operation.AddIntParam(DB_COL_MOV_ID, am.MovementId);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ACCOUNT_MOV_PR" };

            var am = (AccountMovement)entity;
            operation.AddIntParam(DB_COL_MOV_ID, am.MovementId);
            operation.AddIntParam(DB_COL_ACC_NUM, am.AccountNum);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var accMovement = BuildObject(row);
                lstResults.Add(accMovement);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var accMovement = new AccountMovement
            {
                MovementId = GetIntValue(row, DB_COL_MOV_ID),
                AccountNum = GetIntValue(row, DB_COL_ACC_NUM),
                Date = GetDateValue(row, DB_COL_DATE),
                MovType = Convert.ToChar(GetStringValue(row, DB_COL_TYPE)),
                Amount = GetDoubleValue(row, DB_COL_AMOUNT)
            };

            return accMovement;
        }

    }
}