using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAGDAL;

namespace SAG.Admin
{
    public partial class printCertificate : System.Web.UI.Page
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
            try
            {

                DataSet ds = policyDAL.BindCertificateDAL(PolicyId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblTodaysDate.Text = System.DateTime.Now.ToShortDateString();
                    // lblCustId.Text = ds.Tables[0].Rows[0]["CID"].ToString();
                    lblPurchaser.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblAddress.Text = ds.Tables[0].Rows[0]["perAddress"].ToString();
                    lblTelephone.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                    lblPurchaserAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                    lblNominee.Text = ds.Tables[0].Rows[0]["NomName"].ToString();
                    lblNomineeAge.Text = ds.Tables[0].Rows[0]["nomAge"].ToString();
                    lblRelation.Text = ds.Tables[0].Rows[0]["NomAdd"].ToString();
                    lblRegNoDate.Text = PolicyId.ToString() + "  -  " + ds.Tables[0].Rows[0]["StartDate"].ToString();
                    lblPlan.Text = ds.Tables[0].Rows[0]["PlanName"].ToString() + " Years";
                    lblPayMode.Text = ds.Tables[0].Rows[0]["PayModeText"].ToString();

                    lblAmtConsidaration.Text = ds.Tables[0].Rows[0]["PlanAmount"].ToString();
                    lblInstallAmt.Text = ds.Tables[0].Rows[0]["InstallmentAmount"].ToString();
                    lblSumPayable.Text = ds.Tables[0].Rows[0]["MaturityAmount"].ToString();
                    // lblDeathAmount.Text = ds.Tables[0].Rows[0]["DeathAmount"].ToString();
                    // lblMRAmount.Text = ds.Tables[0].Rows[0]["MRAmount"].ToString();

                    lblDueDate.Text = ds.Tables[0].Rows[0]["DueDate"].ToString();
                    lblLastPayDate.Text = ds.Tables[0].Rows[0]["LastPayDate"].ToString();
                    lblExpiryDate.Text = ds.Tables[0].Rows[0]["ExpDate"].ToString();

                    lblSeCode.Text = ds.Tables[0].Rows[0]["DID"].ToString();


                    lblRegNo.Text = PolicyId.ToString();
                    
                    lblRDate.Text = System.DateTime.Now.ToShortDateString();

                    lblRCodeNo.Text = ds.Tables[0].Rows[0]["DID"].ToString();

                    lblRName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblRAdd.Text = ds.Tables[0].Rows[0]["perAddress"].ToString();
                    lblAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();

                    lblRPlanNoTerm.Text = ds.Tables[0].Rows[0]["PlanName"].ToString() + " Years";
                    lblRStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                    lblRDueDate.Text = ds.Tables[0].Rows[0]["DueDate"].ToString();
                    lblRExpDate.Text = ds.Tables[0].Rows[0]["ExpDate"].ToString();

                    lblRPlanAmount.Text = ds.Tables[0].Rows[0]["PlanAmount"].ToString();
                    lblRInstalAmount.Text = ds.Tables[0].Rows[0]["InstallmentAmount"].ToString();

                    lblSumPayWords.Text = retWord(Int64.Parse(lblSumPayable.Text)) + "Rupees Only";
                }

            }
            catch (Exception ex) { lblError.Text = ex.Message; }
        }

        public string retWord(Int64 number)
        {

            if (number == 0) return "Zero";

            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

            Int64[] num = new Int64[4];

            int first = 0;

            Int64 u, h, t;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {

                sb.Append("Minus ");

                number = -number;

            }

            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };

            string[] words = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };

            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            num[0] = number % 1000; // units

            num[1] = number / 1000;

            num[2] = number / 100000;

            num[1] = num[1] - 100 * num[2]; // thousands

            num[3] = number / 10000000; // crores

            num[2] = num[2] - 100 * num[3]; // lakhs



            for (int i = 3; i > 0; i--)
            {

                if (num[i] != 0)
                {

                    first = i;

                    break;

                }

            }

            for (int i = first; i >= 0; i--)
            {

                if (num[i] == 0) continue;

                u = num[i] % 10; // ones

                t = num[i] / 10;

                h = num[i] / 100; // hundreds

                t = t - 10 * h; // tens

                if (h > 0) sb.Append(words0[h] + "Hundred ");

                if (u > 0 || t > 0)
                {

                    if (h > 0 || i == 0) sb.Append("and ");

                    if (t == 0)

                        sb.Append(words0[u]);

                    else if (t == 1)

                        sb.Append(words[u]);

                    else

                        sb.Append(words2[t - 2] + words0[u]);

                }

                if (i != 0) sb.Append(words3[i - 1]);

            }

            return sb.ToString().TrimEnd();

        }

    }
}