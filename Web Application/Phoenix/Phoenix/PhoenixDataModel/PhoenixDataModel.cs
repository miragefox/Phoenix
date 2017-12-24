using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Phoniex.dbaccess;

namespace Phoenix.PhoenixDataModel
{
    public class RequestModel
    {
        private const string GetRequestFromDb = "SELECT RE.RequestTitle,RE.RequestDetail,RE.Comments,RE.RequestStatus FROM REQUEST RE WHERE RE.REQUESTID = '{0}'";
        private const string UpdateRequestToDb = "UPDATE REQUEST SET RequestStatus={0},Comments = '{1}' WHERE REQUESTID = '{2}'";
        private const string GetRequestListToDb = "select RequestId,RequestTitle,RequestStatus from Request order by EditDttm desc";
        private const string InsertRequest = "insert into Request(RequestId,RequestTitle,RequestDetail,Comments,RequestStatus,EditDttm) values('{0}','{1}','{2}','',{3},'{4}')";
        public static bool AddRequest(Request request)
        {
            var sqlBaseBuilder = new StringBuilder(InsertRequest);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), request.RequestId, request.RequestTitle, request.RequestDetail, request.RequestStatus, DateTime.Now);
            //no use of this return value
            var updateOk = DBHelper.ExecuteNonQuery(sqlStr);
            return updateOk;
        }

        public List<Request> GetAllRequest()
        {
            var requestList = new List<Request>();

            var sqlBaseBuilder = new StringBuilder(GetRequestListToDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString());

            var table = DBHelper.GetRecords(sqlStr);

            //list

            return requestList;
        }

        public static Request FindRequestById(string requestId)
        {
            var sqlBaseBuilder = new StringBuilder(GetRequestFromDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), requestId);

            var request = DBHelper.ExecuteScalar(sqlStr);

            return request;
        }

        public static bool UpdateRequest(Request request)
        {
            var sqlBaseBuilder = new StringBuilder(UpdateRequestToDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), request.RequestStatus, request.Comments, request.RequestId);
            //no use of this return value
            var updateOk = DBHelper.ExecuteNonQuery(sqlStr);
            return updateOk;
        }

    }
    public class Request
    {
        public string RequestId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDetail { get; set; }
        public string Comments { get; set; }
        public int RequestStatus { get; set; }
        public DateTime EditTime { get; set; }
    }
}