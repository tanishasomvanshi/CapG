using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exception;

namespace Inventory.DataAccessLayer
{
    public class RawMaterialOrderDetailsDAL
    {
        public static List<RawMaterialOrderDetails> rawMaterialOrderDetailsList = new List<RawMaterialOrderDetails>();

        public bool AddRawMaterialorderDetailsDAL(RawMaterialOrderDetails newRawMaterialOrderDetails)
        {
            bool rawMaterialOrderDetailsAdded = false;
            try
            {
                rawMaterialOrderDetailsList.Add(newRawMaterialOrderDetails);
                rawMaterialOrderDetailsAdded = true;
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialOrderDetailsAdded;

        }

        public RawMaterialOrderDetails SearchRawMaterialOrderDetailDAL(int searchRawMaterialID)
        {
            RawMaterialOrderDetails searchRawMaterialOrderDetail = null;
            try
            {
                searchRawMaterialOrderDetail = rawMaterialOrderDetailsList.Find(item => item.RawMaterialID == searchRawMaterialID);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterialOrderDetail;
        }

        public List<RawMaterialOrderDetails> GetAllRawMaterialOrderDetailsDAL()
        {
            return rawMaterialOrderDetailsList;
        }

        public bool UpdateRawMaterialOrderDetailsDAL(RawMaterialOrderDetails updateRawMaterialOrderDetails)
        {
            bool rawMaterialUpdated = false;
            try
            {
                for (int i = 0; i < rawMaterialOrderDetailsList.Count; i++)
                {
                    if (rawMaterialOrderDetailsList[i].RawMaterialID == updateRawMaterialOrderDetails.RawMaterialID)
                    {
                        rawMaterialOrderDetailsList[i].RawMaterialOrderQuantity = updateRawMaterialOrderDetails.RawMaterialOrderQuantity;
                        rawMaterialOrderDetailsList[i].RawMaterialUnitPrice = updateRawMaterialOrderDetails.RawMaterialUnitPrice;
                        rawMaterialUpdated = true;
                    }
                }
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialUpdated;

        }

        public bool DeleteRawMaterialOrderDetailsDAL(RawMaterialOrderDetails deleterawMaterialOrderDetails)
        {
            bool rawMaterialOrderDetailsDeleted = false;
            try
            {
                RawMaterialOrderDetails deleteRawMaterialOrderDetails = null;

                if (deleteRawMaterialOrderDetails != null)
                {
                    rawMaterialOrderDetailsList.Remove(deleterawMaterialOrderDetails);
                    rawMaterialOrderDetailsDeleted = true;
                }
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialOrderDetailsDeleted;

        }

    }
}