using Microsoft.AspNetCore.Mvc;

// html haina data return garne controller
[ApiController] // yo chai http api ko lagi kaam garcha
[Route("/api/v1/category")] // yo controller ma hit garna euta route banako
public class CategoryController : ControllerBase
{
    // category add ko handling add category service le garcha so 
    // hami yo pani inject garcham
    private readonly AddCategoryService _addCategoryService;
    private readonly GetCategoryListService _getCategoryListService;
    // inject gariyo
    public CategoryController(AddCategoryService addCategoryService , GetCategoryListService getCategoryListService)
    {
        _addCategoryService = addCategoryService;
        _getCategoryListService= getCategoryListService;
    }

    // add garne end point bhayo

    [HttpPost("add")]
    public async Task<AddCategoryResponse> CreateCategory([FromBody] AddCategoryCommand command)
    {
        var response = await _addCategoryService.Add(command);
        return response;
    }
    
    [HttpGet("list")]
    public async Task<IReadOnlyList<CategoryListViewModel>> GetCategoryList([FromQuery] GetCategoryListQuery query){

        var response = await _getCategoryListService.GetAllCategoryList(query);
        return response;
    }
} 