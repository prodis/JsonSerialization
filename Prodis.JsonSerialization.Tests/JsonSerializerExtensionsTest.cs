using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prodis.JsonSerialization;

namespace Prodis.JsonSerialization.Tests
{
    [TestClass]
    public class JsonSerializerExtensionsTest
    {
        private SomeFakeClass fake;
        private string fakeJson;

        [TestInitialize]
        public void Init()
        {
            this.fake = new SomeFakeClass
            {
                ID = 123,
                Text = "I am a sample text.",
                Value = 150.85M
            };

            this.fakeJson = "{\"ID\":123,\"Text\":\"I am a sample text.\",\"Value\":150.85}";
        }

        [TestMethod]
        public void Should_serialize_to_JSON_format()
        {
            Assert.AreEqual<string>(this.fakeJson, this.fake.ToJson());
        }

        [TestMethod]
        public void Should_deserialize_from_JSON_format()
        {
            SomeFakeClass actualFake = this.fakeJson.FromJson<SomeFakeClass>();

            Assert.AreEqual<int>(this.fake.ID, actualFake.ID);
            Assert.AreEqual<string>(this.fake.Text, actualFake.Text);
            Assert.AreEqual<decimal>(this.fake.Value, actualFake.Value);
        }
    }
}
