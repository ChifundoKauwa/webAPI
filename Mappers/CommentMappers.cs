using api.Dto.Comments;
using api.Modules;

namespace api.Mappers
{
     public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment CommentModel)
        {
            return new CommentDto
            {
                Id = CommentModel.Id,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                CreatedOn = CommentModel.CreatedOn,
                StockId = CommentModel.StockId
            };
        }

         public static Comment ToCommentFromCreate(this CreateCommentDto CommentDto,int stockId)
        {
            return new Comment
            {
             
                Title = CommentDto.Title,
                Content = CommentDto.Content,
                StockId = stockId
            };
        }
    }
}