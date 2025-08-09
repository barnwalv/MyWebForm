using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebForm.Helper
{
    public class KeyVaultHelper
    {
        private readonly SecretClient _secretClient;

        public KeyVaultHelper()
        {
            // Replace with your Key Vault URL and secret name
            string keyVaultUrlFromAzure = System.Configuration.ConfigurationManager.AppSettings["KeyVaultUrl"];
            

            // Authenticate using DefaultAzureCredential
            _secretClient = new SecretClient(new Uri(keyVaultUrlFromAzure), new DefaultAzureCredential());
        }

        public string GetSecretValue(string secretName)
        {
            // Retrieve the secret from Azure Key Vault
            KeyVaultSecret secret = _secretClient.GetSecret(secretName);
            return secret.Value;
        }
    }
}