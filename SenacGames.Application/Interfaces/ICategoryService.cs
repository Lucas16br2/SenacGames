using SenacGames.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static SenacGames.Application.DTOs.CategoryDto;

namespace SenacGames.Application.Interfaces
{
    /// <summary>
    /// categoria de serviço de categorias
    /// </summary>
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllSync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync (CreateCategoryDto dto);
        Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();




    }
}
