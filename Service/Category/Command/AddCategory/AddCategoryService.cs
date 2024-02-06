using Microsoft.IdentityModel.Tokens;

public class AddCategoryService(ICategoryRepository _categoryRepository)//yo primary constructor ho ra yo .net 8 ko feature ho
{
    // esle add garcha
    //but add garna lai chaine kura k sanga chata ?
    //IcategoryRespository 
    // it means ki hamro add category service is dependent on Icategoryrepository 
    // so we inject the dependency
    // hence its called dependency injection 

    //************************* old `way to use constrcutor ************************
    
   // private readonly ICategoryRepository _categoryRepository;
   // public AddCategoryService(ICategoryRepository categoryRepository)
    //{
     //   _categoryRepository = categoryRepository;
    //}
    public async Task<AddCategoryResponse> Add(AddCategoryCommand command)
    {
        var response = new AddCategoryResponse();
        if (command.CategoryName.IsNullOrEmpty())
        {
            return  new AddCategoryResponse(){ StatusCode=System.Net.HttpStatusCode.BadRequest, Response="Cannot set empty category name"};
        }
        Category category = new()
        {
            Name = command.CategoryName,
        };

        var success = await _categoryRepository.CreateCategory(category);

        if (success == true)
        {
            response.Response = $"Category {command.CategoryName} Added Successfully";
        }
        else
        {
            response.Response = "Failed to add new category";
        }
        return response;
    }

}