using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class SendForScreeningController : ApiController
    {

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public BookingDetail Post(BookingDetail objbookingDetail)
        {

            try
            {
                DataTable objdt = objHomeDAL.eBookingMyLogSend(objbookingDetail.ROID,objbookingDetail.IsClassified, objbookingDetail.UserId).Tables[0];
                if (objdt.Rows.Count > 0)
                {
                    objbookingDetail.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                    objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                }
            }
            catch (Exception ex)
            {
            }
            return objbookingDetail;
        }

    }
}
