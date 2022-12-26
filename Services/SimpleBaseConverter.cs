using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Services
{
    public class SimpleBaseConverter : IBaseConverter
    {
        public ConvertOutputMessage ConvertBase(ConvertInputMessage message)
        {
            // Переводим число в десятичную систему
            long decimalNumber = Convert.ToInt64(message.Number, message.FromBase);
            // Список для хранения результата
            List<int> result = new List<int>();
            // Переводим число в указанную систему счисления
            while (decimalNumber > 0)
            {
                result.Add((int)(decimalNumber % message.ToBase));
                decimalNumber /= message.ToBase;
            }
            // Переворачиваем список
            result.Reverse();
            // Преобразуем список в строку
            return new ConvertOutputMessage(message.Number, message.FromBase, message.ToBase, string.Join("", result));
        }
    }
}
