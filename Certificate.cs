
namespace CertAPI
{
    public class Certificate
    {
        public string Type { get; private set; }
        public string Number { get; private set; }
        public string NotifiedBody { get; private set; }
        public DateOnly IssueDate { get; private set; }
        public DateOnly ExpiryDate { get; private set; }
        public string StoredFileName { get; private set; }

        public Certificate(string type, string number, string notifiedbody, DateOnly issuedate, DateOnly expirydate, string storedfilename)
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