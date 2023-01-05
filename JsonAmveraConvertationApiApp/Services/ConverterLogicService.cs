using static JsonAmveraConvertationApiApp.Messages.Messages;

namespace JsonAmveraConvertationApiApp.Services
{
    public class ConverterLogicService
    {
        public ConvertOutputMessage Convert(ConvertInputMessage input, IBaseConverter converter)
        {
            return converter.ConvertBase(input);
        }
    }
}
