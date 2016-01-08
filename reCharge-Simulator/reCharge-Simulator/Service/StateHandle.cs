using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.IO;
using AutoSend.Dao;
using AutoSend;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AutoSend
{
    class StateHandle
    {
        Log log = new Log();

        public int insertOrderService(OrderInfo phoneInfo)
        {
            OrderInfoDao dao = new OrderInfoDao();
            return dao.insertOrderDao(phoneInfo);
        }

        public OrderInfo submitOrderService(MainForm frm)
        {
            OrderInfoDao dao = new OrderInfoDao();
            OrderInfo phoneInfo = dao.getSubmitOrderDao();
            if (phoneInfo != null)
            {
                try
                {
                    String jdOrderId = "";
                    String jdOrderInTime = "";
                    String orderId = phoneInfo.order_id.Trim();
                    String facePrice = phoneInfo.face_price.Trim();
                    String telephone = phoneInfo.phone_no.Trim();

                    View.write("实立单号:" + orderId + ",号码:" + telephone + ",面值:" + facePrice + ",开始充值提交...");
                    log.Debug("实立单号:" + orderId + ",号码:" + telephone + ",面值:" + facePrice + ",开始充值提交...");
                    if (!String.IsNullOrEmpty(orderId) && !String.IsNullOrEmpty(facePrice) && !String.IsNullOrEmpty(telephone))
                    {
                        log.Debug("searchSkuIdResult:http://chongzhi.jd.com/json/order/search_searchPhone.action?mobile=" + telephone);
                        String telephoneInfo = Share.getPage("http://chongzhi.jd.com/json/order/search_searchPhone.action", "mobile=" + telephone, "");
                        log.Debug("telephoneInfo:" + telephoneInfo);
                        if (String.IsNullOrEmpty(telephoneInfo) || telephoneInfo.Contains("System.Net.WebException"))
                        {
                            log.Debug("searchSkuIdResult:http://chongzhi.jd.com/json/order/search_searchPhone.action?mobile=" + telephone);
                            telephoneInfo = Share.getPage("http://chongzhi.jd.com/json/order/search_searchPhone.action", "mobile=" + telephone, "");
                            log.Debug("telephoneInfo:" + telephoneInfo);
                        }
                        JObject telephoneInfoJson = (JObject)JsonConvert.DeserializeObject(telephoneInfo);
                        String area = telephoneInfoJson["area"].ToString().Trim();
                        String ISP = telephoneInfoJson["provider"].ToString().Trim();
                        log.Debug("searchSkuIdResult:http://chongzhi.jd.com/json/order/search_searchSkuId.action?ISP=" + ISP + "&area=" + area + "&filltype=0&faceValue=" + facePrice);
                        String searchSkuIdResult = Share.getPage("http://chongzhi.jd.com/json/order/search_searchSkuId.action", "ISP=" + ISP + "&area=" + area + "&filltype=0&faceValue=" + facePrice, "");
                        log.Debug("searchSkuIdResult:" + searchSkuIdResult);
                        if (String.IsNullOrEmpty(searchSkuIdResult) || searchSkuIdResult.Contains("System.Net.WebException"))
                        {
                            log.Debug("searchSkuIdResult:http://chongzhi.jd.com/json/order/search_searchSkuId.action?ISP=" + ISP + "&area=" + area + "&filltype=0&faceValue=" + facePrice);
                            searchSkuIdResult = Share.getPage("http://chongzhi.jd.com/json/order/search_searchSkuId.action", "ISP=" + ISP + "&area=" + area + "&filltype=0&faceValue=" + facePrice, "");
                            log.Debug("searchSkuIdResult:" + searchSkuIdResult);
                        }
                        JObject searchSkuIdResultJson = (JObject)JsonConvert.DeserializeObject(searchSkuIdResult);
                        String skuId = searchSkuIdResultJson["skuId"].ToString();
                        log.Debug("jdPrice:http://chongzhi.jd.com/json/order/searchp_searchJdPrice.action?skuId=" + skuId);
                        String jdPrice = Share.getPage("http://chongzhi.jd.com/json/order/searchp_searchJdPrice.action", "skuId=" + skuId, "").Trim().Replace("\"", "");
                        log.Debug("jdPrice:" + jdPrice);
                        if (String.IsNullOrEmpty(jdPrice) || jdPrice.Contains("System.Net.WebException") || jdPrice.Length > 100)
                        {
                            log.Debug("jdPrice:http://chongzhi.jd.com/json/order/searchp_searchJdPrice.action?skuId=" + skuId);
                            jdPrice = Share.getPage("http://chongzhi.jd.com/json/order/searchp_searchJdPrice.action", "skuId=" + skuId, "").Trim().Replace("\"", "");
                            log.Debug("jdPrice:" + jdPrice);
                        }
                        log.Debug("获取到京东价格:" + jdPrice + ",区域ID:" + area + ",产品ID:" + skuId + ",开始匹配优惠券...");
                        View.write("获取到京东价格:" + ((jdPrice.Length > 100) ? "异常" : jdPrice) + ",区域ID:" + area + ",产品ID:" + skuId + ",开始匹配优惠券...");
                        log.Debug("youHuiQuanJson:http://chongzhi.jd.com/json/order/searchp_searchDxqInfo.action?ISP=" + ISP + "&jdPrice=" + jdPrice);
                        String youHuiQuanJson = Share.getPage("http://chongzhi.jd.com/json/order/searchp_searchDxqInfo.action", "ISP=" + ISP + "&jdPrice=" + jdPrice, "");
                        log.Debug("youHuiQuanJson:" + youHuiQuanJson);
                        if (String.IsNullOrEmpty(youHuiQuanJson) || youHuiQuanJson.Contains("System.Net.WebException"))
                        {
                            log.Debug("youHuiQuanJson:http://chongzhi.jd.com/json/order/searchp_searchDxqInfo.action?ISP=" + ISP + "&jdPrice=" + jdPrice);
                            youHuiQuanJson = Share.getPage("http://chongzhi.jd.com/json/order/searchp_searchDxqInfo.action", "ISP=" + ISP + "&jdPrice=" + jdPrice, "");
                            log.Debug("youHuiQuanJson:" + youHuiQuanJson);
                        }
                        String dxqidsStr = getdxqidsString(youHuiQuanJson, jdPrice);

                        if (!String.IsNullOrEmpty(dxqidsStr))
                        {
                            log.Debug("查找到过期最快的优惠券 dxqidsStr:" + dxqidsStr + ",开始验证是否可以提交充值等信息...");
                            View.write("查找到过期最快的优惠券 dxqidsStr:" + dxqidsStr + ",开始验证是否可以提交充值等信息...");
                            phoneInfo.features = "优惠券编号:" + dxqidsStr;
                            log.Debug("hideKeyResult:http://chongzhi.jd.com/order/order_place.action?skuId=" + skuId + "&mobile=" + telephone + "&entry=4");
                            String hideKeyResult = Share.getPage("http://chongzhi.jd.com/order/order_place.action", "skuId=" + skuId + "&mobile=" + telephone + "&entry=4", "");
                            log.Debug("hideKeyResult:" + hideKeyResult);
                            if (String.IsNullOrEmpty(hideKeyResult) || hideKeyResult.Contains("System.Net.WebException"))
                            {
                                log.Debug("hideKeyResult:http://chongzhi.jd.com/order/order_place.action?skuId=" + skuId + "&mobile=" + telephone + "&entry=4");
                                hideKeyResult = Share.getPage("http://chongzhi.jd.com/order/order_place.action", "skuId=" + skuId + "&mobile=" + telephone + "&entry=4", "");
                                log.Debug("hideKeyResult:" + hideKeyResult);
                            }
                            String hideKey = Share.getValue("<input type=\"hidden\" id=\"hideKey\" name=\"hideKey\" value=\"", "\"/>", hideKeyResult);
                            log.Debug("checkRechargeResult:http://chongzhi.jd.com/json/order/searchp_checkRecharge.action?mobile=" + telephone + "&skuId=" + skuId);
                            String checkRechargeResult = Share.getPage("http://chongzhi.jd.com/json/order/searchp_checkRecharge.action", "mobile=" + telephone + "&skuId=" + skuId, "");
                            log.Debug("checkRechargeResult:" + checkRechargeResult);
                            if (String.IsNullOrEmpty(checkRechargeResult) || checkRechargeResult.Contains("System.Net.WebException"))
                            {
                                log.Debug("checkRechargeResult:http://chongzhi.jd.com/json/order/searchp_checkRecharge.action?mobile=" + telephone + "&skuId=" + skuId);
                                checkRechargeResult = Share.getPage("http://chongzhi.jd.com/json/order/searchp_checkRecharge.action", "mobile=" + telephone + "&skuId=" + skuId, "");
                                log.Debug("checkRechargeResult:" + checkRechargeResult);
                            }
                            JObject checkRechargeResultJson = (JObject)JsonConvert.DeserializeObject(checkRechargeResult);
                            String flag = checkRechargeResultJson["flag"].ToString().Trim().ToLower();
                            log.Debug("获取到是否可以提交充值:" + flag + ",hideKey:" + hideKey + ",开始提交充值...");
                            View.write("获取到是否可以提交充值:" + flag + ",hideKey:" + hideKey + ",开始提交充值...");
                            
                            if (flag == "true")
                            {
                                try
                                {
                                    String mobileFor = telephone.Substring(0, 3) + "+" + telephone.Substring(3, 4) + "+" + telephone.Substring(7, 4);
                                    log.Debug("submitOrderResult:http://chongzhi.jd.com/order/order_submitOrder.action?mobile=" + telephone + "&mobileFor=" + mobileFor + "&placeOrderVo.fillType=0&radiobutton=" + facePrice + dxqidsStr + "&paymentPassword=" + Config.Machine + "&skuId=" + skuId + "&entry=4&price=" + jdPrice + "&hideKey=" + hideKey + "&areaCodeU=7&rechargeTypeU=2&messageId=&initFlag=&payType=3&canUseJingdou=&usedJingdouNum=");
                                    String submitOrderResult = Share.getPage("http://chongzhi.jd.com/order/order_submitOrder.action", "mobile=" + telephone + "&mobileFor=" + mobileFor + "&placeOrderVo.fillType=0&radiobutton=" + facePrice + dxqidsStr + "&paymentPassword=" + Config.Machine + "&skuId=" + skuId + "&entry=4&price=" + jdPrice + "&hideKey=" + hideKey + "&areaCodeU=7&rechargeTypeU=2&messageId=&initFlag=&payType=3&canUseJingdou=&usedJingdouNum=", "http://chongzhi.jd.com/order/order_place.action?skuId=" + skuId + "&mobile=" + telephone + "&entry=4");
                                    log.Debug("submitOrderResult:" + submitOrderResult);
                                    if (String.IsNullOrEmpty(submitOrderResult) || submitOrderResult.Contains("System.Net.WebException"))
                                    {
                                        phoneInfo.fail_reason = "状态未知";
                                        phoneInfo.order_new_status = "3";
                                        log.Debug("状态未知,需要人工核实");
                                        View.write("状态未知,需要人工核实");
                                    }
                                    else
                                    {
                                        if (submitOrderResult.Contains("您已付款成功！正在为您充值"))
                                        {
                                            phoneInfo.order_new_status = "2";
                                            phoneInfo.fail_reason = "付款成功,正在充值";
                                            log.Debug("您已付款成功！正在为您充值,开始获取京东订单号...");
                                            View.write("您已付款成功！正在为您充值,开始获取京东订单号...");
                                            try
                                            {
                                                log.Debug("orderListResult:http://order.jd.com/center/list.action?t=37&d=0&s=4096");
                                                String orderListResult = Share.getPageOrder("http://order.jd.com/center/list.action", "t=37&d=0&s=4096", "");
                                                log.Debug("orderListResult:" + orderListResult);
                                                if (String.IsNullOrEmpty(orderListResult) || orderListResult.Contains("System.Net.WebException"))
                                                {
                                                    log.Debug("orderListResult:http://order.jd.com/center/list.action?t=37&d=0&s=4096");
                                                    orderListResult = Share.getPageOrder("http://order.jd.com/center/list.action", "t=37&d=0&s=4096", "");
                                                    log.Debug("orderListResult:" + orderListResult);
                                                }
                                                String firstOrderId = Share.getValue("<span id=\"pop_sign\" style=\"display:none;\">[{\"orderType\":37,\"orderIds\":[\"", "\"", orderListResult);
                                                log.Debug("firstOrderIdResult:http://chongzhi.jd.com/order/order_autoDetail.action?orderId=" + firstOrderId);
                                                String firstOrderIdResult = Share.getPage("http://chongzhi.jd.com/order/order_autoDetail.action", "orderId=" + firstOrderId, "");
                                                log.Debug("firstOrderIdResult:" + firstOrderIdResult);
                                                if (String.IsNullOrEmpty(firstOrderIdResult) || firstOrderIdResult.Contains("System.Net.WebException"))
                                                {
                                                    log.Debug("firstOrderIdResult:http://chongzhi.jd.com/order/order_autoDetail.action?orderId=" + firstOrderId);
                                                    firstOrderIdResult = Share.getPage("http://chongzhi.jd.com/order/order_autoDetail.action", "orderId=" + firstOrderId, "");
                                                    log.Debug("firstOrderIdResult:" + firstOrderIdResult);
                                                }
                                                String orderTelephone = Share.getValue("<li>手机号码：", "</li>", firstOrderIdResult);
                                                String orderFacePrice = Share.getValue("<li>充值面额：", "元</li>", firstOrderIdResult);
                                                String orderInTime = Share.getValue("<li>下单时间：", "</li>", firstOrderIdResult);
                                                if (float.Parse(orderFacePrice) == float.Parse(facePrice) && Share.getMacherStr(telephone, orderTelephone))
                                                {
                                                    jdOrderId = firstOrderId;
                                                    jdOrderInTime = orderInTime;
                                                    phoneInfo.vender_order_no = jdOrderId;
                                                    log.Debug("获取到京东订单号:" + jdOrderId + ",京东下单时间:" + jdOrderInTime);
                                                    View.write("获取到京东订单号:" + jdOrderId + ",京东下单时间:" + jdOrderInTime);
                                                }
                                                else
                                                {
                                                    log.Debug("获取京东订单信息失败,请人工核实!");
                                                    View.write("获取京东订单信息失败,请人工核实!");
                                                }
                                            }
                                            catch (Exception exc)
                                            {
                                                log.Debug("获取京东订单信息异常,请人工核实!" + exc);
                                                View.write("获取京东订单信息异常,请人工核实!");
                                            }
                                        }
                                        else
                                        {
                                            phoneInfo.order_new_status = "4";
                                            String failReason = Share.getValue("<div class=\"success\"><s></s>", "</h4>", submitOrderResult);
                                            phoneInfo.fail_reason = failReason;
                                            log.Debug("付款失败,失败原因:" + failReason);
                                            View.write("付款失败,失败原因:" + failReason);
                                        }
                                    }
                                }
                                catch (Exception exc)
                                {
                                    phoneInfo.fail_reason = "状态未知";
                                    phoneInfo.order_new_status = "3";
                                    log.Debug("状态未知,需要人工核实");
                                    View.write("状态未知,需要人工核实");
                                }
                            }
                            else
                            {
                                phoneInfo.order_new_status = "4";
                                phoneInfo.fail_reason = "未付款,原因:付款前检查是否可以充值返回" + checkRechargeResult + " is false";
                                log.Debug("未付款,原因:付款前检查是否可以充值返回" + checkRechargeResult + " is false");
                                View.write("未付款,原因:付款前检查是否可以充值" + checkRechargeResult + " is false");
                            }
                        }
                        else
                        {
                            phoneInfo.order_new_status = "4";
                            phoneInfo.fail_reason = "未查找到优惠券,付款失败";
                            log.Debug("未查找到优惠券,付款失败");
                            View.write("未查找到优惠券,付款失败");
                        }
                    }
                    else
                    {
                        phoneInfo.order_new_status = "4";
                        phoneInfo.fail_reason = "该行面值、号码、单号参数为空,提交失败";
                        log.Debug("该行面值、号码、单号参数为空,提交失败");
                        View.write("该行面值、号码、单号参数为空,提交失败");
                    }
                }
                catch (Exception ex)
                {
                    phoneInfo.order_new_status = "4";
                    phoneInfo.fail_reason = "程序异常提交失败";
                    log.Debug("程序异常,提交失败!" + ex);
                    View.write("异常提交失败!");
                }

                int updateCount = dao.updateOrderStatusDao(phoneInfo);
                log.Debug("updateOrderStatusDao orderId:" + phoneInfo.order_id + ",更新结果:" + updateCount);
                View.write("orderId:" + phoneInfo.order_id + ",更新结果:" + updateCount);
            }
            return phoneInfo;
        }

        public int selectCountByOrderId(OrderInfo phoneInfo)
        {
            OrderInfoDao dao = new OrderInfoDao();
            return dao.selectCountByOrderId(phoneInfo);
        }

        public List<OrderInfo> statusNotify(MainForm mainForm)
        {
            OrderInfoDao dao = new OrderInfoDao();
            List<OrderInfo> orderInfoList = dao.statusNotify();
            if (orderInfoList != null && orderInfoList.Count > 0)
            {
                foreach (OrderInfo orderInfo in orderInfoList)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("venderId=").Append(orderInfo.vender_id).Append("&orderId=").Append(orderInfo.order_id).Append("&venderOrderId=").Append(orderInfo.vender_order_no).Append("&orderStatus=").Append(orderInfo.order_status);
                        String sign = Share.MD5(sb.ToString() + "&key=" + Config.md5Key).ToLower();
                        log.Debug("statusNotify start:" + Config.notifyUrl + sb.ToString() + "&sign=" + sign);
                        View.write("回调通知:" + Config.notifyUrl + "?" + sb.ToString() + "&sign=" + sign);
                        String result = Share.getPageInterFace(Config.notifyUrl, sb.ToString() + "&sign=" + sign);
                        log.Debug("statusNotify result:" + result);
                        View.write("回调结果:" + result);
                        if ("success".Equals(result))
                        {
                            orderInfo.notify_status = "8";
                        }
                        else
                        {
                            if (orderInfo.notify_count >= 4)
                            {
                                orderInfo.notify_status = "4";
                            }
                        }
                       
                    }
                    catch(Exception ex)
                    {
                        if (orderInfo.notify_count >= 4)
                        {
                            orderInfo.notify_status = "4";
                        }
                    }
                    int updateCount = dao.updateNotify(orderInfo);
                    log.Debug("回调更新结果:" + updateCount);
                }
            }
            return orderInfoList;
        }

        public DataTable selectOrderList(String startTime, String endTime, string orderId, string phoneNo, int pageIndex, int pageSize)
        {
            OrderInfoDao dao = new OrderInfoDao();
            return dao.selectOrderList(startTime, endTime, orderId, phoneNo, pageIndex, pageSize);
        }

        public int totalRows(String startTime, String endTime, string orderId, string phoneNo)
        {
            OrderInfoDao dao = new OrderInfoDao();
            return dao.totalRows(startTime, endTime, orderId, phoneNo);
        }

        public String getdxqidsString(String youHuiQuanJson, String jdPrice)
        {
            String dxqidsStr = "";
            int youHuiQuanCount = 0;
            if ("98.00".Equals(jdPrice))
            {
                youHuiQuanCount=1;
            }
            else if ("196.00".Equals(jdPrice))
            {
                youHuiQuanCount=2;
            }
            else if ("294.00".Equals(jdPrice))
            {
                youHuiQuanCount=3;
            }
            else if ("490.00".Equals(jdPrice))
            {
                youHuiQuanCount=5;
            }
            JObject youHuiQuanJsonCanUseObj = (JObject)JsonConvert.DeserializeObject(youHuiQuanJson);
            String youHuiQuanJingQuanJson = youHuiQuanJsonCanUseObj["canUse"].ToString();
            JObject youHuiQuanJingQuanJsonObj = (JObject)JsonConvert.DeserializeObject(youHuiQuanJingQuanJson);
            String youHuiQuanJingQuanJsonStr = youHuiQuanJingQuanJsonObj["jingquan"].ToString();
            JArray youHuiQuanJArray = (JArray)JsonConvert.DeserializeObject(youHuiQuanJingQuanJsonStr);
            String id = "";
            int j = 0;
            if (youHuiQuanCount > 0)
            {
                for (int i = 0; i < youHuiQuanJArray.Count; i++)
                {
                    if (float.Parse(youHuiQuanJArray[i]["discount"].ToString().Trim()) == float.Parse("98.0") && youHuiQuanJArray[i]["canUse"].ToString().Trim().ToUpper() == "TRUE")
                    {
                        id = youHuiQuanJArray[i]["id"].ToString().Trim();
                        dxqidsStr = dxqidsStr + "&dxqids=" + id;
                        j++;
                        if (j == youHuiQuanCount)
                        {
                            break;
                        }
                    }
                }
            }
            if (dxqidsStr.Length >= 150)
            {
                return "";
            }
            else 
            {
                dxqidsStr = dxqidsStr + "&dxqSize=" + youHuiQuanCount;
            }
            return dxqidsStr;
        }

        internal List<OrderInfo> queryOrderStatus(MainForm mainForm)
        {
            OrderInfoDao dao = new OrderInfoDao();
            List<OrderInfo> orderInfoList = dao.queryOrderStatus();
            if (orderInfoList != null && orderInfoList.Count > 0)
            {
                foreach (OrderInfo orderInfo in orderInfoList)
                {
                    try
                    {
                        log.Debug("orderListResult:http://chongzhi.jd.com/order/order_autoDetail.action?orderId=" + orderInfo.vender_order_no);
                        String queryOrderStatusResult = Share.getPage("http://chongzhi.jd.com/order/order_autoDetail.action", "orderId=" + orderInfo.vender_order_no, "");
                        log.Debug("queryOrderStatusResult:" + queryOrderStatusResult);
                        String orderStatus = "";
                        int updateCount = 0;
                        if (String.IsNullOrEmpty(queryOrderStatusResult) || queryOrderStatusResult.Contains("System.Net.WebException"))
                        {
                            orderStatus = "查询失败,网络异常";
                        }
                        else if (queryOrderStatusResult.IndexOf("订单号：" + orderInfo.vender_order_no) > -1 || queryOrderStatusResult.IndexOf("订单不存在") > -1)
                        {
                            orderStatus = Share.getValue("<span class=\"ftx-02\">", "</span>", queryOrderStatusResult);
                            if ("正在充值".Equals(orderStatus))
                            {
                                orderInfo.order_status = "2";
                            }
                            else
                            {
                                if ("充值成功".Equals(orderStatus))
                                {
                                    orderInfo.order_status = "8";
                                }
                                else if ("充值失败,退款成功".Equals(orderStatus) || "充值失败,退款处理中".Equals(orderStatus))
                                {
                                    orderInfo.order_status = "4";
                                }
                                else
                                {
                                    orderInfo.order_status = "3";
                                }
                                orderInfo.fail_reason = orderStatus;
                                updateCount = dao.updateOrderStatus(orderInfo);
                            }
                        }
                        else
                        {
                            orderStatus = "查询失败,请求返回异常,请尝试重新登录";
                        }
                        log.Debug("订单状态查询 orderId:" + orderInfo.order_id + "，订单状态:" + orderStatus + ",更新结果:" + updateCount);
                        View.write("订单状态查询 orderId:" + orderInfo.order_id + "，订单状态:" + orderStatus + ",更新结果:" + updateCount);
                    }
                    catch (Exception ex) 
                    {
                        log.Debug("queryOrderStatus error:" + ex);
                    }
                }
            }
            return orderInfoList;
        }
    }
}
