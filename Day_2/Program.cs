using System;
using System.Collections.Generic;
using System.IO;

namespace Day_2
{
    public class Program
    {
        public class Round
        {
            public static int RoundCount { get; set; }
            public static int OpponentScore { get; set; }
            public static int PlayerScore { get; set; }
        }

        public enum OpponentHand
        {
            Rock = 'A',
            Paper = 'B',
            Scissors = 'C'
        }

        public enum PlayerHand
        {
            Rock = 'X',
            Paper = 'Y',
            Scissors = 'Z'
        }

        public enum PlayValue
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        public enum RoundOutcome
        {
            Loss = 0,
            Draw = 3,
            Win = 6
        }

        static void Main(string[] args)
        {
            ParseStrategy();

            Console.WriteLine("Final Score:" + Environment.NewLine +
                "Opponent: {0}" + Environment.NewLine +
                "Player: {1}", Round.OpponentScore, Round.PlayerScore);

            Console.ReadKey();
        }

        public static void ParseStrategy()
        {
            using (StreamReader strategyFile = new StreamReader("strategy.txt"))
            {
                string roundPlay;
                while ((roundPlay = strategyFile.ReadLine()) != null)
                {
                    // Opponent play on index 0, player play on index 2
                    var opponentPlay = roundPlay[0];
                    var playerPlay = roundPlay[2];

                    ExecuteRound(roundPlay, opponentPlay, playerPlay);
                }
            }
        }

        public static void ExecuteRound(string roundPlay, char opponentPlay, char playerPlay)
        {
            Round.RoundCount++;
            Console.WriteLine("Round {0}: {1} vs {2}", Round.RoundCount, opponentPlay, playerPlay);
            //RoundResult(roundPlay); // Used in Part 1
            ForceResult(roundPlay); // Used in Part 2
        }


        // used in Part 1
        public static void RoundResult(string roundPlay)
        {
            switch (roundPlay)
            {
                // draws
                case "A X":
                    Console.WriteLine("Rock draw!");
                    Round.OpponentScore += (int)RoundOutcome.Draw + (int)PlayValue.Rock;
                    Round.PlayerScore += (int)RoundOutcome.Draw + (int)PlayValue.Rock;
                    break;

                case "B Y":
                    Console.WriteLine("Paper draw!");
                    Round.OpponentScore += (int)RoundOutcome.Draw + (int)PlayValue.Paper;
                    Round.PlayerScore += (int)RoundOutcome.Draw + (int)PlayValue.Paper;
                    break;

                case "C Z":
                    Console.Write("Scissors draw!");
                    Round.OpponentScore += (int)RoundOutcome.Draw + (int)PlayValue.Scissors;
                    Round.PlayerScore += (int)RoundOutcome.Draw + (int)PlayValue.Scissors;
                    break;

                // rock wins
                case "A Z":
                    Round.OpponentScore += (int)RoundOutcome.Win + (int)PlayValue.Rock;
                    Round.PlayerScore += (int)RoundOutcome.Loss + (int)PlayValue.Scissors;
                    Console.WriteLine("Rock beats scissors!");
                    break;

                case "C X":
                    Round.OpponentScore += (int)RoundOutcome.Loss + (int)PlayValue.Scissors;
                    Round.PlayerScore += (int)RoundOutcome.Win + (int)PlayValue.Rock;
                    Console.WriteLine("Rock beats scissors!");
                    break;

                // paper wins
                case "A Y":
                    Round.OpponentScore += (int)RoundOutcome.Loss + (int)PlayValue.Rock;
                    Round.PlayerScore += (int)RoundOutcome.Win + (int)PlayValue.Paper;
                    Console.WriteLine("Paper beats rock!");
                    break;

                case "B X":
                    Round.OpponentScore += (int)RoundOutcome.Win + (int)PlayValue.Paper;
                    Round.PlayerScore += (int)RoundOutcome.Loss + (int)PlayValue.Rock;
                    Console.WriteLine("Paper beats rock!");
                    break;

                // scissors wins
                case "B Z":
                    Round.OpponentScore += (int)RoundOutcome.Loss + (int)PlayValue.Paper;
                    Round.PlayerScore += (int)RoundOutcome.Win + (int)PlayValue.Scissors;
                    Console.WriteLine("Scissors beats paper!");
                    break;

                case "C Y":
                    Round.OpponentScore += (int)RoundOutcome.Win + (int)PlayValue.Scissors;
                    Round.PlayerScore += (int)RoundOutcome.Loss + (int)PlayValue.Paper;
                    Console.WriteLine("Scissors beats paper!");
                    break;

            }
        }

        // used in Part 2
        public static void ForceResult(string roundPlay)
        {

            // x = lose
            // y = draw
            // z = win
            switch (roundPlay)
            {
                // draws
                case "A X":
                    Console.WriteLine("Rock beats scissors!");
                    Round.OpponentScore += (int)RoundOutcome.Win + (int)PlayValue.Rock;
                    Round.PlayerScore += (int)RoundOutcome.Loss + (int)PlayValue.Scissors;
                    break;

                case "C X":
                    Round.OpponentScore += (int)RoundOutcome.Win + (int)PlayValue.Scissors;
                    Round.PlayerScore += (int)RoundOutcome.Loss + (int)PlayValue.Paper;
                    Console.WriteLine("Scissors beats paper!");
                    break;

                case "B X":
                    Round.OpponentScore += (int)RoundOutcome.Win + (int)PlayValue.Paper;
                    Round.PlayerScore += (int)RoundOutcome.Loss + (int)PlayValue.Rock;
                    Console.WriteLine("Paper beats rock!");
                    break;

                case "B Y":
                    Console.WriteLine("Paper draw!");
                    Round.OpponentScore += (int)RoundOutcome.Draw + (int)PlayValue.Paper;
                    Round.PlayerScore += (int)RoundOutcome.Draw + (int)PlayValue.Paper;
                    break;

                case "A Y":
                    Round.OpponentScore += (int)RoundOutcome.Draw + (int)PlayValue.Rock;
                    Round.PlayerScore += (int)RoundOutcome.Draw + (int)PlayValue.Rock;
                    Console.WriteLine("Rock draw!");
                    break;

                case "C Y":
                    Round.OpponentScore += (int)RoundOutcome.Draw + (int)PlayValue.Scissors;
                    Round.PlayerScore += (int)RoundOutcome.Draw + (int)PlayValue.Scissors;
                    Console.WriteLine("Scissor draw!");
                    break;

                case "C Z":
                    Console.Write("Rock beats scissors!");
                    Round.OpponentScore += (int)RoundOutcome.Loss + (int)PlayValue.Scissors;
                    Round.PlayerScore += (int)RoundOutcome.Win + (int)PlayValue.Rock;
                    break;

                case "A Z":
                    Round.OpponentScore += (int)RoundOutcome.Loss + (int)PlayValue.Rock;
                    Round.PlayerScore += (int)RoundOutcome.Win + (int)PlayValue.Paper;
                    Console.WriteLine("Paper beats rock!");
                    break;

                case "B Z":
                    Round.OpponentScore += (int)RoundOutcome.Loss + (int)PlayValue.Paper;
                    Round.PlayerScore += (int)RoundOutcome.Win + (int)PlayValue.Scissors;
                    Console.WriteLine("Scissors beats paper!");
                    break;
            }
        }
    }
}
