using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClausyGame
{
    class OpenWindow : GameObject, Giftable
    {
        public bool isGiftable()
        {
            return true;
        }
    }
}
