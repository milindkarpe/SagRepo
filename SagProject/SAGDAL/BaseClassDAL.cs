using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAGDAL
{
    public abstract class BaseClassDAL
    {
        protected SqlBaseClassDAL DAL;

        public BaseClassDAL()
        {
            InstanTiateDAL();
        }

        private void InstanTiateDAL()
        {
            if (DAL == null)
            {
                DAL = new SqlBaseClassDAL();
            }
        }
    }
}
