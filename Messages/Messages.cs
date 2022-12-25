namespace JSONAmveraAPIApp.Messages
{
    public class Messages
    {
        public class CalcInputMessage
        {
            public int NumberSystem { get; set; }
            public int X { get; set; } //Number to convert
            public CalcInputMessage(int numberSystem, int x)
            {
                NumberSystem = numberSystem;
                X = x;
            }
            public override string ToString()
            {
                return $"Trying to convert {X} in {NumberSystem} Number system;";
            }
        }
        public class CalcOutputMessage
        {
            public int NumberSystem { get; set; }
            public int Num { get; set; }
            public string Result { get; set; }
            public CalcOutputMessage(int numberSystem, int num, string result)
            {
                NumberSystem = numberSystem;
                Num = num;
                Result = result;
            }
            public override string ToString()
            {
                return $"{Num} in {NumberSystem} number system is: {Result}";
            }
        }
        public class StatusMessage
        {
            public const string CurrentStatus = "running on localhost";
            public string ServerName { get; set; }
            public string HostName { get; set; }
            public OperatingSystem OCVersion { get; set; }
            public int CPUCores { get; set; }
        }
        public class InfoMessage
        {
            public DateTime currentDateTime { get; set; }
            public const string MethodsAndDescription =
                "Solve - converts a number from 10NS to numberSystem\n" +
                "int numberSystem - number system to convert into\n" +
                "int x - number to convert into NS\n" +
                "Status: provides server status";
        }
        public class ErrorMessage
        {
            public string Error { get; set; }
            public ErrorMessage(string error)
            {
                Error = error;
            }
            public override string ToString()
            {
                return Error;
            }
        }
    }
}
