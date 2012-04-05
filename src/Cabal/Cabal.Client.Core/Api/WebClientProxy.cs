using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace Cabal.Client.Core.Api
{
	/// <summary>
	/// Retrieves data via a WebClient and returns typed data.
	/// </summary>
	public class WebClientProxy<ResultType>
	{
        private const int TimeoutMs = 20 * 1000;

		#region Utility Types

		public delegate void CallbackType(ResultType result);

		private class AsyncState
		{
			public WebRequest Request { get; set; }
			public CallbackType Callback { get; set; }
			public object Parameter { get; set; }
		}

		#endregion

		public Uri Address { get; private set; }
		
		public WebClientProxy(string address)
		{
			Address = new Uri(address);
		}

        public ResultType Get()
        {
            var resetEvent = new AutoResetEvent(false);
            ResultType result = default(ResultType);
            GetAsync(r =>
                    {
                        result = r;
                        resetEvent.Set();
                    });
            resetEvent.WaitOne(TimeoutMs);
            return result;
        }


		public void GetAsync(CallbackType callback)
		{
			WebRequest request = WebRequest.Create(Address);
			//request.ContentType = "application/json";
			request.Method = "GET";

			request.BeginGetResponse(GetResponseComplete, new AsyncState {
				Request = request,
				Callback = callback
			});
		}

        public ResultType Post<ParameterType>(ParameterType param)
        {
            var resetEvent = new AutoResetEvent(false);
            ResultType result = default(ResultType);
            PostAsync(param, r =>
                            {
                                result = r;
                                resetEvent.Set();
                            });
            resetEvent.WaitOne(TimeoutMs);
            return result;
        }

		public void PostAsync<ParameterType>(ParameterType param, CallbackType callback)
		{
			WebRequest request = WebRequest.Create(Address);
			request.ContentType = "application/json";
			request.Method = "POST";
			request.BeginGetRequestStream(GetRequestStreamComplete, new AsyncState {
				Request = request,
				Callback = callback,
				Parameter = param
			});
		}

		private static void GetRequestStreamComplete(IAsyncResult async)
		{
			var state = (AsyncState)async.AsyncState;
			using(Stream requestStream = state.Request.EndGetRequestStream(async))
			{
				var serializer = new DataContractJsonSerializer(state.Parameter.GetType());
				serializer.WriteObject(requestStream, state.Parameter);
			    requestStream.Close();
			}

			state.Request.BeginGetResponse(GetResponseComplete, state);
		}

		private static void GetResponseComplete(IAsyncResult async)
		{
			var state = (AsyncState)async.AsyncState;
			//state.Request.
			using(WebResponse response = state.Request.EndGetResponse(async))
			{
				Stream responseStream = response.GetResponseStream();
				var serializer = new DataContractJsonSerializer(typeof(ResultType));
				var result = (ResultType)serializer.ReadObject(responseStream);
				state.Callback(result);
			}
		}
	}
}