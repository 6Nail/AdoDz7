using Game.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Service
{
    public class SearchService
    {
        private readonly GameContext context;
        private const int gameCount = 3;

        public SearchService(GameContext context)
        {
            this.context = context;
        }

        public void SearchGameByName(string gameName, int pageNumber = 1)
        {
            var result = context.VideoGames.Where(game => game.Title.Contains(gameName)).ToList();
            var pageCount = Math.Ceiling(result.Count / (double)gameCount);

            if (pageNumber > pageCount || pageNumber <= 0)
            {
                Console.WriteLine("Нет такой страницы");
                return;
            }
            var page = result.Skip(gameCount * --pageNumber).Take(gameCount).ToList();


            foreach (var game in page)
            {
                Console.WriteLine($"Название игры: {game.Title}\n Описание: {game.Description}\n Средняя оценка: {game.AvgRating}\n\n");
            }

            Console.WriteLine($"{++pageNumber} | {pageCount}");
        }

        public void ShowAll(int pageNumber = 1)
        {
            var result = context.VideoGames.ToList();
            var pageCount = Math.Ceiling(result.Count / (double)gameCount);
            if (pageNumber > pageCount || pageNumber <= 0)
            {
                Console.WriteLine("Нет такой страницы");
                return;
            }
            var page = result.Skip(gameCount * --pageNumber).Take(gameCount).ToList();

            foreach (var game in page)
            {
                Console.WriteLine($"Название игры: {game.Title}\n Описание: {game.Description}\n Средняя оценка: {game.AvgRating}\n\n");
            }

            Console.WriteLine($"{++pageNumber} | {pageCount}");
        }
    }
}
