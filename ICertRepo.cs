
namespace CertAPI
{
    public interface ICertRepo
    {
        List<Certification> LoadCerts();
        void SaveCert(Certification certification);
    }
}
