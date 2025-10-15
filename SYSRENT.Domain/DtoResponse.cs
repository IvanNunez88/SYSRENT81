namespace SYSRENT.Domain;

public class DtoResponse<T>
{
    public bool Statu { get; set; }
    public T? Values { get; set; }
    public string? Msg { get; set; } = string.Empty;
}
