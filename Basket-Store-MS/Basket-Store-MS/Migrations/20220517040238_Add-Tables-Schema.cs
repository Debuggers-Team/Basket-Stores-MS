using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket_Store_MS.Migrations
{
    public partial class AddTablesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteProduct",
                columns: table => new
                {
                    FavouriteId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProduct", x => new { x.FavouriteId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FavouriteProduct_Favourite_FavouriteId",
                        column: x => x.FavouriteId,
                        principalTable: "Favourite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedBackDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedBacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beauty" },
                    { 2, "Clothes" },
                    { 3, "Mobiles" },
                    { 4, "Computers & accessories" },
                    { 5, "TV & Home Entertainment" },
                    { 6, "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Discount", "InStock", "Name", "Price", "ProductDescription" },
                values: new object[,]
                {
                    { 1, 1, true, 150, "Liner & Colossal Kajal", 15.5, "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml" },
                    { 52, 4, false, 98, "LG 121.9 cm", 345.0, "LG 121.9 cm (48 inches) 4K Ultra HD Smart OLED TV 48A1PTZ (Dark Meteo Titan) (2021 Model)" },
                    { 51, 4, true, 76, "Catvision Doordarshan Freedish MPEG 2", 144.0, "Catvision Doordarshan Freedish MPEG 2 Standard Definition Set Top Box for FreeDish 90+ Channels (Black)" },
                    { 50, 4, true, 87, "DishTV HD DTH Set Top Box", 334.0, "DishTV HD DTH Set Top Box with 12 Month FTA Hindi Pack + Installation" },
                    { 49, 4, false, 577, "Introducing Fire TV Stick 4K Max streaming device", 444.0, "Introducing Fire TV Stick 4K Max streaming device, Alexa Voice Remote (includes TV controls)| 2021 release" },
                    { 48, 3, false, 700, "Samsung Galaxy M12", 123.0, "Samsung Galaxy M12 (Black,4GB RAM, 64GB Storage) 6000 mAh with 8nm Processor | True 48 MP Quad Camera | 90Hz Refresh Rate" },
                    { 47, 3, true, 700, "iPhone 12", 343.0, "Apple iPhone 12 (64GB) - White" },
                    { 53, 4, true, 65, "LG 164 cm", 223.0, "LG 164 cm (65 inches) 4K Ultra HD Smart OLED TV 65CXPTA (Dark Steel Silver) (2020 Model)" },
                    { 46, 3, true, 143, "OnePlus Nord CE", 243.0, "OnePlus Nord CE 2 Lite 5G (Blue Tide, 6GB RAM, 128GB Storage)" },
                    { 44, 3, false, 122, "Samsung Galaxy M33", 612.0, "Samsung Galaxy M33 5G (Deep Ocean Blue, 6GB, 128GB Storage) | Travel Adapter to be Purchased Separately" },
                    { 43, 3, true, 677, "OnePlus Nord CE", 345.0, "OnePlus Nord CE 2 5G (Bahamas Blue, 8GB RAM, 128GB Storage)" },
                    { 42, 3, false, 154, "Vivo Y73", 132.0, "Vivo Y73 (Roman Black, 8GB RAM, 128GB Storage) with No Cost EMI/Additional Exchange Offers" },
                    { 41, 3, false, 365, "Tecno Spark 8 Pro", 454.0, "Tecno Spark 8 Pro (Turquoise Cyan, 7GB Expandable RAM 64GB Storage) 33W Fast Charger | Helio G85 Gaming Processor | 6.8 FHD + Dot -in Display | 48MP Triple Camera" },
                    { 40, 3, true, 143, "OPPO A15s", 123.0, "OPPO A15s (Dynamic Black, 4GB, 128GB Storage) AI Triple Camera | 6.52 HD+ Screen | 2.3GHz Mediatek Helio P35 Octa Core Processor" },
                    { 39, 3, false, 465, "Tecno Pop 5", 121.0, "Tecno Pop 5 LTE(Turquoise Cyan 2G+32GB)| 6.52 HD + Dot Notch | 5000mAh | 8MP Dual Camera | Front Flash |" },
                    { 45, 3, false, 111, "Redmi Note 11", 132.0, "Redmi Note 11 (Horizon Blue, 4GB RAM, 64GB Storage) | 90Hz FHD+ AMOLED Display | Qualcomm® Snapdragon™ 680-6nm | Alexa Built-in | 33W Charger Included" },
                    { 38, 3, false, 654, "Vivo Y73", 543.0, "Vivo Y73 (Roman Black, 8GB RAM, 128GB Storage) with No Cost EMI/Additional Exchange Offers" },
                    { 54, 4, true, 98, "Croma 80 cm", 243.0, "Croma 80 cm (32 Inches) HD Ready LED TV CREL7369 (Black)" },
                    { 56, 4, false, 456, "OnePlus 80 cm (32 inches)", 243.0, "OnePlus 80 cm (32 inches) Y Series HD Ready Smart Android LED TV 32 Y1S (Black) (2022 Model)" },
                    { 70, 5, true, 234, "Bonnell Spring Mattress Maroon", 400.0, "Hypnos Caspio Ortho 8 Inch Medium Firm Single Size Bonnell Spring Mattress Maroon (72X30X08)" },
                    { 69, 5, false, 543, "Air Cooler", 345.0, "Bajaj PMH 25 DLX 24L Personal Air Cooler with Honeycomb Pads, Turbo Fan Technology, Powerful Air Throw and 3-Speed Control, White,PMH25 DLX" },
                    { 68, 5, true, 54, "Dining Table 6 Seater", 432.0, "Driftingwood Dining Table 6 Seater | Six Seater Dinning Table with Chairs | Dining Room Sets | Sheesham Wood, Honey Finish" },
                    { 67, 5, false, 45, "Blackout Curtains", 121.0, "Room Darkening Thermal Insulated Eyelet Noise Reducing Blackout Curtains for Bedroom with Tie Backs- Black (9 Feet - Long Door) 1 Piece" },
                    { 66, 5, false, 54, "Beds Covers", 354.0, "Fashion String 144 TC Microfibre Brown Double Bedsheet with 2 King Size Pillow Covers" },
                    { 65, 5, true, 345, "3 Seater Sofa", 654.0, "Wakefit Snoozer 3 Seater Sofa (Fabric, Cobalt Blue)" },
                    { 55, 4, false, 65, "Redmi 80 cm", 654.0, "Redmi 80 cm (32 inches) HD Ready Smart LED TV | L32M6-RA/L32M7-RA (Black) (2021 Model) | With Android 11" },
                    { 64, 5, false, 54, "Portable Chair", 243.0, "Wakefit Stargazer Manual Single Seater Recliner (Leatherette, Brown)" },
                    { 62, 5, true, 34, "Outdoor Balcony Garden Coffee Table Set", 432.0, "Corazzin Garden Patio Seating Chair and Table Set Outdoor Balcony Garden Coffee Table Set Furniture with 1 Table and 2 Chairs Set (Black)" },
                    { 61, 5, false, 100, "Engineered Wood Platform Bed with Storage", 750.0, "Wakefit Queen Size Taurus Engineered Wood Platform Bed with Storage - (Matte Finish_Brown)" },
                    { 60, 4, true, 56, "Sturdy Flat Cable", 321.0, "boAt Type C A750 Stress Resistant, Tangle-free, Sturdy Flat Cable with 6.5A Fast Charging & 480Mbps Data Transmission, 10000+ Bends Lifespan and Extended 1.5m Length(Radiant Red)" },
                    { 59, 4, false, 565, "Tronica TR-1501 Deep Bass Home Theater with Subwoofer 2.1", 321.0, "Tronica TR-1501 Deep Bass Home Theater with Subwoofer 2.1 Channel with 55W Premium Signature Sound, Multiple Connectivity Modes, Master Remote and Sleek Finish (Black)" },
                    { 58, 4, true, 565, "Mi 138.8 cm", 143.0, "Mi 138.8 cm (55 Inches) 4K Ultra HD Android Smart LED TV 4X | L55M5-5XIN (Black)" },
                    { 57, 4, false, 65, "Redmi 80 cm (32 inches)", 432.0, "Redmi 80 cm (32 inches) HD Ready Smart LED TV | L32M6-RA/L32M7-RA (Black) (2021 Model) | With Android 11" },
                    { 63, 5, true, 34, "Wooden Fold-able Side Table", 232.0, "UHUD CRAFTS Beautiful Antique Wooden Fold-able Side Table/End Table/Plant Stand/Stool Living Room Kids Play Furniture Table Round Shape" },
                    { 37, 3, true, 353, "Tecno Spark 8 Pro", 432.0, "Tecno Spark 8 Pro (Turquoise Cyan, 7GB Expandable RAM 64GB Storage) 33W Fast Charger | Helio G85 Gaming Processor" },
                    { 36, 3, true, 543, "Oppo A54", 123.0, "Oppo A54 (Starry Blue, 6GB RAM, 128GB Storage) with No Cost EMI & Additional Exchange Offers" },
                    { 35, 3, true, 343, "iQOO Z6 5G", 432.0, "iQOO Z6 5G (Chromatic Blue, 6GB RAM, 128GB Storage) | Snapdragon 695-6nm Processor | 120Hz FHD+ Display | 5000mAh Battery" },
                    { 15, 1, true, 100, "Brightening Eye", 43.0, "Kiro Long Wear Brightening Eye Shadow Stick, Nude Pearl, 1.4 g" },
                    { 14, 1, false, 154, "Eyeshadow Palette", 123.0, "MARS Glitter Eyeshadow Palette 7.65 g (multicolor)" },
                    { 13, 1, true, 145, "Liquid Eyeshadow", 45.0, "Swiss Beauty Metallic Liquid Eyeshadow Non-Transfer & Insta Dry, Eye Makeup, Shade-03, 2.25Ml" },
                    { 12, 1, false, 134, "Eye Lash Curler", 23.0, "Vega Premium Eye Lash Curler" },
                    { 11, 1, false, 120, "Eyelashes with Eye Glue", 25.0, "URBANMAC Black Handmade Natural Thick Long Polyester False Eyelashes with Eye Glue" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Discount", "InStock", "Name", "Price", "ProductDescription" },
                values: new object[,]
                {
                    { 10, 1, true, 213, "Nude and Rose Gold Eyeshadow", 150.0, "URBANMAC Nude and Rose Gold Eyeshadow Palette combo" },
                    { 16, 2, false, 123, "Cotton Born Baby", 15.0, "HIKIPO Presents 100% Cotton Born Baby Summer Wear Baby Clothes Sets For Gift" },
                    { 9, 1, false, 200, "Eyeshadow Palette", 100.0, "Swiss Beauty Ultimate 9 Color Eyeshadow Palette, Eye MakeUp, Multicolor-06, 6gm" },
                    { 7, 1, true, 234, "Concealer Palette", 35.0, "Insight Cosmetics Pro Concealer Palette (Concealer)" },
                    { 6, 1, true, 134, "Makeup Fixer", 25.0, "Swiss Beauty Makeup Fixer Natural Aloe Vera With Vitamin-E, Face Makeup, White, 70Ml" },
                    { 5, 1, false, 120, "Gloss ", 15.0, "RENEE See Me Shine Lip Gloss For All Skin Tone, Enriched with Jojoba Oil, Non Sticky, Hydrating, Easy Glide Formula, Pucker Up Peach 2.5ml" },
                    { 4, 1, false, 60, "Concealer ", 35.0, "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer" },
                    { 3, 1, false, 250, "Foundation ", 50.0, "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge" },
                    { 2, 1, true, 120, "Blushes", 20.0, "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set" },
                    { 8, 1, false, 132, "Contour De Force", 45.0, "SUGAR Cosmetics - Contour De Force - Face Palette with Lightweight Blush, Highlighter And Bronzer - 01 Subtle Summit - Long Lasting Contour Blush Palette" },
                    { 17, 2, true, 234, "Kid's Cotton Combo Pack Of 3 Clothing Set", 243.0, "Babyblossom Baby Kid's Cotton Combo Pack Of 3 Clothing Set ( 3 Top And 3 Bottom) (1112,Multicolor,0-3 Months)" },
                    { 18, 2, false, 235, "Men's Regular Fit T-Shirt", 120.0, "Scott International Men's Regular Fit T-Shirt (Pack of 3)" },
                    { 19, 2, true, 21, "Basics Half Crew Printed T Shirt", 20.0, "DAMENSCH Better Basics Half Crew Printed T Shirt" },
                    { 34, 3, true, 435, "narzo 50A", 325.0, "realme narzo 50A (Oxygen Blue , 4GB RAM + 64 GB Storage) Helio G85 Processor | 50MP AI Triple Camera | 6000 mAh Battery" },
                    { 33, 3, false, 235, "iQ1O 9 Pro", 300.0, "iQOO 9 Pro 5G (Legend, 8GB RAM, 256GB Storage) | Snapdragon 8 Gen 1 Mobile Processor | 120W FlashCharge | Upto 12 Months No Cost EMI" },
                    { 32, 3, false, 43, "narzo 50", 200.0, "realme narzo 50 (Speed Blue, 4GB RAM+64GB Storage) Helio G96 Processor | 50MP AI Triple Camera | 120Hz Ultra Smooth Display" },
                    { 31, 3, true, 345, "iQOO 9 SE", 123.0, "iQOO 9 SE 5G (Sunset Sierra, 8GB RAM, 128GB Storage) | Qualcomm Snapdragon 888 | 66W Flash Charge" },
                    { 30, 2, true, 123, "Women's Polyester A-Line Above The Knee Dress", 15.0, "Lymio Women's Polyester A-Line Above The Knee Dress" },
                    { 29, 2, false, 143, "A-line Long Gown", 120.0, "Royal Export Women's Heavy Net A-line Long Gown" },
                    { 28, 2, true, 543, "Knee-Long Dress", 54.0, "A.T.U.N Girl's Synthetic Bubble Hem Knee-Long Dress (GDRS TOD SFY_Amber 2_2-3 YR)" },
                    { 27, 2, false, 21, "Girls' Dress", 24.0, "Bonnie Jean Little Girls' Dress Sweater with Sequin Trim to Allover Sequin Skirt" },
                    { 26, 2, false, 125, "Baby Tight", 45.0, "Jefferies Socks Microfiber Rhumba Baby Tight White/White, 6-18 Months" },
                    { 25, 2, true, 231, "Pack Eyelet Lace Trim And Lace Trim Sock", 35.0, "Jefferies Socks 2 Pack Eyelet Lace Trim And Lace Trim Sock - White/White, 12-24 Months" },
                    { 24, 2, false, 235, "Girl's Easter Dress", 15.0, "Bonnie Jean Girl's Easter Dress - Yellow Bunny Smocked Dress for Baby Toddler and Little Girls" },
                    { 23, 2, true, 345, "Pant for Men", 21.0, "TADEO Stylish Cargo Pant for Men | Army Print Pant for Women | Unisex Joggers Cammando Pants for Boys & Girls | Regular Fit Militry Jeans for Man with Multi Pockets" },
                    { 22, 2, true, 76, "Women's Slim Jeans", 132.0, "Van Heusen Women's Slim Jeans" },
                    { 21, 2, true, 234, "Relaxed Jeans", 42.0, "Ben Martin Men's Relaxed Jeans" },
                    { 20, 2, false, 567, "Regular T-Shirt", 23.0, "Puma Men's Regular T-Shirt" },
                    { 71, 5, false, 154, "2 Door TV Cabinet with Drawers", 544.0, "Amazon Brand - Solimo Cygnus Engineered Wood 2 Door TV Cabinet with Drawers ( Brown, Sienna Cherry)" },
                    { 72, 5, true, 325, "Hand Made Jute Throw Cushion Covers", 299.0, "AEROHAVEN™ Set of 5 Decorative Hand Made Jute Throw/Pillow Cushion Covers - (16 X 16 INCHES)" }
                });

            migrationBuilder.InsertData(
                table: "FeedBacks",
                columns: new[] { "Id", "FeedBackDescription", "ProductsId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "Realy good", 1, 5.0, null },
                    { 2, "Bad", 2, 1.0, null },
                    { 3, "Amazing", 4, 5.0, null },
                    { 4, "Cool", 6, 5.0, null },
                    { 5, "Butifull", 9, 5.0, null },
                    { 6, "Good one", 20, 4.0, null },
                    { 7, "Nice", 34, 4.0, null },
                    { 8, "Amazing", 35, 4.0, null },
                    { 9, "Fantastic", 41, 4.0, null },
                    { 10, "look very good", 42, 4.0, null },
                    { 11, "nice one", 44, 5.0, null },
                    { 12, "good one", 49, 5.0, null },
                    { 13, "realy amazing", 56, 5.0, null },
                    { 14, "butifull", 59, 5.0, null },
                    { 15, "good", 61, 5.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_UserId",
                table: "Favourite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_ProductId",
                table: "FavouriteProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_ProductsId",
                table: "FeedBacks",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_CartId",
                table: "PaymentTypes",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "FavouriteProduct");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
