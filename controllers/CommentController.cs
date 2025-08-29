using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using api.Mappers;
using api.Dto.Comments;

using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IStockInterface _stockRepo;
        public CommentController(ICommentRepo commentRepo, IStockInterface stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAnsyc();
            var commentsDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAnsyc(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
        {
            if (!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("stock does not exist");
            }
            var commentModel = commentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateCommentRequestDto updatecommentRequestDto)
        {
            var comment = await _commentRepo.GetByIdAnsyc(id);
            if (comment == null)
            {
                return NotFound();
            }
            
            comment.Title = updatecommentRequestDto.Title;
            comment.Content = updatecommentRequestDto.Content;
            
            await _commentRepo.UpdateAsync(comment, id);
            return Ok(comment.ToCommentDto());
        }
    }
}