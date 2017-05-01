using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan.ApiDocumentation.Demonstration.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public String UserId { get; set; }
        /// <summary>
        /// 订单地址
        /// </summary>
        public String Address { get; set; }
    }
}