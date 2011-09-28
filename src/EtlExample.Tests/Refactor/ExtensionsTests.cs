using System.Collections.Generic;
using EtlExample.Refactor;
using NUnit.Framework;

namespace EtlExample.Tests.Refactor
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void can_lowercase_first_letter_of_string()
        {
            const string input = "This is a string";
            var output = input.ChangeFirstLetterToLower();
            Assert.AreEqual(output, "this is a string");
        }

        [Test]
        public void can_change_value_of_key_value_pair()
        {
            var input = new KeyValuePair<int, string>(0, "work");
            var output = input.ChangeValue(x => string.Format("does this {0}", x));
            Assert.AreEqual("does this work", output.Value);
        }
    }
}