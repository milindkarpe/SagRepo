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
        string PolicyID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPlanTypeDDL();
            }
        }

        public void BindPlanTypeDDL()
        {
            DataSet dsTemp = PDAL.BindPlanType();

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                ddlPlanType.DataSource = dsTemp.Tables[0];

                ddlPlanType.DataTextField = "PlanType";
                ddlPlanType.DataValueField = "PTID";

                ddlPlanType.DataBind();

                ddlPlanType.Items.Insert(0, new ListItem("Select", "00"));
            }
        }

        public void BindPlanDDL(int PTID)
        {
            DataSet dsTemp = PDAL.BindPlan(PTID);

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                ddlPlanName.DataSource = dsTemp.Tables[0];

                ddlPlanName.DataTextField = "PlanName";
                ddlPlanName.DataValueField = "PID";

                ddlPlanName.DataBind();

                ddlPlanName.Items.Insert(0, new ListItem("Select", "00"));
            }
        }

        protected void ddlPlanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PT = int.Parse(ddlPlanType.SelectedValue.ToString());

            BindPlanDDL(PT);

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
            try
            {
                DataSet dsCust = PDAL.GetCustomerDetailsDAL(Int64.Parse(txtCustCode.Text));

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

            catch (Exception Ex)
            {
                txtCustCode.Text = "";
                txtCustName.Text = "CUSTOMER CODE DOES NOT EXIST";
                txtCustCode.Focus();
            }
        }

        protected void txtIntroCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet dsCust = PDAL.GetIntroducerDetailsDAL(Int64.Parse(txtIntroCode.Text));

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

            catch (Exception Ex)
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
            txtNetAmt.Text = Convert.ToString(Int64.Parse(txtAmtRec.Text) + Int64.Parse(txtRegFees.Text));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ///////////////////// GENERATING PLAN DETAILS - PLAN AMOUNT, MATURITY BENEFIT, END DATE, LAST PAYMENT DATE ETC START 

            Double PlanAmount = 0, InstallmentAmount, MaturityAmount = 0;
            DateTime PurDate, DueDate, LastPayDate, ExpDate;

            //FIND SELECTED PLAN AND DO CALCULATIONS [1 FOR MFP]
            if (ddlPlanType.SelectedValue.ToString() == "1")
            {
                Double MultiplyBy = 0;

                //GETTING VALUES OF 100 UNIT OF SELECTED PLAN
                Int16 PlanID = Int16.Parse(ddlPlanName.SelectedValue.ToString());
                DataSet dsUnit = PDAL.GetMFPUnitByPlanIDDAL(PlanID);

                //GET PAYMENT MODE
                int PayMode = int.Parse(ddlPayMode.SelectedValue.ToString());

                if (PayMode == 1)
                {
                    Double MIFromUnit = Convert.ToDouble(dsUnit.Tables[0].Rows[0]["MI"].ToString());

                    Double InstallmentFromCust = Convert.ToDouble(txtAmtRec.Text.ToString());

                    MultiplyBy = InstallmentFromCust / MIFromUnit;

                    PlanAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["PlanAmount"].ToString());
                    MaturityAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["TotaAmount"].ToString());
                }

                if (PayMode == 2)
                {
                    Double MIFromUnit = Convert.ToDouble(dsUnit.Tables[0].Rows[0]["QI"].ToString());

                    Double InstallmentFromCust = Convert.ToDouble(txtAmtRec.Text.ToString());

                    MultiplyBy = InstallmentFromCust / MIFromUnit;

                    PlanAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["PlanAmount"].ToString());
                    MaturityAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["TotaAmount"].ToString());
                }

                if (PayMode == 3)
                {
                    Double MIFromUnit = Convert.ToDouble(dsUnit.Tables[0].Rows[0]["HYI"].ToString());

                    Double InstallmentFromCust = Convert.ToDouble(txtAmtRec.Text.ToString());

                    MultiplyBy = InstallmentFromCust / MIFromUnit;

                    PlanAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["PlanAmount"].ToString());
                    MaturityAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["TotaAmount"].ToString());
                }

                if (PayMode == 4)
                {
                    Double MIFromUnit = Convert.ToDouble(dsUnit.Tables[0].Rows[0]["YI"].ToString());

                    Double InstallmentFromCust = Convert.ToDouble(txtAmtRec.Text.ToString());

                    MultiplyBy = InstallmentFromCust / MIFromUnit;

                    PlanAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["PlanAmount"].ToString());
                    MaturityAmount = MultiplyBy * Convert.ToDouble(dsUnit.Tables[0].Rows[0]["TotaAmount"].ToString());
                }

                InstallmentAmount = Convert.ToDouble(txtAmtRec.Text.ToString());

                PurDate = Convert.ToDateTime(txtPurDate.Text.ToString());
                DueDate = PurDate.AddYears(PlanID);
                LastPayDate = DueDate.AddMonths(-1);
                ExpDate = DueDate.AddMonths(1);


                ///////////////////// GENERATING PLAN DETAILS - PLAN AMOUNT, MATURITY BENEFIT, END DATE, LAST PAYMENT DATE ETC END

                PolicyID = PDAL.SavePolicyDAL(int.Parse(ddlPlanType.SelectedValue)
                                                    , int.Parse(ddlPlanName.SelectedValue)
                                                    , int.Parse(ddlPayMode.SelectedValue)
                                                    , ddlPayMode.SelectedItem.Text
                                                    , Int64.Parse(txtCustCode.Text)
                                                    , Int64.Parse(txtIntroCode.Text)
                                                    , ddlAmtRecMode.SelectedItem.Text
                                                    , txtChqNo.Text
                                                    , txtBankName.Text
                                                    , PurDate
                                                    , DueDate
                                                    , LastPayDate
                                                    , ExpDate
                                                    , PlanAmount
                                                    , InstallmentAmount
                                                    , MaturityAmount
                                                    , txtNomName.Text
                                                    , Int16.Parse(txtNomAge.Text)
                                                    , Convert.ToDateTime(txtNomDOB.Text)
                                                    , txtNomAdd.Text
                                                    , txtCustBankName.Text
                                                    , txtBranchName.Text
                                                    , txtAccNo.Text
                                                    , txtAccType.Text
                                                    );

                ResetAll();

                lblMsg.Visible = true;
                lblMsg.Text = "Policy Stored Successfully Policy ID : " + PolicyID.ToString();
                lnbCertificateLink.Visible = true;
                lnbCertificateLink.NavigateUrl = "~/admin/certificate.aspx?policyid=" + PolicyID;
            }
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

            txtNomAdd.Text = "";
            txtNomAge.Text = "";
            txtNomDOB.Text = "";
            txtNomName.Text = "";

            txtAccNo.Text = "";
            txtCustBankName.Text = "";
            txtBranchName.Text = "";
            txtAccType.Text = "";

            lblMsg.Visible = false;
            lnbCertificateLink.NavigateUrl = "";
            lnbCertificateLink.Visible = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();

        }

    }
}