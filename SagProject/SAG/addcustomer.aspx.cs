using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAGDAL;

namespace SAG
{
    public partial class addcustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                BindDDL("Branch", "bName", "BranchId", ddlCSC);
            }
        }

        public void BindDDL(String TableName, string ColumnName, String IDColumn, DropDownList DDLName)
        {
            DataSet dsTemp = clsDb.GetDatasets("Select * from " + TableName.ToString());

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                DDLName.DataSource = dsTemp.Tables[0];

                DDLName.DataTextField = ColumnName.ToString();
                DDLName.DataValueField = IDColumn.ToString();

                DDLName.DataBind();

                DDLName.Items.Insert(0, new ListItem("Select", "00"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}