namespace WebApplication.Authentication
{
    public interface ISendEmail
    {
        public void SendActivationEmail(long id, string patientEmailAddress);
        public long TokenToId(string token);
    }
}
