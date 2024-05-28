using System.Collections;

namespace SharedKernel.Common;

public class Enumerable<T> : IEnumerable<T> where T : struct
{
    public string Code { get; set; }
    public string Message { get; set; }

    public Enumerable(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new List<T>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}