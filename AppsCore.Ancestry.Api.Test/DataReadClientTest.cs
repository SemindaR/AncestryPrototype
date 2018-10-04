using System;
using AppsCore.Ancestry.Api.DataReadClient;
using AppsCore.Ancestry.Api.Model;
using Xunit;

namespace AppsCore.Ancestry.Api.Test
{
    public class DataReadClientTest
    {
        [Fact]
        public void ReadJsonData_Sucess()
        {
            IDataReadClient<AncestralData> dataReadClient = new DataReadClient<AncestralData>();

            var data = dataReadClient.ReadJsonData("TestData_small");

            Assert.NotNull(data);
        }
    }
}
