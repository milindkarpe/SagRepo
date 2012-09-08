using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAGDAL;
using System.Data;

namespace SAG
{
    public partial class AddBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblBranchID.Text == "")
            {
                DataSet dsChk = clsDb.GetDatasets("Select * from Branch where bName like '" + txtBName.Text + "'");

                if (dsChk.Tables[0].Rows.Count > 0)
                {
                    lblSaveError.Visible = true;
                    lblSaveError.Text = "Branch Name Already Exists!";

                    lblSaveMsg.Visible = false;
                }
                else
                {

                    String strInsert = "Insert into Branch (bCode,bName,bState,bCity,bAddress,bTelephone) values ('" + txtCode.Text + "','" + txtBName.Text + "','" + txtState.Text + "','" + txtCity.Text + "','" + txtAddress.Text + "','" + txtTelephone.Text + "')";
                    clsDb.InsertUpdate(strInsert.ToString());

                    ClearAll();

                    lblSaveMsg.Visible = true;
                    lblSaveMsg.Text = "Data Saved Successfully";

                    lblSaveError.Visible = false;
                }
            }
            else
            {
                String strUpdate = "Update Branch set bCode='" + txtCode.Text + "',bName='" + txtBName.Text + "',bState='" + txtState.Text + "',bCity='" + txtCity.Text + "',bAddress='" + txtAddress.Text + "',bTelephone='" + txtTelephone.Text + "' where BranchID=" + lblBranchID.Text;
                clsDb.InsertUpdate(strUpdate.ToString());

                ClearAll();

                lblSaveMsg.Visible = true;
                lblSaveMsg.Text = "Data Updated Successfully";

                lblSaveError.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSearch();
        }

        protected void ClearAll()
        {
            txtAddress.Text = "";
            txtBName.Text = "";
            txtCity.Text = "";
            txtCode.Text = "";
            txtState.Text = "";
            txtTelephone.Text = "";
        }

        public void BindSearch()
        {
            DataSet dsRank = clsDb.GetDatasets("Select * from Branch where bName like '%" + txtBranchforSearch.Text + "%'");

            gvBranch.DataSource = dsRank.Tables[0];
            gvBranch.DataBind();
        }

        protected void gvBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblBID = (Label)gvBranch.Rows[e.RowIndex].FindControl("lblBID");

            int BranchID = int.Parse(lblBID.Text.ToString());

            String strDelete = "Delete from Branch where BranchID=" + BranchID.ToString();
            clsDb.InsertUpdate(strDelete.ToString());

            lblMsg.Visible = true;
            lblMsg.Text = "Branch Deleted Successfully";

            lblErrorMsg.Visible = false;

            BindSearch();
        }

        protected void gvBranch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lblBID = (Label)gvBranch.Rows[e.NewEditIndex].FindControl("lblBID");

            int BranchID = int.Parse(lblBID.Text.ToString());

            lblBranchID.Text = BranchID.ToString();

            DataSet dsRankInfo = clsDb.GetDatasets("Select * from Branch where BranchID=" + BranchID.ToString());

            txtCode.Text = dsRankInfo.Tables[0].Rows[0]["bCode"].ToString();
            txtBName.Text = dsRankInfo.Tables[0].Rows[0]["bName"].ToString();
            txtState.Text = dsRankInfo.Tables[0].Rows[0]["bState"].ToString();
            txtCity.Text = dsRankInfo.Tables[0].Rows[0]["bCity"].ToString();
            txtAddress.Text = dsRankInfo.Tables[0].Rows[0]["bAddress"].ToString();
            txtTelephone.Text = dsRankInfo.Tables[0].Rows[0]["bTelephone"].ToString();

            tcBranch.ActiveTabIndex = 0;
        }

       
    }
}