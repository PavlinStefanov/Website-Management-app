using System.Collections.Generic;

namespace WebsiteManagement.Application.Abstractions.Commands
{
    public class CommandPreconditionCheckResult
    {
        public CommandPreconditionCheckResult()
        {
            IsValid = true;
            ValidationMessages = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<string> ValidationMessages { get; set; }
    }
}
