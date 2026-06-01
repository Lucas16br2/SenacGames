using SenacGames.Application.DTOs;
using SenacGames.Application.Interfaces;
using SenacGames.Domain.Entities;
using SenacGames.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.WebRequestMethods;

namespace SenacGames.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            return games.Select(MapToDto);
        }
        public async Task<GameDto?> GetByIdAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            return game == null ? null : MapToDto(game);
        }
        public async Task<IEnumerable<GameDto>> GetFeaturedAsync()
        {
            var games = await _gameRepository.GetFeaturedAsync();
            return games.Select(MapToDto);
        }

        public async Task<IEnumerable<GameDto>> GetByCategoryAsync(int categoryId)
        {
            var games = await _gameRepository.GetByCategoryAsync(categoryId);
            return games.Select(MapToDto);
        }
        public async Task<GameDto> CreateAsync(CreateGameDto dto)
        {
            //mapeia o DTO de criação
            var game = new GameDto
            {
                Title = dto.Title,
                Description = dto.Description,
                ReleaseYear = dto.ReleaseYear,
                coverImageUrl = dto.coverImageUrl,
                CategoryId = dto.CategoryId,
                isFeatured = dto.isFeatured,
                CreatedAt = DateTime.Now
            };

            await _gameRepository.AddAsync(game);

            //retorna o Game criado como DTO
            return MapToDto(game);
        }

        private GameDto MapToDto(GameDto game)
        {
            throw new NotImplementedException();
        }

        public async Task<GameDto?> UpdateAsync (int id, UpdateGameDto dto)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null) return null;

            game.Title = dto.Title;
            game.Description = dto.Description;
            game.ReleaseYear = dto.ReleaseYear;
            game.CoverImageUrl = dto.coverImageUrl;
            game.CategoryId = dto.CategoryId;
            game.IsFeatured = dto.isFeatured;

            await _gameRepository.UpdateAsync(game);
            return MapToDto(game);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return false;
            }
            await _gameRepository.DeleteAsync(id);
            return true;

        }
        public async Task<int> CountAsync()
        {
            return await _gameRepository.CountAsync();
        }

        private static GameDto MapToDto(Game game)
        {
            return new GameDto
            {
                id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ReleaseYear = game.ReleaseYear,
                coverImageUrl = game.CoverImageUrl,
                CategoryId = game.CategoryId,
                CategoryName = game.Category?.Name ?? string.Empty,
                isFeatured = game.IsFeatured,
                CreatedAt = game.CreatedAt
            };
        }   
    }
}
