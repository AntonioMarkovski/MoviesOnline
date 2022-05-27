using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    DateBirth = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 1500, nullable: true),
                    Language = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 100, nullable: true),
                    Popularity = table.Column<bool>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    DateBirth = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Year = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ActorNames = table.Column<string>(nullable: true),
                    DirectorName = table.Column<string>(maxLength: 100, nullable: true),
                    DirectorId = table.Column<int>(nullable: false),
                    Categories = table.Column<string>(maxLength: 100, nullable: true),
                    PublisherId = table.Column<int>(nullable: false),
                    PublisherName = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true),
                    WatchTime = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    CountryOfOrigin = table.Column<string>(maxLength: 50, nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 1500, nullable: true),
                    TrailerURL = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    Popularity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    ActorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieID, x.ActorID });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => new { x.MovieID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_MovieCategories_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Country", "DateBirth", "Gender", "Language", "Name", "PhotoURL", "Popularity", "ShortDescription" },
                values: new object[,]
                {
                    { 12, "Los Angeles, California", "November 11, 1974", "Male", "English", "Leonardo Di Caprio", "LeonardoDiCaprioPhoto.jfif", true, "Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies." },
                    { 16, "Pittsburgh, Pennsylvania, USA", "May 1, 1972", "Female", "English", "Julie Benz", "JulieBenzPhoto.jpg", false, "Julie Benz was born in Pittsburgh, Pennsylvania, USA on May 1, 1972. Julie's father is a Pittsburgh surgeon and her mother is a figure skater. The family settled in nearby Murrysville, when Julie was two, and she started ice skating at age three." },
                    { 15, "New York City, New York, USA", "October 5, 1983", "Male", "English", "Jesse Eisenberg", "JesseEisenbergPhoto.jpg", false, "Curly haired and with a fast-talking voice, Jesse Eisenberg is a movie actor, known for his Academy Award nominated role as Mark Zuckerberg in the 2010 film The Social Network. He has also starred in the films The Squid and the Whale, Adventureland, The Education of Charlie Banks, 30 Minutes or Less, Now You See Me and Zombieland." },
                    { 14, "Thal, Styria, Austria", "July 30, 1947", "Male", "English", "Arnold Schwarcneger", "ArnoldSchwarcnegerPhoto.jpg", false, "With an almost unpronounceable surname and a thick Austrian accent, who would have ever believed that a brash, quick talking bodybuilder from a small European village would become one of Hollywood's biggest stars, marry into the prestigious Kennedy family, amass a fortune via shrewd investments and one day be the Governor of California!" },
                    { 13, "Syracuse, New York, USA", "July 3, 1962", "Male", "English", "Tom Cruse", "TomCrusePhoto.jpg", false, "In 1976, if you had told fourteen-year-old Franciscan seminary student Thomas Cruise Mapother IV that one day in the not too distant future he would be Tom Cruise, one of the top 100 movie stars of all time, he would have probably grinned and told you that his ambition was to join the priesthood. Nonetheless, this sensitive, deeply religious youngster who was born in 1962 in Syracuse, New York, was destined to become one of the highest paid and most sought after actors in screen history." },
                    { 19, "Chicago, Illinois, USA", "February 24, 1966", "Male", "English", "Billy Zane", "BillyZanePhoto.jpg", false, "William George Zane, better known as Billy Zane, was born on February 24, 1966 in Chicago, Illinois, to Thalia (Colovos) and William Zane, both of Greek ancestry. His parents were amateur actors and managed a medical technical school. Billy has an older sister, actress and singer Lisa Zane. Billy was bitten by the acting bug early on." },
                    { 11, "New York City", "July 6, 1946", "Male", "English", "Sylvester Stallone", "SylvesterStallonePhoto.jpg", false, "Sylvester Stallone is a athletically built, dark-haired American actor/screenwriter/director/producer, the movie fans worldwide have been flocking to see Stallone's films for over 40 years, making \"Sly\" one of Hollywood's biggest-ever box office draws." },
                    { 10, "Hammersmith, London, England, UK", "July 19, 1976", "Male", "English", "Benedict Cumberbatch", "BenedictCumberbatchPhoto.jpg", false, "Benedict Timothy Carlton Cumberbatch was born and raised in London, England. His parents, Wanda Ventham and Timothy Carlton (born Timothy Carlton Congdon Cumberbatch), are both actors. He is a grandson of submarine commander Henry Carlton Cumberbatch, and a great-grandson of diplomat Henry Arnold Cumberbatch CMG." },
                    { 9, "Los Angeles, California, USA", "December 4, 1949", "Male", "English", "Jeff Bridges", "JeffBridgesPhoto.jpg", false, "Jeffrey Leon Bridges was born on December 4, 1949 in Los Angeles, California, the son of well-known film and TV star Lloyd Bridges and his long-time wife Dorothy Dean Bridges (née Simpson). He grew up amid the happening Hollywood scene with big brother Beau Bridges. Both boys popped up, without billing, alongside their mother in the film The Company She Keeps (1951), and appeared on occasion with their famous dad on his popular underwater TV series Sea Hunt (1958) while growing up." },
                    { 8, "Chicago, Illinois, USA", "March 11, 1969", "Male", "English", "Terrence Howard", "TerrenceHowardPhoto.jfif", false, "Terrence Howard was born in Chicago, Illinois, to Anita Jeanine Williams (née Hawkins) and Tyrone Howard. He was raised in Cleveland, Ohio. His love for acting came naturally, through summers spent with his great-grandmother, New York stage actress Minnie Gentry. He later began his acting career after being discovered on a New York City street by a casting director. Soon, he followed with several notable TV appearances on shows such as Living Single (1993), NYPD Blue (1993) and Soul Food (2000). He became well known for his lead role in the UPN TV series Sparks (1996)." },
                    { 7, "Los Angeles, California, USA", "September 27, 1972", "Female", "English", "Gwyneth Paltrow", "GwynethPaltrowPhoto.jpg", false, "A tall, wafer thin, delicate beauty, Gwyneth Kate Paltrow was born in Los Angeles, the daughter of noted producer and director Bruce Paltrow and Tony Award-winning actress Blythe Danner. Her father was from a Jewish family, while her mother is of mostly German descent. When Gwyneth was eleven, the family moved to Massachusetts, where her father began working in summer stock productions in the Berkshires." },
                    { 6, "Harlesden, London, England, UK", "May 27, 1971", "Male", "English", "Paul Bettany", "PaulBettanyPhoto.jpg", false, "Paul Bettany is an English actor. He first came to the attention of mainstream audiences when he appeared in the British film Gangster No. 1 (2000), and director Brian Helgeland's film A Knight's Tale (2001). He has gone on to appear in a wide variety of films, including A Beautiful Mind (2001), Master and Commander: The Far Side of the World (2003), Dogville (2003), Wimbledon (2004), and the adaptation of the novel The Da Vinci Code (2006). He is also known for his voice role as J.A.R.V.I.S. in the Marvel Cinematic Universe, specifically the films Iron Man (2008), Iron Man 2 (2010), The Avengers (2012), Iron Man 3 (2013), and Avengers: Age of Ultron (2015), in which he also portrayed the Vision, for which he garnered praise. He reprised his role as the Vision in Captain America: Civil War (2016)." },
                    { 5, "Boston, Massachusetts, USA", "April 2, 1962", "Male", "English", "Clark Gregg", "ClarkGreggPhoto.jpg", false, "Clark Gregg was born on April 2, 1962 in Boston, Massachusetts, USA as Robert Clark Gregg. He is an actor and director, known for The Avengers (2012), Agents of S.H.I.E.L.D. (2013) and The New Adventures of Old Christine (2006)." },
                    { 4, "Queens, New York City, New York, USA", "October 19, 1966", "Male", "English", "Jon Favreau", "JonFavreauPhoto.jpg", false, "The amiable, husky-framed actor with the tight, crinkly hair was born in Queens, New York on October 19, 1966, the only child of Madeleine (Balkoff), an elementary school teacher, and Charles Favreau, a special education teacher. His father has French-Canadian, German, and Italian ancestry, and his mother was from a Russian Jewish family. He attended the Bronx High School of Science before furthering his studies at Queens College in 1984. Dropping out just credits away from receiving his degree, Jon moved to Chicago where he focused on comedy and performed at several Chicago improvisational theaters, including the ImprovOlympic and the Improv Institute. He also found a couple of bit parts in films." },
                    { 3, "Sacramento, California, USA", "October 1, 1989", "Female", "English", "Brie Larson", "BrieLarsonPhoto.jpg", false, "Brie Larson has built an impressive career as an acclaimed television actress, rising feature film star and emerging recording artist. A native of Sacramento, Brie started studying drama at the early age of 6, as the youngest student ever to attend the American Conservatory Theater in San Francisco. She starred in one of Disney Channel's most watched original movies, Right on Track (2003), as well as the WB's Raising Dad (2001) and MGM's teen comedy Sleepover (2004) - all before graduating from middle school." },
                    { 2, "Washington, District of Columbia, USA", "December 21, 1948", "Male", "English", "Samuel L. Jackson", "SamuelJacksonPhoto.jpg", false, "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard with a Vengeance (1995), Unbreakable (2000), Shaft (2000), Formula 51 (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe." },
                    { 1, "Manhattan, New York City, New York, USA", "April 4, 1965", "Male", "English", "Robert Downey Jr.", "RobertDowneyJrPhoto.jpg", false, "Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry." },
                    { 20, "West Covina, California, USA", "October 16, 1958", "Male", "English", "Tim Robbins", "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY1200_CR151,0,630,1200_AL_.jpg", false, "Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981." },
                    { 21, "Newport Beach, California, USA", "July 9, 1957", "Male", "English", "Kelly McGillis", "https://m.media-amazon.com/images/M/MV5BMjA0OTg5ODY3Ml5BMl5BanBnXkFtZTgwNzkxOTU3MDI@._V1_.jpg", false, "Kelly Ann McGillis was born in Newport Beach, California, to Virginia Joan (Snell), a homemaker, and Donald Manson McGillis, a general practitioner of medicine. She has English, Welsh, Scots-Irish, and German ancestry." },
                    { 22, "Los Angeles, California", "November 11, 1974", "Male", "English", "Leonardo DiCaprio", "LeonardoDiCaprioPhoto.jfif", true, "Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies." },
                    { 17, "West Bromwich, West Midlands, England, UK", "March 3, 1973", "Male", "English", "Matthew Marsden", "MatthewMarsdenPhoto.jpg", false, "British actor/singer/Producer Matthew Marsden began his acting career in the UK and rose to stardom from his role on the long-running ITV series Coronation Street (1960), as Chris Collins. He left the show to pursue a music and acting career in the US and hasn't looked back since." },
                    { 18, "Reading, Berkshire, England, UK", "October 5, 1975", "Female", "English", "Kate Winslet", "KateWinsletPhoto.jpg", false, "Ask Kate Winslet what she likes about any of her characters, and the word \"ballsy\" is bound to pop up at least once. The British actress has made a point of eschewing straightforward pretty-girl parts in favor of more devilish damsels; as a result, she's built an eclectic resume that runs the gamut from Shakespearean tragedy to modern-day" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "81b0bb3e-9fc6-4ea7-8672-591c53fbd721", "admin", "ADMIN" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e75", "a0e347bd-de2b-43e9-8d70-37ad1fc4b568", "guest", "GUEST" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e74", "b8c8a31f-9d7c-4f01-a1d9-4653470f3e60", "editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "Test@test.com", true, false, null, "TEST@TEst.COM", "Test@TEST.COM", "AQAAAAEAACcQAAAAEGt6WgjoPqLN1f++oJ5mbuBwHCXrlQZTeYYoda8+Id/mDrvLz7GA/dsZZwk9JLpdag==", null, false, "", false, "Test@test.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 14, "Uncategorised" },
                    { 12, "Biography" },
                    { 11, "Sci-Fi" },
                    { 10, "Comedy" },
                    { 9, "Horror" },
                    { 8, "General" },
                    { 13, "Mystery" },
                    { 6, "Fantasy" },
                    { 5, "Drama" },
                    { 4, "Adventure" },
                    { 3, "Crime" },
                    { 2, "Action" },
                    { 1, "Fiction" },
                    { 7, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Country", "DateBirth", "Gender", "Name", "ShortDescription" },
                values: new object[,]
                {
                    { 16, "USA", "", "Male", "Louis Leterrier", "" },
                    { 17, "USA", "", "Male", "Taika Waititi", "" },
                    { 18, "USA", "", "Male", "Alan Taylor", "" },
                    { 19, "USA", "", "Male", "Joss Whedon", "" },
                    { 20, "USA", "", "Male", "Joe Johnston", "" },
                    { 24, "USA", "", "Male", "Scott Derrickson", "" },
                    { 22, "USA", "", "Male", "Peyton Reed", "" },
                    { 23, "USA", "", "Male", "Jon Watts", "" },
                    { 25, "USA", "", "Male", "Ryan Coogler", "" },
                    { 26, "Ireland", "", "Male", "Kenneth Branagh", "" },
                    { 27, "USA", "", "Male", "Kevin Feige", "" },
                    { 21, "USA", "", "Male", "James Gunn", "" },
                    { 14, "USA", "", "Male", "Jon Favreau", "" },
                    { 15, "USA", "", "Male", "Shane Black", "" },
                    { 12, "USA", "", "Male", "Anthony Russo", "" },
                    { 13, "USA", "", "Female", "Anna Boden", "" },
                    { 2, "USA", "July 6, 1946", null, "Sylvester Stallone", null },
                    { 3, "Kapusaksing, Ontario, Canada", "August 16, 1954", null, "James Cameron", null },
                    { 4, "North Shields, Northumberland, England, UK", "June 21, 1944", null, "Tony Scott", null },
                    { 5, "Ireland", "2012", null, "Pixar", null },
                    { 1, "Belfast, Northern Ireland, UK", "December 10, 1960", null, "Kenneth Branagh", null },
                    { 7, "Denver, Colorado, USA", "August 28, 1962", null, "David Fincher", null },
                    { 8, "Bergen, Norway", "May 19, 1967", null, "Morten Tyldum", null },
                    { 9, "Olten, Switzerland", "April 18, 1978", null, "Baran bo Odar", null },
                    { 10, "London, England, UK", "July 30, 1970", null, "Christopher Nolan", null },
                    { 11, "USA", "", "Male", "Joe Russo", "" },
                    { 6, "London, England, UK", "1958", null, "Iain Softley", null }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Gender", "Name", "ShortDescription", "Year" },
                values: new object[,]
                {
                    { 10, "USA", null, "Legendary Entertainment", null, "2000" },
                    { 1, "USA", null, "20th Century Fox", null, "1935" },
                    { 2, "Vancouver, British Columbia", null, "Lionsgate", null, "July 10, 1997" },
                    { 4, "USA", null, "Paramount Pictures", null, "1916" },
                    { 5, "Not known", null, "Cinema '84", null, "Not known" },
                    { 6, "USA", null, "United Artists", null, "1919" },
                    { 7, "USA", null, "Columbia Pictures", null, "1974" },
                    { 8, "Santa Monica, California", null, "Black Bear Pictures", null, "2011" },
                    { 9, "Germany", null, "Wiedemann & Berg Film Production", null, "2003" },
                    { 11, "USA", null, "Marvel Studios", null, "1996" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ActorNames", "Categories", "Country", "CountryOfOrigin", "DirectorId", "DirectorName", "Language", "PhotoURL", "Popularity", "PublisherId", "PublisherName", "Rating", "ReleaseDate", "ShortDescription", "Title", "TrailerURL", "WatchTime" },
                values: new object[,]
                {
                    { 2, "Leonardo Di Caprio,Kate Winslet,Billy Zane", "Drama, Romance", "USA, Mexico, Australia, Canada", null, 3, "James Cameron", "English, Swedish, Italian, French", "Titanic1997Image.jpg", false, 1, "20th Century Fox", 7.7999999999999998, "19 December 1997", "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, Ill-fated R.M.S Titanic.", "Titanic", null, "194min" },
                    { 1, "Sylvester Stallone,Julie Benz,Matthew Marsden", "Action, Thriller", "Germany,USA,Thailand", null, 2, "Sylvester Stallone", "English, Burmese, Thai", "Rambo2008Image.jpg", false, 2, "Lionsgate", 7.0, "25 January 2008", "In Thailand, John Rambo joins a group of mercenaries to venture into war-torn Burma, and rescue a group of Christian aid workers who were kidnapped by the ruthless local infantry unit.", "Rambo", null, "92min" },
                    { 3, "Tom Cruise,Tim Robbins,Kelly McGillis", "Action, Drama", "USA", null, 4, "Tony Scott", "English", "TopGun1986Image.jpg", false, 4, "Paramount Pictures", 6.9000000000000004, "16 May 1986", "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.", "Top Gun", null, "110min" },
                    { 10, "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Jeff Bridges,Terrence Howard,Paul Bettany,Clark Gregg", "Action, Adventure, Sci-Fi", "USA", null, 5, "Jon Favreau", "English", "IronMan.jpg", false, 4, "Paramount Pictures", 7.9000000000000004, "May 2, 2008", "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", "Iron Man", null, "126min" },
                    { 4, "Arnold Schwarcneger,Linda Hamilton,Michael Biehn", "Action, Sci-Fi", "UK", null, 3, "James Cameron", "English", "TheTerminator1984Image.jpg", false, 5, "Cinema '84", 8.0, "26 October 1984", "A human soldier is sent from 2029 to 1984 to stop an almost indestructible cyborg killing machine, sent from the same year, which has been programmed to execute a young woman whose unborn son is the key to humanity's future salvation.", "The Terminator", null, "107min" },
                    { 6, "Jesse Eisenberg,Andrew Garfield,Justin Timberlake,Rooney Mara", "Drama, Biography", "USA", null, 7, "David Fincher", "English, French", "TheSocialNetwork2010Image.png", false, 7, "Columbia Pictures", 7.7000000000000002, "1 October 2010 ", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "The Social Network", null, "120min" },
                    { 7, "Benedict Cumberbatch,Keira Knightley,Matthew Goode", "Drama, Biography, Thriller", "UK, USA", null, 8, "Morten Tyldum", "English, German", "TheImitationGame2014Image.jpg", false, 8, "Black Bear Pictures", 8.0, "25 December 2014", "During World War II, the English mathematical genius Alan Turing tries to crack the German Enigma code with help from fellow mathematicians.", "The Imitation Game", null, "114min" },
                    { 8, "Leonardo DiCaprio,Joseph Gordon-Levitt,Elliot Page,Ken Watanabe,Tom Hardy,Dileep Rao,Cillian Murphy,Tom Berenger,Marion Cotillard,Michael Caine", "Action, Adventure, Sci-Fi", "USA, UK", null, 10, "Christopher Nolan", "English, Japanese, French", "Inception2010Image.jpg", false, 10, "Legendary Entertainment", 8.8000000000000007, "16 July 2010", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "Inception", null, "148min" },
                    { 5, "Benedict Cumberbatch,Chiwetel Ejiofor,Rachel McAdams", "Action, Adventure, Fanstasy", "USA", null, 15, "Scott Derrickson", "English", "DrStrange.jpg", false, 11, "Marvel Studios", 7.5, "4 November, 2016", "While on a journey of physical and spiritual healing, a brilliant neurosurgeon is drawn into the world of the mystic arts.", "Doctor Strange", null, "115min" },
                    { 9, "Brie Larson,Samuel L. Jackson,Clark Gregg", "Action, Adventure, Sci-Fi", "USA", null, 4, "Anna Boden", "English", "CaptainMarvel.jpg", false, 11, "Marvel Studios", 6.7999999999999998, "March 8, 2019", "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.", "Captain Marvel", null, "123min" }
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
                name: "IX_MovieActors_ActorID",
                table: "MovieActors",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_CategoryID",
                table: "MovieCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PublisherId",
                table: "Movies",
                column: "PublisherId");
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
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
