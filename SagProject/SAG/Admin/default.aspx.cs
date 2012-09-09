using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAGDAL;

namespace SAG
{
    public partial class _default : System.Web.UI.Page
    {
        CustomerDAL cust = new CustomerDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Repeater1.DataSource = cust.BindPosts();
            //Repeater1.DataBind();
            
        }
    }
}