﻿using System;
using Microsoft.Azure.WebJobs.Description;

namespace KeyVaultInputBinding
{
    /// <summary></summary>
    /// <seealso cref="System.Attribute" />
    [Binding, AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class KeyVaultSecretAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSecretAttribute"/> class.
        /// </summary>
        /// <param name="resourceNameSetting">The name of the application setting (eg: MyKeyVault) which holds the name of the Key Vault resource in Azure (eg: my-key-vault)</param>
        /// <param name="secretIdSetting">The name of the application setting which holds the id of the secret whose value should be fetched.</param>
        /// <remarks>You must add the appropriate access policies to your KeyVault instance for your Function App's Managed Service Identity in order for this binding to work.</remarks>
        public KeyVaultSecretAttribute(string resourceNameSetting, string secretIdSetting)
        {
            this.ResourceNameSetting = resourceNameSetting;
            this.SecretIdSetting = secretIdSetting;
        }

        /// <summary>
        /// Gets the name of the application setting (eg: MyKeyVault) which holds the name of the Key Vault resource in Azure (eg: my-key-vault)
        /// </summary>
        [AppSetting(Default = @"KeyVaultResourceName")]
        public string ResourceNameSetting { get; }

        /// <summary>
        /// Gets the name of the application setting which holds the id of the secret whose value should be fetched.
        /// </summary>
        [AppSetting]
        public string SecretIdSetting { get; }
    }
}