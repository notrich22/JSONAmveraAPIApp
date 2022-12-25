namespace JSONAmveraAPIApp.Messages
{
    public class Records
    {
        public record CalcInputMessage(int numberSystem, int x);
        public record CalcOutputMessage(int numberSystem, int num, string result);
        public record ErrorMessage(string Error);

    }
}
