using System;
using FinalTask.Casino;
using FinalTask.Casino.CasinoGames;
using FinalTask.Casino.CasinoGames.Blackjack;
using FinalTask.Casino.CasinoGames.Dice;
using FinalTask.SaveLoad;
using FinalTask.SaveLoad.Data;

namespace FinalTask
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string savePath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "FinalTaskSaves");

                ISaveLoadService<PlayerData> saveLoadService = new FileSystemSaveLoadService<PlayerData>(savePath);

                CasinoGameBase blackjackGame = new BlackjackGame(36);
                CasinoGameBase diceGame = new DiceGame(2, 1, 6);

                IGame casino = new Casino.Casino(saveLoadService, blackjackGame, diceGame);
                casino.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}