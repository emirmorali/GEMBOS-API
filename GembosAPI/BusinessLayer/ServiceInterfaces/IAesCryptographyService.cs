namespace GembosAPI.BusinessLayer.ServiceInterfaces
{
    public interface IAesCryptographyService
    {
        string Encrypt(string plainText);
        string Decrypt(string cypherText);
    }
}
