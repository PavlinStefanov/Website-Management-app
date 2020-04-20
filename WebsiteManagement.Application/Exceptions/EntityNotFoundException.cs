using System;

namespace WebsiteManagement.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, int id)
            : base($"Entity of type {name} with id: {id} not found.")
        {
        }
    }
}
