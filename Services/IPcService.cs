using APBD_TASK7.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TASK7.Services
{
    public interface IPcService
    {
        public Task<List<PcResponseDto>> GetAllAsync();
        public Task<List<PcComponentResponseDto>> GetComponentsAsync(int id);
        public Task<PcResponseDto> CreateAsync(PcRequestDto request);
        public Task<PcResponseDto?> UpdateAsync(int id, PcRequestDto request);
        public Task<bool> DeleteAsync(int id);
    }
}
