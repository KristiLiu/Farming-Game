//Pumpkin class, child class of crops
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestStarNewEdition
{
    class Pumpkin : Crops
    {
        //constant integers to store the crops' buying price, selling price, and end of growth days
        public const int PUMPKIN_BUY_PRICE = 50;
        public const int PUMPKIN_SELL_PRICE = 100;
        public const int END_OF_GROWTH = 5;

        //create a pumpking object with days have grown, x location, y location, boolean if its full grown, name, selling price, 
        //buying price
        public Pumpkin(int daysHaveGrown, int xLoc, int yLoc, bool isFullGrown)
            : base("Pumpkin",PUMPKIN_SELL_PRICE, PUMPKIN_BUY_PRICE, daysHaveGrown, END_OF_GROWTH, xLoc, yLoc, isFullGrown)
        {

        }
    }
}
