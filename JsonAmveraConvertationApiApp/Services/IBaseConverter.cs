using static JsonAmveraConvertationApiApp.Messages.Messages;

namespace JsonAmveraConvertationApiApp.Services
{
    public interface IBaseConverter
    {
            ConvertOutputMessage ConvertBase(ConvertInputMessage convertation);
    }
}
