using ContactApi.Dtos.BusinessSubcategory;
using ContactApi.Models;

namespace ContactApi.Mappers
{
    public static class BusinessSubcategoryMapper
    {
        public static BusinessSubcategoryDto ToBusinessSubcategoryDto(this BusinessSubcategory businessSubcategory)
        {
            return new BusinessSubcategoryDto
            {
                Id = businessSubcategory.Id,
                Name = businessSubcategory.Name,
            };
        }
    }
}