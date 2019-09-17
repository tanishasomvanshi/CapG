using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exception;

namespace Inventory.DataAccessLayer
{
    public class RawMaterialDAL
    {
        public static List<RawMaterial> rawMaterialList = new List<RawMaterial>();

        public bool AddRawMaterialDAL(RawMaterial newRawMaterial)
        {
            bool rawMaterialAdded = false;
            try
            {
                rawMaterialList.Add(newRawMaterial);
                rawMaterialAdded = true;
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialAdded;

        }

        public List<RawMaterial> GetAllRawMaterialsDAL()
        {
            return rawMaterialList;
        }

        public RawMaterial SearchRawMaterialDAL(int searchRawMaterialID)
        {
            RawMaterial searchRawMaterial = null;
            try
            {
                searchRawMaterial = rawMaterialList.Find(item => item.RawMaterialID == searchRawMaterialID);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterial;
        }

        public List<RawMaterial> GetRawMaterialByNameDAL(string rawMaterialName)
        {
            List<RawMaterial> searchRawMaterial = new List<RawMaterial>();
            try
            {
                foreach (RawMaterial item in rawMaterialList)
                {
                    if (item.RawMaterialName == rawMaterialName)
                    {
                        searchRawMaterial.Add(item);
                    }
                }
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterial;
        }

        public bool UpdateRawMaterialDAL(RawMaterial updateRawMaterial)
        {
            bool rawMaterialUpdated = false;
            try
            {
                for (int i = 0; i < rawMaterialList.Count; i++)
                {
                    if (rawMaterialList[i].RawMaterialID == updateRawMaterial.RawMaterialID)
                    {
                        updateRawMaterial.RawMaterialName = rawMaterialList[i].RawMaterialName;
                        updateRawMaterial.RawMaterialUnitPrice = rawMaterialList[i].RawMaterialUnitPrice;
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

        public bool DeleteRawMaterialDAL(int deleteRawMaterialID)
        {
            bool rawMaterialDeleted = false;
            try
            {
                RawMaterial deleteRawMaterial = null;

                if (deleteRawMaterial != null)
                {
                    rawMaterialList.Remove(deleteRawMaterial);
                    rawMaterialDeleted = true;
                }
            }
            catch (InventoryException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialDeleted;

        }

    }
}