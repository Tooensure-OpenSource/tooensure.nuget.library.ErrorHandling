using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.ErrorHandling
{
    public class ServiceResponse<T>
    {
        public T? Data { get; private set; } = default(T?);
        public bool IsSuccessful { get; private set; }
        public string? Message { get; private set; }
        private Dictionary<string, bool>? Requriments { get; set; } = new Dictionary<string, bool>();

        public ServiceResponse()
        {
            IsSuccessful = false;
            Message = string.Empty;
        }

        private ServiceResponse(T? data, bool issuccessful, string? message)
        {
            Data = data;
            IsSuccessful = issuccessful;
            Message = message;
        }

        public ServiceResponse<T> SuccessResponse(T? data = default, string? message = null) { return new ServiceResponse<T>(data, true, message); }

        public ServiceResponse<T> ErrorResponse(T? data = default, string ? message = null) { return new ServiceResponse<T>(data, false, message); }

        public ServiceResponse<T> AddRequirement(string key, bool result)
        {
            if (Requriments.Any(kvp => kvp.Key == key)) return ErrorResponse(message: "There are mutiple matching keys, should only maintain one");
            Requriments.Add(key, result);
            return this;
        }

        public ServiceResponse<T> ErrorCheck(Dictionary<string, bool>? errorCheckList = null)
        {
            if (errorCheckList == null && Requriments.Count <= 0) ErrorResponse(message:"pram null or not registered requirments");
            if (errorCheckList == null) errorCheckList = Requriments;

            var responseErrors = new ServiceResponse<T>();

            foreach (var errorCheckItem in errorCheckList)
            {
                if (errorCheckItem.Value.Equals(true)) return responseErrors = ErrorResponse(message: errorCheckItem.Key);
            }

            return responseErrors;
        }
    }
}
