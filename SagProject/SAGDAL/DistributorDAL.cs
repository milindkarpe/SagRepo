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
            Int64 RankID,
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
            SqlParameter[] ParameterArray ={ new SqlParameter ("@RankID",SqlDbType.BigInt),
                                               new SqlParameter("@IntroducerID",SqlDbType.VarChar),
                                               new SqlParameter("@preName",SqlDbType.VarChar),
                                               new SqlParameter("@Name",SqlDbType.VarChar),
                                               new SqlParameter("@preSdw",SqlDbType.VarChar),
                                               new SqlParameter("@sdwName",SqlDbType.VarChar),
                                               new SqlParameter("@PanCard",SqlDbType.VarChar),
                                               new SqlParameter("@Email",SqlDbType.VarChar),
                                               new SqlParameter("@PreAdd",SqlDbType.VarChar),
                                               new SqlParameter("@PrePIN",SqlDbType.VarChar),
                                               new SqlParameter("@PerAdd",SqlDbType.VarChar),
                                               new SqlParameter("@PerPIN",SqlDbType.VarChar),
                                               new SqlParameter("@Mobile",SqlDbType.VarChar),
                                               new SqlParameter("@Telephone",SqlDbType.VarChar),
                                               new SqlParameter("@DOB",SqlDbType.DateTime),
                                               new SqlParameter("@Age",SqlDbType.Int),
                                               new SqlParameter("@Nominee",SqlDbType.VarChar),
                                               new SqlParameter("@Relation",SqlDbType.VarChar),
                                               new SqlParameter("@NomDOB",SqlDbType.DateTime),
                                               new SqlParameter("@NomAge",SqlDbType.Int),
                                               new SqlParameter("@JoinDate",SqlDbType.DateTime),
                                               new SqlParameter("@BranchID",SqlDbType.VarChar),
                                           };

            ParameterArray[0].Value = RankID;
            ParameterArray[1].Value = IntroducerID;
            ParameterArray[2].Value = preName;
            ParameterArray[3].Value = Name;
            ParameterArray[4].Value = preSdw;
            ParameterArray[5].Value = sdwName;
            ParameterArray[6].Value = PanCard;
            ParameterArray[7].Value = Email;
            ParameterArray[8].Value = PreAdd;
            ParameterArray[9].Value = PrePIN;
            ParameterArray[10].Value = PerAdd;
            ParameterArray[11].Value = PerPIN;
            ParameterArray[12].Value = Mobile;
            ParameterArray[13].Value = Telephone;
            ParameterArray[14].Value = DOB;
            ParameterArray[15].Value = Age;
            ParameterArray[16].Value = Nominee;
            ParameterArray[17].Value = Relation;
            ParameterArray[18].Value = NomDOB;
            ParameterArray[19].Value = NomAge;
            ParameterArray[20].Value = JoinDate;
            ParameterArray[21].Value = BranchID;


            ExecuteSP("SPSaveDistributor", ParameterArray);
        }
    }
}
