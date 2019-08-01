using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAmsMakelaars.Models;
using Flurl;
using Flurl.Http;

namespace TopAmsMakelaars
{
    public class FundaAPIRepo
    {
        public string m_baseUrl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json";

        public async Task<Root> GetMakelaars(int pageNum,int pageSize)
        {
            return await m_baseUrl
                      .AppendPathSegment("ac1b0b1572524640a0ecc54de453ea9f")
                      .SetQueryParams(new
                      {
                          type = "koop",
                          zo = "/amsterdam/",
                          page = pageNum,
                          pagesize = pageSize
                      }
                      ).GetJsonAsync<Root>();
        }

        public async Task<Root> GetMakelaarsWithTuin(int pageNum, int pageSize)
        {
            return await m_baseUrl
                      .AppendPathSegment("ac1b0b1572524640a0ecc54de453ea9f")
                      .SetQueryParams(new
                      {
                          type = "koop",
                          zo = "/amsterdam/tuin/",
                          page = pageNum,
                          pagesize = pageNum
                      }
                      ).GetJsonAsync<Root>();
        }
    }
}
