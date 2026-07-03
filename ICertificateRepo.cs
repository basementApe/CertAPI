
namespace CertAPI
{
    public interface ICertificateRepo
    {
        List<Certificate> LoadCerts();
        void SaveCerts(Certificate certificate);
    }
}