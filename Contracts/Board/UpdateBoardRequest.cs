using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Board
{
    public record UpdateBoardRequest(
        string Title,
        string Description
     );
}
