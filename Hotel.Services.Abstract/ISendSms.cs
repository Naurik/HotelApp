namespace Hotel.Services.Abstract
{
    public interface ISendSms
    {
        void SendSmsTwilio(string numberUsers);
    }
}
