using MyWebForm.Helper;
using System;
using System.Web.UI;

namespace MyWebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            // Get Secret from Wb.config
            string secretName = System.Configuration.ConfigurationManager.AppSettings["SecretName"];

            //Get Secret value from helper class.
            var secret = new KeyVaultHelper().GetSecretValue(secretName);

            if (!string.IsNullOrEmpty(secret))
            {
                // Display the secret value in a label or any other control
                lblMessage.Text = $"Secret Value: {secret}";
            }
            else
            {
                lblMessage.Text = "Failed to retrieve secret value.";
            }
        }
    }
}