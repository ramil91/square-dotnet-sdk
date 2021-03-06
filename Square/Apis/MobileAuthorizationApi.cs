using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;

namespace Square.Apis
{
    internal class MobileAuthorizationApi : BaseApi, IMobileAuthorizationApi
    {
        internal MobileAuthorizationApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Generates code to authorize a mobile application to connect to a Square card reader
        /// Authorization codes are one-time-use and expire __60 minutes__ after being issued.
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:
        /// ```
        /// Authorization: Bearer ACCESS_TOKEN
        /// ```
        /// Replace `ACCESS_TOKEN` with a
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateMobileAuthorizationCodeResponse response from the API call</return>
        public Models.CreateMobileAuthorizationCodeResponse CreateMobileAuthorizationCode(Models.CreateMobileAuthorizationCodeRequest body)
        {
            Task<Models.CreateMobileAuthorizationCodeResponse> t = CreateMobileAuthorizationCodeAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Generates code to authorize a mobile application to connect to a Square card reader
        /// Authorization codes are one-time-use and expire __60 minutes__ after being issued.
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:
        /// ```
        /// Authorization: Bearer ACCESS_TOKEN
        /// ```
        /// Replace `ACCESS_TOKEN` with a
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateMobileAuthorizationCodeResponse response from the API call</return>
        public async Task<Models.CreateMobileAuthorizationCodeResponse> CreateMobileAuthorizationCodeAsync(Models.CreateMobileAuthorizationCodeRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/mobile/authorization-code");

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryBuilder.ToString(), _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["global"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateMobileAuthorizationCodeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}