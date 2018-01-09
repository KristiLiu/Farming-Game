//Deanna & Kristi
//Fri Jan 27 2017
//The map contains object within the game such as the crops planted and player, the user goes through the map to access the player
//Grid setup, saves and loads happen within the map class, as well as actions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace HarvestStarNewEdition
{
    class Map
    {

        //the player that is controlled by the user
        private Player _mainPlayer;

        //ai object
        private AI _villager;

        //Integer variables to store the daysPassed
        private int _daysPassed;

        //Store the grid of tiles in the map
        private Maptile[,] _mapLayout;

        //Integer constant for title in row and col
        private const int NUM_OF_TILES_IN_ROW = 20;
        private const int NUM_OF_TILES_IN_COLUMN = 20;

        //Store crops 2D array
        private Crops[,] _cropsLayout = new Crops[20, 20];

        //Store rectangle for tile box
        Rectangle[,] _tileBox = new Rectangle[20, 20];

        //Store tile size in the map
        Size _tileSize = new Size();

        //Store tile's location
        Point _tileLoc = new Point();

        /// <summary>
        /// Sets up the sizes of the hitboxes, locations etc, so they may be used to draw images on top
        /// </summary>
        /// <param name="ClientSizeH">The client size height</param>
        /// <param name="ClientSizeW">The client size width</param>
        public void SetUpTileSize(int ClientSizeH, int ClientSizeW)
        {
            //Sets the tile size that will be used
            _tileSize.Width = ClientSizeW / NUM_OF_TILES_IN_ROW;
            _tileSize.Height = ClientSizeH / NUM_OF_TILES_IN_COLUMN;

            //Loops through a rectangle array setting the points of the array for the game
            for (int i = 0; i < NUM_OF_TILES_IN_COLUMN; i++)
            {
                for (int j = 0; j < NUM_OF_TILES_IN_ROW; j++)
                {
                    _tileLoc.X = _tileSize.Width * j;
                    _tileLoc.Y = _tileSize.Height * i;
                    _tileBox[j, i].Location = _tileLoc;
                    _tileBox[j, i].Size = _tileSize;

                }
            }
        }

        //get and set for villager
        public AI Villager
        {
            get
            {
                return _villager;
            }
            private set
            {
                _villager = value;
            }
        }

        //Get and Set tile box
        public Rectangle[,] TileBox
        {

            get
            {
                return _tileBox;
            }
            private set
            {
                _tileBox = value;
            }
        }

        //Get and Set tile size
        public Size TileSize
        {
            get
            {
                return _tileSize;
            }
            private set
            {
                _tileSize = value;
            }
        }

        //Get and Set tile location 
        public Point TileLoc
        {
            get
            {
                return _tileLoc;
            }
            set
            {
                _tileLoc = value;
            }
        }

        //Get and Set Dayspassed
        public int DaysPassed
        {
            get
            {
                return _daysPassed;
            }
            set
            {
                _daysPassed = value;
            }

        }
        //Get and Set player
        public Player ThePlayer
        {
            get
            {
                return _mainPlayer;
            }
            set
            {
                _mainPlayer = value;
            }
        }

        //Get and Set MapLayout
        public Maptile[,] MapLayout
        {
            get
            {
                return _mapLayout;
            }
            set
            {
                _mapLayout = value;
            }
        }

        //Get and Set cropsLayout
        public Crops[,] CropsLayout
        {
            get
            {
                return _cropsLayout;
            }
            set
            {
                _cropsLayout = value;
            }
        }

        /// <summary>
        /// Creates a new player when there is a new game
        /// </summary>
        /// <param name="name">The users chosen name</param>
        public void MakeNewPlayer(string name)
        {
            //Creates a new player object
            _mainPlayer = new Player(name);

            //Sets the new game days passed to 0
            _daysPassed = 0;

            //Calls the hit box of the player to be setup
            _mainPlayer.SetUpPlayer();
        }


        public void CreateNewAI()
        {
            _villager = new AI();
            _villager.SetUpAI();
        }

        /// <summary>
        /// If the player has an existing game loads the file
        /// </summary>
        public void LoadPlayer()
        {
            //Checks to see if an old file exists that can be loaded
            if (File.Exists("PlayerInfo.txt")) //file
            {
                try
                {
                    //Reads the desired file
                    using (StreamReader input = new StreamReader("PlayerInfo.txt"))
                    {
                        //Checks that there is information to be read, takes the info and uses it to create player object
                        while (input.Peek() != -1)
                        {
                            int.TryParse(input.ReadLine(), out _daysPassed);

                            //Reads the player's name
                            string name = input.ReadLine();

                            int balance;
                            int.TryParse(input.ReadLine(), out balance);
                            //UP ABOVE ADDED CODE
                            //integer variables to store the player's row, column and balance 
                            //int row, col, balance;

                            //Read the row and column and convert it into an integer for the player 
                            int x, y;
                            int.TryParse(input.ReadLine(), out x);
                            int.TryParse(input.ReadLine(), out y);

                            int direction;

                            int.TryParse(input.ReadLine(), out direction);
                            //Reads the facing direction of the player, and turn it into a direction for the player


                            //Read the balance of the player and conver it into an integer for the player 
                            //int.TryParse(input.ReadLine(), out balance);
                            _mainPlayer = new Player(name, balance, x, y, Direction.Down);
                            _mainPlayer.SetUpPlayer();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Could not read the file");
                }
            }
        }

        /// <summary>
        /// Saves the player info
        /// </summary>
        public void SavePlayer()
        {
            //Writes into a file the players info
            using (StreamWriter playerInfo = new StreamWriter("PlayerInfo.txt"))
            {
                playerInfo.WriteLine(_daysPassed.ToString());
                playerInfo.WriteLine(_mainPlayer.Name);
                playerInfo.WriteLine(_mainPlayer.Balance.ToString());
                playerInfo.WriteLine(_mainPlayer.PlayerLocation.X.ToString());
                playerInfo.WriteLine(_mainPlayer.PlayerLocation.Y.ToString());
            }
        }
        /// <summary>
        /// Loads all crops from old file
        /// </summary>
        public void LoadOldCrops()
        {
            //Checks to see if the file exists
            if (File.Exists("CropsLayout.txt"))
            {
                //Reads the file if it does exist uses that info to set up crop layout and create crop objects
                using (StreamReader input = new StreamReader("CropsLayout.txt"))
                {
                    while (input.Peek() != -1)
                    {
                        int daysGrown;
                        bool isFullGrown;
                        string cropType;
                        int x;
                        int y;

                        cropType = input.ReadLine();

                        //read the line to determine if the crop is fully grown, and make it a boolean 
                        //MIGHT HAVE TO CHANGE IF I JUST WRITE FALSE WILL IT WORK IN THE LOAD
                        Boolean.TryParse(input.ReadLine(), out isFullGrown);

                        //read the line to determine the days grown, and make it an integer
                        int.TryParse(input.ReadLine(), out daysGrown);

                        int.TryParse(input.ReadLine(), out x);

                        int.TryParse(input.ReadLine(), out y);

                        if (cropType == "Pumpkin")
                        {
                            _cropsLayout[x,y]= new Pumpkin(daysGrown, x, y, isFullGrown);

                        }
                        else if (cropType == "Radish")
                        {
                            _cropsLayout[x,y] = new Radish(daysGrown, x, y, isFullGrown);
                           
                        }
                        else if (cropType == "WeddingCake")
                        {
                            _cropsLayout[x,y] = new WeddingCake(daysGrown, x, y, isFullGrown);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Saves all the infor of the crops in the layout
        /// </summary>
        public void SaveCropsLayout()
        {
            //Uses stream writer to save crops in the map
            using (StreamWriter cropInfo = new StreamWriter("CropsLayout.txt"))
            {
                //Loops through the croplayout array to save all crop info
                for (int i = 0; i < NUM_OF_TILES_IN_COLUMN; i++)
                {
                    for (int j = 0; j < NUM_OF_TILES_IN_ROW; j++)
                    {
                        if (_cropsLayout[j, i] != null)
                        {
                            //Writes out all the information into the file
                            cropInfo.WriteLine(_cropsLayout[j, i].CropType);
                            cropInfo.WriteLine(_cropsLayout[j, i].IsFullGrown.ToString());
                            cropInfo.WriteLine(_cropsLayout[j, i].DaysGrown.ToString());
                            cropInfo.WriteLine(j.ToString());
                            cropInfo.WriteLine(i.ToString());
                        }
                    }
                }
            }
        }

        public void SaveAI()
        {
            using (StreamWriter villagerInfo = new StreamWriter("AI.txt"))
            {

                villagerInfo.WriteLine(_villager.RelationshipPoints.ToString());
                villagerInfo.WriteLine(_villager.HasTalkedTo.ToString());
                villagerInfo.WriteLine(_villager.HasGifted.ToString());
                villagerInfo.Write(_villager.IsMarried.ToString());
            }
        }

        public void LoadAI()
        {
            //Checks if file exists
            if (File.Exists("AI.txt"))
            {
                //Reads file
                using (StreamReader villagerInfo = new StreamReader("AI.txt"))
                {
                    while (villagerInfo.Peek() != -1)
                    {
                        int rp;
                        bool hasTalk;
                        bool hasGift;
                        bool isMarried;

                        int.TryParse(villagerInfo.ReadLine(), out rp);
                        Boolean.TryParse(villagerInfo.ReadLine(), out hasTalk);
                        Boolean.TryParse(villagerInfo.ReadLine(), out hasGift);
                        Boolean.TryParse(villagerInfo.ReadLine(), out isMarried);

                        //Creates villager
                        _villager = new AI(rp, isMarried, hasTalk, hasGift);

                        //Sets up AI
                        _villager.SetUpAI();

                    }
                }
            }

        }

        //Get the y coordinate in front of the player
        private int GetYInFront()
        {
            int y = 0;

            y = Convert.ToInt32(_mainPlayer.PlayerLocation.Y / _tileSize.Height);
            if (_mainPlayer.FacingDirection == Direction.Up)
            {
                y -= 1;
            }
            else if (_mainPlayer.FacingDirection == Direction.Down)
            {
                y += 1;
            }

            if (y < 0)
            {
                return 0;
            }
            else if (y > (NUM_OF_TILES_IN_COLUMN - 1))
            {
                return NUM_OF_TILES_IN_COLUMN - 1;
            }
            return y;
        }

        //Get the x coordinate infront of the player 
        private int GetXInFront()
        {
            //get the row that the player's x location, and depending on the 
            //facing direction, find the x infront of the player 
            int x = 0;
            x = Convert.ToInt32(_mainPlayer.PlayerLocation.X / _tileSize.Width);

            if (_mainPlayer.FacingDirection == Direction.Left)
            {
                x -= 1;
            }
            else if (_mainPlayer.FacingDirection == Direction.Right)
            {
                x += 1;
            }

            if (x < 0)
            {
                return x = 0;
            }
            else if (x > (NUM_OF_TILES_IN_ROW - 1))
            {
                return NUM_OF_TILES_IN_ROW - 1;
            }
            return x;
        }

        /// <summary>
        /// Sell player crops
        /// </summary>
        public void SellCrop()
        {
            //Checks to see if the player is holding an item
            if (_mainPlayer.IsHoldingItem == true && _mainPlayer.ItemHolding.IsFullGrown == true)
            {
                //Checks what kind of crop the player is holding, sets the new balance depending on item
                if (_mainPlayer.ItemHolding is Pumpkin)
                {
                    _mainPlayer.SellPumpkin();
                }
                else if (_mainPlayer.ItemHolding is Radish)
                {
                    _mainPlayer.SellRadish();
                }
                else if (_mainPlayer.ItemHolding is WeddingCake)
                {
                    _mainPlayer.SellWeddingCake();
                }
            }
        }

        //Pickup Crop if the crop is ready
        public void PickUpCrop()
        {
            //Checks that the crop is ready to be picked up and that there is a crop to be picked up on the tile
            if (_cropsLayout[GetXInFront(), GetYInFront()] != null && _cropsLayout[GetXInFront(), GetYInFront()].IsFullGrown == true)
            {
                //Picks up the crop, the player holds the crop and the crop is no longer in the map layout
                _mainPlayer.PickUpCrop(_cropsLayout[GetXInFront(), GetYInFront()]);
                _cropsLayout[GetXInFront(), GetYInFront()] = null;
            }
        }

        //Drop Crop if the play holds item
        public void DropCrop()
        {
            if (_cropsLayout[GetXInFront(), GetYInFront()] == null && _mainPlayer.ItemHolding != null)
            {
                _cropsLayout[GetXInFront(), GetYInFront()] = _mainPlayer.ItemHolding;
                _mainPlayer.DropCrop();
            }
        }


        public int CalcDistanceFromAI()
        {
            //reminder setup ai hitbox 
            float rise = _mainPlayer.PlayerLocation.Y - _villager.VillagerLocation.Y;
            float run = _mainPlayer.PlayerLocation.X - _villager.VillagerLocation.X;
            double hypotenuse = Math.Sqrt(rise * rise + run * run);
            
            return Convert.ToInt32(hypotenuse);
        }

        //Talk to the AI on the map
        public string TalkToAI()
        {
            if (_mainPlayer.FacingDirection == Direction.Right || _mainPlayer.FacingDirection == Direction.Left)
            {
                if (CalcDistanceFromAI() <= (TileSize.Width * 2))
                {
                    return _villager.Talk();
                }
            }
            else if (_mainPlayer.FacingDirection == Direction.Up || _mainPlayer.FacingDirection == Direction.Down)
            {
                if (CalcDistanceFromAI() <= (TileSize.Height * 2))
                {
                    return _villager.Talk();
                }
            }
            return null; 
                            
        }

        public string GiftAI()
        {
            if (_mainPlayer.IsHoldingItem == true && _mainPlayer.ItemHolding.IsFullGrown == true && _mainPlayer.ItemHolding is WeddingCake)
            {
                _mainPlayer.GiftItem();
                return _villager.RecieveWeddingCake();
            }
            else if (_mainPlayer.IsHoldingItem == true && _mainPlayer.ItemHolding.IsFullGrown == true)
            {
                _mainPlayer.GiftItem();
                return _villager.RecieveCropGift();
            }
            else
            {
                return null;
            }

        }
        //The player buy Pumpkin
        public void BuyPumpkin()
        {
            _mainPlayer.BuyPumpkin();
        }

        //The player buy Radish
        public void BuyRadish()
        {
            _mainPlayer.BuyRadish();
        }

        //The player buy WeddingCake
        public void BuyWeddingCake()
        {
            _mainPlayer.BuyWeddingCake();
        }

        //The player moveUp
        public void MoveUp()
        {
            _mainPlayer.MoveUp();
        }

        //The player moveDown
        public void MoveDown(int ClientSizeH)
        {
            _mainPlayer.MoveDown(ClientSizeH);
        }

        //The player moveleft
        public void MoveLeft()
        {
            _mainPlayer.MoveLeft();
        }

        // The player moveRight
        public void MoveRight(int ClientSizeW)
        {
            _mainPlayer.MoveRight(ClientSizeW);
        }

        // The player waters crop
        public void WaterCrop()
        {
            if (_cropsLayout[GetXInFront(), GetYInFront()] != null)
            {
                _cropsLayout[GetXInFront(), GetYInFront()].BeWatered();
            }
        }

        //Ends the day in game, increased the day count and loops through the crop layout in order to water crops
        public void EndDay()
        { 
            int x = _cropsLayout.GetLength(0);
            int y = _cropsLayout.GetLength(1);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (_cropsLayout[j, i] != null && _cropsLayout[j, i].IsWatered == true && _cropsLayout[j, i].IsFullGrown == false)
                    {
                        _cropsLayout[j, i].EndDay();
                    }

                }
            }
            _daysPassed += 1;
            _villager.EndDay();
        }
    }

}
