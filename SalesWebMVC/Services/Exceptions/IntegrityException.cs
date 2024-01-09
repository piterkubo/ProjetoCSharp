using System;

namespace SalesWebMVC.Services.Exceptions
{
    // criando uma classe com herança do applicationException
    public class IntegrityException :ApplicationException
    {
        public IntegrityException(string messege) : base(messege) 
        { 
        
            
        
        }
    }
}
