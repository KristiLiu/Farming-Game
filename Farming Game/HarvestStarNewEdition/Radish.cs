//Child class of crops, is a radish object that the player can plant, sell, buy and gift this crop
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestStarNewEdition
{
    class Radish : Crops
    {
        //constant integers to store the crops' buying price, selling price, and end of growth days
        public const int RADISH_BUY_PRICE = 20;
        public const int RADISH_SELL_PRICE = 50;
        public const int END_OF_GROWTH = 3;

        //create a pumpking object with days have grown, x location, y location, boolean if its full grown, name, selling price, 
        //buying price
        public Radish(int daysHaveGrown, int xLoc, int yLoc, bool isFullGrown)
            : base("Radish", RADISH_SELL_PRICE, RADISH_BUY_PRICE, daysHaveGrown, END_OF_GROWTH, xLoc, yLoc, isFullGrown) 
        {

        }
       
    }
}
