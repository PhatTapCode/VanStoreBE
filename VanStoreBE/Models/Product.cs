namespace VanStoreBE.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProDetails = new HashSet<ProDetail>();
        }
        
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục này !!!")]
        public int ProID { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục này !!!")]
        public string ProName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục này !!!")]
        public int CatID { get; set; }
        public string ProImage { get; set; }
        public string ProImageHover { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục này !!!")]
        public string NameDecription { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số >0")]
        public int ViewQuantity { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProDetail> ProDetails { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImageHover { get; set; }

    }
}
