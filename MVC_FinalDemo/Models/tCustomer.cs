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

    public partial class tCustomer
    {
        public int Id { get; set; }
        [DisplayName("編號")]
        [Required]
        public string fCustomerID { get; set; }

        [DisplayName("用戶")]
        [Required]
        public string fCustomerName { get; set; }

        [DisplayName("密碼")]
        [Required]
        public string fCustomerPassword { get; set; }

        [DisplayName("電戶")]
        [Required]
        public string fCustomerPhone { get; set; }

        [DisplayName("地址")]
        [Required]
        public string fCustomerAddress { get; set; }

        [DisplayName("信箱")]
        [Required]
        public string fCustomerEmail { get; set; }
    }
}
