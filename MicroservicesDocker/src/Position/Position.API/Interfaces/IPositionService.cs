using Position.API.Models;

namespace Position.API.Interfaces
{
    public interface IPositionService
    {
        public Task<ResponseModel> CreatePosition(PositionDTO position);

        public Task<List<PositionModel>> GetAllPositions();
    }
}
