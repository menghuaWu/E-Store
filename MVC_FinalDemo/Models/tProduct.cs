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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tProduct
    {
        public int Id { get; set; }
        [DisplayName("編號")]
        [Required]
        public string fProductID { get; set; }

        [DisplayName("品名")]
        [Required]
        public string fProductName { get; set; }

        [DisplayName("種類")]
        [Required]
        public string fProductCatagory { get; set; }

        [DisplayName("單價")]
        [Required]
        public Nullable<int> fProductPrice { get; set; }
        public string fImg { get; set; }
    }
}
