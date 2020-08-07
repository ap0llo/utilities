using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Grynwald.Utilities.Test
{
    public class StringExtensionsTest
    {

        [Theory]
        [InlineData("foo", "foo")]
        [InlineData("  foo", "  foo")]
        [InlineData("foo  ", "foo  ")]
        [InlineData("  foo  ", "  foo  ")]
        [InlineData("\tfoo", "\tfoo")]
        [InlineData("\tfoo\t", "\tfoo\t")]
        [InlineData("foo\t", "foo\t")]
        [InlineData("\r\nfoo", "foo")]
        [InlineData("\r\nfoo\r\n", "foo\r\n")]
        [InlineData("foo\r\n", "foo\r\n")]
        [InlineData("\rfoo", "foo")]
        [InlineData("\rfoo\r", "foo\r")]
        [InlineData("foo\r", "foo\r")]
        [InlineData("\nfoo", "foo")]
        [InlineData("\nfoo\n", "foo\n")]
        [InlineData("foo\n", "foo\n")]
        [InlineData("\r\n\r\nfoo", "foo")]
        [InlineData("\r\n\r\nfoo\r\n\r\n", "foo\r\n")]
        [InlineData("foo\r\n\r\n", "foo\r\n")]
        [InlineData("\r\rfoo", "foo")]
        [InlineData("\r\rfoo\r\r", "foo\r")]
        [InlineData("foo\r\r", "foo\r")]
        [InlineData("\n\nfoo", "foo")]
        [InlineData("\n\nfoo\n\n", "foo\n")]
        [InlineData("foo\n\n", "foo\n")]
        [InlineData("   \r\nfoo", "foo")]
        [InlineData("   \r\nfoo  \r\n", "foo  \r\n")]
        [InlineData("foo  \r\n  ", "foo  \r\n")]
        [InlineData("   \rfoo", "foo")]
        [InlineData("   \rfoo  \r", "foo  \r")]
        [InlineData("foo  \r", "foo  \r")]
        [InlineData("   \nfoo", "foo")]
        [InlineData("   \nfoo  \n", "foo  \n")]
        [InlineData("foo  \n", "foo  \n")]
        [InlineData("   \r\n  \r\nfoo", "foo")]
        [InlineData("   \r\n  \r\nfoo   \r\n  \r\n", "foo   \r\n")]
        [InlineData("foo   \r\n  \r\n", "foo   \r\n")]
        [InlineData("   \r  \rfoo", "foo")]
        [InlineData("   \r  \rfoo   \r  \r", "foo   \r")]
        [InlineData("foo   \r  \r", "foo   \r")]
        [InlineData("   \n  \nfoo", "foo")]
        [InlineData("   \n  \nfoo   \n  \n", "foo   \n")]
        [InlineData("foo   \n  \n", "foo   \n")]
        [InlineData("  foo  \r\n", "  foo  \r\n")]
        [InlineData("\r\nfoo  ", "foo  ")]
        public void TrimEmptyLines_returns_expected_value(string input, string expectedResult)
        {
            var actualResult = input.TrimEmptyLines();

            if (!expectedResult.Equals(actualResult))
            {
                throw new XunitException($"Unexpected result from {nameof(StringExtensions.TrimEmptyLines)}\r\n" +
                    $"Input:    \"{input.Replace("\n", "\\n").Replace("\r", "\\r")}\"\r\n" +
                    $"Expected: \"{expectedResult.Replace("\n", "\\n").Replace("\r", "\\r")}\"\r\n" +
                    $"Actual:   \"{actualResult.Replace("\n", "\\n").Replace("\r", "\\r")}\"");
            }
        }

        [Theory]
        [InlineData("", "D41D8CD98F00B204E9800998ECF8427E")]
        [InlineData("Some Input", "F1FB950EB2C26B4B561BCF9C8A839201")]
        public void ComputeHash_returns_expected_MD5_value(string input, string expectedOutput)
        {
            var actualOutput = input.ComputeHashString(HashAlgorithmName.MD5);
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Theory]
        [InlineData("", "DA39A3EE5E6B4B0D3255BFEF95601890AFD80709")]
        [InlineData("Some Input", "2F5F6AEA7308D4034760676735CB2A7502F5B5FC")]
        public void ComputeHash_returns_expected_SHA1_value(string input, string expectedOutput)
        {
            var actualOutput = input.ComputeHashString(HashAlgorithmName.SHA1);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("", "E3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B855")]
        [InlineData("Some Input", "1A419DF6D13F6B79F0C81C5FFE7FB344A896A716B145C1056AA2416FF97B2B0E")]
        public void ComputeHash_returns_expected_SHA256_value(string input, string expectedOutput)
        {
            var actualOutput = input.ComputeHashString(HashAlgorithmName.SHA256);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("", "38B060A751AC96384CD9327EB1B1E36A21FDB71114BE07434C0CC7BF63F6E1DA274EDEBFE76F65FBD51AD2F14898B95B")]
        [InlineData("Some Input", "9F5D96D3F5FD45370E615E18B54ACCA39207D44723045E6260AA6B83F19ABC37BE0107F5B594096FEC195BAEC656C2E6")]
        public void ComputeHash_returns_expected_SHA384_value(string input, string expectedOutput)
        {
            var actualOutput = input.ComputeHashString(HashAlgorithmName.SHA384);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("", "CF83E1357EEFB8BDF1542850D66D8007D620E4050B5715DC83F4A921D36CE9CE47D0D13C5D85F2B0FF8318D2877EEC2F63B931BD47417A81A538327AF927DA3E")]
        [InlineData("Some Input", "172BF593C2E1BB43FB07415E60BDC5D6E27A33B56B4E18C5BD74AEB5E6EE27973CB3C98F06D72980AE13A3F013E7E7A2EBB375BBB0ED4B5995F67A8DCF113055")]
        public void ComputeHash_returns_expected_SHA512_value(string input, string expectedOutput)
        {
            var actualOutput = input.ComputeHashString(HashAlgorithmName.SHA512);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
