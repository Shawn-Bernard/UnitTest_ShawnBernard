using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest_ShawnBernard
{
    /// <summary>
    /// A direction that has state for up, down, left and right
    /// </summary>
    public enum Direction { Up, Down, Left, Right }
    /// <summary>
    /// Unit testing for player that uses the player move
    /// </summary>
    [TestClass]
    public class UnitTest_Player : Player
    {
        /// <summary>
        /// Moves the player right 1 and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_CanMoveRight()
        {
            Move(Direction.Right);

            Assert.AreEqual(3, X);
            //I know I should check the tile in move but I just to see what tile I was on 
            Assert.AreEqual(0, CheckTile(X, Y));
            Assert.IsTrue(CanMove);
        }
        /// <summary>
        /// Moves the player left1 and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_CanMoveLeft()
        {
            Move(Direction.Left);

            Assert.AreEqual(1, X);
            Assert.AreEqual(0, CheckTile(X, Y));
            Assert.IsTrue(CanMove);
        }
        /// <summary>
        /// Moves the player up 1 and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_CanMoveUp()
        {
            Move(Direction.Up);

            Assert.AreEqual(3, Y);
            Assert.AreEqual(0, CheckTile(X, Y));
            Assert.IsTrue(CanMove);
        }
        /// <summary>
        /// Moves the player down 1 and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_CanMoveDown()
        {
            Move(Direction.Down);

            Assert.AreEqual(1, Y);
            Assert.AreEqual(0, CheckTile(X, Y)); 
            Assert.IsTrue(CanMove);
        }
        /// <summary>
        /// Goes up left the map width and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_MoveLeftIntoWall()
        {
            for (int i = 0; i < 3; i++)
            {
                Move(Direction.Left);
            }

            Assert.AreEqual(0, X);
            Assert.AreEqual(1, CheckTile(X, Y));
            Assert.IsFalse(CanMove);
        }
        /// <summary>
        /// Goes right untill the map width and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_MoveRightIntoWall()
        {
            for (int i = 0; i < 3; i++)
            {
                Move(Direction.Right);
            }

            Assert.AreEqual(4, X);
            Assert.AreEqual(1, CheckTile(X, Y));
            Assert.IsFalse(CanMove);
        }
        /// <summary>
        /// Goes up untill the map height and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_MoveUpIntoWall()
        {
            for (int i = 0; i < 3; i++)
            {
                Move(Direction.Up);
            }

            Assert.AreEqual(4, Y);
            Assert.AreEqual(1, CheckTile(X, Y));
            Assert.IsFalse(CanMove);
        }
        /// <summary>
        /// Goes down untill the map height and checks player position and checks tile
        /// </summary>
        [TestMethod]
        public void Player_MoveDownIntoWall()
        {
            for (int i = 0; i < 3; i++)
            {
                Move(Direction.Down);
            }

            Assert.AreEqual(0, Y);
            Assert.AreEqual(1, CheckTile(X, Y)); 
            Assert.IsFalse(CanMove);
        }
    }
    /// <summary>
    /// My player that holds all methods
    /// </summary>
    public class Player
    {

        int[,] Map;
        /// <summary>
        /// The maps width
        /// </summary>
        public int MapWidth;
        /// <summary>
        /// The maps height
        /// </summary>
        public int MapHeight;

        int Ground = 0;
        int Wall = 1;

        /// <summary>
        /// Bool to see if you can move
        /// </summary>
        public bool CanMove;

        /// <summary>
        /// Gets the player's X coordinate.
        /// </summary>
        public int X = 2;

        /// <summary>
        /// Gets the player's Y coordinate.
        /// </summary>
        public int Y = 2;

        /// <summary>
        /// Making a map using 2D array
        /// </summary>
        public void StartMap()
        {
            MapWidth = 5;
            MapHeight = 5;
            // Initialize the 2D array
            Map = new int[MapWidth, MapHeight];

            // Adding my floor tiles
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    Map[x, y] = Ground;
                }
            }

            // Adding my walls around the map
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    if (x == 0 || y == 0 || x == MapWidth - 1 || y == MapHeight - 1)
                    {
                        Map[x, y] = Wall;
                    }
                }
            }
        }

        /// <summary>
        /// Used to check the value of the position and returns it 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns a tile int value from the x/y position</returns>
        public int CheckTile(int x, int y)
        {
            return Map[x,y];
        }
        /// <summary>
        /// Switch state for movement depending on which direction is put in and checks if the players within bounds
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Returns true if the player is within bounds, returns false if not</returns>
        public void Move(Direction direction)
        {
            // Just so i have a map to check 
            StartMap();
            // Adding my player x and y to a new move x/y before we move
            int newX = X;
            int newY = Y;

            // Checks what vector moves and adds or subtracts on which state was passed in 
            switch (direction)
            {
                // And taking away 1 or adding 1 to my new x/y 
                case Direction.Up:
                    newY++;
                    break;

                case Direction.Down:
                    newY--;
                    break;

                case Direction.Left:
                    newX--;
                    break;

                case Direction.Right:
                    newX++;
                    break;
            }
            // Checks if the new x/y are within my map boundaries
            if (newX >= 0 && newY >= 0 && newX <= MapWidth -1 && newY <= MapHeight -1)
            {
                
                // If within bounds update the player's X/Y to new x/y
                X = newX;
                Y = newY;
                
                CanMove = true;

            }
            else
            {
                CanMove = false;
            }
            
        }
    }
}
