using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAGDAL;

namespace SAG.Admin
{
    public partial class FreshBusiness : System.Web.UI.Page
    {
        PolicyDAL PDAL = new PolicyDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL("PlanType", "PlanType", "PTID", ddlPlanType);
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

        public void BindPlanDDL(String TableName, string ColumnName, String IDColumn, DropDownList DDLName)
        {
            DataSet dsTemp = clsDb.GetDatasets("Select * from [" + TableName.ToString() + "] where PTID=" + ddlPlanType.SelectedValue.ToString());

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                DDLName.DataSource = dsTemp.Tables[0];

                DDLName.DataTextField = ColumnName.ToString();
                DDLName.DataValueField = IDColumn.ToString();

                DDLName.DataBind();

                DDLName.Items.Insert(0, new ListItem("Select", "00"));
            }
        }

        protected void ddlPlanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPlanDDL("Plan", "PlanName", "PID", ddlPlanName);

            int PT = int.Parse(ddlPlanType.SelectedValue.ToString());

            if (PT > 1)
            {
                ddlPayMode.SelectedIndex = ddlPayMode.Items.IndexOf(ddlPayMode.Items.FindByValue("4"));
                ddlPayMode.Enabled = false;
            }
            else
            {
                ddlPayMode.Enabled = true;
            }
        }

        protected void txtCustCode_TextChanged(object sender, EventArgs e)
        {
            DataSet dsCust = clsDb.GetDatasets("Select * from Customer where CID=" + txtCustCode.Text);

            if (dsCust.Tables[0].Rows.Count > 0)
            {
                txtCustName.Text = dsCust.Tables[0].Rows[0]["PreName"].ToString() + " " + dsCust.Tables[0].Rows[0]["Name"].ToString();
                txtIntroCode.Focus();
            }
            else
            {
                txtCustCode.Text = "";
                txtCustName.Text = "CUSTOMER CODE DOES NOT EXIST";
                txtCustCode.Focus();
            }
        }

        protected void txtIntroCode_TextChanged(object sender, EventArgs e)
        {
            DataSet dsCust = clsDb.GetDatasets("Select * from Distributor where DID=" + txtIntroCode.Text);

            if (dsCust.Tables[0].Rows.Count > 0)
            {
                txtIntroName.Text = dsCust.Tables[0].Rows[0]["PreName"].ToString() + " " + dsCust.Tables[0].Rows[0]["Name"].ToString();
                txtAmtRec.Focus();
            }
            else
            {
                txtIntroCode.Text = "";
                txtIntroName.Text = "DISTRIBUTOR CODE DOES NOT EXIST";
                txtIntroCode.Focus();
            }
        }

        protected void ddlAmtRecMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlAmtRecMode.SelectedValue.ToString()) == 1)
            {
                txtBankName.Text = "";
                txtChqNo.Text = "";
                
                txtChqNo.Enabled = true;
                txtBankName.Enabled = true;

                txtChqNo.CssClass = "input-mini";
            }
            else
            {
                txtChqNo.Text = "000000";
                txtBankName.Text = "N/A";

                txtChqNo.Enabled = false;
                txtBankName.Enabled = false;

                txtChqNo.CssClass = "input-mini disabled";
                txtBankName.CssClass = "input disabled";
            }
        }

        protected void txtRegFees_TextChanged(object sender, EventArgs e)
        {
            txtNetAmt.Text = Convert.ToString(Int64.Parse(txtAmtRec.Text) - Int64.Parse(txtRegFees.Text));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string PolicyID = PDAL.SavePolicyDAL(int.Parse(ddlPlanType.SelectedValue)
                                                , int.Parse(ddlPlanName.SelectedValue)
                                                , ddlPayMode.SelectedValue
                                                , ddlPayMode.SelectedItem.Text
                                                , Int64.Parse(txtCustCode.Text)
                                                , Int64.Parse(txtIntroCode.Text)
                                                , Int64.Parse(txtNetAmt.Text)
                                                , ddlAmtRecMode.SelectedItem.Text
                                                , txtChqNo.Text
                                                , txtBankName.Text
                                                , Convert.ToDateTime(txtPurDate.Text)
                                                );

            ResetAll();

            lblMsg.Visible = true;
            lblMsg.Text = "Policy Stored Successfully Policy ID : " + PolicyID.ToString();

        }

        protected void ResetAll()
        {
            ddlAmtRecMode.SelectedIndex = -1;
            ddlPayMode.SelectedIndex = -1;
            ddlPlanName.SelectedIndex = -1;
            ddlPlanType.SelectedIndex = -1;

            txtAmtRec.Text = "";
            txtBankName.Text = "";
            txtChqNo.Text = "";
            txtCustCode.Text = "";
            txtCustName.Text = "";
            txtIntroCode.Text = "";
            txtIntroName.Text = "";
            txtNetAmt.Text = "";
            txtPurDate.Text = "";
            txtRegFees.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            lblMsg.Visible = false;
        }
    }
}