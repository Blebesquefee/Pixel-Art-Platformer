using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

Console.WriteLine("Hello World");

var client = new SecretClient(vaultUri: new Uri("https://keyvaultpixelartproject.vault.azure.net/"),
credential: new VisualStudioCredential());

var secret = client.GetSecret("KeyVaultPixelArtProject");

if (secret != null)
    Console.WriteLine(secret.Value.Value);