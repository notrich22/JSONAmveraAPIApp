namespace JsonAmveraConvertationApiApp.Messages
{
    public class Messages
    {
        public record IPMessage(string IP);
        private readonly static List<MethodDescription> methods = new List<MethodDescription>()
        {
            new MethodDescription()
            {
                MethodName = "Status",
                MethodUrl = "/status",
                Description = "Gets status of a server"
            },
            new MethodDescription()
            {
                MethodName  = "Convert",
                MethodUrl = "/convert",
                Description = "Converts value to another base. Parameters: (string)Number, (int)ToBase, (int)FromBase"
            },
            new MethodDescription()
            {
                MethodName  = "Get hosts",
                MethodUrl = "/get-hosts",
                Description = "Provides a list of hosts"
            },
            new MethodDescription()
            {
                MethodName  = "Get requests",
                MethodUrl = "/get-requests",
                Description = "Provides a list of requests"
            },
            new MethodDescription()
            {
                MethodName  = "Get requests by host",
                MethodUrl = "/get-requests-by-host",
                Description = "Provides a list of requests by host. Parameter: (string)IP"
            }
        };
        public class ConvertInputMessage
        {
            public int FromBase { get; set; }
            public int ToBase { get; set; }
            public string Number { get; set; } //Number to convert
            public ConvertInputMessage(string number, int fromBase, int toBase)
            {
                Number = number;
                FromBase = fromBase;
                ToBase = toBase;
            }
            public override string ToString()
            {
                return $"Trying to convert {Number} from {FromBase} Base in {ToBase} Base;";
            }
        }
        public class ConvertOutputMessage
        {
            public int FromBase { get; set; }
            public int ToBase { get; set; }
            public string Number { get; set; }
            public string Result { get; set; }
            public ConvertOutputMessage(string number, int fromBase, int toBase, string result)
            {
                FromBase = fromBase;
                ToBase = toBase;
                Number = number;
                Result = result;
            }
            public override string ToString()
            {
                return $"{Number} converted from {FromBase} Base to {ToBase} Base is: {Result}";
            }
        }
        public class StatusMessage
        {
            public const string CurrentStatus = "running on Amvera";
            public string ServerName { get; set; }
            public string HostName { get; set; }
            public OperatingSystem OCVersion { get; set; }
            public int CPUCores { get; set; }
        }
        public class InfoMessage
        {
            public List<MethodDescription> MethodsAndDescription
            {
                get
                {
                    return methods;
                }
            }
        }
        //TODO
        public class MethodDescription
        {
            public string MethodName { get; set; }
            public string MethodUrl { get; set; }
            public string Description { get; set; }
        }
        public class ErrorMessage
        {
            public Exception Error { get; set; }
            public ErrorMessage(Exception ex)
            {
                Error = ex;
            }
            public override string ToString()
            {
                return $"Exception occured: {Error.Message}: DateTime:{DateTime.Now.ToLongTimeString()}";
            }
        }
    }
}
