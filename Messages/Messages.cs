namespace JSONAmveraAPIApp.Messages
{
    public class Messages
    {
        public class ConvertInputMessage
        {
            public int FromBase { get; set; }
            public int ToBase { get; set; }
            public string Number { get; set; } //Number to convert
            public ConvertInputMessage(string number, int fromBase, int toBase)
            {
                FromBase= fromBase;
                ToBase= toBase;
                Number = number;
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
                FromBase= fromBase;
                ToBase= toBase;
                Number = number;
                Result= result;
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
            public DateTime currentDateTime { get; set; }
            public List<MethodDescription> MethodsAndDescription { 
                get {
                    return null;
                } }
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
