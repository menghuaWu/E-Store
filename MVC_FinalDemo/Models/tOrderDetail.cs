//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_FinalDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tOrderDetail
    {
        public int Id { get; set; }
        public string fOrderID { get; set; }
        public string fProductID { get; set; }
        public string fProductName { get; set; }
        public Nullable<int> fProductPrice { get; set; }
        public Nullable<int> fProductCount { get; set; }
        public Nullable<int> fTotalPrice { get; set; }
    }
}