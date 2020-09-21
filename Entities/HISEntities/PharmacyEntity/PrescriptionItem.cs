using System;
using System.Collections.Generic;

namespace Entities.HISEntities.PharmacyEntity
{
    public  class PrescriptionItem
    {

        public int Id { get; set; }
        public int? PrescriptionId { get; set; }
        public int? SalableId { get; set; }
        public int? PrescriptionItemId { get; set; }
        public double? Qty { get; set; }
        public byte? IsGauaranteed { get; set; }
        public bool? PartOfCompund { get; set; }
        public byte? DeliTypeIx { get; set; }
        public byte? LableOfIx { get; set; }
        public decimal? Price { get; set; }
        public decimal? GaurantorShare { get; set; }
        public string Processed { get; set; }
        public bool? HasComponent { get; set; }
        public decimal? PreparationPrice { get; set; }
        public int? StorageId { get; set; }
        public decimal? GaurantorPrice { get; set; }
        public DateTime? ExpDate { get; set; }
        public byte IsNis { get; set; }
        public int? PackagingId { get; set; }
        public string Description { get; set; }
        public byte? SimilarityIs { get; set; }
        public short? RankOf { get; set; }
        public string BatchNo { get; set; }
        public decimal? PatPartDiscount { get; set; }
        public int? FrequencyUsageId { get; set; }

    }
}
