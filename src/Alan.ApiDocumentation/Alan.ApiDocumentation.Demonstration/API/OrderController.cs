using Alan.ApiDocumentation.Demonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alan.ApiDocumentation.Attributes;

namespace Alan.ApiDocumentation.Demonstration.API
{
    /// <summary>
    /// Order API
    /// </summary>
    public class OrderController : ApiController
    {
        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <author>God</author>
        /// <returns>{}</returns>
        /// <returns-fail>
        /// {
        ///     success: false,
        ///     message: "失败原因"
        /// }
        /// </returns-fail>
        public List<Order> Get()
        {
            return new List<Order>();
        }
        /// <summary>
        /// Query order by order id
        /// </summary>
        /// <param name="id" is-required="true">Order id</param>
        /// <returns-fail>
        /// {
        ///     success: bool/false,
        ///     message: string
        /// }
        /// </returns-fail>
        /// <returns>
        /// {
        ///     success: bool,
        ///     message: string,
        ///     data: [{
        ///         fn: string,
        ///         ln: string
        ///     }]
        /// }
        /// </returns>
        public Order Get(int id)
        {
            return new Order();
        }
        /// <summary>
        /// Delete order by order id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>{}</returns>
        public bool Delete(int id)
        {
            return true;
        }

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <author>Alan Wei</author>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// {
        ///     success: bool,
        ///     message: string,
        ///     data:[
        ///         OrderId: int,
        ///         OrderAddr: string,
        ///         Price: decimal
        ///     ]
        /// }
        /// </returns>
        public bool Post(Order order)
        {
            return true;
        }

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="id" is-required="true">订单ID</param>
        /// <param name="order" is-required="false">订单信息</param>
        /// <returns>bool</returns>
        public bool Put(int id, Order order)
        {
            return true;
        }
    }
}
