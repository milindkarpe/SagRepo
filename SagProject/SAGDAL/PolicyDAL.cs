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
        public string SavePolicyDAL(int PolicyType, int PlanID, int PayMode,String PayModeText, Int64 CustCode, Int64 IntroCode,
                                    string AmtRecMode, string ChqNo, string BankName,
                                    DateTime PurDate, DateTime DueDate, DateTime LastPayDate, DateTime ExpDate,
                                    Double PlanAmount, Double InstallmentAmount, Double MaturityAmount,
                                    String NomName, Int16 NomAge, DateTime NomDOB, String NomAdd,
                                    String CustBankName, String BranchName, String AccNo, String AccType,
                                    Double DeathAmount,Double MRAmount)
        {
            SqlParameter[] ParameterArray = {
                                                new SqlParameter("@PolicyType", SqlDbType.Int),
                                                new SqlParameter("@PlanID", SqlDbType.Int),
                                                new SqlParameter("@PayMode", SqlDbType.Int),
                                                new SqlParameter("@PayModeText", SqlDbType.VarChar),
                                                new SqlParameter("@CustCode", SqlDbType.BigInt),
                                                new SqlParameter("@IntroCode", SqlDbType.BigInt),
                                                                                                
                                                new SqlParameter("@AmtRecMode", SqlDbType.Text),
                                                new SqlParameter("@ChqNo", SqlDbType.VarChar),
                                                new SqlParameter("@BankName", SqlDbType.Text),

                                                new SqlParameter("@PurDate", SqlDbType.DateTime),
                                                new SqlParameter("@DueDate", SqlDbType.DateTime),
                                                new SqlParameter("@LastPayDate", SqlDbType.DateTime),
                                                new SqlParameter("@ExpDate", SqlDbType.DateTime),

                                                new SqlParameter("@PlanAmount", SqlDbType.Float),
                                                new SqlParameter("@InstallmentAmount", SqlDbType.Float),
                                                new SqlParameter("@MaturityAmount", SqlDbType.Float),

                                                new SqlParameter("@NomName", SqlDbType.VarChar),
                                                new SqlParameter("@NomAge", SqlDbType.Int),
                                                new SqlParameter("@NomDOB", SqlDbType.DateTime),
                                                new SqlParameter("@NomAdd", SqlDbType.Text),

                                                new SqlParameter("@CustBankName", SqlDbType.VarChar),
                                                new SqlParameter("@BranchName", SqlDbType.VarChar),
                                                new SqlParameter("@AccNo", SqlDbType.VarChar),
                                                new SqlParameter("@AccType", SqlDbType.VarChar),

                                                new SqlParameter("@DeathAmount", SqlDbType.Float),
                                                new SqlParameter("@MRAmount", SqlDbType.Float)
                                              };

            ParameterArray[0].Value = PolicyType;
            ParameterArray[1].Value = PlanID;
            ParameterArray[2].Value = PayMode;
            ParameterArray[3].Value = PayModeText;
            ParameterArray[4].Value = CustCode;
            ParameterArray[5].Value = IntroCode;            
            ParameterArray[6].Value = AmtRecMode;
            ParameterArray[7].Value = ChqNo;
            ParameterArray[8].Value = BankName;
            
            ParameterArray[9].Value = PurDate;
            ParameterArray[10].Value = DueDate;
            ParameterArray[11].Value = LastPayDate;
            ParameterArray[12].Value = ExpDate;

            ParameterArray[13].Value = PlanAmount;
            ParameterArray[14].Value = InstallmentAmount;
            ParameterArray[15].Value = MaturityAmount;

            ParameterArray[16].Value = NomName;
            ParameterArray[17].Value = NomAge;
            ParameterArray[18].Value = NomDOB;
            ParameterArray[19].Value = NomAdd;

            ParameterArray[20].Value = CustBankName;
            ParameterArray[21].Value = BranchName;
            ParameterArray[22].Value = AccNo;
            ParameterArray[23].Value = AccType;

            ParameterArray[24].Value = DeathAmount;
            ParameterArray[25].Value = MRAmount;

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

        public DataSet BindCertificateDAL(Int64 PolicyID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@PolicyID",SqlDbType.BigInt) };

            ParameterArray[0].Value = PolicyID;

            return DAL.ExecuteDatasetSP("SPBindCertificate", ParameterArray);
        }

        public DataSet GetMFPUnitByPlanIDDAL(Int16 PlanID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@PID", SqlDbType.Int) };

            ParameterArray[0].Value = PlanID;

            return DAL.ExecuteDatasetSP("SPGetMFPUnitByPlanID", ParameterArray);
        }

        public DataSet GetSFPUnitByPlanIDDAL(Int16 PlanID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@PID", SqlDbType.Int) };

            ParameterArray[0].Value = PlanID;

            return DAL.ExecuteDatasetSP("SPGetSFPUnitByPlanID", ParameterArray);
        }

        public DataSet GetMRFPUnitByPlanIDDAL(Int16 PlanID)
        {
            SqlParameter[] ParameterArray = { new SqlParameter("@PID", SqlDbType.Int) };

            ParameterArray[0].Value = PlanID;

            return DAL.ExecuteDatasetSP("SPGetMRFPUnitByPlanID", ParameterArray);
        }
    }
}
