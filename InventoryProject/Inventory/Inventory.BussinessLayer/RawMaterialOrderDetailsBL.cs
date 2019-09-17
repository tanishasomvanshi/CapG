using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.DataAccessLayer;
using System.Text.RegularExpressions;
using Inventory.Exception;

namespace Inventory.BusinessLayer
{
    public class RawMaterialOrderDetailsBL
    {
        public double CalcAmount(RawMaterialOrderDetails rawMaterialOrderDetails)
        {
            double amount = 0;
            try
            {
                amount = rawMaterialOrderDetails.RawMaterialOrderQuantity * rawMaterialOrderDetails.RawMaterialUnitPrice;
            }
            catch (InventoryException)
            {
                throw;
            }
            return amount;
        }
        private static bool ValidateRawMaterialOrderDetails(RawMaterialOrderDetails rawMaterialOrderDetail)
        {
            bool validRawMaterialOrderDetails = true;
            try
            {
                StringBuilder sb = new StringBuilder();

                if (rawMaterialOrderDetail.RawMaterialID == 0 || rawMaterialOrderDetail.RawMaterialID > 99999)
                {
                    validRawMaterialOrderDetails = false;
                    sb.Append("\nInvalid Raw Material OrderID");
                }
                if (rawMaterialOrderDetail.RawMaterialOrderQuantity <= 0)
                {
                    validRawMaterialOrderDetails = false;
                    sb.Append("\nInvalid Quantity");
                }
                if (rawMaterialOrderDetail.RawMaterialUnitPrice <= 0)
                {
                    validRawMaterialOrderDetails = false;
                    sb.Append("\nInvalid Unit Price");
                }
                if (validRawMaterialOrderDetails == false)
                {
                    throw new InventoryException(sb.ToString());
                }
            }
            catch (InventoryException)
            {
                throw;
            }

            return validRawMaterialOrderDetails;
        }

        public static bool AddRawMaterialOrderDetailBL(RawMaterialOrderDetails newRawMaterialOrderDetail)
        {
            bool rawMaterialOrderDetailAdded = false;
            try
            {
                if (ValidateRawMaterialOrderDetails(newRawMaterialOrderDetail))
                {
                    RawMaterialOrderDetailsDAL rawMaterialDAL = new RawMaterialOrderDetailsDAL();
                    rawMaterialOrderDetailAdded = rawMaterialDAL.AddRawMaterialorderDetailsDAL(newRawMaterialOrderDetail);
                }
                else
                {
                    throw new InventoryException("Invalid Order Material Details");
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            return rawMaterialOrderDetailAdded;
        }

        public static bool DeleteRawMaterialOrderDetailBL(RawMaterialOrderDetails deleteRawMaterialOrderDetails)
        {
            bool rawMaterialOrderDetailDeleted = false;
            try
            {
                if (deleteRawMaterialOrderDetails.RawMaterialID > 0 && deleteRawMaterialOrderDetails.RawMaterialID < 99999)
                {
                    RawMaterialOrderDetailsDAL rawMaterialOrderDetailsDAL = new RawMaterialOrderDetailsDAL();
                    rawMaterialOrderDetailDeleted = rawMaterialOrderDetailsDAL.DeleteRawMaterialOrderDetailsDAL(deleteRawMaterialOrderDetails);
                }
                else
                {
                    throw new InventoryException("Invalid Order ID");
                }

            }
            catch (InventoryException)
            {
                throw;
            }
            return rawMaterialOrderDetailDeleted;
        }

        public static List<RawMaterialOrderDetails> GetAllRawMaterialOrderDetailssBL()
        {
            List<RawMaterialOrderDetails> rawMaterialOrderDetailsList = null;
            try
            {
                RawMaterialOrderDetailsDAL rawMaterialOrderDetailsDAL = new RawMaterialOrderDetailsDAL();
                rawMaterialOrderDetailsList = rawMaterialOrderDetailsDAL.GetAllRawMaterialOrderDetailsDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            return rawMaterialOrderDetailsList;
        }

        public static RawMaterialOrderDetails SearchRawMaterialOrderDetailsByIDBL(int searchRawMaterialID)
        {
            RawMaterialOrderDetails searchRawMaterialOrderDetail = null;
            try
            {
                RawMaterialOrderDetailsDAL rawMaterialOrderDetailsDAL = new RawMaterialOrderDetailsDAL();
                searchRawMaterialOrderDetail = rawMaterialOrderDetailsDAL.SearchRawMaterialOrderDetailDAL(searchRawMaterialID);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            return searchRawMaterialOrderDetail;
        }
    }
}
