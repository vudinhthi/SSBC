
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
    public static partial class StationTracking
    {
    
        public static Source.Data.SourceContext.MSG Save(Source.Data.Entities.StationTracking item,string Symbol)
        {
            var _return = new Source.Data.SourceContext.MSG();
            try
            {
                using (var dbContext = new Source.Data.SourceContext())
                {
                    //check the ObjectState property and mark appropriate EntityState 
                    if (item.UpdateStatus == "Added")
                    {
                        var items = dbContext.StationTrackings.Where(x=>x.Station==item.Station && x.Year==item.Year);
                        var itemCheck = items.Where(s => s.SessionID == item.SessionID).ToList();
                        if (itemCheck.Count > 0)
                        {
                            _return.IsError = true;
                            _return.MsgInformation = "Can not save data <<Duplication>>!";
                        }
                        else
                        {
                            item.UserAdded = tmpLogin.Id;
                            item.UserAddedTime = DateTime.Now;
                            item.UserUpdate = tmpLogin.Id;
                            item.UserUpdateTime = DateTime.Now;
                            
                            int MaxID = items.Count() == 0 ? 0 : items.Max(x => x == null ? 0 :(int)x.Seq);
                            item.Seq = MaxID + 1;


                            item.SessionID =Symbol + item.Year.Substring(2, 2) + item.Seq.ToString("00000#");

                            
                            
                            dbContext.Entry(item).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    else if (item.UpdateStatus == "Modified")
                    {
                        item.UserUpdate = tmpLogin.Id;
                        item.UserUpdateTime = DateTime.Now;
                        
                        dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        dbContext.Entry(item).Property(x => x.Seq).IsModified = false;
                        dbContext.Entry(item).Property(x => x.UserAdded).IsModified = false;
                        dbContext.Entry(item).Property(x => x.UserAddedTime).IsModified = false;
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
        public static Source.Data.SourceContext.MSG Delete(IEnumerable<Source.Data.Entities.StationTracking> items)
        {
            var _return = new Source.Data.SourceContext.MSG();
            try
            {
                var dbContext = new  Source.Data.SourceContext();
                foreach (var item in items)
                {
                    var itemDel = dbContext.StationTrackings.Where(s => s.SessionID == item.SessionID).FirstOrDefault();
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


