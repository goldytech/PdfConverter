namespace Contoso.PdfConverter.WebApi.Handlers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The license handler which checks for the License Key in the Authorization header of http request.
    /// </summary>
    public class LicenseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
         HttpRequestMessage request,
         CancellationToken cancellationToken)
        {
            try
            {
                var headers = request.Headers;
                if (headers.Authorization != null)
                {
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    var license = encoding.GetString(Convert.FromBase64String(headers.Authorization.Parameter));

                    var isAuthenticated = CheckForLicense(license);

                    // TODO - Do authentication of userId and password against your credentials store here
                    if (isAuthenticated)
                    {
                        // everything is fine
                    }
                    else
                    {
                        var response = request.CreateResponse(HttpStatusCode.Unauthorized);
                        response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(license));
                        return response;
                    }
                }
                else
                {
                    // Authorization headers are not there
                    var response = request.CreateResponse(HttpStatusCode.BadRequest);

                    // response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(SCHEME));
                    return response;
                }
            }
            catch (Exception)
            {
                var response = request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }

            return await base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// The check for license.
        /// </summary>
        /// <param name="license">
        /// The license.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CheckForLicense(string license)
        {
            return true;
        }
    }
}
