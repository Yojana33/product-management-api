public interface ICategoryRepository{
    
    //return boolean if success
    //it takes entity as parameter
    //and creates a new category row in our table
    Task<bool> CreateCategory(Category category);

    Task<IReadOnlyList<Category>> GetCategories(GetCategoryListQuery query);


}