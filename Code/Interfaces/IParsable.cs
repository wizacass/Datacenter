namespace Datacenter.Code
{
    public interface IParsable
    {
        void Parse(string dataString);

        void Parse(string[] dataArray);
    }
}
