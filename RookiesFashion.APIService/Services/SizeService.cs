using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services
{
    public class SizeService : ISizeService
    {
        private readonly RookiesFashionContext _context;
        public SizeService(RookiesFashionContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse> DeleteSize(int sizeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetSizeById(int sizeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetSizes()
        {
            throw new NotImplementedException();
        }

        public List<Size> GetSizesFromRange(List<int> sizeIds)
        {
            var listSize = _context.Sizes.Where(s=>sizeIds.Contains(s.SizeId)).ToList();
            return listSize;
        }

        public Task<ServiceResponse> InsertSize(Size size)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int sizeId, out Size size)
        {
            size = _context.Sizes.Find(sizeId);
            return size != null;
        }

        public Task<ServiceResponse> UpdateSize(Size size)
        {
            throw new NotImplementedException();
        }
    }
}