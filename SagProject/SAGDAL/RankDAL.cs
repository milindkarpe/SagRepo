using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SAGDAL;

namespace SAGDAL
{
    public class RankDAL : SqlBaseClassDAL
    {
        public String SaveRankDAL(String Rank, Double PQ)
        {
            SqlParameter[] ParameterArray ={ new SqlParameter("@Rank",DbType.String),
                                               new SqlParameter("@PQ",DbType.Double)
                                           };

            String Status = ExecuteMMScalarSP("SPSaveRank", ParameterArray);

            return Status;
        }

        public DataSet SearchRankDAL(String Rank)
        {
            SqlParameter[] ParameterArray ={ new SqlParameter("@Rank",DbType.String)                                               
                                           };

            DataSet dsRank = ExecuteDatasetSP("SPSearchRank", ParameterArray);

            return dsRank;
        }
    }
}
