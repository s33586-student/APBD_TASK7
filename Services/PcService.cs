using APBD_TASK7.Data;
using APBD_TASK7.Dtos;
using APBD_TASK7.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_TASK7.Services
{
    public class PcService : IPcService
    {
        private readonly AppDbContext _context;
        
        public PcService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PcResponseDto>> GetAllAsync()
        {
            return await _context.Pcs
                .Select(pc => new PcResponseDto
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    Weight = pc.Weight,
                    Warranty = pc.Warranty,
                    CreatedAt = pc.CreatedAt,
                    Stock = pc.Stock
                })
                .ToListAsync();
        }
        public async Task<List<PcComponentResponseDto>> GetComponentsAsync(int id)
        {
            var exists = await _context.Pcs.FirstOrDefaultAsync(p => p.Id == id);

            if (exists == null)
                return null;

            return await _context.PcComponents
                .Where(pc => pc.PcId == id)
                .Select(pc => new PcComponentResponseDto
                {
                    ComponentCode = pc.Component.Code,
                    ComponentName = pc.Component.Name,
                    Description = pc.Component.Description,
                    ComponentType = pc.Component.ComponentType.Name,
                    Manufacturer = pc.Component.ComponentManufacturer.FullName,
                    Amount = pc.Amount
                })
                .ToListAsync();
        }
        public async Task<PcResponseDto> CreateAsync(PcRequestDto request)
        {
            var pc = new Pc
            {
                Name = request.Name,
                Weight = request.Weight,
                Warranty = request.Warranty,
                CreatedAt = request.CreatedAt,
                Stock = request.Stock
            };

            _context.Pcs.Add(pc);

            await _context.SaveChangesAsync();

            return new PcResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            };
        }
        public async Task<PcResponseDto?> UpdateAsync(int id, PcRequestDto request)
        {
            var pc = await _context.Pcs.FirstOrDefaultAsync(p => p.Id == id);

            if (pc == null)
                return null;

            pc.Name = request.Name;
            pc.Weight = request.Weight;
            pc.Warranty = request.Warranty;
            pc.CreatedAt = request.CreatedAt;
            pc.Stock = request.Stock;

            await _context.SaveChangesAsync();

            return new PcResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var pc = await _context.Pcs.FirstOrDefaultAsync(p => p.Id == id);

            if (pc == null)
                return false;

            _context.Pcs.Remove(pc);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
