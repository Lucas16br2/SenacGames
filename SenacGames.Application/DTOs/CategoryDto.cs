using System;
using System.Collections.Generic;
using System.Text;

namespace SenacGames.Application.DTOs
{
    public class CategoryDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;

        //quantidades de games nesta categoria
        //util para listagem
        public int GameCount { get; set; }
        //

        /// <summary>
        /// dto para cirar categaoria
        /// </summary>
        public class CreateCategoryDto
        {
            public string name { get; set; } = string.Empty;
        }
        /// <summary>
        /// atualizar categoria
        /// </summary>
        public class UpdateCategoryDto
        {
            public string name { get; set; } = string.Empty;
        }

    }
}
