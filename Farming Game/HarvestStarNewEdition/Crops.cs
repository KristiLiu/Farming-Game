using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestStarNewEdition
{
    class Crops
    {


        //Integer variable to store the crop's sellingPrice 
        protected int sellingPrice;

        //Integer variable to store the crop's buyingPrice 
        protected int buyingPrice;

        //Integer variable to store the crop's buyingPrice 
        protected int daysGrown;

        //Integer variable to store the crop's endOfGrowth 
        protected int endOfGrowth;

        //Integer variable to store the crop's row and column  
        protected int xCoordinate;
        protected int yCoordinate;

        //String variable to store the crop's Type
        protected string cropType;

        //Boolean variable that stores if the crop is full grown or not
        protected bool isFullGrown;

        //Boolean variable that stores if the crop is water or not
        protected bool isWatered;

        //Boolean variable that stores if the crop is on ground or not
        protected bool isOnGround;

        //Creates a crops with a type, sellPric, buyPrice, daysHaveGrown, endGrowth, x location, y location and isGrown 
        public Crops(string type, int sellPrice, int buyPrice, int daysHaveGrown, int endGrowth, int xLoc, int yLoc, bool isGrown)
        {
            sellingPrice = sellPrice;
            buyingPrice = buyPrice;
            daysGrown = daysHaveGrown;
            endOfGrowth = endGrowth;
            isFullGrown = isGrown;
            cropType = type;
            xCoordinate = xLoc;
            yCoordinate = yLoc;
        }

        //Get and Set Crop type in the map.
        public string CropType
        {
            get
            {
                return cropType;
            }
            private set
            {
                cropType = value;
            }
        }

        //Get and Set Crop sell price
        public int SellingPrice
        {
            get
            {
                return sellingPrice;
            }
            private set
            {
                sellingPrice = value;
            }

        }

        //Get and Set Crop buy price
        public int BuyingPrice
        {
            get
            {
                return buyingPrice;
            }
            private set
            {
                buyingPrice = value;
            }
        }

        //Get and Set Crop daysGrown
        public int DaysGrown
        {
            get
            {
                return daysGrown;
            }
            private set
            {
                daysGrown = value;
            }
        }

        //Get and Set Crop is FullGrown
        public bool IsFullGrown
        {
            get
            {
                return isFullGrown;
            }
            private set
            {
                isFullGrown = value;
            }

        }

        //Get and Set Crop EndOfGrowth
        public int EndOfGrowth
        {
            get
            {
                return endOfGrowth;
            }
            private set
            {
                endOfGrowth = value;
            }
        }

        //Get and Set Crop isWatered
        public bool IsWatered
        {
            get
            {
                return isWatered;
            }
            private set
            {
                isWatered = value;
            }
        }

        //Crop is watered
        public void BeWatered()
        {
            isWatered = true;
        }

        //Crop is endDay if crop is watered and crop's daysGrown is equal crop's endOfGrown
        public void EndDay()
        {
            //Sets the crop watered to be false and increased days grown
            isWatered = false;
            daysGrown += 1;

            //Checks if the crop is fully grown , is so makes the crop a full grown crop
            if (daysGrown == endOfGrowth)
            {
                IsFullGrown = true;
            }
        }
    }
}
