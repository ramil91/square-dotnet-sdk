using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchTeamMembersRequest 
    {
        public SearchTeamMembersRequest(Models.SearchTeamMembersQuery query = null,
            int? limit = null,
            string cursor = null)
        {
            Query = query;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Represents the parameters in a search for `TeamMember` objects.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchTeamMembersQuery Query { get; }

        /// <summary>
        /// The maximum number of `TeamMember` objects in a page (25 by default).
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// The opaque cursor for fetching the next page. Read about
        /// [pagination](https://developer.squareup.com/docs/working-with-apis/pagination) with Square APIs for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Query(Query)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private Models.SearchTeamMembersQuery query;
            private int? limit;
            private string cursor;



            public Builder Query(Models.SearchTeamMembersQuery query)
            {
                this.query = query;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public SearchTeamMembersRequest Build()
            {
                return new SearchTeamMembersRequest(query,
                    limit,
                    cursor);
            }
        }
    }
}