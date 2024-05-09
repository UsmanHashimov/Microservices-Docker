using Microsoft.EntityFrameworkCore;
using Position.API.Interfaces;
using Position.API.Models;
using Position.API.Persistence;

namespace Position.API.Services
{
    public class PositionService : IPositionService
    {
        private readonly PositionDbContext _context;

        public PositionService(PositionDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> CreatePosition(PositionDTO position)
        {
            var pos = new PositionModel
            {
                Title = position.Title,
                Description = position.Description,
                Level = position.Level
            };

            await _context.Positions.AddAsync(pos);
            await _context.SaveChangesAsync();

            return new ResponseModel { Message = "Position created", StatusCode = 201, isSuccess = true };
        }

        public async Task<List<PositionModel>> GetAllPositions()
        {
            var res = await _context.Positions.ToListAsync();

            return res;
        }
    }
}
