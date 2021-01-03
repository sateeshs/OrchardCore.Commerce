using System;
using System.Collections.Generic;
using System.Text;
using YesSql;
using System.Threading.Tasks;
using OrchardCore.Commerce.Models;
using OrchardCore.ContentManagement.GraphQL.Queries;
using GraphQL.Types;
using OrchardCore.Commerce.Indexes;
using OrchardCore.ContentManagement;
using OrchardCore.Apis.GraphQL.Queries;

namespace OrchardCore.Commerce.GraphQL
{
    public class ProductPartGraphQLFilter : GraphQLFilter<ProductPart>
    {
        public override Task<IQuery<ProductPart>> PreQueryAsync(IQuery<ProductPart> query, ResolveFieldContext context)
        {
            if (!context.HasArgument("productPart"))
            {
                return Task.FromResult(query);
            }

            var part = context.GetArgument<ProductPart>("productPart");

            if (part == null)
            {
                return Task.FromResult(query);
            }

            var autorouteQuery = query.With<ProductPartIndex>();

            if (!string.IsNullOrWhiteSpace(part.Content.ContentItemId))
            {
                var queryResult = autorouteQuery.Where(index => index.ContentItemId == (part as IContent).ContentItem.ContentItemId)
                                                .All();
                return Task.FromResult(queryResult);
                                    
            }

            return Task.FromResult(query);

        }
    }
    public class AddItemsToCartInputObjectType : WhereInputObjectGraphType<ShoppingCartItem>
    {
        public AddItemsToCartInputObjectType()
        {
            Name = "ShoppingCartItemInput";

        }
    }
}
