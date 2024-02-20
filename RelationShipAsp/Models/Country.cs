namespace RelationShipAsp.Models;

public class Country
{
    public int Id { get;set; }
    public string? Name { get;set; }
    public ICollection<State> State { get; set;}=new HashSet<State>();
}
