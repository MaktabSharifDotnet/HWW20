using App.Domain.Core.Exceptions;
using System.Text.RegularExpressions;

namespace App.Domain.Core.ValueObjects
{
  
    public class MobileNumber
    {
         
        public string Value { get; private set; }

      
        private MobileNumber() { }

        
        public MobileNumber(string value)
        {
           
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidMobileNumberException(value);
            }

            
            var normalizedValue = value.Trim();

           
          
            if (!Regex.IsMatch(normalizedValue, @"^09[0-9]{9}$"))
            {
                
                throw new InvalidMobileNumberException(normalizedValue);
            }

           
            this.Value = normalizedValue;
        }

       
        public override string ToString()
        {
            return this.Value;
        }
    }
}