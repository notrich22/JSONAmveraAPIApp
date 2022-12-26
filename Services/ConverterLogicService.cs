using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Services
{
    public class ConverterLogicService
    {
        public ConvertOutputMessage Convert(ConvertInputMessage input, IBaseConverter converter)
        {
            return converter.ConvertBase(input);
        }
    }
}
