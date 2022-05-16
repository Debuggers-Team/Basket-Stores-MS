using Basket_Store_MS.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket_Store_MS.Data
{
    public class BasketStoreDBContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
        public BasketStoreDBContext(DbContextOptions options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>().HasData(
              new Cart { Id = 1, TotalCost = 35.00, State = "Delivered", Quantity = 1 },
              new Cart { Id = 2, TotalCost = 40.22, State = "Open", Quantity = 3 },
              new Cart { Id = 3, TotalCost = 100.00, State = "Delivered", Quantity = 4 },
              new Cart { Id = 4, TotalCost = 200.22, State = "Delivered", Quantity = 5 },
              new Cart { Id = 5, TotalCost = 340.22, State = "Open", Quantity = 9 },
              new Cart { Id = 6, TotalCost = 760.22, State = "Open", Quantity = 1 },
              new Cart { Id = 7, TotalCost = 154.0, State = "Open", Quantity = 5 },
              new Cart { Id = 8, TotalCost = 540.22, State = "Open", Quantity = 1 },
              new Cart { Id = 9, TotalCost = 512.22, State = "Delivered", Quantity = 20 },
              new Cart { Id = 10, TotalCost = 912.22, State = "Delivered", Quantity = 1 },
              new Cart { Id = 11, TotalCost = 632.22, State = "Open", Quantity = 2 },
              new Cart { Id = 12, TotalCost = 134.00, State = "Open", Quantity = 3 },
              new Cart { Id = 13, TotalCost = 45.87, State = "Open", Quantity = 1 },
              new Cart { Id = 14, TotalCost = 143.00, State = "Open", Quantity = 2 }

            );
            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Beauty" },
              new Category { Id = 2, Name = "Clothes" },
              new Category { Id = 3, Name = "Mobiles" },
              new Category { Id = 4, Name = "Computers & accessories" },
              new Category { Id = 5, Name = "TV & Home Entertainment" },
              new Category { Id = 6, Name = "Furniture" }

            );
            modelBuilder.Entity<FeedBack>().HasData(
            new FeedBack { Id = 1, FeedBackDescription = "Realy good", Rating = 5, ProductsId = 1 },
            new FeedBack { Id = 2, FeedBackDescription = "Bad", Rating = 1, ProductsId = 2 },
            new FeedBack { Id = 3, FeedBackDescription = "Amazing", Rating = 5, ProductsId = 4 },
            new FeedBack { Id = 4, FeedBackDescription = "Cool", Rating = 5, ProductsId = 6 },
            new FeedBack { Id = 5, FeedBackDescription = "Butifull", Rating = 5, ProductsId = 9 },
            new FeedBack { Id = 6, FeedBackDescription = "Good one", Rating = 4, ProductsId = 20 },
            new FeedBack { Id = 7, FeedBackDescription = "Nice", Rating = 4, ProductsId = 34 },
            new FeedBack { Id = 8, FeedBackDescription = "Amazing", Rating = 4, ProductsId = 35 },
            new FeedBack { Id = 9, FeedBackDescription = "Fantastic", Rating = 4, ProductsId = 41 },
            new FeedBack { Id = 10, FeedBackDescription = "look very good", Rating = 4, ProductsId = 42 },
            new FeedBack { Id = 11, FeedBackDescription = "nice one", Rating = 5, ProductsId = 44 },
            new FeedBack { Id = 12, FeedBackDescription = "good one", Rating = 5, ProductsId = 49 },
            new FeedBack { Id = 13, FeedBackDescription = "realy amazing", Rating = 5, ProductsId = 56 },
            new FeedBack { Id = 14, FeedBackDescription = "butifull", Rating = 5, ProductsId = 59 },
            new FeedBack { Id = 15, FeedBackDescription = "good", Rating = 5, ProductsId = 61 }
            );
            modelBuilder.Entity<PaymentType>().HasData(
            new PaymentType { Id = 1, PaymentTypes = "Visa", CartId = 1 },
            new PaymentType { Id = 2, PaymentTypes = "Master Card", CartId = 2 },
            new PaymentType { Id = 3, PaymentTypes = "Cash", CartId = 3 },
            new PaymentType { Id = 4, PaymentTypes = "Credit Card", CartId = 4 }

            );
            modelBuilder.Entity<Products>().HasData(
            new Products { Id = 1, Name = "Liner & Colossal Kajal", Price = 15.5, InStock = 150, ProductDescription = "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", Discount = true, CategoryId = 1 },
            new Products { Id = 2, Name = "Blushes", Price = 20.00, InStock = 120, ProductDescription = "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", Discount = true, CategoryId = 1 },
            new Products { Id = 3, Name = "Foundation ", Price = 50.00, InStock = 250, ProductDescription = "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", Discount = false, CategoryId = 1 },
            new Products { Id = 4, Name = "Concealer ", Price = 35.00, InStock = 60, ProductDescription = "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer", Discount = false, CategoryId = 1 },
            new Products { Id = 5, Name = "Gloss ", Price = 15.00, InStock = 120, ProductDescription = "RENEE See Me Shine Lip Gloss For All Skin Tone, Enriched with Jojoba Oil, Non Sticky, Hydrating, Easy Glide Formula, Pucker Up Peach 2.5ml", Discount = false, CategoryId = 1 },
            new Products { Id = 6, Name = "Makeup Fixer", Price = 25.00, InStock = 134, ProductDescription = "Swiss Beauty Makeup Fixer Natural Aloe Vera With Vitamin-E, Face Makeup, White, 70Ml", Discount = true, CategoryId = 1 },
            new Products { Id = 7, Name = "Concealer Palette", Price = 35.00, InStock = 234, ProductDescription = "Insight Cosmetics Pro Concealer Palette (Concealer)", Discount = true, CategoryId = 1 },
            new Products { Id = 8, Name = "Contour De Force", Price = 45.00, InStock = 132, ProductDescription = "SUGAR Cosmetics - Contour De Force - Face Palette with Lightweight Blush, Highlighter And Bronzer - 01 Subtle Summit - Long Lasting Contour Blush Palette", Discount = false, CategoryId = 1 },
            new Products { Id = 9, Name = "Eyeshadow Palette", Price = 100.00, InStock = 200, ProductDescription = "Swiss Beauty Ultimate 9 Color Eyeshadow Palette, Eye MakeUp, Multicolor-06, 6gm", Discount = false, CategoryId = 1 },
            new Products { Id = 10, Name = "Nude and Rose Gold Eyeshadow", Price = 150.00, InStock = 213, ProductDescription = "URBANMAC Nude and Rose Gold Eyeshadow Palette combo", Discount = true, CategoryId = 1 },
            new Products { Id = 11, Name = "Eyelashes with Eye Glue", Price = 25.00, InStock = 120, ProductDescription = "URBANMAC Black Handmade Natural Thick Long Polyester False Eyelashes with Eye Glue", Discount = false, CategoryId = 1 },
            new Products { Id = 12, Name = "Eye Lash Curler", Price = 23.00, InStock = 134, ProductDescription = "Vega Premium Eye Lash Curler", Discount = false, CategoryId = 1 },
            new Products { Id = 13, Name = "Liquid Eyeshadow", Price = 45.00, InStock = 145, ProductDescription = "Swiss Beauty Metallic Liquid Eyeshadow Non-Transfer & Insta Dry, Eye Makeup, Shade-03, 2.25Ml", Discount = true, CategoryId = 1 },
            new Products { Id = 14, Name = "Eyeshadow Palette", Price = 123.00, InStock = 154, ProductDescription = "MARS Glitter Eyeshadow Palette 7.65 g (multicolor)", Discount = false, CategoryId = 1 },
            new Products { Id = 15, Name = "Brightening Eye", Price = 43.00, InStock = 100, ProductDescription = "Kiro Long Wear Brightening Eye Shadow Stick, Nude Pearl, 1.4 g", Discount = true, CategoryId = 1 },
            new Products { Id = 16, Name = "Cotton Born Baby", Price = 15.00, InStock = 123, ProductDescription = "HIKIPO Presents 100% Cotton Born Baby Summer Wear Baby Clothes Sets For Gift", Discount = false, CategoryId = 2 },
            new Products { Id = 17, Name = "Kid's Cotton Combo Pack Of 3 Clothing Set", Price = 243.00, InStock = 234, ProductDescription = "Babyblossom Baby Kid's Cotton Combo Pack Of 3 Clothing Set ( 3 Top And 3 Bottom) (1112,Multicolor,0-3 Months)", Discount = true, CategoryId = 2 },
            new Products { Id = 18, Name = "Men's Regular Fit T-Shirt", Price = 120.00, InStock = 235, ProductDescription = "Scott International Men's Regular Fit T-Shirt (Pack of 3)", Discount = false, CategoryId = 2 },
            new Products { Id = 19, Name = "Basics Half Crew Printed T Shirt", Price = 20.00, InStock = 21, ProductDescription = "DAMENSCH Better Basics Half Crew Printed T Shirt", Discount = true, CategoryId = 2 },
            new Products { Id = 20, Name = "Regular T-Shirt", Price = 23.00, InStock = 567, ProductDescription = "Puma Men's Regular T-Shirt", Discount = false, CategoryId = 2 },
            new Products { Id = 21, Name = "Relaxed Jeans", Price = 42.00, InStock = 234, ProductDescription = "Ben Martin Men's Relaxed Jeans", Discount = true, CategoryId = 2 },
            new Products { Id = 22, Name = "Women's Slim Jeans", Price = 132.00, InStock = 76, ProductDescription = "Van Heusen Women's Slim Jeans", Discount = true, CategoryId = 2 },
            new Products { Id = 23, Name = "Pant for Men", Price = 21.00, InStock = 345, ProductDescription = "TADEO Stylish Cargo Pant for Men | Army Print Pant for Women | Unisex Joggers Cammando Pants for Boys & Girls | Regular Fit Militry Jeans for Man with Multi Pockets", Discount = true, CategoryId = 2 },
            new Products { Id = 24, Name = "Girl's Easter Dress", Price = 15.00, InStock = 235, ProductDescription = "Bonnie Jean Girl's Easter Dress - Yellow Bunny Smocked Dress for Baby Toddler and Little Girls", Discount = false, CategoryId = 2 },
            new Products { Id = 25, Name = "Pack Eyelet Lace Trim And Lace Trim Sock", Price = 35.00, InStock = 231, ProductDescription = "Jefferies Socks 2 Pack Eyelet Lace Trim And Lace Trim Sock - White/White, 12-24 Months", Discount = true, CategoryId = 2 },
            new Products { Id = 26, Name = "Baby Tight", Price = 45.00, InStock = 125, ProductDescription = "Jefferies Socks Microfiber Rhumba Baby Tight White/White, 6-18 Months", Discount = false, CategoryId = 2 },
            new Products { Id = 27, Name = "Girls' Dress", Price = 24.00, InStock = 21, ProductDescription = "Bonnie Jean Little Girls' Dress Sweater with Sequin Trim to Allover Sequin Skirt", Discount = false, CategoryId = 2 },
            new Products { Id = 28, Name = "Knee-Long Dress", Price = 54.00, InStock = 543, ProductDescription = "A.T.U.N Girl's Synthetic Bubble Hem Knee-Long Dress (GDRS TOD SFY_Amber 2_2-3 YR)", Discount = true, CategoryId = 2 },
            new Products { Id = 29, Name = "A-line Long Gown", Price = 120.00, InStock = 143, ProductDescription = "Royal Export Women's Heavy Net A-line Long Gown", Discount = false, CategoryId = 2 },
            new Products { Id = 30, Name = "Women's Polyester A-Line Above The Knee Dress", Price = 15.00, InStock = 123, ProductDescription = "Lymio Women's Polyester A-Line Above The Knee Dress", Discount = true, CategoryId = 2 },
            new Products { Id = 31, Name = "iQOO 9 SE", Price = 123.00, InStock = 345, ProductDescription = "iQOO 9 SE 5G (Sunset Sierra, 8GB RAM, 128GB Storage) | Qualcomm Snapdragon 888 | 66W Flash Charge", Discount = true, CategoryId = 3 },
            new Products { Id = 32, Name = "narzo 50", Price = 200.00, InStock = 43, ProductDescription = "realme narzo 50 (Speed Blue, 4GB RAM+64GB Storage) Helio G96 Processor | 50MP AI Triple Camera | 120Hz Ultra Smooth Display", Discount = false, CategoryId = 3 },
            new Products { Id = 33, Name = "iQ1O 9 Pro", Price = 300.00, InStock = 235, ProductDescription = "iQOO 9 Pro 5G (Legend, 8GB RAM, 256GB Storage) | Snapdragon 8 Gen 1 Mobile Processor | 120W FlashCharge | Upto 12 Months No Cost EMI", Discount = false, CategoryId = 3 },
            new Products { Id = 34, Name = "narzo 50A", Price = 325.00, InStock = 435, ProductDescription = "realme narzo 50A (Oxygen Blue , 4GB RAM + 64 GB Storage) Helio G85 Processor | 50MP AI Triple Camera | 6000 mAh Battery", Discount = true, CategoryId = 3 },
            new Products { Id = 35, Name = "iQOO Z6 5G", Price = 432.00, InStock = 343, ProductDescription = "iQOO Z6 5G (Chromatic Blue, 6GB RAM, 128GB Storage) | Snapdragon 695-6nm Processor | 120Hz FHD+ Display | 5000mAh Battery", Discount = true, CategoryId = 3 },
            new Products { Id = 36, Name = "Oppo A54", Price = 123.00, InStock = 543, ProductDescription = "Oppo A54 (Starry Blue, 6GB RAM, 128GB Storage) with No Cost EMI & Additional Exchange Offers", Discount = true, CategoryId = 3 },
            new Products { Id = 37, Name = "Tecno Spark 8 Pro", Price = 432.00, InStock = 353, ProductDescription = "Tecno Spark 8 Pro (Turquoise Cyan, 7GB Expandable RAM 64GB Storage) 33W Fast Charger | Helio G85 Gaming Processor", Discount = true, CategoryId = 3 },
            new Products { Id = 38, Name = "Vivo Y73", Price = 543.00, InStock = 654, ProductDescription = "Vivo Y73 (Roman Black, 8GB RAM, 128GB Storage) with No Cost EMI/Additional Exchange Offers", Discount = false, CategoryId = 3 },
            new Products { Id = 39, Name = "Tecno Pop 5", Price = 121.00, InStock = 465, ProductDescription = "Tecno Pop 5 LTE(Turquoise Cyan 2G+32GB)| 6.52 HD + Dot Notch | 5000mAh | 8MP Dual Camera | Front Flash |", Discount = false, CategoryId = 3 },
            new Products { Id = 40, Name = "OPPO A15s", Price = 123.00, InStock = 143, ProductDescription = "OPPO A15s (Dynamic Black, 4GB, 128GB Storage) AI Triple Camera | 6.52 HD+ Screen | 2.3GHz Mediatek Helio P35 Octa Core Processor", Discount = true, CategoryId = 3 },
            new Products { Id = 41, Name = "Tecno Spark 8 Pro", Price = 454.00, InStock = 365, ProductDescription = "Tecno Spark 8 Pro (Turquoise Cyan, 7GB Expandable RAM 64GB Storage) 33W Fast Charger | Helio G85 Gaming Processor | 6.8 FHD + Dot -in Display | 48MP Triple Camera", Discount = false, CategoryId = 3 },
            new Products { Id = 42, Name = "Vivo Y73", Price = 132.00, InStock = 154, ProductDescription = "Vivo Y73 (Roman Black, 8GB RAM, 128GB Storage) with No Cost EMI/Additional Exchange Offers", Discount = false, CategoryId = 3 },
            new Products { Id = 43, Name = "OnePlus Nord CE", Price = 345.00, InStock = 677, ProductDescription = "OnePlus Nord CE 2 5G (Bahamas Blue, 8GB RAM, 128GB Storage)", Discount = true, CategoryId = 3 },
            new Products { Id = 44, Name = "Samsung Galaxy M33", Price = 612.00, InStock = 122, ProductDescription = "Samsung Galaxy M33 5G (Deep Ocean Blue, 6GB, 128GB Storage) | Travel Adapter to be Purchased Separately", Discount = false, CategoryId = 3 },
            new Products { Id = 45, Name = "Redmi Note 11", Price = 132.00, InStock = 111, ProductDescription = "Redmi Note 11 (Horizon Blue, 4GB RAM, 64GB Storage) | 90Hz FHD+ AMOLED Display | Qualcomm® Snapdragon™ 680-6nm | Alexa Built-in | 33W Charger Included", Discount = false, CategoryId = 3 },
            new Products { Id = 46, Name = "OnePlus Nord CE", Price = 243.00, InStock = 143, ProductDescription = "OnePlus Nord CE 2 Lite 5G (Blue Tide, 6GB RAM, 128GB Storage)", Discount = true, CategoryId = 3 },
            new Products { Id = 47, Name = "iPhone 12", Price = 343.00, InStock = 700, ProductDescription = "Apple iPhone 12 (64GB) - White", Discount = true, CategoryId = 3 },
            new Products { Id = 48, Name = "Samsung Galaxy M12", Price = 123.00, InStock = 700, ProductDescription = "Samsung Galaxy M12 (Black,4GB RAM, 64GB Storage) 6000 mAh with 8nm Processor | True 48 MP Quad Camera | 90Hz Refresh Rate", Discount = false, CategoryId = 3 },
            new Products { Id = 49, Name = "Introducing Fire TV Stick 4K Max streaming device", Price = 444.00, InStock = 577, ProductDescription = "Introducing Fire TV Stick 4K Max streaming device, Alexa Voice Remote (includes TV controls)| 2021 release", Discount = false, CategoryId = 4 },
            new Products { Id = 50, Name = "DishTV HD DTH Set Top Box", Price = 334.00, InStock = 87, ProductDescription = "DishTV HD DTH Set Top Box with 12 Month FTA Hindi Pack + Installation", Discount = true, CategoryId = 4 },
            new Products { Id = 51, Name = "Catvision Doordarshan Freedish MPEG 2", Price = 144.00, InStock = 76, ProductDescription = "Catvision Doordarshan Freedish MPEG 2 Standard Definition Set Top Box for FreeDish 90+ Channels (Black)", Discount = true, CategoryId = 4 },
            new Products { Id = 52, Name = "LG 121.9 cm", Price = 345.00, InStock = 98, ProductDescription = "LG 121.9 cm (48 inches) 4K Ultra HD Smart OLED TV 48A1PTZ (Dark Meteo Titan) (2021 Model)", Discount = false, CategoryId = 4 },
            new Products { Id = 53, Name = "LG 164 cm", Price = 223.00, InStock = 65, ProductDescription = "LG 164 cm (65 inches) 4K Ultra HD Smart OLED TV 65CXPTA (Dark Steel Silver) (2020 Model)", Discount = true, CategoryId = 4 },
            new Products { Id = 54, Name = "Croma 80 cm", Price = 243.00, InStock = 98, ProductDescription = "Croma 80 cm (32 Inches) HD Ready LED TV CREL7369 (Black)", Discount = true, CategoryId = 4 },
            new Products { Id = 55, Name = "Redmi 80 cm", Price = 654.00, InStock = 65, ProductDescription = "Redmi 80 cm (32 inches) HD Ready Smart LED TV | L32M6-RA/L32M7-RA (Black) (2021 Model) | With Android 11", Discount = false, CategoryId = 4 },
            new Products { Id = 56, Name = "OnePlus 80 cm (32 inches)", Price = 243.00, InStock = 456, ProductDescription = "OnePlus 80 cm (32 inches) Y Series HD Ready Smart Android LED TV 32 Y1S (Black) (2022 Model)", Discount = false, CategoryId = 4 },
            new Products { Id = 57, Name = "Redmi 80 cm (32 inches)", Price = 432.00, InStock = 65, ProductDescription = "Redmi 80 cm (32 inches) HD Ready Smart LED TV | L32M6-RA/L32M7-RA (Black) (2021 Model) | With Android 11", Discount = false, CategoryId = 4 },
            new Products { Id = 58, Name = "Mi 138.8 cm", Price = 143.00, InStock = 565, ProductDescription = "Mi 138.8 cm (55 Inches) 4K Ultra HD Android Smart LED TV 4X | L55M5-5XIN (Black)", Discount = true, CategoryId = 4 },
            new Products { Id = 59, Name = "Tronica TR-1501 Deep Bass Home Theater with Subwoofer 2.1", Price = 321.00, InStock = 565, ProductDescription = "Tronica TR-1501 Deep Bass Home Theater with Subwoofer 2.1 Channel with 55W Premium Signature Sound, Multiple Connectivity Modes, Master Remote and Sleek Finish (Black)", Discount = false, CategoryId = 4 },
            new Products { Id = 60, Name = "Sturdy Flat Cable", Price = 321.00, InStock = 56, ProductDescription = "boAt Type C A750 Stress Resistant, Tangle-free, Sturdy Flat Cable with 6.5A Fast Charging & 480Mbps Data Transmission, 10000+ Bends Lifespan and Extended 1.5m Length(Radiant Red)", Discount = true, CategoryId = 4 },
            new Products { Id = 61, Name = "Engineered Wood Platform Bed with Storage", Price = 750.00, InStock = 100, ProductDescription = "Wakefit Queen Size Taurus Engineered Wood Platform Bed with Storage - (Matte Finish_Brown)", Discount = false, CategoryId = 5 },
            new Products { Id = 62, Name = "Outdoor Balcony Garden Coffee Table Set", Price = 432.00, InStock = 34, ProductDescription = "Corazzin Garden Patio Seating Chair and Table Set Outdoor Balcony Garden Coffee Table Set Furniture with 1 Table and 2 Chairs Set (Black)", Discount = true, CategoryId = 5 },
            new Products { Id = 63, Name = "Wooden Fold-able Side Table", Price = 232.00, InStock = 34, ProductDescription = "UHUD CRAFTS Beautiful Antique Wooden Fold-able Side Table/End Table/Plant Stand/Stool Living Room Kids Play Furniture Table Round Shape", Discount = true, CategoryId = 5 },
            new Products { Id = 64, Name = "Portable Chair", Price = 243.00, InStock = 54, ProductDescription = "Wakefit Stargazer Manual Single Seater Recliner (Leatherette, Brown)", Discount = false, CategoryId = 5 },
            new Products { Id = 65, Name = "3 Seater Sofa", Price = 654.00, InStock = 345, ProductDescription = "Wakefit Snoozer 3 Seater Sofa (Fabric, Cobalt Blue)", Discount = true, CategoryId = 5 },
            new Products { Id = 66, Name = "Beds Covers", Price = 354.00, InStock = 54, ProductDescription = "Fashion String 144 TC Microfibre Brown Double Bedsheet with 2 King Size Pillow Covers", Discount = false, CategoryId = 5 },
            new Products { Id = 67, Name = "Blackout Curtains", Price = 121.00, InStock = 45, ProductDescription = "Room Darkening Thermal Insulated Eyelet Noise Reducing Blackout Curtains for Bedroom with Tie Backs- Black (9 Feet - Long Door) 1 Piece", Discount = false, CategoryId = 5 },
            new Products { Id = 68, Name = "Dining Table 6 Seater", Price = 432.00, InStock = 54, ProductDescription = "Driftingwood Dining Table 6 Seater | Six Seater Dinning Table with Chairs | Dining Room Sets | Sheesham Wood, Honey Finish", Discount = true, CategoryId = 5 },
            new Products { Id = 69, Name = "Air Cooler", Price = 345.00, InStock = 543, ProductDescription = "Bajaj PMH 25 DLX 24L Personal Air Cooler with Honeycomb Pads, Turbo Fan Technology, Powerful Air Throw and 3-Speed Control, White,PMH25 DLX", Discount = false, CategoryId = 5 },
            new Products { Id = 70, Name = "Bonnell Spring Mattress Maroon", Price = 400.00, InStock = 234, ProductDescription = "Hypnos Caspio Ortho 8 Inch Medium Firm Single Size Bonnell Spring Mattress Maroon (72X30X08)", Discount = true, CategoryId = 5 },
            new Products { Id = 71, Name = "2 Door TV Cabinet with Drawers", Price = 544.00, InStock = 154, ProductDescription = "Amazon Brand - Solimo Cygnus Engineered Wood 2 Door TV Cabinet with Drawers ( Brown, Sienna Cherry)", Discount = false, CategoryId = 5 },
            new Products { Id = 72, Name = "Hand Made Jute Throw Cushion Covers", Price = 299.00, InStock = 325, ProductDescription = "AEROHAVEN™ Set of 5 Decorative Hand Made Jute Throw/Pillow Cushion Covers - (16 X 16 INCHES)", Discount = true, CategoryId = 5 }

            );
            modelBuilder.Entity<CartProduct>().HasKey(
            CartProduct => new { CartProduct.CartId, CartProduct.ProductId }
            );
        }

    }

}
