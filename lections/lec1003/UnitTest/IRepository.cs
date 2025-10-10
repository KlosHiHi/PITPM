namespace UnitTest
{
    public interface IRepository
    {
        public IEnumerable<string> GetStrings();

        public void AddString(string value);
    }
}
