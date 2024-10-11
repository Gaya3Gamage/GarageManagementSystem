using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GarageManagement.Data
{
    public class CustomerDetail
    {
        [Key]
        [JsonIgnore]
        public int CustomerID { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNO { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Nid { get; set; } = null!;
    }
}
