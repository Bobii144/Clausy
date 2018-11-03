using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClausyGame
{
    interface IGiftable
    {
        bool IsGiftable();
        bool Gifted { get;set; }
    }
}
