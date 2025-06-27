using ContactApi.Dtos.Category;

namespace ContactApi.Mappers
{
    public static class CetegoryMapper
    {
        public static CategoryDto ToCategoryDto(this Models.Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}