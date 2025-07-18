﻿using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class MasterFeatures : BaseEntity
    {
        public int MasterFeaturesId { get; set; }

        public string MasterFeaturesIcon { get; set; }

        [DataType(DataType.Text)]
        public string MasterFeaturesTitle { get; set; }
    }
}
