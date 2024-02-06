public class Baseclass{
    
    public string? Id { get; set; }= Guid.NewGuid().ToString();

    public bool IsActive{get; set;}= true;
    public DateTime CreatedAt{ get; set;}= DateTime.Now;

    public DateTime UpdatedAt{ get; set;}

    public DateTime DeletedAt{ get; set;}
}