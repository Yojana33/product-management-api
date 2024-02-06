using System.Data;
using Dapper;

public class ProductRepository: IProductRepository{


//dependency injection
private readonly IDbConnection _dbconnection;

public ProductRepository(IDbConnection dbConnection){
    _dbconnection= dbConnection;
}

// implementing inteface method
    public async Task<bool> CreateProduct(Product product){
    

    try{
        var sql= "INSERT INTO product(id, name, price, quantity, description, category_id, is_active, created_at) VALUES (@Id, @Name, @Price, @Quantity, @Description, @CategoryId, @IsActive, @CreatedAt)";
        await _dbconnection.ExecuteAsync(sql, product);
        return true;
    }

    catch(Exception){
       throw;
    }


    }
    public async Task<IReadOnlyList<Product>> GetProducts(GetProductListQuery query){
        try{
        var sql= "SELECT p.id AS Id, p.name AS Name, p.quantity AS Quantity,p.price AS price, p.created_at AS CreatedAt ,c.name AS Category FROM product p LEFT JOIN category c ON p.category_id = c.id WHERE p.is_active = true ORDER BY p.created_at DESC";
        var data= await _dbconnection.QueryAsync<Product>(sql);
        return data.ToList();

        }
        catch(Exception){
            throw;
        }
     }

    public async Task<bool> UpdateProduct(Product product)
    {
        var sql = @"UPDATE product
                    SET name = @Name,
                        price = @Price,
                       updated_at = @UpdatedAt
                       
                    WHERE id = @Id";

        var affectedRows = await _dbconnection.ExecuteAsync(sql, product);
        return affectedRows > 0;
    }

    public Task<Product?> GetProductById(string id)
    {
        var sql = "SELECT * FROM product WHERE id = @Id AND is_active = true";
        return _dbconnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
    }


}