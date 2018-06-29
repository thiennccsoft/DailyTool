using System;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseModels;
using DTValueObjects;
using DTModels.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DTModels.Models
{
    public class ItemModel:BaseItem<vItems>
    {
        public override List<vItems> GetAll()
        {
            List<vItems> listI = new List<vItems>();
            var listitem = db.Items;
            foreach (var item in listitem)
            {
                vItems it = new vItems();
                it = changetovItem(item);

                listI.Add(it);
            }
            return listI;
        }
        public override List<vItems> GetbyPaging(int pageIndex, int pageSize)
        {
            int rc = 0;
            var listItem = from t in (db.Items.OrderBy(x => x.Created_At).Distinct().ToList())
                           select new
                           {
                               RowNumber = ++rc,
                               t.ItemId,
                               t.Title,
                               t.Description,
                               t.Status,
                               t.Created_At,
                               t.Finish_At
                           };
            var listab = from i in listItem
                         where i.RowNumber > pageIndex && i.RowNumber <= (pageIndex + pageSize)
                         select new
                         {
                             i.ItemId,
                             i.Title,
                             i.Description,
                             i.Status,
                             i.Created_At,
                             i.Finish_At
                         };
            List<vItems> listI = new List<vItems>();
            foreach (var item in listab)
            {
                vItems nitem = new vItems();
                nitem.ItemId = item.ItemId;
                nitem.Title = item.Title;
                nitem.Description = item.Description;
                nitem.Status = item.Status;
                nitem.Created_At = item.Created_At;
                nitem.Finish_At = item.Finish_At;

                listI.Add(nitem);
            }
            return listI;
        }
        public override vItems GetbyId(vItems Item)
        {
            var kq = db.Items.ToList().Find(x => x.ItemId == Item.ItemId);
            vItems nitem = new vItems();
            nitem = changetovItem(kq);

            return nitem;
        }
        public override bool Insert(vItems Item)
        {
            Items nitem = changetoItem(Item);
            db.Items.Add(nitem);
            db.SaveChanges();
            return true;
        }
        public override bool Update(vItems Item)
        {
            Items nitem = db.Items.ToList().Find(x => x.ItemId == Item.ItemId);
            db.Attach(nitem);
            nitem = changetoItem(Item);
            db.Entry(nitem).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public override bool Delete(vItems Item)
        {
            Items nitem = changetoItem(Item);
            db.Items.Remove(nitem);
            db.SaveChanges();
            return true;
        }
        public Items changetoItem(vItems vitem)
        {
            Items nitem = new Items();
            nitem.ItemId = vitem.ItemId;
            nitem.Title = vitem.Title;
            nitem.Description = vitem.Description;
            nitem.Status = vitem.Status;
            nitem.Created_At = vitem.Created_At;
            nitem.Finish_At = vitem.Finish_At;
            return nitem;
        }
        public vItems changetovItem(Items item)
        {
            vItems nitem = new vItems();
            nitem.ItemId = item.ItemId;
            nitem.Title = item.Title;
            nitem.Description = item.Description;
            nitem.Status = item.Status;
            nitem.Created_At = item.Created_At;
            nitem.Finish_At = item.Finish_At;
            return nitem;
        }
    }
}
