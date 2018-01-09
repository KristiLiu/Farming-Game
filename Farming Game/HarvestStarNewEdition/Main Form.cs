/*
 * Kristi and Deanna
 * Jan 27, 2017
 * Culminating project : Harves Star. A farming game where there is a world, a player, an AI and crop objects. The player will farm
 * crop objects, interact with AI, sell crops..etc. The player can choose from a new game or loading an old game.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;    

namespace HarvestStarNewEdition
{
    public partial class Form1 : Form
    {
        //create the world 
        Map worldMap;

        //boolean variables to store if the player is moving right, down, left and right
        bool moveUp = false;
        bool moveDown = false;
        bool moveLeft = false;
        bool moveRight = false;

        //boolean variable to store if the player is watering something
        bool isWatering = false;

        //boolean variable to store if the game is running
        bool isGameRunning = false;

        //boolean variable to store if the player is holding an item 
        bool isHoldingItem = false;
        

        public Form1()
        {
            InitializeComponent();
            
            //Starting instructions 
            lblInstructions.Text = ("Welcome to Farming Life Simulator!" + "\r\n" + "You will start with 100 coins, with these coins you can buy crops" + "\r\n"
            + "Pumpkin costs 50 coins, Radish costs 20 coints, and wedding cake will cost 100 coins!" + "\r\n" + "You can plant these crops wherever you want."
            + "\r\n" + "Pumpkin takes 5 days to grow, radish takes 3 days to grow, and wedding cake takes 10 days to grow" + "\r\n" + "You may sell the crops after to get coins." +
            "\r\n" + "However, if you do not water these crops, they will not grow" + "\r\n" + "With the wedding cake, you may marry another villager by just giving them the cake!"
            + "\r\n" + "Use the arrows for movement, click the labels to buy crops, w key to water" + "\r\n" + " and the space key to plant or harvest a crop" + "\r\n"
             + " and finally, t key to give an item or to talk to the villager.");
        }

        public void SetUpLabelsPanelsTimer()
        {
            //panel refesh images look glitch might redo
            pnlStartGame.Visible = false;
            pnlStartGame.Enabled = false;

            //Show the player's name, balance, and the days passed
            lblName.Text = "Name : " + worldMap.ThePlayer.Name;
            lblBalance.Text = "Balance : " + worldMap.ThePlayer.Balance.ToString();
            lblDayCount.Text = "Day #: " + worldMap.DaysPassed.ToString();

            //the visibilities of in game interaction buttons true 
            lblBuyRadish.Visible = true;
            lblBuyWeddingCake.Visible = true;
            lblBuyPumpkinSeed.Visible = true;
            lblSell.Visible = true;
            lblName.Visible = true;
            lblBalance.Visible = true;
            lblDayCount.Visible = true;
            lblEndDay.Visible = true;
            lblSave.Visible = true;
            tmrRunTime.Enabled = true;
        }

        //Sets up the new game
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //Creates the world map
            if (txtName.Text != "")
            {
                worldMap = new Map();
                worldMap.SetUpTileSize(ClientSize.Width, ClientSize.Height);
                worldMap.CreateNewAI();
                worldMap.MakeNewPlayer(txtName.Text);
                //Game is running 
                isGameRunning = true;
                //Set up new player 
                SetUpLabelsPanelsTimer();
            }
        }
        //Load saved file
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            //create new world, and set up world 
            worldMap = new Map();
            worldMap.SetUpTileSize(ClientSize.Width, ClientSize.Height);
            worldMap.LoadPlayer();
            worldMap.LoadAI();
            worldMap.LoadOldCrops();

            //Timer that checks for game changes 
            SetUpLabelsPanelsTimer();

            //Game is running 
            isGameRunning = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            lblMessage.Text = null;

            //if the user presses the up key, make move up true 
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }

            //if the user presses the down key, make move down true 
            else if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
            //if the user presses the left key, make move left true 
            else if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            //if the user presses the right key, make move right true 
            else if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }

            //if the player presses the space key 
            else if (e.KeyCode == Keys.Space) 
            {
                
                //If the player is holding a crop item, plant the crop item 
                if (worldMap.ThePlayer.IsHoldingItem == true)
                {
                    worldMap.DropCrop();
                }
                // if the player is not holding a crop item, the player will pick up the crop 
                else
                {
                    worldMap.PickUpCrop();
                }
            }
            //If the player presses W watering will be true 
            else if (e.KeyCode == Keys.W)
            {
                isWatering = true;
                worldMap.WaterCrop();
            }
            else if (e.KeyCode == Keys.T)
            {
                lblMessage.Text = worldMap.TalkToAI();
            }
            else if (e.KeyCode == Keys.G)
            {
                lblMessage.Text = worldMap.GiftAI();
            }
        }
        // put an if statement inside refresh that says if true run the movecropitem thingy 

        //Set all movement booleans to false if the player stops pressing the keys 
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                isWatering = false;
            }
        }

        //Loads graphics 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (isGameRunning == true)
            {
                e.Graphics.DrawImage(Properties.Resources.Background, 0, 0, ClientSize.Width, ClientSize.Height);
                e.Graphics.DrawImage(Properties.Resources.guy, worldMap.Villager.VillagerHitBox);

                if (worldMap.ThePlayer.FacingDirection == Direction.Left)
                {
                    e.Graphics.DrawImage(Properties.Resources.Left1, worldMap.ThePlayer.PlayerHitBox);
                }
                else if (worldMap.ThePlayer.FacingDirection == Direction.Right)
                {
                    e.Graphics.DrawImage(Properties.Resources.Right1, worldMap.ThePlayer.PlayerHitBox);
                }
                else if (worldMap.ThePlayer.FacingDirection == Direction.Down)
                {
                    e.Graphics.DrawImage(Properties.Resources.Down1, worldMap.ThePlayer.PlayerHitBox);
                }
                else if (worldMap.ThePlayer.FacingDirection == Direction.Up)
                {
                    e.Graphics.DrawImage(Properties.Resources.Up1, worldMap.ThePlayer.PlayerHitBox);
                }

                if (isWatering == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.rainCloud, worldMap.ThePlayer.ItemInHandBox);
                }

                if (worldMap.ThePlayer.IsHoldingItem == true)
                {
                    if (worldMap.ThePlayer.ItemHolding is Pumpkin)
                    {
                        if (worldMap.ThePlayer.ItemHolding.IsFullGrown == true)
                        {
                            e.Graphics.DrawImage(Properties.Resources.pumpkinCrop, worldMap.ThePlayer.ItemInHandBox);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Properties.Resources.pumpkinSeed, worldMap.ThePlayer.ItemInHandBox);
                        }
                    }
                    else if (worldMap.ThePlayer.ItemHolding is Radish)
                    {
                        if (worldMap.ThePlayer.ItemHolding.IsFullGrown == true)
                        {
                            e.Graphics.DrawImage(Properties.Resources.raddish, worldMap.ThePlayer.ItemInHandBox);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Properties.Resources.radishSeed, worldMap.ThePlayer.ItemInHandBox);
                        }
                    }
                    else if (worldMap.ThePlayer.ItemHolding is WeddingCake)
                    {
                        if (worldMap.ThePlayer.ItemHolding.IsFullGrown == true)
                        {
                            e.Graphics.DrawImage(Properties.Resources.weddingCake, worldMap.ThePlayer.ItemInHandBox);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Properties.Resources.cakeSeed, worldMap.ThePlayer.ItemInHandBox);
                        }
                    }
                }
                //Loops through the layout of all crops, and draw graphics depending on what it is 
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (worldMap.CropsLayout[j, i] != null)
                        {
                            if (worldMap.CropsLayout[j, i] is Pumpkin)
                            {
                                if (worldMap.CropsLayout[j, i].IsFullGrown == true)
                                {
                                    e.Graphics.DrawImage(Properties.Resources.pumpkinCrop, worldMap.TileBox[j, i]);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(Properties.Resources.seedOnGround, worldMap.TileBox[j, i]);
                                }
                            }
                            else if (worldMap.CropsLayout[j, i].CropType == "Radish")
                            {
                                if (worldMap.CropsLayout[j, i].IsFullGrown == true)
                                {
                                    e.Graphics.DrawImage(Properties.Resources.raddish, worldMap.TileBox[j, i]);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(Properties.Resources.seedOnGround, worldMap.TileBox[j, i]);
                                }
                            }
                            else if (worldMap.CropsLayout[j, i].CropType == "WeddingCake")
                            {
                                if (worldMap.CropsLayout[j, i].IsFullGrown == true)
                                {
                                    e.Graphics.DrawImage(Properties.Resources.weddingCake, worldMap.TileBox[j, i]);
                                }
                                else
                                {
                                    e.Graphics.DrawImage(Properties.Resources.seedOnGround, worldMap.TileBox[j, i]);
                                }
                            }
                        }
                    }
                }
            }

        }

        //Timer for player's movement 
        private void tmrRunTime_Tick(object sender, EventArgs e)
        {
            if (moveDown == true)
            {
                worldMap.MoveDown(ClientSize.Height);
            }
            else if (moveUp == true)
            {
                worldMap.MoveUp();
            }
            else if (moveLeft == true)
            {
                worldMap.MoveLeft();
            }
            else if (moveRight == true)
            {
                worldMap.MoveRight(ClientSize.Width);
            }

            if (isHoldingItem == true || isWatering == true)
            {
                worldMap.ThePlayer.MoveObjectHolding();
            }
            //Display the player's balance, and the day number
            lblBalance.Text = worldMap.ThePlayer.Balance.ToString();
            lblDayCount.Text = "Day #: " + worldMap.DaysPassed.ToString();

            Refresh();
        }

        //End of the day, goes to new day
        private void lblEndDay_Click(object sender, EventArgs e)
        {
            lblMessage.Text = null;
            worldMap.EndDay();
        }

        //Buy a radish seed
        private void lblBuyRadish_Click(object sender, EventArgs e)
        {
            worldMap.BuyRadish();
            isHoldingItem = worldMap.ThePlayer.IsHoldingItem;
        }

        //Buy a pumpkin seed
        private void lblBuyPumpkinSeed_Click(object sender, EventArgs e)
        {
            worldMap.BuyPumpkin();
            isHoldingItem = worldMap.ThePlayer.IsHoldingItem;
        }

        //Buy a weddingcake seed 
        private void lblBuyWeddingCake_Click(object sender, EventArgs e)
        {
            //Goes to world map the buy wedding cake
            worldMap.BuyWeddingCake();
            isHoldingItem = worldMap.ThePlayer.IsHoldingItem;
        }
        private void lblSave_Click(object sender, EventArgs e)
        {
            //Save the player information and save the crops 
            worldMap.SaveAI();
            worldMap.SavePlayer();
            worldMap.SaveCropsLayout();
        }

        private void lblSell_Click(object sender, EventArgs e)
        {
            worldMap.SellCrop();
        }

        private void lblInstructions_Click(object sender, EventArgs e)
        {

        }

    }
}
