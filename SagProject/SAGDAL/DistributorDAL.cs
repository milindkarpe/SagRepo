using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAGDAL;
using System.Data.SqlClient;

namespace SAGDAL
{
    public class DistributorDAL : SqlBaseClassDAL
    {
        public void SaveDistributorDAL(
            int RankID,
            String IntroducerID,
            String preName,
            String Name,
            String preSdw,
            String sdwName,
            String PanCard,
            String Email,
            String PreAdd,
            String PrePIN,
            String PerAdd,
            String PerPIN,
            String Mobile,
            String Telephone,
            DateTime DOB,
            int Age,
            String Nominee,
            String Relation,
            DateTime NomDOB,
            int NomAge,
            DateTime JoinDate,
            String BranchID)
        {
            SqlParameter[] ParameterArray ={ new SqlParameter ("@RankID",DbType.Int16),
                                               new SqlParameter("@IntroducerID",DbType.String),
                                               new SqlParameter("@preName",DbType.String),
                                               new SqlParameter("@Name",DbType.String),
                                               new SqlParameter("@preSdw",DbType.String),
                                               new SqlParameter("@sdwName",DbType.String),
                                               new SqlParameter("@PanCard",DbType.String),
                                               new SqlParameter("@Email",DbType.String),
                                               new SqlParameter("@PreAdd",DbType.String),
                                               new SqlParameter("@PrePIN",DbType.String),
                                               new SqlParameter("@PerAdd",DbType.String),
                                               new SqlParameter("@PerPIN",DbType.String),
                                               new SqlParameter("@Mobile",DbType.String),
                                               new SqlParameter("@Telephone",DbType.String),
                                               new SqlParameter("@DOB",DbType.DateTime),
                                               new SqlParameter("@Age",DbType.Int16),
                                               new SqlParameter("@Nominee",DbType.String),
                                               new SqlParameter("@Relation",DbType.String),
                                               new SqlParameter("@NomDOB",DbType.DateTime),
                                               new SqlParameter("@NomAge",DbType.Int16),
                                               new SqlParameter("@JoinDate",DbType.DateTime),
                                               new SqlParameter("@BranchID",DbType.String),
                                           };

            ParameterArray[0].Value = RankID;
            ParameterArray[1].Value = IntroducerID;
            ParameterArray[2].Value = 1;
            ParameterArray[3].Value = Name;
            ParameterArray[4].Value = 1;
            ParameterArray[5].Value = sdwName;
            ParameterArray[6].Value = Email;
            ParameterArray[7].Value = PreAdd;
            ParameterArray[8].Value = PrePIN;
            ParameterArray[9].Value = PerAdd;
            ParameterArray[10].Value = PerPIN;
            ParameterArray[11].Value = Mobile;
            ParameterArray[12].Value = Telephone;
            ParameterArray[13].Value = DOB;
            ParameterArray[14].Value = Age;
            ParameterArray[15].Value = Nominee;
            ParameterArray[16].Value = Relation;
            ParameterArray[17].Value = NomDOB;
            ParameterArray[18].Value = NomAge;
            ParameterArray[19].Value = JoinDate;
            ParameterArray[20].Value = BranchID;


            ExecuteSP("SPSaveDistributor", ParameterArray);
        }
    }
}
