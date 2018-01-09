//Ai class 
//Contains the ai's information and methods that allows the player to interact with the ai, and for the player to marry the ai. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HarvestStarNewEdition
{
    class AI
    { 

        //rectangle variable to store the villager's hitbox 
        private Rectangle _villagerHitBox;

        //point variable to store the villager's location
        private Point _villagerLocation;

        //size variable to store the hitbox's location 
        private Size _villagerSize;

        //boolean to store if the player is married 
        private bool _isMarried;

        //integer variable to store the relationship points 
        private int _relationshipPoints;

        //boolean variable to store if the player has gifted, or has talked to the AI 
        private bool _hasTalkedTo;
        private bool _hasGifted;

        public AI()
            :this (0, false, false, false)
        {

        }

        //create an AI with a relationship points, and if they are married 
        public AI(int rp, bool married, bool talked, bool gifted)
        {
            _relationshipPoints = rp;
            _isMarried = married;
            _hasGifted = gifted;
            _hasTalkedTo = talked;
        }


        //get and set relationship points
        public int RelationshipPoints
        {
            get
            {
                return _relationshipPoints;
            }
            private set
            {
                _relationshipPoints = value;
            }
        }

        //get and set if the player has talked to AI
        public bool HasTalkedTo
        {
            get
            {
                return _hasTalkedTo;
            }
            private set
            {
                _hasTalkedTo = value;
            }
        }

        //get and set if the player has gifted the AI
        public bool HasGifted
        {
            get
            {
                return _hasGifted;
            }
            private set
            {
                _hasGifted = value;
            }
        }

        //Get and set if the AI is married to the player 
        public bool IsMarried
        {
            get
            {
                return _isMarried;
            }
            private set
            {
                _isMarried = value;
            }
        }

        //get and set the villager's hit box
        public Rectangle VillagerHitBox
        {
            get
            {
                return _villagerHitBox;
            }
            private set
            {
                _villagerHitBox = value;
            }
        }

        //get and set the villager's location 
        public Point VillagerLocation
        {
            get
            {
                return _villagerLocation;
            }
            private set
            {
                _villagerLocation = value;
            }
        }

        //get and set the villager's size 
        public Size VillagerSize
        {
            get
            {
                return _villagerSize;
            }
            private set
            {
                _villagerSize = value;
            }
        }

        //Sets up the AI location, hieght, width, size, and hitbox location 
        public void SetUpAI()
        {
            _villagerLocation.X = 100;
            _villagerLocation.Y = 300;

            _villagerSize.Height = 45;
            _villagerSize.Width = 35;

            _villagerHitBox.Location = _villagerLocation;
            _villagerHitBox.Size = _villagerSize;
        }

        //Ai and player talk 
        public string Talk()
        {
            //Checks if they are married
            if (_isMarried == true)
            {

                return "Hi honey, how are you? You look beautiful today, love you.";

            }
            else
            {
                //if they are not married, and he relationship points are greater than 50
                if (_relationshipPoints >= 50)
                {
                    //Checks tey have been talked to or not
                    if (_hasTalkedTo == false)
                    {
                        _hasTalkedTo = true;
                        _relationshipPoints += 10;
                    }

                    //Sets points to 100
                    if (_relationshipPoints > 100)
                    {
                        _relationshipPoints = 100;
                    }
                    //Set bool to true
                    return "Hey, what's up? Good to see you. Don't overwork youself on the farm.";
                }
                else
                {
                    //Adds points, sets tak to true, returns message
                    if (_hasTalkedTo == false)
                    {
                        _relationshipPoints += 10;
                    }
                    _hasTalkedTo = true;
                    return "Hey, there.";
                }
            }

        }

        //Recieve a wedding cake from the player 
        public string RecieveWeddingCake()
        {
            if (_isMarried == true)
            {
                return "Thanks honey.";
            }

            //if hey are not married, and their points is not 100
            if (_isMarried == false && _relationshipPoints >= 100)
            {

                //they will get married 
                _isMarried = true;
                return "You want to get married!? Of course I'll marry you.";
            }

            //not married, return message
            return "I'm not ready to get married yet sorry.";
        }
    

        //Recieve crop gift from the player
        public string RecieveCropGift()
        {
            //Checks if they were gifted today
            if (_hasGifted == false)
            {     
                //Adds points if not gifted
                _relationshipPoints += 20;
            }

            //if the points will be greater than 100, it will equal 100
            if (_relationshipPoints > 100)
            {
                _relationshipPoints = 100;

            }
            _hasGifted = true;
            //Returns message
            return "Oh, thank you!, I love it.";


        }

        //End of day, will set has talked to to false, and has gifted to false for next day 
        public void EndDay()
        {
            _hasTalkedTo = false;
            _hasGifted = false;
        }

    }
}
