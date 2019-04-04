using System;

namespace RunSqlAndDTtoList
{
    public class MixBrandProduct
    {
        public long ID { get; set; }

        public int TenantID { get; set; }

        public int Brand_ID { get; set; }

        public long HGP_Product_ID { get; set; }

        public long My_Product_ID { get; set; }

        public UInt64 Is_Sale_By_Package { get; set; }

        public UInt64 Enable { get; set; }

        public int Create_By { get; set; }

        public System.DateTime Create_Time { get; set; }

        public int Update_By { get; set; }

        public System.DateTime Update_Time { get; set; }

        public System.DateTime TIMESTAMP { get; set; }

        public int Status { get; set; }

        public int Brand_Product_Type { get; set; }

        public string Batch_No { get; set; }

        public string Qty_Discount { get; set; }

        public string KeyCode { get; set; }

        public double Min_Order_Qty { get; set; }

        public long Inventory_ID { get; set; }

        public UInt64 Is_Factory_Natural_Color { get; set; }

        public string My_Part_No { get; set; }

        public int Delivery_Days { get; set; }

        public Nullable<System.DateTime> Up_Time { get; set; }

        public Nullable<System.DateTime> Down_Time { get; set; }

        public double Base_Price { get; set; }

        public double Red_Price { get; set; }

        public string Red_Price_Ref { get; set; }

        public string Group_For_BasePrice { get; set; }

        public UInt64 Is_Natural_Color { get; set; }

        public double Min_Buy_Qty { get; set; }

        public string Remark { get; set; }

        public sbyte Base_Unit { get; set; }

        public long OrderIndex { get; set; }

        public string Alias_Specification { get; set; }

        public string Alias_Product_Name { get; set; }

        public string ConsignmentBy { get; set; }

        public double Online_Inventory_Rate { get; set; }
        public sbyte IsMarketable { get; set; }
        public int NamedBrandID { get; set; }
        public sbyte MaterialSourceId { get; set; }
        public long NaturalBrandProductId { get; set; }
    }
}
