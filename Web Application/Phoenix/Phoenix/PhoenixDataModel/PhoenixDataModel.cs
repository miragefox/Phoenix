using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Phoniex.dbaccess;
using System.Data;
using static Phoenix.RequestStatus;

namespace Phoenix.PhoenixDataModel
{
    public class RequestModel
    {
        private const string GetRequestById = "SELECT RE.RequestId,RE.RequestTitle,RE.RequestStatus,RE.RequestDetail,RE.Comments,RE.CreateDate,RE.DueDate,RE.ActionSource,RE.BusinessCode,RE.EditDttm FROM REQUEST RE WHERE RE.REQUESTID = '{0}'";
        private const string UpdateRequestToDb = "UPDATE REQUEST SET RequestStatus={0},Comments = '{1}',EditDttm = '{2}' WHERE REQUESTID = '{3}'";
        private const string GetRequestListFromDb = "SELECT RequestId,RequestTitle,RequestStatus,RequestDetail,Comments,CreateDate,DueDate,ActionSource,BusinessCode,EditDttm from Request order by EditDttm desc";
        private const string InsertRequest = "INSERT INTO Request(RequestId,RequestTitle,RequestDetail,Comments,RequestStatus,EditDttm,Priority) VALUES('{0}','{1}','{2}','',{3},'{4}',{5},'{6}','{7}','{8}','{9}')";
        public bool AddRequest(Request request)
        {
            var sqlBaseBuilder = new StringBuilder(InsertRequest);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), request.RequestId, request.RequestTitle, request.RequestDetail, (int)request.RequestStatus, DateTime.Now, request.Priority, DateTime.Now, request.DueDate, request.ActionSource, request.ActionSource);
            var addOk = DBHelper.ExecuteNonQuery(sqlStr);
            return addOk > 0;
        }

        public List<Request> GetAllRequest()
        {
            var requestList = new List<Request>();

            var table = DBHelper.GetRecords(GetRequestListFromDb);

            foreach (DataRow row in table.Rows)
            {
                var request = GenerateRequest(row);
                requestList.Add(request);
            }
            return requestList;
        }

        public Request FindRequestById(string requestId)
        {
            var sqlBaseBuilder = new StringBuilder(GetRequestById);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), requestId);

            var table = DBHelper.GetRecords(sqlStr);
            if (table.Rows.Count > 0)
            {
                var request = GenerateRequest(table.Rows[0]);
                return request;
            }
            return null;
        }

        public bool UpdateRequest(Request request)
        {
            var sqlBaseBuilder = new StringBuilder(UpdateRequestToDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), (int)request.RequestStatus, request.Comments, DateTime.Now, request.RequestId);
            var updateOk = DBHelper.ExecuteNonQuery(sqlStr);
            return updateOk > 0;
        }
        public Request GenerateRequest(DataRow dataRow)
        {
            Request request = new Request();
            request.RequestId = dataRow[0].ToString();
            request.RequestTitle = dataRow[1].ToString();
            request.RequestStatus = (RequestStatusDetail)Enum.ToObject(typeof(RequestStatusDetail), Convert.ToUInt32(dataRow[2]));
            request.RequestDetail = dataRow[3].ToString();
            request.Comments = dataRow[4].ToString();
            request.CreateDate = Convert.ToDateTime(dataRow[5]);
            request.DueDate = Convert.ToDateTime(dataRow[6]);
            request.ActionSource = dataRow[7].ToString();
            request.BusinessCode = dataRow[8].ToString();
            request.EditDttm = Convert.ToDateTime(dataRow[9]);

            return request;
        }

    }
    public class Request
    {
        public string RequestId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDetail { get; set; }
        public string Comments { get; set; }
        public RequestStatusDetail RequestStatus { get; set; }
        public DateTime EditDttm { get; set; }
        public int Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ActionSource { get; set; }
        public string BusinessCode { get; set; }

    }
}