namespace App.Domain.Core.Exceptions
{
    public class InvalidMobileNumberException : Exception
    {
        public InvalidMobileNumberException(string mobile)
            : base($"'{mobile}' is not a valid mobile number.")
        {
        }
    }
}