
namespace CertAPI
{
    public interface ICertificateRepo
    {
        List<Certificate> LoadCerts();
        void SaveCert(Certificate certificate);
    }
}
