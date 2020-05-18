namespace Datacenter.Code
{
    public interface IRunnable
    {
        string Id { get; }

        void Run(string fileId);
    }
}
