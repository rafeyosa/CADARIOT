using SQLite4Unity3d;

public class ErrorModel {
    [PrimaryKey, AutoIncrement]
	public int Id { get; set; }
    public string errorCode { get; set; }
    public string message { get; set; }
    public string description { get; set; }
    public string createdAt { get; set; }

    public override string ToString ()
	{
		return string.Format ("[ErrorModel: Id={0}, errorCode={1},  message={2}, createdAt={3}]", Id, errorCode, message, createdAt);
	}
}
