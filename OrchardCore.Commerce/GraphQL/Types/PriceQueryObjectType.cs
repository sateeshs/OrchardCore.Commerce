using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using OrchardCore.Commerce.Models;

namespace OrchardCore.Commerce.GraphQL.Types
{
    public class PriceQueryObjectType : ObjectGraphType<PricePart>
    {
        public PriceQueryObjectType()
        {
            Name = "PriceQuery";
            Field(x => x.Price.Value);
        }
    }
}
