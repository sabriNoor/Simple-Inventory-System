namespace SimpleInventorySystem.Interfaces
{
    public interface IFileService <T>
    {
        List<T> ReadFile();
        void WriteFile(List<T> items);
    }
}