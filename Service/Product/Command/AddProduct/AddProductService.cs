// public class AddProductService(IProductRepository _productRepository)
// {


   
//     public async Task<AddProductResponse> Add(AddProductCommand command)
//     {
//         var response = new AddProductResponse();
//         if (string.IsNullOrEmpty(command.ProductName))
//         {
//             return  new AddProductResponse(){ StatusCode=System.Net.HttpStatusCode.BadRequest, Response="Cannot set empty product name"};
//         }
//         Product product = new()
//         {
//             Name = command.ProductName,
//         };

//         var success = await _productRepository.CreateProduct(product);

//         if (success == true)
//         {
//             response.Response = $"Product {command.ProductName} Added Successfully";
//         }
//         else
//         {
//             response.Response = "Failed to add new product";
//         }
//         return response;
//     }

// }
//*************************new***********************
public class AddProductService
{
    private readonly IProductRepository _productRepository;

    public AddProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<AddProductResponse>> Add(AddProductCommand command)
    {
        List<AddProductResponse> response = [];

        // Validate ProductName
        if (string.IsNullOrEmpty(command.ProductName))
        {
            response.Add( new AddProductResponse()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Response = "Cannot set empty product name"
            });
        }

        // Validate ProductPrice
        if (command.ProductPrice <= 0)
        {
            response.Add( new AddProductResponse()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Response = "Product price must be greater than zero"
            });
        }
        //validate quantity
        if (command.ProductQuantity <= 0)
        {
            response.Add( new AddProductResponse()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Response = "Product quantity must be greater than zero"
            });
        }

        // Validate ProductDescription
        if (string.IsNullOrEmpty(command.ProductDescription))
        {
         response.Add( new AddProductResponse()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Response = "Cannot set empty product description"
            });
        }
         if(response.Count>0){
            return response;
         }
        // Create a new Product object
        Product product = new()
        {
            Name = command.ProductName,
            Price = command.ProductPrice,
            Description = command.ProductDescription,
            Quantity= command.ProductQuantity,
            CategoryId=command.CategoryId
            // Other properties...
        };

        // Call CreateProduct method on the repository
        var success = await _productRepository.CreateProduct(product);

        // Set response message based on the success of the operation
        if (success == true)
        {
                        response.Add( new AddProductResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Response = $"Product {command.ProductName} added successfully"
            });
        }
        else
        {
                        response.Add( new AddProductResponse()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Response = "Product cannot be added"
            });
        }

        return response;
    }
}
