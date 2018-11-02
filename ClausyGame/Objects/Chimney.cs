using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClausyGame
{
    class Chimney : GameObject, Giftable
    {
        public bool isGiftable()
        {
            return true;
        }
    }
}
