using AutoMapper;
using WebStoreA.Data.Entities;
using WebStoreA.Models.Categories;

namespace WebStoreA.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<CategoryEntity, CategoryItemViewModel>();
        }
    }
}
