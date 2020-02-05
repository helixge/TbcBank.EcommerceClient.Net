using System;
using System.Collections.Generic;

namespace TbcBank.EcommerceClient
{
    public abstract class OperationResponse
    {
        private const char LineSeparator = '\n';
        private const char KeyValueSeparator = ':';

        private IDictionary<string, string> _keyValuePairs;
        private string _rawResponse;

        public string RawResponse { get; private set; }
        public string ErrorMessage { get; private set; }

        public bool IsError => ErrorMessage != null;

        public OperationResponse(HttpRequestResult httpResult)
        {
            if (httpResult == null) { throw new ArgumentNullException(nameof(httpResult)); }
            if (httpResult.RawResponse == null) { throw new ArgumentOutOfRangeException(nameof(httpResult.RawResponse)); }

            RawResponse = httpResult.RawResponse;
            if (RawResponse != null)
            {
                ParseRawResponseKeyValues();
            }
        }

        protected abstract void AssignModelValues();

        protected string GetResponseKeyValue(string key)
        {
            return _keyValuePairs.ContainsKey(key)
                 ? _keyValuePairs[key]
                 : null;
        }

        private void ParseRawResponseKeyValues()
        {
            _keyValuePairs = new Dictionary<string, string>();

            if (RawResponse.StartsWith("error:"))
            {
                ErrorMessage = RawResponse;
                return;
            }

            string[] lines = RawResponse.Split(LineSeparator);
            if (lines.Length == 0) { return; }

            foreach (var line in lines)
            {
                string[] kvp = line.Split(KeyValueSeparator);
                if (kvp.Length < 2) { continue; }

                _keyValuePairs.Add(kvp[0].Trim(), kvp[1].Trim());
            }

            AssignModelValues();
        }
    }
}
