using GraphQL.Types;
using OrchardCore.Commerce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrchardCore.Commerce.GraphQL.Types
{
    public class OrderQueryObjectType : ObjectGraphType<OrderPart>
    {
        public OrderQueryObjectType() { }
    }
}
