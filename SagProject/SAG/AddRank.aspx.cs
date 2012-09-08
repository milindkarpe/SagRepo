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
    public partial class AddRank : System.Web.UI.Page
    {
        RankDAL RDAL = new RankDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Check
            if (lblRankID.Text == "")
            {
                DataSet dsChk = clsDb.GetDatasets("Select * from Rank where Rank like '" + txtRank.Text + "'");

                if (dsChk.Tables[0].Rows.Count > 0)
                {
                    lblSaveError.Visible = true;
                    lblSaveError.Text = "Rank Already Exists!";

                    lblSaveMsg.Visible = false;
                }
                else
                {

                    String strInsert = "Insert into Rank (Rank,PQuota) values ('" + txtRank.Text + "'," + txtPQ.Text + ")";
                    clsDb.InsertUpdate(strInsert.ToString());

                    ClearAll();

                    lblSaveMsg.Visible = true;
                    lblSaveMsg.Text = "Data Saved Successfully";

                    lblSaveError.Visible = false;
                }
            }
            else
            {
                String strUpdate = "Update Rank set Rank='" + txtRank.Text + "',PQuota=" + txtPQ.Text + " where RankID=" + lblRankID.Text;
                clsDb.InsertUpdate(strUpdate.ToString());

                ClearAll();

                lblSaveMsg.Visible = true;
                lblSaveMsg.Text = "Data Updated Successfully";

                lblSaveError.Visible = false;
            }


            //String Status = RDAL.SaveRankDAL(txtRank.Text.ToString(), Convert.ToDouble(txtPQ.Text.ToString()));

            //if (Status == "1")
            //{
            //    lblSaveMsg.Visible = true;
            //    lblSaveMsg.Text = "Data Saved Successfully";

            //    lblSaveError.Visible = false;
            //}
            //else
            //{
            //    lblSaveError.Visible = true;
            //    lblSaveError.Text = "Rank Already Exists!";

            //    lblSaveMsg.Visible = false;
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSearch();
        }

        protected void ClearAll()
        {
            txtPQ.Text = "";
            txtRank.Text = "";
        }

        public void BindSearch()
        {
            DataSet dsRank = clsDb.GetDatasets("Select * from Rank where Rank like '%" + txtRankforSearch.Text + "%'");

            gvRank.DataSource = dsRank.Tables[0];
            gvRank.DataBind();
        }



        protected void gvRank_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblIRD = (Label)gvRank.Rows[e.RowIndex].FindControl("lblRID");

            int RankID = int.Parse(lblIRD.Text.ToString());

            String strDelete = "Delete from Rank where RankID=" + RankID.ToString();
            clsDb.InsertUpdate(strDelete.ToString());

            lblMsg.Visible = true;
            lblMsg.Text = "Rank Deleted Successfully";

            lblErrorMsg.Visible = false;

            BindSearch();
        }

        protected void gvRank_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lblIRD = (Label)gvRank.Rows[e.NewEditIndex].FindControl("lblRID");

            int RankID = int.Parse(lblIRD.Text.ToString());

            lblRankID.Text = RankID.ToString();

            DataSet dsRankInfo = clsDb.GetDatasets("Select Rank,PQuota from Rank where RankID=" + RankID.ToString());

            txtRank.Text = dsRankInfo.Tables[0].Rows[0]["Rank"].ToString();
            txtPQ.Text = dsRankInfo.Tables[0].Rows[0]["PQuota"].ToString();

            tcRank.ActiveTabIndex = 0;
        }
    }
}