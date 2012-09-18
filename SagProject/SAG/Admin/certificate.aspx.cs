using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAGDAL;

namespace SAG.Admin
{
    public partial class certificate : System.Web.UI.Page
    {
        PolicyDAL policyDAL = new PolicyDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckQueryString();
            }
        }

        protected void CheckQueryString()
        {
            if (Request.QueryString["policyId"] != null)
            {
                Int64 PolicyId;
                PolicyId = Convert.ToInt64(Request.QueryString["policyId"]);

                GenerateCertificate(PolicyId);
            }
        }

        protected void GenerateCertificate(Int64 PolicyId)
        {
            try {

                DataSet ds= policyDAL.BindCertificateDAL(PolicyId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblTodaysDate.Text=System.DateTime.Now.ToShortDateString();
                    lblCustId.Text = ds.Tables[0].Rows[0]["CID"].ToString();
                    lblPurchaser.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblAddress.Text = ds.Tables[0].Rows[0]["perAddress"].ToString() + "<br> Mobile - "+ ds.Tables[0].Rows[0]["mobile"].ToString();
                    lblPurchaserAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                    lblNominee.Text = ds.Tables[0].Rows[0]["NomName"].ToString();
                    lblNomineeAge.Text = ds.Tables[0].Rows[0]["nomAge"].ToString();
                    lblRelation.Text = ds.Tables[0].Rows[0]["NomAdd"].ToString();
                    lblRegNoDate.Text =PolicyId.ToString()+"  -  "+ ds.Tables[0].Rows[0]["StartDate"].ToString();
                    lblPlan.Text = ds.Tables[0].Rows[0]["PlanType"].ToString() + " " + ds.Tables[0].Rows[0]["PlanName"].ToString(); ;
                    lblPayMode.Text = ds.Tables[0].Rows[0]["PayModeText"].ToString();
                    
                    lblAmtConsidaration.Text = ds.Tables[0].Rows[0]["PlanAmount"].ToString();
                    lblInstallAmt.Text = ds.Tables[0].Rows[0]["InstallmentAmount"].ToString();
                    lblSumPayable.Text = ds.Tables[0].Rows[0]["MaturityAmount"].ToString();
                    lblDeathAmount.Text = ds.Tables[0].Rows[0]["DeathAmount"].ToString();
                    lblMRAmount.Text = ds.Tables[0].Rows[0]["MRAmount"].ToString();

                    lblDueDate.Text = ds.Tables[0].Rows[0]["DueDate"].ToString();
                    lblLastPayDate.Text = ds.Tables[0].Rows[0]["LastPayDate"].ToString();
                    lblExpiryDate.Text = ds.Tables[0].Rows[0]["ExpDate"].ToString();

                    lblSeCode.Text = ds.Tables[0].Rows[0]["DID"].ToString();
                }
            
            }
            catch (Exception ex) { lblError.Text = ex.Message; }
        }

    }
}