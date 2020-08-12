using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetPrintReportDataController : ApiController
    {

        public IEnumerable<PrintReceipt> Post(BookingDetail objbookingDetail)
        {
            Dictionary<string, object> OrderDetails = new Dictionary<string, object>();
            List<PrintReceipt> objListPrintReceipt = new List<PrintReceipt>();
            PrintReceipt objPrintReceipt;
            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string strXml = string.Empty;
                strXml += "<ebooking><actionname>printreceipt</actionname><receiptid>" + objbookingDetail.ReceiptID + "</receiptid></ebooking>";
                DataTable objdt = objHomeDAL.eBookingActions(strXml).Tables[0];

                if (objdt.Rows.Count > 0)
                {

                    //objOpenOder.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    //if (objOpenOder.IsValid == 1)
                    //{
                    //    objOpenOder.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                    //    objOpenOder.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    //    objListOpenOrder.Add(objOpenOder);
                    //    OrderDetails.Add("OpenOrder", objListOpenOrder);
                    //}
                    //else
                    //{
                    foreach (DataRow dr in objdt.Rows)
                    {
                        objPrintReceipt = new PrintReceipt();
                        objPrintReceipt.OrderReceiptNo = Convert.ToString(dr["OrderReceiptNo"]);
                        objPrintReceipt.ClientName = Convert.ToString(dr["ClientName"]);
                        objPrintReceipt.Address = Convert.ToString(dr["Address"]);
                        objPrintReceipt.City = Convert.ToString(dr["City"]);
                        objPrintReceipt.Phone = Convert.ToString(dr["Phone"]);
                        objPrintReceipt.Zip = Convert.ToString(dr["Zip"]);
                        objPrintReceipt.BookedBy = Convert.ToString(dr["BookedBy"]);
                        objPrintReceipt.BookedBy = Convert.ToString(dr["BookedBy"]);
                        objPrintReceipt.REVISION_NUMBER = Convert.ToString(dr["REVISION_NUMBER"]);	
                        objPrintReceipt.IsClassified = Convert.ToString(dr["isClassified"]);
                        objPrintReceipt.VATNumber = Convert.ToString(dr["VATNumber"]);
                        objPrintReceipt.Premia = Convert.ToString(dr["Premia"]);
                        objPrintReceipt.Size = Convert.ToString(dr["Size"]);
                        objPrintReceipt.Publication = Convert.ToString(dr["Publication"]);
                        objPrintReceipt.AdTypeName = Convert.ToString(dr["AdTypeName"]);
                        objPrintReceipt.Pubdate = Convert.ToString(dr["Pubdate"]);
                        objPrintReceipt.Cost = Convert.ToString(dr["Cost"]);
                        objPrintReceipt.VatAmount = Convert.ToString(dr["VatAmount"]);
                        objPrintReceipt.Total = Convert.ToString(dr["Total"]);
                        objPrintReceipt.Date = Convert.ToString(dr["Date"]);
                        objPrintReceipt.AgencyName = Convert.ToString(dr["AgencyName"]);
                        objPrintReceipt.AgencyCode = Convert.ToString(dr["AgencyCode"]);
                        objPrintReceipt.Category1 = Convert.ToString(dr["Category1"]);
                        objPrintReceipt.Category2 = Convert.ToString(dr["Category2"]);
                        objPrintReceipt.Material = Convert.ToString(dr["Material"]);
                        objListPrintReceipt.Add(objPrintReceipt);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ReportError("PrintReceiptController::Post:", ex);
            }
            return objListPrintReceipt;
        }

    }
}
