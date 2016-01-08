using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace AutoSend.Dao
{
    class OrderInfoDao
    {
        Log log = new Log();
        public int insertOrderDao(OrderInfo phoneInfo)
        {
            //插入记录
            String sql = "insert into cz_order (vender_id,order_id,face_price,phone_no,provider,province_code,city_code,state,order_status,created,notify_count,notify_status) values ("
                + phoneInfo.vender_id + "," + phoneInfo.order_id + "," + phoneInfo.face_price + "," + phoneInfo.phone_no + "," + phoneInfo.provider + "," + phoneInfo.province_code + "," + phoneInfo.city_code + ",1," + phoneInfo.order_status + ",datetime('now'),0,0)";
            try
            {
                return SqliteHelper.ExecuteSql(sql);
            }
            catch(Exception ex)
            {
                log.Debug("insertOrderDao error"+ ex);
                return 0;
            }
        }

        public OrderInfo getSubmitOrderDao()
        {
            String sql = "select * from cz_order where state=1 and vender_id=" + Config.venderId + "  and order_status=0 order by created DESC limit 0,1";
            try
            {
                DataTable dt = SqliteHelper.ExecDataSet(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    OrderInfo phoneInfo = new OrderInfo();
                    phoneInfo.vender_id = dt.Rows[0]["vender_id"].ToString();
                    phoneInfo.order_id = dt.Rows[0]["order_id"].ToString();
                    phoneInfo.phone_no = dt.Rows[0]["phone_no"].ToString();
                    phoneInfo.provider = dt.Rows[0]["provider"].ToString();
                    phoneInfo.province_code = dt.Rows[0]["province_code"].ToString();
                    phoneInfo.face_price = dt.Rows[0]["face_price"].ToString();
                    phoneInfo.order_status = dt.Rows[0]["order_status"].ToString();
                    phoneInfo.features = dt.Rows[0]["features"].ToString();

                    String updateSql = "update cz_order set order_status =1 where state=1 and vender_id=" + Config.venderId + " and order_status=" + phoneInfo.order_status + " and order_id=" + phoneInfo.order_id;
                    int updateCount = SqliteHelper.ExecuteSql(updateSql);
                    if (updateCount > 0)
                    {
                        phoneInfo.order_status = "1";
                        return phoneInfo;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Debug("getSubmitOrderDao error" + ex);
                return null;
            }
        }

        public int updateOrderStatusDao(OrderInfo phoneInfo)
        {
            String sql = "";
            if (phoneInfo.vender_order_no == null || "".Equals(phoneInfo.vender_order_no))
            {
                sql = "update cz_order set order_status =" + phoneInfo.order_new_status + ",fail_reason='" + phoneInfo.fail_reason + ",features='" + phoneInfo.features + "',submit_recharge_time=datetime('now') where state=1 and vender_id=" + Config.venderId + " and order_status=" + phoneInfo.order_status + " and order_id=" + phoneInfo.order_id;
            }
            else
            {
                sql = "update cz_order set order_status =" + phoneInfo.order_new_status + ",vender_order_no='" + phoneInfo.vender_order_no + "',fail_reason='" + phoneInfo.fail_reason + ",features='" + phoneInfo.features + "',submit_recharge_time=datetime('now') where state=1 and vender_id=" + Config.venderId + " and order_status=" + phoneInfo.order_status + " and order_id=" + phoneInfo.order_id;
            }
            try
            {
                return SqliteHelper.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                log.Debug("updateOrderStatusDao error" + ex);
                return 0;
            }
        }


        public int selectCountByOrderId(OrderInfo phoneInfo)
        {
            String sql = "select count(*) from cz_order where order_id =" + phoneInfo.order_id;
            try
            {
                return SqliteHelper.ExecuteScalar(sql);
            }
            catch (Exception ex)
            {
                log.Debug("selectCountByOrderId error" + ex);
                return 0;
            }
        }

        public List<OrderInfo> statusNotify()
        {
            String sql = "select * from cz_order where state=1 and vender_id=" + Config.venderId + " and order_status in(4,8) and notify_count<=4 and notify_status=0 order by notify_time DESC";
            try
            {
                List<OrderInfo> phoneInfoList = new List<OrderInfo>();
                DataTable dt = SqliteHelper.ExecDataSet(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        OrderInfo phoneInfo = new OrderInfo();
                        phoneInfo.vender_id = dataRow["vender_id"].ToString();
                        phoneInfo.order_id = dataRow["order_id"].ToString();
                        phoneInfo.phone_no = dataRow["phone_no"].ToString();
                        phoneInfo.provider = dataRow["provider"].ToString();
                        phoneInfo.province_code = dataRow["province_code"].ToString();
                        phoneInfo.face_price = dataRow["face_price"].ToString();
                        phoneInfo.features = dataRow["features"].ToString();
                        phoneInfo.order_status = dataRow["order_status"].ToString();
                        phoneInfo.notify_status = dataRow["notify_status"].ToString();
                        phoneInfo.notify_count = Convert.ToInt32(dataRow["notify_count"].ToString());
                        phoneInfo.vender_order_no = dataRow["vender_order_no"].ToString();
                        phoneInfoList.Add(phoneInfo);
                    }
                    return phoneInfoList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Debug("statusNotify error" + ex);
                return null;
            }
        }

        public int updateNotify(OrderInfo orderInfo)
        {
            String sql = "update cz_order set notify_status=" + orderInfo.notify_status + ",notify_count=notify_count+1,notify_time=datetime('now') where state=1 and vender_id=" + Config.venderId + " and order_id=" + orderInfo.order_id;
            try
            {
                return SqliteHelper.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                log.Debug("updateNotify error" + ex);
                return 0;
            }
        }

        public DataTable selectOrderList(String startTime, String endTime, string orderId, string phoneNo, int pageIndex, int pageSize)
        {
            String sql = "select order_id,vender_id,vender_order_no,phone_no,face_price,provider,province_code,city_code,submit_recharge_time,features,case when notify_status=4 then '通知失败' when notify_status=8 then '通知成功' when notify_status=0 then '通知中' end as notify_status,notify_count,notify_time,created,fail_reason, case when order_status=2 then '提交成功' when order_status=4 then '充值失败' when order_status=8 then '充值成功' when order_status=3 then '人工核实' when order_status=0 then '等待充值' end as order_status from cz_order where state=1 and vender_id=" + Config.venderId;
            if (startTime != null)
            {
                sql += " and created > '" + startTime + "'";
            }
            if (endTime != null)
            {
                sql += " and created < '" + endTime + "'";
            }
            if (orderId != null && !"".Equals(orderId))
            {
                sql += " and order_id =" + orderId;
            }
            if (phoneNo != null && !"".Equals(phoneNo))
            {
                sql += " and phone_no =" + phoneNo;
            }
            sql += " order by created DESC limit " + pageSize + " offset " + (pageIndex-1) * pageSize;
            try
            {
                return SqliteHelper.ExecDataSet(sql);
            }
            catch (Exception ex)
            {
                log.Debug("selectOrderList error" + ex);
                return null;
            }
        }

        public int totalRows(string startTime, string endTime, string orderId, string phoneNo)
        {
            String sql = "select count(*) from cz_order where state=1 and vender_id=" + Config.venderId;
            if (startTime != null)
            {
                sql += " and created > '" + startTime + "'";
            }
            if (endTime != null)
            {
                sql += " and created < '" + endTime + "'";
            }
            if (orderId != null && !"".Equals(orderId))
            {
                sql += " and order_id =" + orderId;
            }
            if (phoneNo != null && !"".Equals(phoneNo))
            {
                sql += " and phone_no =" + phoneNo;
            }
            sql += " order by created DESC";
            try
            {
                return SqliteHelper.ExecuteScalar(sql);
            }
            catch (Exception ex)
            {
                log.Debug("totalRows error" + ex);
                return 0;
            }
        }

        internal List<OrderInfo> queryOrderStatus()
        {
            String sql = "select * from cz_order where state=1 and vender_id=" + Config.venderId + " and order_status=2 order by created DESC";
            try
            {
                List<OrderInfo> phoneInfoList = new List<OrderInfo>();
                DataTable dt = SqliteHelper.ExecDataSet(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        OrderInfo phoneInfo = new OrderInfo();
                        phoneInfo.vender_id = dataRow["vender_id"].ToString();
                        phoneInfo.order_id = dataRow["order_id"].ToString();
                        phoneInfo.phone_no = dataRow["phone_no"].ToString();
                        phoneInfo.provider = dataRow["provider"].ToString();
                        phoneInfo.province_code = dataRow["province_code"].ToString();
                        phoneInfo.face_price = dataRow["face_price"].ToString();
                        phoneInfo.features = dataRow["features"].ToString();
                        phoneInfo.order_status = dataRow["order_status"].ToString();
                        phoneInfo.fail_reason = dataRow["fail_reason"].ToString();
                        phoneInfo.vender_order_no = dataRow["vender_order_no"].ToString();
                        phoneInfoList.Add(phoneInfo);
                    }
                    return phoneInfoList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Debug("queryOrderStatus error" + ex);
                return null;
            }
        }

        internal int updateOrderStatus(OrderInfo orderInfo)
        {
              try
            {
                String sql = "update cz_order set order_status =" + orderInfo.order_status + ",fail_reason='" + orderInfo.fail_reason + "' where state=1 and vender_id=" + Config.venderId + " and order_status=2 and order_id=" + orderInfo.order_id;
                return SqliteHelper.ExecuteSql(sql);
            }
              catch (Exception ex)
              {
                  log.Debug("updateOrderStatus error" + ex);
                  return 0;
              }
        }
    }
}