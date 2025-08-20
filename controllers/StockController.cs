using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Modules;
using Microsoft.AspNetCore.Http.HttpResults;
using api.Mappers; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Dto;
using api.Dto.Stock;
using api.interfaces;
using api.Repository;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockInterface _stockRepo;
        public StockController(ApplicationDBContext context,IStockInterface stockRepo)
        {
            _context = context;
            _stockRepo = stockRepo;

        }

        [HttpGet]

        public  async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stockDto =stocks.Select(s => s.ToStockDto()); //performing differed execution
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]

        public  async Task<IActionResult> Create([FromBody] CreateStockDto StockDto)
        {
            var stockModel = StockDto.ToStockFromCreateDto();
            await _stockRepo.CreateAsync(stockModel);
           await  _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task< IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }


        
            return Ok(stockModel.ToStockDto());

        }

        [HttpDelete]
        [Route("{id}")]
       public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepo.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
           
            return NoContent();
        }


    }
}