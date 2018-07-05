using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTModels.Models;
using DTValueObjects;

namespace DTBLL.Controllers
{
    public class ItemDTcontroller:BaseItem<vItems>
    {
        private ItemModel it = new ItemModel();
        public override List<vItems> GetAll()
        {
            return it.GetAll();
        }
        public override List<vItems> GetbyPaging(int pageIndex, int pageSize)
        {
            return it.GetbyPaging(pageIndex, pageSize);
        }

        public vItems GetbyId(Guid Item)
        {
            return it.GetbyId(Item);
        }
        public override bool Insert(vItems Item)
        {
            return it.Insert(Item);
        }
        public override bool Update(vItems Item)
        {
            return it.Update(Item);
        }
        public override bool Delete(vItems Item)
        {
            return it.Delete(Item);
        }

        public List<vItems> getItemsNotFinish()
        {
            return it.getItemsNotFinish();
        }
    }
}
