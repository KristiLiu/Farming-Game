//Child class of crops, is a wedding cake which the player can buy, plant and sell
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestStarNewEdition
{
    class WeddingCake : Crops
    {
        //constant integers to store the crops' buying price, selling price, and end of growth days
        public const int WEDDINGCAKE_BUY_PRICE = 100;
        public const int WEDDINGCAKE_SELL_PRICE = 200;
        public const int END_OF_GROWTH_WEDDINGCAKE = 10;

        //create a pumpking object with days have grown, x location, y location, boolean if its full grown, name, selling price, 
        //buying price
        public WeddingCake(int daysHaveGrown, int xLoc, int yLoc, bool isFullGrown)
            : base("WeddingCake", WEDDINGCAKE_SELL_PRICE, WEDDINGCAKE_BUY_PRICE, daysHaveGrown, END_OF_GROWTH_WEDDINGCAKE, xLoc, yLoc, isFullGrown)
        {
        }
    }
}
