using System;

namespace SalesWebMVC.Services.Exceptions
{
    // classe criada para tratamento de excessões
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message) 
        {

        }    
    }
}
