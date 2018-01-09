//Creates a player object contains variables and methods that are used for the player 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HarvestStarNewEdition
{
    class Player
    {
        //private string variable to store the player's name
        private string _name;

        //Integer variable to store the player's balance 
        private int _balance;

        //crop object to store what the player is holding 
        Crops _itemHolding;

        //Boolean variable that stores if the player is holding an object or not
        private bool _isHolding = false;
        private Direction _facingDirection;


        //Integer to store the player's constant player speed 
        const int PLAYER_SPEED = 5;

        //Player's hit box , location and size of hit box
        private Rectangle _playerHitBox = new Rectangle();
        private Point _playerLocation = new Point();
        private Size _playerSize = new Size();


        //When to put the graphics to keep holding the item
        Rectangle _itemInHandBox = new Rectangle();
        Point _itemInHandLoc = new Point();
        Size _itemInHandSize = new Size();

        //Creates a player object that takes in the player's name 
        //player has name, balance, x location, y location and a facing direction 
        public Player(string playerName)
            : this(playerName, 100, 0, 0, Direction.Down)
        {

        }

        //Creates a player with a name, balance, x location, y location and facing direction 
        public Player(string playername, int balance, int x, int y, Direction facing)
        {
            _name = playername;
            _facingDirection = facing;
            _balance = balance;
            _playerLocation.X = x;
            _playerLocation.Y = y;

        }

        //Sets up the player
        public void SetUpPlayer()
        {

            _playerSize.Height = 45;
            _playerSize.Width = 35;

            _playerHitBox.Location = _playerLocation;
            _playerHitBox.Size = _playerSize;
        }

        //Sets up the location, size for the object the player is holding 
        public void MoveObjectHolding()
        {
            //width and height of the item the player is holding 
            _itemInHandSize.Width = 20;
            _itemInHandSize.Height = 20;

            //location of the item the player is holding 
            _itemInHandBox.Y = _playerLocation.Y - _itemInHandSize.Height;
            _itemInHandBox.X = PlayerLocation.X;

            //size of the hitbox of the item player is holding 
            _itemInHandBox.Size = _itemInHandSize;
        }

        //get and set item in hand's hit box 
        public Rectangle ItemInHandBox
        {
            get
            {
                return _itemInHandBox;
            }
            private set
            {
                _itemInHandBox = value;
            }
        }

        //get and set the size of the item in player's hand 
        public Size ItemInHandSize
        {
            get
            {
                return _itemInHandSize;
            }
            private set
            {
                _itemInHandSize = value;
            }

        }

        //get and set the location of the item in player's hand 
        public Point ItemInHandLoc
        {
            get
            {
                return _itemInHandLoc;
            }
            private set
            {
                _itemInHandLoc = value;
            }
        }

        //get and set the player's size 
        public Size PlayerSize
        {
            get
            {
                return _playerSize;
            }
            private set
            {
                _playerSize = value;
            }

        }

        //get and set the player's hit box 
        public Rectangle PlayerHitBox
        {
            get
            {
                return _playerHitBox;
            }
            private set
            {
                _playerHitBox = value;
            }
        }

        //get and set the player's location 
        public Point PlayerLocation
        {
            get
            {
                return _playerLocation;
            }
            private set
            {
                _playerLocation = value;
            }
        }

        //Get the player balance
        public int Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                _balance = value;
            }
        }

        //Get the facing direction of the player
        public Direction FacingDirection
        {
            get
            {
                return _facingDirection;
            }
            private set
            {
                _facingDirection = value;
            }

        }

        //Get the name of the player
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }

        //Check if the player if holding an item
        public bool IsHoldingItem
        {
            get
            {
                return _isHolding;
            }
            private set
            {
                _isHolding = value;
            }
        }
        //Get the item the player is holding
        public Crops ItemHolding
        {
            get
            {
                return _itemHolding;
            }
            private set
            {
                _itemHolding = value;
            }
        }

        //Places crop on the ground 
        public void DropCrop()
        {
            //player is no longer holding item
            _itemHolding = null;
            _isHolding = false;
        }

        /// <summary>
        /// Picks up the crop infront of the player
        /// </summary>
        /// <param name="crop">crop item that is to be picked up </param>
        public void PickUpCrop(Crops crop)
        {
            //player is holding an crop item
            _itemHolding = crop;
            _isHolding = true;
        }

        //Buys a pumpking crop object
        public void BuyPumpkin()
        {

            if (Balance >= Pumpkin.PUMPKIN_BUY_PRICE)
            {
                _balance -= Pumpkin.PUMPKIN_BUY_PRICE;
                _itemHolding = new Pumpkin(0, PlayerLocation.X, PlayerLocation.Y, false);
                _isHolding = true;
            }
        }
        public void BuyRadish()
        {
            if (IsHoldingItem == false)
            {
                if (Balance >= Radish.RADISH_BUY_PRICE)
                {
                    _balance -= Radish.RADISH_BUY_PRICE;
                    _itemHolding = new Radish(0, PlayerLocation.X, PlayerLocation.Y, false);
                    _isHolding = true;
                }
            }
        }
        public void BuyWeddingCake()
        {
            if (Balance >= WeddingCake.WEDDINGCAKE_BUY_PRICE)
            {
                // maybe change to captial get one
                _balance -= WeddingCake.WEDDINGCAKE_BUY_PRICE;
                _itemHolding = new WeddingCake(0, PlayerLocation.X, PlayerLocation.Y, false);
                _isHolding = true;
            }
        }

        //Sell a pumpkin
        public void SellPumpkin()
        {
            //adjust the player's balance 
            //player is no longer holding an item
            _balance += Pumpkin.PUMPKIN_SELL_PRICE;
            _itemHolding = null;
            _isHolding = false;
        }

        //Sell a radish
        public void SellRadish()
        {
            //adjust the player's balance 
            //player is no longer holding an item
            _balance += Radish.RADISH_SELL_PRICE;
            _itemHolding = null;
            _isHolding = false;
        }
        public void SellWeddingCake()
        {
            //adjust the player's balance 
            //player is no longer holding an item
            _balance += WeddingCake.WEDDINGCAKE_SELL_PRICE;
            _itemHolding = null;
            _isHolding = false;
        }

        //Player moves up 
        public void MoveUp()
        {
            //Player is facing up and the player moves at the player's speed
            _facingDirection = Direction.Up;
            _playerLocation.Y = _playerLocation.Y - PLAYER_SPEED;

            //the player's can't move off of the screen 
            if (_playerLocation.Y < 0)
            {
                _playerLocation.Y = 0;
            }

            //update the player's location 
            _playerHitBox.Location = _playerLocation;
        }

        //Player movement, move down
        //Passes in the lowermost location of the screen
        public void MoveDown(int lowerBound)
        {
            _facingDirection = Direction.Down;
            //Moves the player
            _playerLocation.Y = _playerLocation.Y + PLAYER_SPEED;

            //Prevents player from going off screen
            if (_playerLocation.Y + _playerHitBox.Height > lowerBound)
            {
                _playerLocation.Y = lowerBound - _playerHitBox.Height;
            }

            _playerHitBox.Location = _playerLocation;


        }

        public void GiftItem()
        {
            _isHolding = false;
            _itemHolding = null;
        }

        //Player movement, move left
        public void MoveLeft()
        {
            _facingDirection = Direction.Left;
            //Moves the player
            _playerLocation.X = _playerLocation.X - PLAYER_SPEED;

            //Makes sure player does not go off screen
            if (_playerLocation.X < 0)
            {
                _playerLocation.X = 0;
            }

            //update player's hitbox 
            _playerHitBox.Location = _playerLocation;

        }

        /// <summary>
        /// Moves the player right
        /// </summary>
        /// <param name="rightBound">The right boundary of the screen</param>
        public void MoveRight(int rightBound)
        {
            _facingDirection = Direction.Right;
            //Moves the player
            _playerLocation.X = _playerLocation.X + PLAYER_SPEED;

            //Checks that the player is in bounds, keeps player from going off screen
            if (_playerLocation.X + _playerHitBox.Width > rightBound)
            {
                _playerLocation.X = rightBound - _playerHitBox.Width;
            }

            //Sets the hitbox location
            _playerHitBox.Location = _playerLocation;
        }
    }
}
