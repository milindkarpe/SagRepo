using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SAGDAL;

namespace SAGDAL
{
    public class CustomerDAL : BaseClassDAL
    {
        public DataTable BindPosts()
        {
            return DAL.ExecuteReader("select * from branch");
        }

       
    }
}
