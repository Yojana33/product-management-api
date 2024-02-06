using System.Drawing.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
 public class GetCategoryListService(ICategoryRepository _categoryRepository)
{
    public async Task<IReadOnlyList<CategoryListViewModel>>GetAllCategoryList(GetCategoryListQuery query){
      
      //we can define new list like this
      List<CategoryListViewModel> categoryList= [];


      //get category entity list because db le yei return garcha
      var data= await _categoryRepository.GetCategories(query);

      //harek aako entity lai euta naya vm object ko field ma map gardinchum
      foreach(var items in data)
      {
        categoryList.Add(new CategoryListViewModel(){
            Id= items.Id,
            Name= items.Name,
            CreatedAt= items.CreatedAt,
        });
      }
      return categoryList;


    }
}