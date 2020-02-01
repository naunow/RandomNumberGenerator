using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNumberGenerator
{
    public class RandomNumber
    {
        /// <summary>
        /// 被加算数
        /// </summary>
        public int Augend { get; set; }

        /// <summary>
        /// 加算数
        /// </summary>
        public int Addend { get; set; }

        private int result;

        /// <summary>
        /// 計算結果
        /// </summary>
        //public int Result { get; set; }
        //public int Result = 5;
        public int Result
        {
            get { return result + Addend + Augend; }
            private set { }

        }

    }
}
