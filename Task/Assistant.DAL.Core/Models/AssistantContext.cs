using System.Collections.Generic;

namespace Assistant.DAL.Core.Models
{
    public class AssistantContext
    {
        public AssistantContext()
        {

        }

        public List<User> Users { get; set; }
        
        public List<MoneyMovement> MoneyMovements { get; set; } 
    }
}
