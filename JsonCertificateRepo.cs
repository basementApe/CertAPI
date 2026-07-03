using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace CertAPI
{
    public class JsonCertificateRepo:ICertificateRepo
    {
        private readonly string filename = "certificates.json";
        public List<Certificate> LoadCerts()
        {
            if (!File.Exists(filename)) return new List<Certificate>();
            var json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Certificate>>(json);
        }

        public void SaveCerts(Certificate certificate)
        {
            var certs = LoadCerts();

            certs.Add(certificate);

            var json = JsonSerializer.Serialize(certs);
            File.WriteAllText(filename, json);
        }
    }
}

