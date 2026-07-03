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
            if (!File.Exists(filename)) return new List<Certificate>(); //Array.Empty<Certificate>();
            var json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Certificate>>(json);
        }

        public void SaveCerts(Certificate certificate)
        {
            // var certs = new List<Certificate>();
            // if (File.Exists(filename))
            // {
            //     var json1 = File.ReadAllText(filename);
            //     var certsArray = JsonSerializer.Deserialize<List<Certificate>>(json1);
            //     certs.AddRange(certsArray);
            // }
            // certs.Add(certificate);
            // var json2 = JsonSerializer.Serialize(certs);
            // File.WriteAllText(filename, json2);
            var certs = LoadCerts();

            certs.Add(certificate);

            var json = JsonSerializer.Serialize(certs);
            File.WriteAllText(filename, json);
        }
    }
}

