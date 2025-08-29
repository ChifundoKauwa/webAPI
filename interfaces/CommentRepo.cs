using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Modules;
using api.Dto.Comments;


namespace api.interfaces
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetAllAnsyc();
        Task<Comment?> GetByIdAnsyc(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        
        Task<Comment?> UpdateAsync(Comment commentModel, int id);
       
    }
}