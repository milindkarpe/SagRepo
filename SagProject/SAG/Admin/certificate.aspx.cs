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
                    lblNominee.Text = ds.Tables[0].Rows[0]["Nominee"].ToString();
                    lblNomineeAge.Text = ds.Tables[0].Rows[0]["nomAge"].ToString();
                    lblRelation.Text = ds.Tables[0].Rows[0]["Relation"].ToString();
                    lblRegNoDate.Text =PolicyId.ToString()+"  "+ ds.Tables[0].Rows[0]["StartDate"].ToString();
                    lblPlan.Text = ds.Tables[0].Rows[0]["PlanType"].ToString() + " " + ds.Tables[0].Rows[0]["PlanName"].ToString(); ;
                    lblPayMode.Text = ds.Tables[0].Rows[0]["PayModeText"].ToString();
                    lblAmtConsidaration.Text = ds.Tables[0].Rows[0]["Amount"].ToString();

                }
            
            }
            catch (Exception ex) { lblError.Text = ex.Message; }
        }

    }
}