namespace api_recomendation.Models;

public enum State{
    Added,
    Modified,
    Deleted
}
public class Audit{
    public int Id { get; set; }
    public string TableName { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public string Action { get; set; }
    public string ChangedBy { get; set; }
    public DateTime ChangedDate { get; set; }
    public State State { get; set; }
    public string StateName => State.ToString();
}