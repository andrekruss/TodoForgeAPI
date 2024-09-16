using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.TaskItem
{
    public record CreateTaskItemRequest(
            int BoardId,
            string Title,
            string Description,
            DateTime DueDate
     );
}
