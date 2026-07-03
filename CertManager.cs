namespace CertAPI
{
    public class CertManager
    {
        private readonly List<Certificate> _certificates = [];

        public List<Certificate> GetAll() => new List<Certificate>(_certificates);      // return a copy instead of the actual list so _certificates itself remains protected
    }
}