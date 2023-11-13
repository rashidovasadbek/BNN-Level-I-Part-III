using System.Security.Cryptography;
using System.Text;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class VerificationCodeGeneratorService
{
    private static string GenerateOnlyDigitCode(int length)
    {
        var code = new StringBuilder();

        for (int index = 0; index < length; index++)
        {
            code.Append(RandomNumberGenerator.GetInt32(0, 10));
        }

        return code.ToString();
    }
}