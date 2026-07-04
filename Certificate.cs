
namespace CertAPI
{
    public class Certificate
    {
        public int Id { get; private set; }
        public string Type { get; private set; }
        public string Number { get; private set; }
        public string NotifiedBody { get; private set; }
        public DateOnly IssueDate { get; private set; }
        public DateOnly ExpiryDate { get; private set; }

        public Certificate(int id, string type, string number, string notifiedbody, DateOnly issuedate, DateOnly expirydate)
        {
            Id = id;
            Type = type;
            Number = number;
            NotifiedBody = notifiedbody;
            IssueDate = issuedate;
            ExpiryDate = expirydate;
        }

        public void Update(string type, string number, string notifiedbody, DateOnly issuedate, DateOnly expirydate)
        {
            Type = type;
            Number = number;
            NotifiedBody = notifiedbody;
            IssueDate = issuedate;
            ExpiryDate = expirydate;
        }
    }
}