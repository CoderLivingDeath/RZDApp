namespace RZDModel.Interfaces.Services
{
    public interface IPaymentService
    {
        bool PayByCard(string cardNumber, decimal price);
    }
}