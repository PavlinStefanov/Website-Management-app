using System;

namespace WebsiteManagement.Application.Exceptions
{
    public class EmptyCollectionException : Exception
    {
        public EmptyCollectionException(string collectionType)
            : base($"Collection of type {collectionType} is empty.")
        {
        }
    }
}
