using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Grynwald.Utilities.Configuration.Test
{
    /// <summary>
    /// Unit tests for <see cref="ConfigurationBuilderExtensions"/>
    /// </summary>
    public class ConfigurationBuilderExtensionsTest
    {
        private enum TestEnum1
        {
            Value1,
            Value2
        }

        private class TestSettingsClass1
        {
            [ConfigurationValue("root:Setting1")]
            public string? Setting1 { get; set; }

            public string? SomeProperty { get; set; }

            [ConfigurationValue("root:Setting2")]
            public bool Setting2 { get; set; }

            [ConfigurationValue("root:Setting3")]
            public bool? Setting3 { get; set; }

            [ConfigurationValue("root:Setting4")]
            public TestEnum3 Setting4 { get; set; }

            [ConfigurationValue("root:Setting5")]
            public TestEnum3? Setting5 { get; set; }

            [ConfigurationValue("root:Setting6")]
            public int Setting6 { get; set; }

            [ConfigurationValue("root:Setting7")]
            public int? Setting7 { get; set; }
        }

        [Fact]
        public void GetSettingsDictionary_returns_the_expected_configuration_values()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass1()
            {
                Setting1 = "value1",
                Setting2 = true,
                Setting3 = false,
                Setting4 = TestEnum3.Value2,
                Setting5 = TestEnum3.Value2,
                Setting6 = 1,
                Setting7 = 2
            };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Contains("root:Setting1", settingsDictionary.Keys);
            Assert.Contains("root:Setting2", settingsDictionary.Keys);
            Assert.Contains("root:Setting3", settingsDictionary.Keys);
            Assert.Contains("root:Setting4", settingsDictionary.Keys);
            Assert.Contains("root:Setting5", settingsDictionary.Keys);

            Assert.Equal("value1", settingsDictionary["root:Setting1"]);
            Assert.Equal("True", settingsDictionary["root:Setting2"]);
            Assert.Equal("False", settingsDictionary["root:Setting3"]);
            Assert.Equal("Value2", settingsDictionary["root:Setting4"]);
            Assert.Equal("Value2", settingsDictionary["root:Setting5"]);
            Assert.Equal("1", settingsDictionary["root:Setting6"]);
            Assert.Equal("2", settingsDictionary["root:Setting7"]);
        }

        private class TestSettingsClass2
        {
            [ConfigurationValue("")]
            public string? Setting1 { get; set; }
        }

        [Fact]
        public void GetSettingsDictionary_ignores_properties_when_the_configuration_key_is_empty()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass2();


            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Empty(settingsDictionary);
        }

        private class TestSettingsClass3
        {
            [ConfigurationValue("setting1")]
            public object? Setting1 { get; set; }
        }

        [Fact]
        public void GetSettingsDictionary_throws_InvalidOperationException_is_property_type_is_not_string_or_bool()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass3();

            // ACT / ASSERT
            Assert.Throws<InvalidOperationException>(() => ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject));
        }

        private class TestSettingsClass4
        {
            [ConfigurationValue("setting1")]
            public string? Setting1 { set { } }
        }

        [Fact]
        public void GetSettingsDictionary_throws_InvalidOperationException_is_property_has_not_getter()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass4();

            // ACT / ASSERT
            Assert.Throws<InvalidOperationException>(() => ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject));
        }

        private class TestSettingsClass5
        {
            [ConfigurationValue("root:Setting1")]
            public string? Setting1 { get; set; }
        }

        [Fact]
        public void GetSettingsDictionary_ignores_properties_if_their_value_is_null()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass5() { Setting1 = null };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Empty(settingsDictionary);
        }


        private class TestSettingsClass6
        {
            [ConfigurationValue("root:Setting1")]
            public string? Setting1 { get; }


            public TestSettingsClass6(string setting1)
            {
                Setting1 = setting1;
            }
        }

        [Fact]
        public void GetSettingsDictionary_loads_values_from_readonly_properties()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass6("value1");

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            var kvp = Assert.Single(settingsDictionary);
            Assert.Equal("root:Setting1", kvp.Key);
            Assert.Equal("value1", kvp.Value);
        }


        private class TestSettingsClass7
        {
            [ConfigurationValue("setting1")]
            private string Setting1 { get; set; } = "Some Value";

            [ConfigurationValue("setting2")]
            protected string Setting2 { get; set; } = "Some Value";

            [ConfigurationValue("setting3")]
            internal string Setting3 { get; set; } = "Some Value";
        }

        [Fact]
        public void GetSettingsDictionary_ignores_non_public_properties()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass7();

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Empty(settingsDictionary);
        }

        private class TestSettingsClass8
        {
            [ConfigurationValue("setting1")]
            public bool? Setting1 { get; set; }

            [ConfigurationValue("setting2")]
            public bool? Setting2 { get; set; }

            [ConfigurationValue("setting3")]
            public bool? Setting3 { get; set; }
        }


        [Fact]
        public void GetSettingsDictionary_correctly_handles_nullable_bools()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass8()
            {
                Setting1 = true,
                Setting2 = false,
                Setting3 = null
            };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Contains("setting1", settingsDictionary.Keys);
            Assert.Contains("setting2", settingsDictionary.Keys);
            Assert.DoesNotContain("setting3", settingsDictionary.Keys);

            Assert.Equal("True", settingsDictionary["setting1"]);
            Assert.Equal("False", settingsDictionary["setting2"]);
        }

        private enum TestEnum2
        {
            Value1,
            Value2
        }

        private class TestSettingsClass9
        {
            [ConfigurationValue("setting1")]
            public TestEnum2? Setting1 { get; set; }

            [ConfigurationValue("setting2")]
            public TestEnum2? Setting2 { get; set; }

            [ConfigurationValue("setting3")]
            public TestEnum2? Setting3 { get; set; }
        }

        [Fact]
        public void GetSettingsDictionary_correctly_handles_nullable_enums()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass9()
            {
                Setting1 = TestEnum2.Value1,
                Setting2 = TestEnum2.Value2,
                Setting3 = null
            };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Contains("setting1", settingsDictionary.Keys);
            Assert.Contains("setting2", settingsDictionary.Keys);
            Assert.DoesNotContain("setting3", settingsDictionary.Keys);

            Assert.Equal("Value1", settingsDictionary["setting1"]);
            Assert.Equal("Value2", settingsDictionary["setting2"]);
        }

        private class TestSettingsClass10
        {
            [ConfigurationValue("setting1")]
            public int? Setting1 { get; set; }

            [ConfigurationValue("setting2")]
            public int? Setting2 { get; set; }

            [ConfigurationValue("setting3")]
            public int? Setting3 { get; set; }
        }

        [Fact]
        public void GetSettingsDictionary_correctly_handles_nullable_ints()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass10()
            {
                Setting1 = 23,
                Setting2 = 42,
                Setting3 = null
            };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Contains("setting1", settingsDictionary.Keys);
            Assert.Contains("setting2", settingsDictionary.Keys);
            Assert.DoesNotContain("setting3", settingsDictionary.Keys);

            Assert.Equal("23", settingsDictionary["setting1"]);
            Assert.Equal("42", settingsDictionary["setting2"]);
        }

        private class TestSettingsClass11
        {
            [ConfigurationValue("setting1")]
            public string[] Setting1 { get; set; } = Array.Empty<string>();
        }

        [Fact]
        public void GetSettingsDictionary_correctly_handles_arrays()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass11()
            {
                Setting1 = new[] { "value1", "value2" }
            };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Equal(2, settingsDictionary.Count);
            Assert.Contains("setting1:0", settingsDictionary.Keys);
            Assert.Contains("setting1:1", settingsDictionary.Keys);

            Assert.Equal("value1", settingsDictionary["setting1:0"]);
            Assert.Equal("value2", settingsDictionary["setting1:1"]);
        }

        private class TestSettingsClass12
        {
            [ConfigurationValue("setting1")]
            public IEnumerable<string> Setting1 { get; set; } = Enumerable.Empty<string>();
        }

        [Fact]
        public void GetSettingsDictionary_correctly_handles_IEnumerables()
        {
            // ARRANGE
            var settingsObject = new TestSettingsClass12()
            {
                Setting1 = Enumerable.Range(1, 2).Select(i => $"value{i}")
            };

            // ACT 
            var settingsDictionary = ConfigurationBuilderExtensions.GetSettingsDictionary(settingsObject);

            // ASSERT
            Assert.NotNull(settingsDictionary);
            Assert.Equal(2, settingsDictionary.Count);
            Assert.Contains("setting1:0", settingsDictionary.Keys);
            Assert.Contains("setting1:1", settingsDictionary.Keys);

            Assert.Equal("value1", settingsDictionary["setting1:0"]);
            Assert.Equal("value2", settingsDictionary["setting1:1"]);
        }


        private enum TestEnum3
        {
            Value1,
            Value2
        }

        [Theory]
        // scalar types
        [InlineData(typeof(string))]
        [InlineData(typeof(bool))]
        [InlineData(typeof(bool?))]
        [InlineData(typeof(TestEnum3))]
        [InlineData(typeof(TestEnum3?))]
        [InlineData(typeof(int))]
        [InlineData(typeof(int?))]
        // Arrays
        [InlineData(typeof(string[]))]
        [InlineData(typeof(bool[]))]
        [InlineData(typeof(bool?[]))]
        [InlineData(typeof(TestEnum3[]))]
        [InlineData(typeof(TestEnum3?[]))]
        [InlineData(typeof(int[]))]
        [InlineData(typeof(int?[]))]
        // IEnumerables
        [InlineData(typeof(IEnumerable<string>))]
        [InlineData(typeof(IEnumerable<bool>))]
        [InlineData(typeof(IEnumerable<bool?>))]
        [InlineData(typeof(IEnumerable<TestEnum3>))]
        [InlineData(typeof(IEnumerable<TestEnum3?>))]
        [InlineData(typeof(IEnumerable<int>))]
        [InlineData(typeof(IEnumerable<int?>))]
        public void IsSupportedPropertyType_returns_true_for_supported_property_types(Type type)
        {
            Assert.True(ConfigurationBuilderExtensions.IsSupportedPropertyType(type));
        }

        [Theory]
        [InlineData(typeof(char))]
        [InlineData(typeof(object))]
        public void IsSupportedPropertyType_returns_false_for_unsupported_property_types(Type type)
        {
            Assert.False(ConfigurationBuilderExtensions.IsSupportedPropertyType(type));
        }
    }
}
