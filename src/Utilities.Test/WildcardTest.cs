using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Grynwald.Utilities.Test
{
    public class WildcardTest
    {

        [Theory]
        [InlineData("*", "", true)]
        [InlineData("?", "", false)]
        [InlineData("?", "a", true)]
        [InlineData("*", "someString", true)]
        [InlineData("someString", "someString", true)]
        [InlineData("someString", "someOtherString", false)]
        [InlineData("some*", "someOtherString", true)]
        [InlineData("*bar", "foobar", true)]
        [InlineData("*bar*", "foobarfoo", true)]
        [InlineData("foo*foo", "foobarfoo", true)]
        [InlineData("foo?foo", "foobfoo", true)]
        [InlineData("f??", "foo", true)]
        public void IsMatch_returns_the_expected_value(string pattern, string value, bool shouldMatch)
        {
            var wildCard = new Wildcard(pattern);
            var isMatch = wildCard.IsMatch(value);

            Assert.Equal(shouldMatch, isMatch);
        }

    }
}
