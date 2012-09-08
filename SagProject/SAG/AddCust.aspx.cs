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
    public partial class AddCust : System.Web.UI.Page
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
            String Code;

            DataSet dsCustCount = clsDb.GetDatasets("Select Count(CID) as TotalCust from Customer");

            Int64 Count = Int64.Parse(dsCustCount.Tables[0].Rows[0]["TotalCust"].ToString());

            Code = ddlCSC.SelectedValue.ToString() + "-" + txtIntroducer.Text + "-" + (Count + 1).ToString();
            
            String strInsert = "Insert into Customer(Code,introducer,preName,Name,preSdw,sdwName,pancard,email,preAddress,prePincode,";
            strInsert += " perAddress,perPincode,mobile,telephone,dob,age,nominee,relation,nomDob,nomAge,branchId)";
            strInsert += "Values(";
            strInsert += "'" + Code.ToString() + "',";
            strInsert += "'" + txtIntroducer.Text + "',";
            strInsert += "'" + ddlPre.SelectedItem.Text.ToString() + "',";
            strInsert += "'" + txtName.Text.ToString() + "',";
            strInsert += "'" + ddlSDW.SelectedItem.Text.ToString() + "',";
            strInsert += "'" + txtSDW.Text.ToString() + "',";
            strInsert += "'" + txtPan.Text.ToString() + "',";
            strInsert += "'" + txtEmail.Text.ToString() + "',";
            strInsert += "'" + txtPreAdd.Text.ToString() + "',";
            strInsert += "'" + txtPrePin.Text.ToString() + "',";
            strInsert += "'" + txtPerAdd.Text.ToString() + "',";
            strInsert += "'" + txtPerPin.Text.ToString() + "',";
            strInsert += "'" + txtMobile.Text.ToString() + "',";
            strInsert += "'" + txtTelephone.Text.ToString() + "',";
            strInsert += "'" + Convert.ToDateTime(txtDOB.Text.ToString()) + "',";
            strInsert += "'" + txtAge.Text.ToString() + "',";
            strInsert += "'" + txtNominee.Text.ToString() + "',";
            strInsert += "'" + txtRelation.Text.ToString() + "',";
            strInsert += "'" + Convert.ToDateTime(txtDBONom.Text.ToString()) + "',";
            strInsert += "'" + txtAgeNom.Text.ToString() + "',";            
            strInsert += "'" + ddlCSC.SelectedValue.ToString() + "')";

            clsDb.InsertUpdate(strInsert.ToString());

            ResetAll();

            lblMsg.Visible = true;
            lblMsg.Text = "Customer Information Saved Successfully. Your Code is <b>" + Code.ToString() + "</b>";
        }

        public void ResetAll()
        {
            ddlCSC.SelectedIndex = -1;
            ddlPre.SelectedIndex = -1;
            ddlSDW.SelectedIndex = -1;

            txtAge.Text = "";
            txtAgeNom.Text = "";
            txtDBONom.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtIntroducer.Text = "";            
            txtMobile.Text = "";
            txtName.Text = "";
            txtNominee.Text = "";
            txtPan.Text = "";
            txtPerAdd.Text = "";
            txtPerPin.Text = "";
            txtPreAdd.Text = "";
            txtPrePin.Text = "";
            txtRelation.Text = "";
            txtSDW.Text = "";
            txtTelephone.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            lblMsg.Visible = false;
        }
    }
}