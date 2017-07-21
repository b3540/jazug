﻿/* This class get a result of Translator API
 * http://docs.microsofttranslator.com/text-translate.html#!/default/get_Translate
 */
using System;
using System.Net.Http;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace AzureSample
{
    public class Translate
    {
        const string uriBase = "https://api.microsofttranslator.com/v2/http.svc/Translate";

		public static async Task<string> TranslateTextAsync(string rowText)
		{
			var token = await AuthenticationToken.GetBearerTokenAsync(Secrets.TranslatorTextApiKey);

			using (var client = new HttpClient())
			{
				var sendUri = $"{uriBase}?appid={token}&text={rowText}&from=ja&to=en&category=generalnn";
				var stream = await client.GetStreamAsync(sendUri);
				var doc = XElement.Load(stream);

				return doc.Value;
			}
		}
    }
}