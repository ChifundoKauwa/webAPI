using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.interfaces;
using api.Modules;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepo

    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;

        }
        public async Task<List<Comment>> GetAllAnsyc()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAnsyc(int id)
        {
            return await _context.Comments.FindAsync(id); 
        }

      
    }
}