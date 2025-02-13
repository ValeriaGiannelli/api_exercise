﻿using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        /// <summary>
        /// Metodo per modificare da Comment a DTO
        /// </summary>
        /// <param name="stockModel"></param>
        /// <returns></returns>
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreateOn = commentModel.CreateOn,
                StockId = commentModel.StockId,

            };
        }
    }
}
