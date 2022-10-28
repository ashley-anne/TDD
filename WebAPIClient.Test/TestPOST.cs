using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAPIClient.Test
{
    public class TestPOST
    {

        private static readonly HttpClient client = new HttpClient();


        [Fact]
        public async void API_Post()
        {
            var resultPOST = await Program.ClientPOST();

            Assert.Equal((double)201, (double)resultPOST.StatusCode);
        }

    }

}



