using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataAcess.Mapper
{
    public class PaymentMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_PAYMENT_DATE = "PAYMENT_DATE";
        private const string DB_COL_AMOUNT = "AMOUNT";
        private const string DB_COL_CREDIT_ID = "CREDIT_ID";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PAYMENT_PR" };

            var p = (Payment)entity;
            operation.AddVarcharParam(DB_COL_PAYMENT_DATE, Convert.ToString(p.PaymentDate));
            operation.AddIntParam(DB_COL_AMOUNT, p.Amount);
            operation.AddIntParam(DB_COL_CREDIT_ID, p.CreditId);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PAYMENT_PR" };

            var p = (Payment)entity;
            operation.AddIntParam(DB_COL_CREDIT_ID, p.CreditId);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PAYMENTS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PAYMENT_PR" };

            var p = (Payment)entity;
            operation.AddVarcharParam(DB_COL_PAYMENT_DATE, Convert.ToString(p.PaymentDate));
            operation.AddIntParam(DB_COL_AMOUNT, p.Amount);
            operation.AddIntParam(DB_COL_CREDIT_ID, p.CreditId);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PAYMENT_PR" };

            var p = (Payment)entity;
            operation.AddIntParam(DB_COL_CREDIT_ID, p.CreditId);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var payment = BuildObject(row);
                lstResults.Add(payment);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var payment = new Payment
            {
                PaymentDate = GetDateValue(row, DB_COL_PAYMENT_DATE),
                Amount = GetIntValue(row, DB_COL_AMOUNT),
                CreditId = GetIntValue(row, DB_COL_CREDIT_ID)
            };

            return payment;
        }

    }
}
