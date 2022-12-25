using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Services
{
    public interface ISolvator
    {
        CalcOutputMessage Solve(CalcInputMessage Input);

    }
}
