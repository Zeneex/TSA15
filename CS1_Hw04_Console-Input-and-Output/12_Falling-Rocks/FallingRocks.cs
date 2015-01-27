/*
 * Problem 12.** Falling Rocks
 *
 * Implement the "Falling Rocks" game in the text console.
 *     A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
 *     A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
 *     Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, -, distributed with appropriate density. The dwarf is (O).
 * Ensure a constant game speed by Thread.Sleep(150).
 * Implement collision detection and scoring system.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class FallingRocks
{
    public struct playunit
    {
        public string body;
        public int x;
        public int y;
        public ConsoleColor color;
    }

    public struct scorePane
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public ConsoleColor color;
        public int indentLeft;
        public int indentTop;
        public string score;
        public string lives;
        public string difficulty;
        public string speed;
    }

    public static void DrawUnit(playunit unit)
    {
        Console.SetCursorPosition(unit.x, unit.y);
        Console.ForegroundColor = unit.color;
        Console.Write(unit.body);
    }

    public static void Main()
    {
        int playfieldWidth = 100;
        int playfieldHeight = 20;
        int playAreaWidth = playfieldWidth / 2;
        int playAreaHeight = playfieldHeight;
        int minimumNumberOfUnitsOnRow = 1;
        int maximumNumberOfUnitsOnRow = 1;      //it will increment as difficulty grows
        int minimumUnitBody = 1;            //the length of the rocks
        int maximumUnitBody = 2;            //the length of the rocks
        ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));  //I copy-pasted it - don't exactly get how and why it works, as I don't get the enums and the composite types yet :(...
        char[] symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        bool playerCrash = false;
        int gamesLeft = 5;
        int playScore = 0;
        int playSpeed = 0;          //play control values
        //int playDifficulty = 0;   //play control values
        int iterator = 0;           //play control values

        //create the playfield
        if (playfieldWidth < Console.WindowWidth)                           //horizontal init
            Console.BufferWidth = Console.WindowWidth = playfieldWidth;
        else
            Console.WindowWidth = Console.BufferWidth = playfieldWidth;

        if (playfieldHeight < Console.WindowHeight)                         //vertical init
            Console.BufferHeight = Console.WindowHeight = playfieldHeight;
        else
            Console.WindowHeight = Console.BufferHeight = playfieldHeight;

        //create the dwarf
        playunit dwarf = new playunit();

        //create the rocks
        List<playunit> rocks = new List<playunit>();

        //create random generator
        Random random = new Random();

        //create the score pane
        scorePane rightPane = new scorePane();

        //config everything
        //init everything
        //init dwarf
        dwarf.body = "(0)";
        dwarf.color = ConsoleColor.White;
        dwarf.x = (playAreaWidth - dwarf.body.Length) / 2;
        dwarf.y = playAreaHeight - 1;

        ////init rocks row
        int numberOfUnitsOnRow = random.Next(minimumNumberOfUnitsOnRow, maximumNumberOfUnitsOnRow + 1);
        //for (int i = 0; i < numberOfUnitsOnRow; i++)
        //{
        //    playunit rock = new playunit();
        //    rock.x = random.Next(0, playAreaWidth - 1);
        //    rock.y = 0;
        //    //rock.color = colors[random.Next(0, colors.Length)];
        //    do
        //    {
        //        rock.color = colors[random.Next(0, colors.Length)];
        //    }
        //    while (rock.color == Console.BackgroundColor);

        //    rock.body = new string(symbols[random.Next(0, symbols.Length)], random.Next(minimumUnitBody, maximumUnitBody + 1));
        //    rocks.Add(rock);
        //}

        //init the score pain
        rightPane.top = 0;
        rightPane.bottom = playfieldHeight - 1;
        rightPane.left = playAreaWidth;
        rightPane.right = playfieldWidth - 1;
        rightPane.indentLeft = 5;
        rightPane.indentTop = 5;
        rightPane.score = "Score:";
        rightPane.lives = "Lives:";
        rightPane.speed = "Speed:";
        rightPane.difficulty = "Difficulty:";
        rightPane.color = ConsoleColor.Yellow;

        while (true)                 //run
        {
            iterator++;

            //move the dwarf
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow && dwarf.x + dwarf.body.Length - 1 < playAreaWidth - 1)
                {
                    dwarf.x += 1;
                }
                else if (key.Key == ConsoleKey.LeftArrow && dwarf.x > 0)
                {
                    dwarf.x -= 1;
                }

                /*if (Console.KeyAvailable)
                    Console.In.ReadToEnd();*/
                while (Console.KeyAvailable)
                    Console.ReadKey();
            }

            //move the rocks
            for (int i = 0; i < rocks.Count; i++)
            {
                if (rocks[i].y + 1 < playAreaHeight)
                {
                    playunit rockShadowCopy = rocks[i];
                    rockShadowCopy.y += 1;
                    rocks[i] = rockShadowCopy;

                    //check the processed rock for collision
                    if (rockShadowCopy.y == playAreaHeight - 1)     //rock at the bottom
                    {
                        if (!(rockShadowCopy.x + rockShadowCopy.body.Length - 1 < dwarf.x || rockShadowCopy.x > dwarf.x + dwarf.body.Length - 1))
                        { //collision detected
                            playerCrash = true;
                            dwarf.color = ConsoleColor.Red;
                        }
                        else
                        {
                            playScore += 1;     //play-score increment with the count of avoided rocks (1 for each rock at the bottom)
                        }
                    }
                }
                else
                {
                    rocks.RemoveAt(i);
                    --i;
                }
            }
            //create new rocks row
            numberOfUnitsOnRow = random.Next(minimumNumberOfUnitsOnRow, maximumNumberOfUnitsOnRow + 1);
            for (int i = 0; i < numberOfUnitsOnRow; i++)
            {
                playunit rock = new playunit();
                rock.x = random.Next(0, playAreaWidth - 1);
                rock.y = 0;
                //rock.color = colors[random.Next(0, colors.Length)];
                do
                {
                    rock.color = colors[random.Next(0, colors.Length)];
                }
                while (rock.color == Console.BackgroundColor ||
                    rock.color == ConsoleColor.DarkBlue);       //I barely see dark blue dot on my monitor; you can exclude the rule

                rock.body = new string(symbols[random.Next(0, symbols.Length)], random.Next(minimumUnitBody, maximumUnitBody + 1));
                rocks.Add(rock);
            }

            //clear the field
            Console.Clear();

            //draw the dwarf
            DrawUnit(dwarf);
            //draw the rocks
            foreach (var rock in rocks)
            {
                DrawUnit(rock);
            }

            //draw the right pane, it should be a method
            {
                Console.ForegroundColor = rightPane.color;

                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, playfieldHeight / 5);
                Console.Write(rightPane.score);
                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, (playfieldHeight / 5) + 1);
                Console.Write(playScore);

                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, playfieldHeight * 2 / 5);
                Console.Write(rightPane.lives);
                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, (playfieldHeight * 2 / 5) + 1);
                Console.Write(gamesLeft);

                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, playfieldHeight * 3 / 5);
                Console.Write(rightPane.speed);
                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, (playfieldHeight * 3 / 5) + 1);
                Console.Write(playSpeed / 30);

                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, playfieldHeight * 4 / 5);
                Console.Write(rightPane.difficulty);
                Console.SetCursorPosition(rightPane.left + rightPane.indentLeft, (playfieldHeight * 4 / 5) + 1);
                Console.Write(maximumNumberOfUnitsOnRow - 1);
            }
            //draw border line
            for (int i = 0; i < playfieldHeight; i++)
            {
                Console.SetCursorPosition(rightPane.left, i);
                Console.Write("|");
            }

            if (iterator % (playfieldHeight * 10) == 0 && maximumNumberOfUnitsOnRow < 7)
            {
                maximumNumberOfUnitsOnRow += 1;     //1 difficulty up on every 10 screen heights
            }

            if (iterator % (playfieldHeight * 3) == 0 && playSpeed < 10 * 30)
            {
                playSpeed += 30;       //30 milliseconds faster on every 3 screen heights
            }

            if (playerCrash && gamesLeft > 0)
            {
                if (playScore >= 1000)
                    playScore -= 1000 / (playSpeed + 1);
                if (maximumNumberOfUnitsOnRow > 1)
                    maximumNumberOfUnitsOnRow -= 1;
                if (playSpeed > 0)
                    playSpeed -= 30;
                gamesLeft -= 1;
                string repeatPrompt = "GET READY AND PRESS A KEY TO TRY AGAIN";
                Console.SetCursorPosition((playfieldWidth - repeatPrompt.Length) / 2, playfieldHeight / 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(repeatPrompt);

                rocks.Clear();
                playerCrash = false;
                iterator = 0;
                dwarf.color = ConsoleColor.White;

                Console.ReadKey();
            }
            else if (playerCrash && gamesLeft == 0)
            {
                //playScore -= 500 / playDifficulty + 1;
                //playDifficulty -= 1;
                //playSpeed -= 50;
                //gamesLeft -= 1;
                //string repeatPrompt = "GET READY AND PRESS A KEY TO TRY AGAIN";
                string endPrompt = "GAME OVER (press a key to exit)";
                Console.SetCursorPosition((playfieldWidth - endPrompt.Length) / 2, playfieldHeight / 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(endPrompt);
                Console.ReadKey();
                return;
            }
            //count the cycles


            //slow the process
            Thread.Sleep(Math.Max(100, 400 - playSpeed));     //minimum 100 milliseconds, as play speed can vary
        }
    }
}