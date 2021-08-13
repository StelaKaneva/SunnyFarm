﻿namespace SunnyFarm.Data
{
    public class DataConstants
    {
        public class PersonalData 
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
            public const int PhoneMinLength = 9;
            public const int PhoneMaxLength = 20;
        }

        public class Shop
        {
            public const int AddressMinLength = 20;
            public const int AddressMaxLength = 120;
            public const int ShopNameMinLength = 5;
            public const int ShopNameMaxLength = 30;
            public const int WorkingHoursMinLength = 8;
            public const int WorkingHoursMaxLength = 100;
        }

        public class Product
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 60;
            public const int DescriptionMinLength = 10;
            public const int SizeMinValue = 1;
            public const int SizeMaxValue = 999;
            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 999;
        }
    }
}
