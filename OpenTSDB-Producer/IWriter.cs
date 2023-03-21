namespace OpenTSDB_Producer;

public interface IWriter
{
    void Write(string location, double value);
}