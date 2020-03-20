using SSBC_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSBC_Data.DAO
{
    public class LoadData
    {
        private static LoadData instance;
        public static LoadData Instance
        {
            get { if (instance == null) instance = new LoadData(); return LoadData.instance; }
            private set { LoadData.instance = value; }
        }
       
        public static int TableWidth = 90;
        public static int TableHeight = 90;
        private LoadData() { }

        SourceContext dbContext = new SourceContext();
        public List<SSBCMaterials> LoadShiftList()
        {
            var shiftList = dbContext.SSBCMaterials
                .Select(x=> new SSBCMaterials
                {
                    MaterialCo = x.MaterialCo,
                    MaterialName = x.MaterialName,
                })
                .ToList();
            return shiftList;
        }

            
    }
}
