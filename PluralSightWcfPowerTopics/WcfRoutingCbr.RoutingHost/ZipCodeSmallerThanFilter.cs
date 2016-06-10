using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WcfRoutingCbr.RoutingHost
{
    // Custom Content Filter!
    public class ZipCodeSmallerThanFilter : MessageFilter
    {
        private int _conditionValue;

        public ZipCodeSmallerThanFilter(string filterData)
        {
            if(!Int32.TryParse(filterData, out _conditionValue))
            {
                _conditionValue = 0;
            }
        }

        public override bool Match(MessageBuffer buffer)
        {
            return true;
        }

        public override bool Match(Message message)
        {
            var ret = false;


            var regexp = new Regex(@".*<zipcode>[ ]*([\-]*[0-9]+)[ ]*</zipcode>.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            var fullMessage = message.ToString();
            Console.WriteLine(fullMessage);

            var match = regexp.Match(fullMessage);
            if(match.Success)
            {
                var zipCodeInMessage = Int32.Parse(match.Groups[1].Value);
                if(zipCodeInMessage < _conditionValue)
                {
                    ret = true;
                }
            } 
            
            return ret;
        }
    }
}
