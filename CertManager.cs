namespace CertAPI
{
    public class CertManager
    {
        private readonly ICertificateRepo _repo;

        public CertManager(ICertificateRepo repo)
        {
            _repo = repo;
        }


        public List<Certificate> GetByNumber(string number)
        {
            return _repo.LoadCerts().Where(c => c.Number == number).ToList();
        }

        public List<Certificate> GetByType(string type)
        {
            return _repo.LoadCerts().Where(c => c.Type.Contains(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}