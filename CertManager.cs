namespace CertAPI
{
    public class CertManager
    {
        private readonly List<Certificate> _certificates = [];

        public List<Certificate> GetAll() => new List<Certificate>(_certificates);      // return a copy instead of the actual list so _certificates itself remains protected

        public List<Certificate> GetByNumber()
        {
            var list = GetAll();
            return list;
        }

        public List<Certificate> GetByType()
        {
            var list = GetAll();
            return list;
        }
    }
}