using Microsoft.AspNetCore.Mvc;


[ApiController] 
[Route("/api/v1/product")] 
public class ProductController : ControllerBase
{
    
    private readonly AddProductService _addProductService;

    private readonly GetProductListService _getProductListService;

        private readonly UpdateProductService _updateProductService;
    // inject gariyo
    public ProductController(AddProductService addProductService , GetProductListService getProductListService, UpdateProductService updateProductService )
    {
        _addProductService = addProductService;
        _getProductListService= getProductListService;
        _updateProductService= updateProductService;
    }

    

    [HttpPost("add")]
    public async Task<List<AddProductResponse>> CreateProduct([FromBody] AddProductCommand command)
    {
        var response = await _addProductService.Add(command);
        return response;
    }
        [HttpGet("list")]
    public async Task<IReadOnlyList<ProductListViewModel>> GetProductList([FromQuery] GetProductListQuery query){

        var response = await _getProductListService.GetAllProductList(query);
        return response;
    }
    [HttpPatch("update")]
    public async Task<UpdateProductResponse> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var response = await _updateProductService.ExecuteAsync(command);

        return response;
    }
}