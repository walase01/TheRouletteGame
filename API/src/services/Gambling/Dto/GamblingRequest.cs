using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Gambling.Dto
{
    public class GamblingRequest
    {
        public string User {  get; set; }
        public int Amount { get; set; }
        public int Number { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
    }
}
