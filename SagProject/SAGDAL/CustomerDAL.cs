using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SAGDAL;

namespace SAGDAL
{
    public class CustomerDAL : BaseClassDAL
    {

        public string SaveCustomerDAL(string code,string introducer,string preName,string name,string preSdw, string sdwName,string pancard,string email,string preAdd,string perAdd,string prePin,string perPin,string mobile,
            string nominee,string telephone,string relation,DateTime dob,DateTime nomDob,int age,int nomAge,DateTime StartDate,int BranchId,string preNom)
        {
            SqlParameter[] ParameterArray = {
                                                new SqlParameter("@introducer", SqlDbType.VarChar),
                                                new SqlParameter("@preName", SqlDbType.VarChar),
                                                new SqlParameter("@Name", SqlDbType.VarChar),
                                                new SqlParameter("@preSdw", SqlDbType.VarChar),
                                                new SqlParameter("@sdwName", SqlDbType.VarChar),
                                                new SqlParameter("@pancard", SqlDbType.VarChar),
                                                new SqlParameter("@email", SqlDbType.VarChar),
                                                new SqlParameter("@preAddress", SqlDbType.Text),
                                                new SqlParameter("@perAddress", SqlDbType.Text),
                                                new SqlParameter("@prePincode", SqlDbType.VarChar),
                                                new SqlParameter("@perPincode", SqlDbType.VarChar),
                                                new SqlParameter("@mobile", SqlDbType.VarChar),
                                                new SqlParameter("@nominee", SqlDbType.VarChar),
                                                new SqlParameter("@telephone", SqlDbType.VarChar),
                                                new SqlParameter("@relation", SqlDbType.VarChar),
                                                new SqlParameter("@dob ", SqlDbType.Date),
                                                new SqlParameter("@nomDob ", SqlDbType.Date),
                                                new SqlParameter("@age ", SqlDbType.Int),
                                                new SqlParameter("@nomAge ", SqlDbType.Int),
                                                new SqlParameter("@startDate ", SqlDbType.Date),
                                                new SqlParameter("@branchId", SqlDbType.VarChar),
                                                new SqlParameter("@preNom", SqlDbType.VarChar),
                                                new SqlParameter("@code", SqlDbType.VarChar)
                                              };

                ParameterArray[0].Value = introducer;
                ParameterArray[1].Value = preName;
                ParameterArray[2].Value = name;
                ParameterArray[3].Value = preSdw;
                ParameterArray[4].Value = sdwName;
                ParameterArray[5].Value = pancard;
                ParameterArray[6].Value = email;
                ParameterArray[7].Value = preAdd;
                ParameterArray[8].Value = perAdd;
                ParameterArray[9].Value = prePin;
                ParameterArray[10].Value = perPin;
                ParameterArray[11].Value = mobile;
                ParameterArray[12].Value = nominee;
                ParameterArray[13].Value = telephone;
                ParameterArray[14].Value = relation;
                ParameterArray[15].Value = dob;
                ParameterArray[16].Value = nomDob;
                ParameterArray[17].Value = age;
                ParameterArray[18].Value = nomAge;
                ParameterArray[19].Value = StartDate;
                ParameterArray[20].Value = BranchId;
                ParameterArray[21].Value = preNom;
                ParameterArray[22].Value = code;

                return DAL.ExecuteMMScalarSP("SaveCustomer", ParameterArray);

        }

        public DataSet BindPosts()
        {
            return DAL.ExecuteDatasetSP("spBindPosts");
        }

    }
}
