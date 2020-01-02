using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSBC_Data
{
    public abstract partial class EntitiesObject
    {
        [NotMapped]
        public String UpdateStatus
        {
            get; set;
        }

        [NotMapped]
        public String AutoId
        {
            get; set;
        }

        [NotMapped]
        public Boolean IsChecked
        {
            get; set;
        }
    }
}