using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.DataLoader;
using GraphQL.Types;
using OrchardCore.Apis.GraphQL;
using OrchardCore.Commerce.Models;

namespace OrchardCore.Commerce.GraphQL.Types
{
    //https://github.com/OrchardCMS/OrchardCore/blob/1879619df4418ff175a59ba70dcb36bab89fcbb5/src/docs/reference/core/Apis.GraphQL.Abstractions/README.md
    //https://docs.orchardcore.net/en/dev/docs/reference/core/Apis.GraphQL.Abstractions/
    //https://github.com/OrchardCMS/OrchardCore/issues/5288
    public class ProductQueryObjectType : ObjectGraphType<ProductPart>
    {//IDataLoaderContextAccessor dataLoaderAccessor
        public ProductQueryObjectType()
        {
            Name = nameof(ProductPart);
            // Map the fields you want to expose
            Field(x => x.Sku);
            Field(x => x.ContentItem.DisplayText);
            Field<ListGraphType<PriceQueryObjectType>, PricePart[]>()
                .Name("productPrice")
                .Description("the product price")
                .PagingArguments()
                //.ResolveAsync(x =>  
                //{
                //    // x.GetOrAddCollectionBatchLoader();
                //    //var contentItemLoader = x.GetorAddPublishedContentItemByIdDataLoader();
                //    //return contentItemLoader.LoadAsync(x.Page(x.Source.ContentItemIds));
                //    var loader =
                //       dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, PricePart>(
                //           "GetReviewsByProductId", productPartGraphQLFilter.PreQueryAsync);
                //    return loader.LoadAsync(context.Source.Id);
                //}); 
                ;
        }
    }
}
