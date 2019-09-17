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
    public class RawMaterialOrderBL
    {
        public double CalcTotalAmount(List<RawMaterialOrderDetails> rawMaterialOrderDetails)
        {
            double totalAmount = 0;
            try
            {
                foreach (RawMaterialOrderDetails item in rawMaterialOrderDetails)
                {
                    totalAmount += CalcTotalAmount(rawMaterialOrderDetails);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            return totalAmount;
        }
        private static bool ValidateRawMaterialOrder(RawMaterialOrder rawMaterialOrder)
        {
            StringBuilder sb = new StringBuilder();
            bool validRawMaterialOrder = true;
            if (rawMaterialOrder.RawMaterialOrderID == 0 || rawMaterialOrder.RawMaterialOrderID > 99999)
            {
                validRawMaterialOrder = false;
                sb.Append("\nInvalid Raw Material OrderID");
            }
            if (rawMaterialOrder.TotalAmount <= 0)
            {
                validRawMaterialOrder = false;
                sb.Append("\nInvalid Total");
            }
            if (validRawMaterialOrder == false)
            {
                throw new InventoryException(sb.ToString());
            }
            return validRawMaterialOrder;
        }

        public static bool AddRawMaterialOrderBL(RawMaterialOrder newRawMaterialOrder)
        {
            bool rawMaterialOrderAdded = false;
            try
            {
                if (ValidateRawMaterialOrder(newRawMaterialOrder))
                {
                    RawMaterialOrderDAL rawMaterialDAL = new RawMaterialOrderDAL();
                    rawMaterialOrderAdded = rawMaterialDAL.AddRawMaterialOrderDAL(newRawMaterialOrder);
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
            return rawMaterialOrderAdded;
        }

        public static bool DeleteRawMaterialOrderBL(int deleteRawMaterialOrderID)
        {
            bool rawMaterialOrderDeleted = false;
            try
            {
                if (deleteRawMaterialOrderID > 0 && deleteRawMaterialOrderID < 99999)
                {
                    RawMaterialOrderDAL rawMaterialOrderDAL = new RawMaterialOrderDAL();
                    rawMaterialOrderDeleted = rawMaterialOrderDAL.DeleteRawMaterialOrderDAL(deleteRawMaterialOrderID);
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
            return rawMaterialOrderDeleted;
        }

        public static List<RawMaterialOrder> GetAllRawMaterialOrdersBL()
        {
            List<RawMaterialOrder> rawMaterialOrderList = null;
            try
            {
                RawMaterialOrderDAL rawMaterialOrderDAL = new RawMaterialOrderDAL();
                rawMaterialOrderList = rawMaterialOrderDAL.GetAllRawMaterialOrdersDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            return rawMaterialOrderList;
        }

        public static RawMaterialOrder SearchRawMaterialOrderByIDBL(int searchRawMaterialOrderID)
        {
            RawMaterialOrder searchRawMaterialOrder = null;
            try
            {
                RawMaterialOrderDAL rawMaterialOrderDAL = new RawMaterialOrderDAL();
                searchRawMaterialOrder = rawMaterialOrderDAL.SearchRawMaterialOrderDAL(searchRawMaterialOrderID);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            return searchRawMaterialOrder;
        }
    }
}
