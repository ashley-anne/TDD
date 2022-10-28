using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestPUT
    {

        private static readonly HttpClient client = new HttpClient();


        [Fact]
        public async void API_Put()
        {
            var resultPUT = await Program.ClientPUT();

            Assert.Equal((double)204, (double)resultPUT.StatusCode);
        }

    }

}


