using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebsiteManagement.Domain.Entities
{
    public class Member : IdentityUser
    {
        public Member()
        {
            //TopicDetails = new HashSet<TopicDetails>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public virtual ICollection<TopicDetails> TopicDetails { get; set; }
    }
}
