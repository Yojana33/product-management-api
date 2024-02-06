using System.Drawing.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
 public class GetProductListService(IProductRepository _productRepository)
{
    public async Task<IReadOnlyList<ProductListViewModel>>GetAllProductList(GetProductListQuery query){
      
      //we can define new list like this
      List<ProductListViewModel> productList= [];


      //get category entity list because db le yei return garcha
      var data= await _productRepository.GetProducts(query);

      //harek aako entity lai euta naya vm object ko field ma map gardinchum
      foreach(var items in data)
      {
        productList.Add(new ProductListViewModel(){
            Id= items.Id,
            Name= items.Name,
            Quantity = items.Quantity,
            Price = items.Price,
            Category = items.Category,
            CreatedAt= items.CreatedAt,
        });
      }
      return productList;


    }
}