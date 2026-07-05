
namespace CertAPI
{
    public class Certification
    {
        public string Type { get; private set; }
        public string Number { get; private set; }
        public string NotifiedBody { get; private set; }
        public DateOnly IssueDate { get; private set; }
        public DateOnly ExpiryDate { get; private set; }
        public string StoredFileName { get; private set; }

        public Certification(string type, string number, string notifiedbody, DateOnly issuedate, DateOnly expirydate, string storedfilename)
        {
            Type = type;
            Number = number;
            NotifiedBody = notifiedbody;
            IssueDate = issuedate;
            ExpiryDate = expirydate;
            StoredFileName = storedfilename;
        }
    }
}