using Azure;

public class UpdateProductService(IProductRepository _productRepository){


        public async Task<UpdateProductResponse> ExecuteAsync(UpdateProductCommand command)
    {
        try
        {
            var existingProduct = await _productRepository.GetProductById(command.Id);

            if (existingProduct == null)
            {
                return new UpdateProductResponse { Success = false, ErrorMessage = "Product not found." };
            }

            // Apply updates to the existing product based on the command
            existingProduct.Name = command.NewName;
            existingProduct.Price = command.NewPrice;

            existingProduct.UpdatedAt= DateTime.Now;

            var success = await _productRepository.UpdateProduct(existingProduct);

            if (success)
            {
                return new UpdateProductResponse { Success = true, ErrorMessage = string.Empty };
            }
            else
            {
                return new UpdateProductResponse { Success = false, ErrorMessage = "Failed to update product." };
            }
        }
        catch (Exception ex)
        {
            return new UpdateProductResponse { Success = false, ErrorMessage = ex.Message };
        }
    }

    }
