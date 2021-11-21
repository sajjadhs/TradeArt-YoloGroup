using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDataClient.Queries
{
    public class PageAssetsQuery : GraphQLRequest
    {
        public PageAssetsQuery()
        {
            Query = @"query PageAssetsQuery {
                        assets(sort: [{marketCapRank: ASC}]) {
                            assetName
                            assetSymbol
                            id
                        }
                    }";
            OperationName = nameof(PageAssetsQuery);
        }
    }
}
