using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Common
{
    public class Result<T>
    {
        public T TransactionResult { get; set; }
        public bool İsSucceeded { get; set; }
        public string UserMessage { get; set; }
        public Exception TransactionException { get; set; }
    }
}
