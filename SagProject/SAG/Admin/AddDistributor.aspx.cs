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
    public partial class AddDistributor : System.Web.UI.Page
    {
        DistributorDAL DistDAL = new DistributorDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL("Rank", "Rank", "RankID", ddlRank);
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

            
            try
            {
                DistDAL.SaveDistributorDAL(int.Parse(ddlRank.SelectedValue.ToString()),
                                            txtIntroducer.Text,
                                            ddlPre.SelectedItem.Text.ToString(),
                                            txtName.Text,
                                            ddlPreSDW.SelectedItem.Text.ToString(),
                                            txtSDW.Text,
                                            txtPan.Text,
                                            txtEmail.Text,
                                            txtPreAdd.Text,
                                            txtPrePin.Text,
                                            txtPerAdd.Text,
                                            txtPerPin.Text,
                                            txtMobile.Text,
                                            txtTelephone.Text,
                                            Convert.ToDateTime(txtDOB.Text),
                                            int.Parse(txtAge.Text),
                                            txtNominee.Text,
                                            txtRelation.Text,
                                            Convert.ToDateTime(txtDBONom.Text),
                                            int.Parse(txtAgeNom.Text),
                                            Convert.ToDateTime(txtJoinDate.Text),
                                            ddlCSC.SelectedValue.ToString()
                                            );

                //String strInsert = "Insert into Distributor(RankID,introducer,preName,Name,preSdw,sdwName,pancard,email,preAddress,prePincode,";
                //strInsert += " perAddress,perPincode,mobile,telephone,dob,age,nominee,relation,nomDob,nomAge,joinDate,branchId)";
                //strInsert += "Values(";
                //strInsert += int.Parse(ddlRank.SelectedValue.ToString()) + ",";
                //strInsert += "'" + txtIntroducer.Text + "',";
                //strInsert += "'" + ddlPre.SelectedItem.Text.ToString() + "',";
                //strInsert += "'" + txtName.Text.ToString() + "',";
                //strInsert += "'" + ddlPreSDW.SelectedItem.Text.ToString() + "',";
                //strInsert += "'" + txtSDW.Text.ToString() + "',";
                //strInsert += "'" + txtPan.Text.ToString() + "',";
                //strInsert += "'" + txtEmail.Text.ToString() + "',";
                //strInsert += "'" + txtPreAdd.Text.ToString() + "',";
                //strInsert += "'" + txtPrePin.Text.ToString() + "',";
                //strInsert += "'" + txtPerAdd.Text.ToString() + "',";
                //strInsert += "'" + txtPerPin.Text.ToString() + "',";
                //strInsert += "'" + txtMobile.Text.ToString() + "',";
                //strInsert += "'" + txtTelephone.Text.ToString() + "',";
                //strInsert += "'" + Convert.ToDateTime(txtDOB.Text.ToString()) + "',";
                //strInsert += "'" + txtAge.Text.ToString() + "',";
                //strInsert += "'" + txtNominee.Text.ToString() + "',";
                //strInsert += "'" + txtRelation.Text.ToString() + "',";
                //strInsert += "'" + Convert.ToDateTime(txtDBONom.Text.ToString()) + "',";
                //strInsert += "'" + txtAgeNom.Text.ToString() + "',";
                //strInsert += "'" + Convert.ToDateTime(txtJoinDate.Text.ToString()) + "',";
                //strInsert += "'" + ddlCSC.SelectedValue.ToString() + "')";

                //clsDb.InsertUpdate(strInsert.ToString());

                ResetAll();

                lblMsg.Visible = true;
                lblMsg.Text = "Distributor Information Saved Successfully";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ResetAll()
        {
            ddlCSC.SelectedIndex = -1;
            ddlPre.SelectedIndex = -1;
            ddlPreSDW.SelectedIndex = -1;
            ddlRank.SelectedIndex = -1;

            txtAge.Text = "";
            txtAgeNom.Text = "";
            txtDBONom.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtIntroducer.Text = "";
            txtJoinDate.Text = "";
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