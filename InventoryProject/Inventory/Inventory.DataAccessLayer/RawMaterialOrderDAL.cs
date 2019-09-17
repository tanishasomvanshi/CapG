using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exception;

namespace Inventory.DataAccessLayer
{
    public class RawMaterialOrderDAL
    {
        public static List<RawMaterialOrder> rawMaterialOrderList = new List<RawMaterialOrder>();

        public bool AddRawMaterialOrderDAL(RawMaterialOrder newRawMaterialOrder)
        {
            bool rawMaterialOrderAdded = false;
            try
            {
                rawMaterialOrderList.Add(newRawMaterialOrder);
                rawMaterialOrderAdded = true;
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialOrderAdded;

        }

        public List<RawMaterialOrder> GetAllRawMaterialOrdersDAL()
        {
            return rawMaterialOrderList;
        }

        public RawMaterialOrder SearchRawMaterialOrderDAL(int searchRawMaterialOrderID)
        {
            RawMaterialOrder searchRawMaterialOrder = null;
            try
            {
                searchRawMaterialOrder = rawMaterialOrderList.Find(item => item.RawMaterialOrderID == searchRawMaterialOrderID);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterialOrder;
        }

        public bool UpdateRawMaterialOrderDAL(RawMaterialOrderDetails updateRawMaterialOrderDetail)
        {
            bool rawMaterialOrderUpdated = false;
            try
            {

            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialOrderUpdated;

        }

        public bool DeleteRawMaterialOrderDAL(int deleteRawMaterialOrderID)
        {
            bool rawMaterialOrderDeleted = false;
            try
            {
                RawMaterialOrder deleteRawMaterialOrder = null;

                if (deleteRawMaterialOrder != null)
                {
                    rawMaterialOrderList.Remove(deleteRawMaterialOrder);
                    rawMaterialOrderDeleted = true;
                }
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialOrderDeleted;

        }

    }
}