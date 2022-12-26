using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Services
{
    public interface IBaseConverter
    {
        ConvertOutputMessage ConvertBase(ConvertInputMessage convertation);

    }
}
