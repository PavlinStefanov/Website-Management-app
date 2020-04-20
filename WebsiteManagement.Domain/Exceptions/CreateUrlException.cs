using System;

namespace WebsiteManagement.Domain.Exceptions
{
    public class CreateUrlException : Exception
    {
        public CreateUrlException(string urlToCreate, Exception ex)
            : base($"URL {urlToCreate} is invalid.", ex)
        { 
        }
    }
}
