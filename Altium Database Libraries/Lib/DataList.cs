using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altium_Database_Libraries.Lib
{
    public class DataList
    {
        private string _PartType;
        private string _PartNumber;
        private string _Manufacturer;
        private string _ManufacturerPartNumber;
        private string _Description;
        private string _LeadTime;
        private string _Categories;
        private string _Temperature;
        private string _MountingType;
        private string _Package;
        private string _SupplierPackage;


        public string PartType
        {
            get { return _PartType; }
            set { _PartType = value; }
        }

        public string PartNumber
        {
            get { return _PartNumber; }
            set { _PartNumber = value; }
        }

        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { _Manufacturer = value; }
        }

        public string ManufacturerPartNumber
        {
            get { return _ManufacturerPartNumber; }
            set { _ManufacturerPartNumber = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        public string LeadTime
        {
            get { return _LeadTime; }
            set { _LeadTime = value; }
        }

        public string Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }

        public string Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        public string MountingType
        {
            get { return _MountingType; }
            set { _MountingType = value; }
        }

        public string Package
        {
            get { return _Package; }
            set { _Package = value; }
        }

        public string SupplierPackage
        {
            get { return _SupplierPackage; }
            set { _SupplierPackage = value; }
        }
    }
}
