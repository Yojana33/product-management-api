using System.Data;
using Dapper;

public class CategoryRepository: ICategoryRepository{


//dbconnection is dependent upon idb so inject
private readonly IDbConnection _dbconnection;

public CategoryRepository(IDbConnection dbConnection){
    _dbconnection= dbConnection;
}

//interface kai ho vannale implementing inteface method
//junchai hamle program.cs ma mapping gareko cham
    public async Task<bool> CreateCategory(Category category){
    

    try{
        var sql= "INSERT INTO category(id, name, is_active, created_at) VALUES (@Id, @Name, @IsActive, @CreatedAt)";
        await _dbconnection.ExecuteAsync(sql, category);
        return true;
    }

    catch(Exception){
       throw;
    }


    }

     public async Task<IReadOnlyList<Category>> GetCategories(GetCategoryListQuery query){
        try{
        var sql= "SELECT * FROM category WHERE is_active = true ORDER BY created_at DESC";
        var data= await _dbconnection.QueryAsync<Category>(sql);
        return data.ToList();

        }
        catch(Exception){
            throw;
        }
     }


}