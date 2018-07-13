using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace Amalay.Helpers
{
    public class KeyVaultHelper
    {
        #region "Singleton Intance"

        private static readonly KeyVaultHelper _Instance = new KeyVaultHelper();
        Dictionary<string, string> keyVaultConfigSettigs = null;

        private KeyVaultHelper()
        {

        }

        public static KeyVaultHelper Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "Public Methods"

        public Dictionary<string, string> GetAllSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, bool checkKeyVaultCertificate = true, bool checkValidCertificateOnly = false)
        {
            if (!string.IsNullOrEmpty(keyVaultConnectionString) && !string.IsNullOrEmpty(keyVaultBaseUrl))
            {
                string certificateSubject = this.GetSubjectNameFromKeyVaultConnectionString(keyVaultConnectionString);

                if (checkKeyVaultCertificate && !this.IsKeyVaultCertificateInstalled(certificateSubject, SearchKeyType.SubjectName, checkValidCertificateOnly))
                {
                    throw new ApplicationException("Either keyVault certificate is not valid or not installed! " + certificateSubject);
                }

                keyVaultConfigSettigs = this.GetSecretsFromKeyVault(keyVaultConnectionString, keyVaultBaseUrl);
            }
            else
            {
                throw new ApplicationException("Either keyVaultConnectionString or keyVaultBaseUrl are not supplied!");
            }

            return keyVaultConfigSettigs;
        }

        public Dictionary<string, string> GetAllSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, List<string> configList, bool checkKeyVaultCertificate = true, bool checkValidCertificateOnly = false)
        {
            if (!string.IsNullOrEmpty(keyVaultConnectionString) && !string.IsNullOrEmpty(keyVaultBaseUrl) && configList != null && configList.Count > 0)
            {
                string certificateSubject = this.GetSubjectNameFromKeyVaultConnectionString(keyVaultConnectionString);

                if (checkKeyVaultCertificate && !this.IsKeyVaultCertificateInstalled(certificateSubject, SearchKeyType.SubjectName, checkValidCertificateOnly))
                {
                    throw new ApplicationException("Either keyVault certificate is not valid or not installed! " + certificateSubject);
                }

                keyVaultConfigSettigs = this.GetSecretsFromKeyVault(keyVaultConnectionString, keyVaultBaseUrl, configList);
            }
            else
            {
                throw new ApplicationException("Either keyVaultConnectionString or keyVaultBaseUrl or configList are not supplied!");
            }

            return keyVaultConfigSettigs;
        }

        public Dictionary<string, string> GetAllSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, string keyVaultCertificateSerialNo, bool checkValidCertificateOnly = false)
        {
            if (!string.IsNullOrEmpty(keyVaultConnectionString) && !string.IsNullOrEmpty(keyVaultBaseUrl) && !string.IsNullOrEmpty(keyVaultCertificateSerialNo))
            {
                if (!this.IsKeyVaultCertificateInstalled(keyVaultCertificateSerialNo, SearchKeyType.SerialNumber, checkValidCertificateOnly))
                {
                    throw new ApplicationException("Either keyvault certificate is not valid or not installed! " + keyVaultCertificateSerialNo);
                }

                keyVaultConfigSettigs = this.GetSecretsFromKeyVault(keyVaultConnectionString, keyVaultBaseUrl);
            }
            else
            {
                throw new ApplicationException("Either keyVaultConnectionString or keyVaultBaseUrl or keyVaultCertificateSerialNo are not supplied!");
            }

            return keyVaultConfigSettigs;
        }

        public Dictionary<string, string> GetAllSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, string keyVaultCertificateSerialNo, List<string> configList, bool checkValidCertificateOnly = false)
        {
            if (!string.IsNullOrEmpty(keyVaultConnectionString) && !string.IsNullOrEmpty(keyVaultBaseUrl) && !string.IsNullOrEmpty(keyVaultCertificateSerialNo) && configList != null && configList.Count > 0)
            {
                if (this.IsKeyVaultCertificateInstalled(keyVaultCertificateSerialNo, SearchKeyType.SerialNumber, checkValidCertificateOnly))
                {
                    throw new ApplicationException("Either keyVault certificate is not valid or not installed! " + keyVaultCertificateSerialNo);
                }

                keyVaultConfigSettigs = this.GetSecretsFromKeyVault(keyVaultConnectionString, keyVaultBaseUrl, configList);
            }
            else
            {
                throw new ApplicationException("Either keyVaultConnectionString or keyVaultBaseUrl or keyVaultCertificateSerialNo or configList are not supplied!");
            }

            return keyVaultConfigSettigs;
        }

        public Dictionary<string, string> GetSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, string keyVaultThumbprint, bool checkValidCertificateOnly = false)
        {
            if (!string.IsNullOrEmpty(keyVaultConnectionString) && !string.IsNullOrEmpty(keyVaultBaseUrl) && !string.IsNullOrEmpty(keyVaultThumbprint))
            {
                if (!this.IsKeyVaultCertificateInstalled(keyVaultThumbprint, SearchKeyType.Thumbprint, checkValidCertificateOnly))
                {
                    throw new ApplicationException("Either keyvault certificate is not valid or not installed! " + keyVaultThumbprint);
                }

                keyVaultConfigSettigs = this.GetSecretsFromKeyVault(keyVaultConnectionString, keyVaultBaseUrl);
            }
            else
            {
                throw new ApplicationException("Either keyVaultConnectionString or keyVaultBaseUrl or keyVaultCertificateSerialNo are not supplied!");
            }

            return keyVaultConfigSettigs;
        }

        public Dictionary<string, string> GetSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, string keyVaultThumbprint, List<string> configList, bool checkValidCertificateOnly = false)
        {
            if (!string.IsNullOrEmpty(keyVaultConnectionString) && !string.IsNullOrEmpty(keyVaultBaseUrl) && !string.IsNullOrEmpty(keyVaultThumbprint) && configList != null && configList.Count > 0)
            {
                if (this.IsKeyVaultCertificateInstalled(keyVaultThumbprint, SearchKeyType.Thumbprint, checkValidCertificateOnly))
                {
                    throw new ApplicationException("Either keyVault certificate is not valid or not installed! " + keyVaultThumbprint);
                }

                keyVaultConfigSettigs = this.GetSecretsFromKeyVault(keyVaultConnectionString, keyVaultBaseUrl, configList);
            }
            else
            {
                throw new ApplicationException("Either keyVaultConnectionString or keyVaultBaseUrl or keyVaultCertificateSerialNo or configList are not supplied!");
            }

            return keyVaultConfigSettigs;
        }

        #endregion

        #region "Private Methods"

        private string GetSubjectNameFromKeyVaultConnectionString(string keyVaultConnectionString)
        {
            string certificateSubject = string.Empty;

            if (!string.IsNullOrEmpty(keyVaultConnectionString))
            {
                var parts = keyVaultConnectionString.Split(';');

                if (parts != null && parts.Length > 2)
                {
                    var subject = parts[3];

                    if (!string.IsNullOrEmpty(subject))
                    {
                        certificateSubject = subject.Replace("CertificateSubjectName=CN=", "").Trim();
                    }
                }
            }

            return certificateSubject;
        }

        private bool IsKeyVaultCertificateInstalled(string searchKey, SearchKeyType searchKeyType, bool checkValidCertificateOnly)
        {
            bool isInstalled = false;

            if (!string.IsNullOrEmpty(searchKey))
            {
                using (var store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine))
                {
                    System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates = null;

                    store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.OpenExistingOnly);

                    if (searchKeyType == SearchKeyType.Thumbprint)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.SerialNumber)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySerialNumber, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.SubjectName)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.Name)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.FriendlyName)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, searchKey, checkValidCertificateOnly);
                    }

                    if (certificates != null && certificates.Count > 0)
                    {
                        isInstalled = true;
                    }
                    else
                    {
                        isInstalled = this.IsKeyVaultCertificateInstalledInCurrentUser(searchKey, searchKeyType, checkValidCertificateOnly);
                    }
                }
            }

            return isInstalled;
        }

        private bool IsKeyVaultCertificateInstalledInCurrentUser(string searchKey, SearchKeyType searchKeyType, bool checkValidCertificateOnly)
        {
            bool isInstalled = false;

            if (!string.IsNullOrEmpty(searchKey))
            {
                using (var store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser))
                {
                    System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates = null;

                    store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.OpenExistingOnly);

                    if (searchKeyType == SearchKeyType.Thumbprint)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.SerialNumber)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySerialNumber, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.SubjectName)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.Name)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, searchKey, checkValidCertificateOnly);
                    }
                    else if (searchKeyType == SearchKeyType.FriendlyName)
                    {
                        certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, searchKey, checkValidCertificateOnly);
                    }

                    if (certificates != null && certificates.Count > 0)
                    {
                        isInstalled = true;
                    }
                }
            }

            return isInstalled;
        }

        private Dictionary<string, string> GetSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl)
        {
            var keyVaultConfigs = new Dictionary<string, string>();

            try
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider(keyVaultConnectionString);

                var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                Microsoft.Rest.Azure.IPage<Microsoft.Azure.KeyVault.Models.SecretItem> secrets = null;
                
                do
                {
                    if (secrets == null) //Very first iteration.
                    {
                        secrets = Task.Run(() => keyVaultClient.GetSecretsAsync(keyVaultBaseUrl)).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                    else //Next iterations
                    {
                        secrets = Task.Run(() => keyVaultClient.GetSecretsNextAsync(secrets.NextPageLink)).ConfigureAwait(false).GetAwaiter().GetResult();
                    }

                    if (secrets != null && secrets.Count() > 0)
                    {
                        foreach (var secret in secrets)
                        {
                            var item = keyVaultClient.GetSecretAsync(secret.Id).GetAwaiter().GetResult();

                            if (item != null)
                            {
                                keyVaultConfigs.Add(item.SecretIdentifier.Name, item.Value);
                            }
                        }
                    }

                } while (secrets != null && !string.IsNullOrWhiteSpace(secrets.NextPageLink));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while getting secrets from key vault! " + ex.ToString());
            }

            return keyVaultConfigs;
        }

        private Dictionary<string, string> GetSecretsFromKeyVault(string keyVaultConnectionString, string keyVaultBaseUrl, List<string> configList)
        {
            var keyVaultConfigs = new Dictionary<string, string>();

            try
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider(keyVaultConnectionString);

                var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                var keyVaultUri = keyVaultBaseUrl + "secrets/";

                foreach (var configKey in configList)
                {
                    var secret = keyVaultClient.GetSecretAsync(keyVaultUri + configKey).GetAwaiter().GetResult();

                    if (secret != null)
                    {
                        keyVaultConfigs.Add(configKey, secret.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while getting secrets from key vault! " + ex.ToString());
            }

            return keyVaultConfigs;
        }

        #endregion
    }
}
