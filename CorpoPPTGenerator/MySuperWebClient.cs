using System.Net;
using System.Security.AccessControl;

namespace CorpoPPTGenerator
{
    public class MySuperWebClient : WebClient
    {
        private const string cbsgAddress = " http://cbsg.sf.net";

        public string CbsgAddress
        {
            get { return cbsgAddress; }
        }
        
    }
}