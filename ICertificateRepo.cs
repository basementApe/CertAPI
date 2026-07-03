using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertAPI
{
    public interface ICertificateRepo
    {
        List<Certificate> LoadCerts();
        void SaveCerts(Certificate certificate);
    }
}