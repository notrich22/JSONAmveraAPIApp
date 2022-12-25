using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Services
{
    public class NSSolvator : ISolvator
    {
        public CalcOutputMessage Solve(CalcInputMessage Input)
        {
            int x = Input.X;
            int numberSystem = Input.NumberSystem;
            if (x <= 0)
            {
                throw new Exception("Enter an X");
            }
            string result = Convert.ToString(x, numberSystem);
            return new CalcOutputMessage(numberSystem, x, result);
        }
    }
}
