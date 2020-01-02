
//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Source.Data.Controllers
{
    public static partial class Stocks
    {
    
        public static Source.Data.SourceContext.MSG Save(Source.Data.Entities.Stocks item)
        {
            var _return = new Source.Data.SourceContext.MSG();
            try
            {
                using (var dbContext = new Source.Data.SourceContext())
                {
                    //check the ObjectState property and mark appropriate EntityState 
                    if (item.UpdateStatus == "Added")
                    {
                        var items = dbContext.Stocks;
                        var itemCheck = items.Where(s => s.Yy == item.Yy
                && s.Mm == item.Mm
                && s.ColorCode == item.ColorCode
                && s.MaterialCo == item.MaterialCo
                && s.MaterialType == item.MaterialType
                && s.StockName == item.StockName).ToList();
                        if (itemCheck.Count > 0)
                        {
                            _return.IsError = true;
                            _return.MsgInformation = "Can not save data <<Duplication>>!";
                        }
                        else
                        {
                            //item.UserAdded = tmpLogin.Id;
                            //item.UserAddedTime = DateTime.Now;
                            //item.UserUpdate = tmpLogin.Id;
                            //item.UserUpdateTime = DateTime.Now;
                            
                            //int MaxID = items.Count() == 0 ? 0 : items.Max(x => x == null ? 0 :(int)x.Seq);
                            //item.Seq = MaxID + 1;
                            
                            
                //item.Yy = "I" +item.Seq.ToString();
                //item.Mm = "I" +item.Seq.ToString();
                //item.ColorCode = "I" +item.Seq.ToString();
                //item.MaterialCo = "I" +item.Seq.ToString();
                //item.MaterialType = "I" +item.Seq.ToString();
                //item.StockName = "I" +item.Seq.ToString();
                            
                            
                            dbContext.Entry(item).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    else if (item.UpdateStatus == "Modified")
                    {
                        //item.UserUpdate = tmpLogin.Id;
                        //item.UserUpdateTime = DateTime.Now;
                        
                        //dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        //dbContext.Entry(item).Property(x => x.Seq).IsModified = false;
                        //dbContext.Entry(item).Property(x => x.UserAdded).IsModified = false;
                        //dbContext.Entry(item).Property(x => x.UserAddedTime).IsModified = false;
                        //dbContext.Entry(item).Property(x => x.Isdel).IsModified = false;
                    }
                    else if (item.UpdateStatus == "Deleted")
                    {
                        dbContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                    else
                    {
                        dbContext.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                    }
                    //=========================
                    if (_return.IsError != true)
                    {
                        dbContext.SaveChanges();
                        _return = new Source.Data.SourceContext.MSG(item.UpdateStatus, false);
                    }
                }
            }
            catch (Exception err)
            {
                _return = new Source.Data.SourceContext.MSG(item.UpdateStatus, true);
                _return.MsgInformation += "\n " + err.ToString();
            }
            return _return;

        }
        //=============
        #region  Delete
        public static Source.Data.SourceContext.MSG Delete(IEnumerable<Source.Data.Entities.Stocks> items)
        {
            var _return = new Source.Data.SourceContext.MSG();
            try
            {
                var dbContext = new  Source.Data.SourceContext();
                foreach (var item in items)
                {
                    var itemDel = dbContext.Stocks.Where(s => s.Yy == item.Yy
                && s.Mm == item.Mm
                && s.ColorCode == item.ColorCode
                && s.MaterialCo == item.MaterialCo
                && s.MaterialType == item.MaterialType
                && s.StockName == item.StockName).FirstOrDefault();
                    dbContext.Entry(itemDel).State = System.Data.Entity.EntityState.Deleted;
                };
                dbContext.SaveChanges();
                _return = new Source.Data.SourceContext.MSG("Deleted", false);
            }
            catch (Exception err)
            {
                _return = new Source.Data.SourceContext.MSG("Deleted", true);
                _return.MsgInformation += "\n " + err.ToString();
            }



            return _return;

        }
        #endregion
    }
    
}


