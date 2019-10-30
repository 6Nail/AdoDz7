using Game.DataAccess;
using Game.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.UI.Extensions
{
    public static class RatingExtension
    {
        public static void AddRating(this GameContext context, Rating rating)
        {
            context.Ratings.Add(rating);
            context.SaveChanges();

            var ratings = context.Ratings.ToList();
            var game = context.VideoGames.SingleOrDefault(game => game.Id == rating.VideoGame.Id);
            var avgRating = 0;

            foreach (var mark in ratings)
            {
                avgRating += mark.Mark;
            }

            avgRating /= ratings.Count;
            game.AvgRating = avgRating;
        }
    }
}
