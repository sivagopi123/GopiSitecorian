using System;
using System.Collections.Generic;

namespace GenericsSamples
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        public Dictionary<string,Vendor> DictionaryCollectionSample()
        {
            var vendor = new Dictionary<string, Vendor> {
                { "ABC",
                    new Vendor
                    {
                        VendorId = 5,
                        CompanyName = "ABC copy",
                        Email = "abc@abc.com"
                    }
                },
                { "CDFS",
                    new Vendor
                        {
                        VendorId = 3,
                        CompanyName = "CFS copy",
                        Email = "csdf@sdcxf.com"
                    }
                }
            };

            //foreach (var dic in vendor)
            //{
            //    Console.WriteLine($"Key\t:{dic.Key}\nVendor\t:{dic.Value.CompanyName} : {dic.Value.Email}");
            //}

            foreach (var companyName in vendor.Values)
            {
                Console.WriteLine(companyName);
            }

            return vendor;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            //Vendor compareVendor = obj as Vendor;
            if (obj is Vendor compareVendor &&
                this.VendorId == compareVendor.VendorId &&
                this.CompanyName == compareVendor.CompanyName &&
                this.Email == compareVendor.Email
                )
                return true;

            return base.Equals(obj);
        }
    }
}