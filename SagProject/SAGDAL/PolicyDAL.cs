using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SAGDAL;

namespace SAGDAL
{
    public class PolicyDAL : BaseClassDAL
    {
        public string SavePolicyDAL(int PolicyType, int PlanID, string PayMode,String PayModeText, Int64 CustCode, Int64 IntroCode, Int64 Amount,
            string AmtRecMode, string ChqNo, string BankName, DateTime PurDate)
        {
            SqlParameter[] ParameterArray = {
                                                new SqlParameter("@PolicyType", SqlDbType.Int),
                                                new SqlParameter("@PlanID", SqlDbType.Int),
                                                new SqlParameter("@PayMode", SqlDbType.Int),
                                                new SqlParameter("@PayModeText", SqlDbType.VarChar),
                                                new SqlParameter("@CustCode", SqlDbType.BigInt),
                                                new SqlParameter("@IntroCode", SqlDbType.BigInt),
                                                new SqlParameter("@Amount", SqlDbType.BigInt),
                                                new SqlParameter("@AmtRecMode", SqlDbType.Text),
                                                new SqlParameter("@ChqNo", SqlDbType.Text),
                                                new SqlParameter("@BankName", SqlDbType.VarChar),
                                                new SqlParameter("@PurDate", SqlDbType.DateTime)                                                
                                              };

            ParameterArray[0].Value = PolicyType;
            ParameterArray[1].Value = PlanID;
            ParameterArray[2].Value = PayMode;
            ParameterArray[3].Value = PayModeText;
            ParameterArray[4].Value = CustCode;
            ParameterArray[5].Value = IntroCode;
            ParameterArray[6].Value = Amount;
            ParameterArray[7].Value = AmtRecMode;
            ParameterArray[8].Value = ChqNo;
            ParameterArray[9].Value = BankName;
            ParameterArray[10].Value = PurDate;            

            return DAL.ExecuteMMScalarSP("SPSavePolicyFP", ParameterArray);

        }

        public DataSet BindPlanType()
        {
            return DAL.ExecuteDatasetSP("SPBindPlanType");
        }

        public DataSet BindPlan(int PTID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@PTID", DbType.Int16) };

            ParameterArray[0].Value = PTID;

            return DAL.ExecuteDatasetSP("SPBindPlan", ParameterArray);
        }

        public DataSet GetCustomerDetailsDAL(Int64 CID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@CID", DbType.Int64) };

            ParameterArray[0].Value = CID;

            return DAL.ExecuteDatasetSP("SPGetCustomerDetails", ParameterArray);
        }

        public DataSet GetIntroducerDetailsDAL(Int64 DID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@DID", DbType.Int64) };

            ParameterArray[0].Value = DID;

            return DAL.ExecuteDatasetSP("SPGetIntroducerDetails", ParameterArray);
        }
    }
}
