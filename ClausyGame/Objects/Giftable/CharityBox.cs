﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClausyGame
{
    class CharityBox : GameObject, IGiftable
    {
        public bool Gifted { get; set; }
        public bool IsGiftable() {

           
            return true;
        }

    }
}
