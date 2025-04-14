using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Gambling.Dto
{
    public class WinInfoByUser
    {
        public int WinningNumber {  get; set; }
        public string WinningColor { get; set; }
        public bool Successful { get; set; }
        public double Award { get; set; }
        public double UserAmount { get; set; }
    }
}
