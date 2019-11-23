﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvxMovies.Entities;
using MvxMovies.Services.Contracts;

namespace MvxMovies.Services.Implementations.Mocks
{
    public class MoviesServiceMock : IMoviesService
    {
        public Task<MovieDto> GetMovieById(int id)
        {
            return Task.FromResult(GetMovie(id, null));
        }

        public async Task<IEnumerable<MovieDto>> SearchMovies(string name)
        {
            var list = await GetMovies();

            return list;
        }

        private static async Task<List<MovieDto>> GetMovies()
        {
            var list = new List<MovieDto>();
            await Task.Run(() =>
            {
                var random = new Random(1000);
                for (int i = 0; i < 10; i++)
                {
                    list.Add(GetMovie(i, random));
                }
            });
            return list;
        }

        private static MovieDto GetMovie(int i, Random random = null)
        {
            if (random == null)
            {
                random = new Random(1000);
            }
            return new MovieDto
            {
                Image = "data:image/jpeg;base64,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",
                Title = $"Title {i}",
                Plot = $"Plot {i}",
                Rating = random.Next(1, 5)
            };
        }
    }
}
