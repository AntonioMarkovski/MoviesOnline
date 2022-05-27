using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Movie.Entities;

namespace Movie.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Wishlist> WishLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieID, ma.ActorID });
            modelBuilder.Entity<MovieActor>()
                .HasOne(m => m.Movie)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<MovieActor>()
                .HasOne(a => a.Actor)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(a => a.ActorID);

            modelBuilder.Entity<MovieCategory>()
                .HasKey(ma => new { ma.MovieID, ma.CategoryID });
            modelBuilder.Entity<MovieCategory>()
                .HasOne(m => m.Movie)
                .WithMany(a => a.MovieCategories)
                .HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<MovieCategory>()
                .HasOne(a => a.Category)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(a => a.CategoryID);


            #region Admin and Roles
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "Test123!";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                    Name = "editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                    Name = "guest",
                    NormalizedName = "GUEST"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Test@test.com",
                NormalizedUserName = "Test@TEST.COM",
                Email = "Test@test.com",
                NormalizedEmail = "TEST@TEst.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            #endregion

            #region Movies
            modelBuilder.Entity<Movies>().HasData(
                new Movies
                {
                    Id = 1,
                    Title = "Rambo",
                    Categories = "Action, Thriller",
                    ActorNames = "Sylvester Stallone,Julie Benz,Matthew Marsden",
                    Country = "Germany,USA,Thailand",
                    ShortDescription = "In Thailand, John Rambo joins a group of mercenaries to venture into war-torn Burma, and rescue a group of Christian aid workers who were kidnapped by the ruthless local infantry unit.",
                    Language = "English, Burmese, Thai",
                    DirectorId = 2,
                    DirectorName = "Sylvester Stallone",
                    PublisherId = 2,
                    PublisherName = "Lionsgate",
                    PhotoURL = "Rambo2008Image.jpg",
                    Rating = 7.0,
                    WatchTime = "92min",
                    ReleaseDate = "25 January 2008"
                },
                new Movies
                {
                    Id = 2,
                    Title = "Titanic",
                    ActorNames = "Leonardo Di Caprio,Kate Winslet,Billy Zane",
                    Categories = "Drama, Romance",
                    Country = "USA, Mexico, Australia, Canada",
                    ShortDescription = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, Ill-fated R.M.S Titanic.",
                    Language = "English, Swedish, Italian, French",
                    DirectorId = 3,
                    DirectorName = "James Cameron",
                    PublisherId = 1,
                    PublisherName = "20th Century Fox",
                    PhotoURL = "Titanic1997Image.jpg",
                    Rating = 7.8,
                    WatchTime = "194min",
                    ReleaseDate = "19 December 1997"
                },
                new Movies
                {
                    Id = 3,
                    Title = "Top Gun",
                    ActorNames = "Tom Cruise,Tim Robbins,Kelly McGillis",
                    Categories = "Action, Drama",
                    Country = "USA",
                    ShortDescription = "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.",
                    Language = "English",
                    DirectorId = 4,
                    DirectorName = "Tony Scott",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    PhotoURL = "TopGun1986Image.jpg",
                    Rating = 6.9,
                    WatchTime = "110min",
                    ReleaseDate = "16 May 1986"
                },
                new Movies
                {
                    Id = 4,
                    Title = "The Terminator",
                    ActorNames = "Arnold Schwarcneger,Linda Hamilton,Michael Biehn",
                    Categories = "Action, Sci-Fi",
                    Country = "UK",
                    ShortDescription = "A human soldier is sent from 2029 to 1984 to stop an almost indestructible cyborg killing machine, sent from the same year, which has been programmed to execute a young woman whose unborn son is the key to humanity's future salvation.",
                    Language = "English",
                    DirectorId = 3,
                    DirectorName = "James Cameron",
                    PublisherId = 5,
                    PublisherName = "Cinema '84",
                    PhotoURL = "TheTerminator1984Image.jpg",
                    Rating = 8.0,
                    WatchTime = "107min",
                    ReleaseDate = "26 October 1984"

                },
                new Movies
                {
                    Id = 5,
                    Title = "Doctor Strange",
                    Categories = "Action, Adventure, Fanstasy",
                    ShortDescription = "While on a journey of physical and spiritual healing, a brilliant neurosurgeon is drawn into the world of the mystic arts.",
                    DirectorId = 15,
                    DirectorName = "Scott Derrickson",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "115min",
                    ActorNames = "Benedict Cumberbatch,Chiwetel Ejiofor,Rachel McAdams",
                    Language = "English",
                    Rating = 7.5,
                    ReleaseDate = "4 November, 2016",
                    PhotoURL = "DrStrange.jpg",
                },
                new Movies
                {
                    Id = 6,
                    Title = "The Social Network",
                    ActorNames = "Jesse Eisenberg,Andrew Garfield,Justin Timberlake,Rooney Mara",
                    Categories = "Drama, Biography",
                    Country = "USA",
                    ShortDescription = "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.",
                    Language = "English, French",
                    DirectorId = 7,
                    DirectorName = "David Fincher",
                    PublisherId = 7,
                    PublisherName = "Columbia Pictures",
                    PhotoURL = "TheSocialNetwork2010Image.png",
                    Rating = 7.7,
                    WatchTime = "120min",
                    ReleaseDate = "1 October 2010 "
                },
                new Movies
                {
                    Id = 7,
                    Title = "The Imitation Game",
                    ActorNames = "Benedict Cumberbatch,Keira Knightley,Matthew Goode",
                    Categories = "Drama, Biography, Thriller",
                    Country = "UK, USA",
                    ShortDescription = "During World War II, the English mathematical genius Alan Turing tries to crack the German Enigma code with help from fellow mathematicians.",
                    Language = "English, German",
                    DirectorId = 8,
                    DirectorName = "Morten Tyldum",
                    PublisherId = 8,
                    PublisherName = "Black Bear Pictures",
                    PhotoURL = "TheImitationGame2014Image.jpg",
                    Rating = 8.0,
                    WatchTime = "114min",
                    ReleaseDate = "25 December 2014"
                },
                new Movies
                {
                    Id = 8,
                    Title = "Inception",
                    ActorNames = "Leonardo DiCaprio,Joseph Gordon-Levitt,Elliot Page,Ken Watanabe,Tom Hardy,Dileep Rao,Cillian Murphy,Tom Berenger,Marion Cotillard,Michael Caine",
                    Categories = "Action, Adventure, Sci-Fi",
                    Country = "USA, UK",
                    ShortDescription = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Language = "English, Japanese, French",
                    DirectorId = 10,
                    DirectorName = "Christopher Nolan",
                    PublisherId = 10,
                    PublisherName = "Legendary Entertainment",
                    PhotoURL = "Inception2010Image.jpg",
                    Rating = 8.8,
                    WatchTime = "148min",
                    ReleaseDate = "16 July 2010"
                },
                new Movies
                {
                    Id = 9,
                    Title = "Captain Marvel",
                    Categories = "Action, Adventure, Sci-Fi",
                    ShortDescription = "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.",
                    DirectorId = 4,
                    DirectorName = "Anna Boden",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "123min",
                    ActorNames = "Brie Larson,Samuel L. Jackson,Clark Gregg",
                    Language = "English",
                    Rating = 6.8,
                    ReleaseDate = "March 8, 2019",
                    PhotoURL = "CaptainMarvel.jpg",
                },
                new Movies
                {
                    Id = 10,
                    Title = "Iron Man",
                    ShortDescription = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                    DirectorId = 5,
                    DirectorName = "Jon Favreau",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    Country = "USA",
                    WatchTime = "126min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Jeff Bridges,Terrence Howard,Paul Bettany,Clark Gregg",
                    Language = "English",
                    Rating = 7.9,
                    ReleaseDate = "May 2, 2008",
                    PhotoURL = "IronMan.jpg",
                }
                );
            #endregion

            #region Actors
            modelBuilder.Entity<Actor>().HasData(

                new Actor
                {
                    Id = 1,
                    Name = "Robert Downey Jr.",
                    Country = "Manhattan, New York City, New York, USA",
                    DateBirth = "April 4, 1965",
                    Gender = "Male",
                    ShortDescription = "Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry.",
                    Language = "English",
                    PhotoURL = "RobertDowneyJrPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 2,
                    Name = "Samuel L. Jackson",
                    Country = "Washington, District of Columbia, USA",
                    DateBirth = "December 21, 1948",
                    Gender = "Male",
                    ShortDescription = "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard with a Vengeance (1995), Unbreakable (2000), Shaft (2000), Formula 51 (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe.",
                    Language = "English",
                    PhotoURL = "SamuelJacksonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 3,
                    Name = "Brie Larson",
                    Country = "Sacramento, California, USA",
                    DateBirth = "October 1, 1989",
                    Gender = "Female",
                    ShortDescription = "Brie Larson has built an impressive career as an acclaimed television actress, rising feature film star and emerging recording artist. A native of Sacramento, Brie started studying drama at the early age of 6, as the youngest student ever to attend the American Conservatory Theater in San Francisco. She starred in one of Disney Channel's most watched original movies, Right on Track (2003), as well as the WB's Raising Dad (2001) and MGM's teen comedy Sleepover (2004) - all before graduating from middle school.",
                    Language = "English",
                    PhotoURL = "BrieLarsonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 4,
                    Name = "Jon Favreau",
                    Country = "Queens, New York City, New York, USA",
                    DateBirth = "October 19, 1966",
                    Gender = "Male",
                    ShortDescription = "The amiable, husky-framed actor with the tight, crinkly hair was born in Queens, New York on October 19, 1966, the only child of Madeleine (Balkoff), an elementary school teacher, and Charles Favreau, a special education teacher. His father has French-Canadian, German, and Italian ancestry, and his mother was from a Russian Jewish family. He attended the Bronx High School of Science before furthering his studies at Queens College in 1984. Dropping out just credits away from receiving his degree, Jon moved to Chicago where he focused on comedy and performed at several Chicago improvisational theaters, including the ImprovOlympic and the Improv Institute. He also found a couple of bit parts in films.",
                    Language = "English",
                    PhotoURL = "JonFavreauPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 5,
                    Name = "Clark Gregg",
                    Country = "Boston, Massachusetts, USA",
                    DateBirth = "April 2, 1962",
                    Gender = "Male",
                    ShortDescription = "Clark Gregg was born on April 2, 1962 in Boston, Massachusetts, USA as Robert Clark Gregg. He is an actor and director, known for The Avengers (2012), Agents of S.H.I.E.L.D. (2013) and The New Adventures of Old Christine (2006).",
                    Language = "English",
                    PhotoURL = "ClarkGreggPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 6,
                    Name = "Paul Bettany",
                    Country = "Harlesden, London, England, UK",
                    DateBirth = "May 27, 1971",
                    Gender = "Male",
                    ShortDescription = "Paul Bettany is an English actor. He first came to the attention of mainstream audiences when he appeared in the British film Gangster No. 1 (2000), and director Brian Helgeland's film A Knight's Tale (2001). He has gone on to appear in a wide variety of films, including A Beautiful Mind (2001), Master and Commander: The Far Side of the World (2003), Dogville (2003), Wimbledon (2004), and the adaptation of the novel The Da Vinci Code (2006). He is also known for his voice role as J.A.R.V.I.S. in the Marvel Cinematic Universe, specifically the films Iron Man (2008), Iron Man 2 (2010), The Avengers (2012), Iron Man 3 (2013), and Avengers: Age of Ultron (2015), in which he also portrayed the Vision, for which he garnered praise. He reprised his role as the Vision in Captain America: Civil War (2016).",
                    Language = "English",
                    PhotoURL = "PaulBettanyPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 7,
                    Name = "Gwyneth Paltrow",
                    Country = "Los Angeles, California, USA",
                    DateBirth = "September 27, 1972",
                    Gender = "Female",
                    ShortDescription = "A tall, wafer thin, delicate beauty, Gwyneth Kate Paltrow was born in Los Angeles, the daughter of noted producer and director Bruce Paltrow and Tony Award-winning actress Blythe Danner. Her father was from a Jewish family, while her mother is of mostly German descent. When Gwyneth was eleven, the family moved to Massachusetts, where her father began working in summer stock productions in the Berkshires.",
                    Language = "English",
                    PhotoURL = "GwynethPaltrowPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 8,
                    Name = "Terrence Howard",
                    Country = "Chicago, Illinois, USA",
                    DateBirth = "March 11, 1969",
                    Gender = "Male",
                    ShortDescription = "Terrence Howard was born in Chicago, Illinois, to Anita Jeanine Williams (née Hawkins) and Tyrone Howard. He was raised in Cleveland, Ohio. His love for acting came naturally, through summers spent with his great-grandmother, New York stage actress Minnie Gentry. He later began his acting career after being discovered on a New York City street by a casting director. Soon, he followed with several notable TV appearances on shows such as Living Single (1993), NYPD Blue (1993) and Soul Food (2000). He became well known for his lead role in the UPN TV series Sparks (1996).",
                    Language = "English",
                    PhotoURL = "TerrenceHowardPhoto.jfif",
                    Popularity = false
                },
                new Actor
                {
                    Id = 9,
                    Name = "Jeff Bridges",
                    Country = "Los Angeles, California, USA",
                    DateBirth = "December 4, 1949",
                    Gender = "Male",
                    ShortDescription = "Jeffrey Leon Bridges was born on December 4, 1949 in Los Angeles, California, the son of well-known film and TV star Lloyd Bridges and his long-time wife Dorothy Dean Bridges (née Simpson). He grew up amid the happening Hollywood scene with big brother Beau Bridges. Both boys popped up, without billing, alongside their mother in the film The Company She Keeps (1951), and appeared on occasion with their famous dad on his popular underwater TV series Sea Hunt (1958) while growing up.",
                    Language = "English",
                    PhotoURL = "JeffBridgesPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 10,
                    Name = "Benedict Cumberbatch",
                    ShortDescription = "Benedict Timothy Carlton Cumberbatch was born and raised in London, England. His parents, Wanda Ventham and Timothy Carlton (born Timothy Carlton Congdon Cumberbatch), are both actors. He is a grandson of submarine commander Henry Carlton Cumberbatch, and a great-grandson of diplomat Henry Arnold Cumberbatch CMG.",
                    Popularity = false,
                    Country = "Hammersmith, London, England, UK",
                    Gender = "Male",
                    DateBirth = "July 19, 1976",
                    Language = "English",
                    PhotoURL = "BenedictCumberbatchPhoto.jpg"
                },
                new Actor
                {
                    Id = 11,
                    Name = "Sylvester Stallone",
                    ShortDescription = "Sylvester Stallone is a athletically built, dark-haired American actor/screenwriter/director/producer, the movie fans worldwide have been flocking to see Stallone's films for over 40 years, making \"Sly\" one of Hollywood's biggest-ever box office draws.",
                    Popularity = false,
                    Country = "New York City",
                    Gender = "Male",
                    DateBirth = "July 6, 1946",
                    Language = "English",
                    PhotoURL = "SylvesterStallonePhoto.jpg"
                },
                new Actor
                {
                    Id = 12,
                    Name = "Leonardo Di Caprio",
                    ShortDescription = "Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies.",
                    Popularity = true,
                    Country = "Los Angeles, California",
                    Gender = "Male",
                    DateBirth = "November 11, 1974",
                    Language = "English",
                    PhotoURL = "LeonardoDiCaprioPhoto.jfif"
                },
                new Actor
                {
                    Id = 13,
                    Name = "Tom Cruse",
                    ShortDescription = "In 1976, if you had told fourteen-year-old Franciscan seminary student Thomas Cruise Mapother IV that one day in the not too distant future he would be Tom Cruise, one of the top 100 movie stars of all time, he would have probably grinned and told you that his ambition was to join the priesthood. Nonetheless, this sensitive, deeply religious youngster who was born in 1962 in Syracuse, New York, was destined to become one of the highest paid and most sought after actors in screen history.",
                    Popularity = false,
                    Country = "Syracuse, New York, USA",
                    Gender = "Male",
                    DateBirth = "July 3, 1962",
                    Language = "English",
                    PhotoURL = "TomCrusePhoto.jpg"
                },
                new Actor
                {
                    Id = 14,
                    Name = "Arnold Schwarcneger",
                    ShortDescription = "With an almost unpronounceable surname and a thick Austrian accent, who would have ever believed that a brash, quick talking bodybuilder from a small European village would become one of Hollywood's biggest stars, marry into the prestigious Kennedy family, amass a fortune via shrewd investments and one day be the Governor of California!",
                    Popularity = false,
                    Country = "Thal, Styria, Austria",
                    Gender = "Male",
                    DateBirth = "July 30, 1947",
                    Language = "English",
                    PhotoURL = "ArnoldSchwarcnegerPhoto.jpg"

                },
                new Actor
                {
                    Id = 15,
                    Name = "Jesse Eisenberg",
                    ShortDescription = "Curly haired and with a fast-talking voice, Jesse Eisenberg is a movie actor, known for his Academy Award nominated role as Mark Zuckerberg in the 2010 film The Social Network. He has also starred in the films The Squid and the Whale, Adventureland, The Education of Charlie Banks, 30 Minutes or Less, Now You See Me and Zombieland.",
                    Popularity = false,
                    Country = "New York City, New York, USA",
                    Gender = "Male",
                    DateBirth = "October 5, 1983",
                    Language = "English",
                    PhotoURL = "JesseEisenbergPhoto.jpg"
                },
                new Actor
                {
                    Id = 16,
                    Name = "Julie Benz",
                    ShortDescription = "Julie Benz was born in Pittsburgh, Pennsylvania, USA on May 1, 1972. Julie's father is a Pittsburgh surgeon and her mother is a figure skater. The family settled in nearby Murrysville, when Julie was two, and she started ice skating at age three.",
                    Popularity = false,
                    Country = "Pittsburgh, Pennsylvania, USA",
                    Gender = "Female",
                    DateBirth = "May 1, 1972",
                    Language = "English",
                    PhotoURL = "JulieBenzPhoto.jpg"
                },
                new Actor
                {
                    Id = 17,
                    Name = "Matthew Marsden",
                    ShortDescription = "British actor/singer/Producer Matthew Marsden began his acting career in the UK and rose to stardom from his role on the long-running ITV series Coronation Street (1960), as Chris Collins. He left the show to pursue a music and acting career in the US and hasn't looked back since.",
                    Popularity = false,
                    Country = "West Bromwich, West Midlands, England, UK",
                    Gender = "Male",
                    DateBirth = "March 3, 1973",
                    Language = "English",
                    PhotoURL = "MatthewMarsdenPhoto.jpg"
                },
                new Actor
                {
                    Id = 18,
                    Name = "Kate Winslet",
                    ShortDescription = "Ask Kate Winslet what she likes about any of her characters, and the word \"ballsy\" is bound to pop up at least once. The British actress has made a point of eschewing straightforward pretty-girl parts in favor of more devilish damsels; as a result, she's built an eclectic resume that runs the gamut from Shakespearean tragedy to modern-day",
                    Popularity = false,
                    Country = "Reading, Berkshire, England, UK",
                    Gender = "Female",
                    DateBirth = "October 5, 1975",
                    Language = "English",
                    PhotoURL = "KateWinsletPhoto.jpg"
                },
                new Actor
                {
                    Id = 19,
                    Name = "Billy Zane",
                    ShortDescription = "William George Zane, better known as Billy Zane, was born on February 24, 1966 in Chicago, Illinois, to Thalia (Colovos) and William Zane, both of Greek ancestry. His parents were amateur actors and managed a medical technical school. Billy has an older sister, actress and singer Lisa Zane. Billy was bitten by the acting bug early on.",
                    Popularity = false,
                    Country = "Chicago, Illinois, USA",
                    Gender = "Male",
                    DateBirth = "February 24, 1966",
                    Language = "English",
                    PhotoURL = "BillyZanePhoto.jpg"
                },
                new Actor
                {
                    Id = 20,
                    Name = "Tim Robbins",
                    ShortDescription = "Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981.",
                    Popularity = false,
                    Country = "West Covina, California, USA",
                    Gender = "Male",
                    DateBirth = "October 16, 1958",
                    Language = "English",
                    PhotoURL = "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY1200_CR151,0,630,1200_AL_.jpg"
                },
                new Actor
                {
                    Id = 21,
                    Name = "Kelly McGillis",
                    ShortDescription = "Kelly Ann McGillis was born in Newport Beach, California, to Virginia Joan (Snell), a homemaker, and Donald Manson McGillis, a general practitioner of medicine. She has English, Welsh, Scots-Irish, and German ancestry.",
                    Popularity = false,
                    Country = "Newport Beach, California, USA",
                    Gender = "Male",
                    DateBirth = "July 9, 1957",
                    Language = "English",
                    PhotoURL = "https://m.media-amazon.com/images/M/MV5BMjA0OTg5ODY3Ml5BMl5BanBnXkFtZTgwNzkxOTU3MDI@._V1_.jpg"
                },
                new Actor
                {
                    Id = 22,
                    Name = "Leonardo DiCaprio",
                    ShortDescription = "Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies.",
                    Popularity = true,
                    Country = "Los Angeles, California",
                    Gender = "Male",
                    DateBirth = "November 11, 1974",
                    Language = "English",
                    PhotoURL = "LeonardoDiCaprioPhoto.jfif"
                });

            #endregion

            #region Category

            modelBuilder.Entity<Category>().HasData(
            new Category { ID = 1, Name = "Fiction" },
            new Category { ID = 2, Name = "Action" },
            new Category { ID = 3, Name = "Crime" },
            new Category { ID = 4, Name = "Adventure" },
            new Category { ID = 5, Name = "Drama" },
            new Category { ID = 6, Name = "Fantasy" },
            new Category { ID = 7, Name = "Thriller" },
            new Category { ID = 8, Name = "General" },
            new Category { ID = 9, Name = "Horror" },
            new Category { ID = 10, Name = "Comedy" },
            new Category { ID = 11, Name = "Sci-Fi" },
            new Category { ID = 12, Name = "Biography" },
            new Category { ID = 13, Name = "Mystery" },
            new Category { ID = 14, Name = "Uncategorised" }
            );

            #endregion

            #region Publishers

            modelBuilder.Entity<Publisher>().HasData(
              new Publisher
              {
                  Id = 1,
                  Name = "20th Century Fox",
                  Country = "USA",
                  Year = "1935"

              },
              new Publisher
              {
                  Id = 2,
                  Name = "Lionsgate",
                  Country = "Vancouver, British Columbia",
                  Year = "July 10, 1997"
              },
              new Publisher
              {
                  Id = 4,
                  Name = "Paramount Pictures",
                  Country = "USA",
                  Year = "1916"
              },
              new Publisher
              {
                  Id = 5,
                  Name = "Cinema '84",
                  Country = "Not known",
                  Year = "Not known"
              },
              new Publisher
              {
                  Id = 6,
                  Name = "United Artists",
                  Country = "USA",
                  Year = "1919"
              },
              new Publisher
              {
                  Id = 7,
                  Name = "Columbia Pictures",
                  Country = "USA",
                  Year = "1974"
              },
              new Publisher
              {
                  Id = 8,
                  Name = "Black Bear Pictures",
                  Country = "Santa Monica, California",
                  Year = "2011"
              },
              new Publisher
              {
                  Id = 9,
                  Name = "Wiedemann & Berg Film Production",
                  Country = "Germany",
                  Year = "2003"
              },
              new Publisher
              {
                  Id = 10,
                  Name = "Legendary Entertainment",
                  Country = "USA",
                  Year = "2000"
              },
              new Publisher
              {
                  Id = 11,
                  Name = "Marvel Studios",
                  Country = "USA",
                  Year = "1996"
              }
              );
            #endregion

            #region Directors

            modelBuilder.Entity<Director>().HasData(
            new Director
            {
                Id = 1,
                Name = "Kenneth Branagh",
                Country = "Belfast, Northern Ireland, UK",
                DateBirth = "December 10, 1960"

            },
            new Director
            {
                Id = 2,
                Name = "Sylvester Stallone",
                Country = "USA",
                DateBirth = "July 6, 1946"
            },
            new Director
            {
                Id = 3,
                Name = "James Cameron",
                Country = "Kapusaksing, Ontario, Canada",
                DateBirth = "August 16, 1954"
            },
            new Director
            {
                Id = 4,
                Name = "Tony Scott",
                Country = "North Shields, Northumberland, England, UK",
                DateBirth = "June 21, 1944"
            },
            new Director
            {
                Id = 5,
                Name = "Pixar",
                Country = "Ireland",
                DateBirth = "2012"

            },
            new Director
            {
                Id = 6,
                Name = "Iain Softley",
                Country = "London, England, UK",
                DateBirth = "1958"
            },
            new Director
            {
                Id = 7,
                Name = "David Fincher",
                Country = "Denver, Colorado, USA",
                DateBirth = "August 28, 1962"
            },
            new Director
            {
                Id = 8,
                Name = "Morten Tyldum",
                Country = "Bergen, Norway",
                DateBirth = "May 19, 1967"
            },
            new Director
            {
                Id = 9,
                Name = "Baran bo Odar",
                Country = "Olten, Switzerland",
                DateBirth = "April 18, 1978"
            },
            new Director
            {
                Id = 10,
                Name = "Christopher Nolan",
                Country = "London, England, UK",
                DateBirth = "July 30, 1970"
            },
            new Director
            {
                Id = 11,
                Name = "Joe Russo",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 12,
                Name = "Anthony Russo",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 13,
                Name = "Anna Boden",
                Country = "USA",
                Gender = "Female",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 14,
                Name = "Jon Favreau",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 15,
                Name = "Shane Black",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 16,
                Name = "Louis Leterrier",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 17,
                Name = "Taika Waititi",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 18,
                Name = "Alan Taylor",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 19,
                Name = "Joss Whedon",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 20,
                Name = "Joe Johnston",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 21,
                Name = "James Gunn",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 22,
                Name = "Peyton Reed",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 23,
                Name = "Jon Watts",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 24,
                Name = "Scott Derrickson",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 25,
                Name = "Ryan Coogler",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 26,
                Name = "Kenneth Branagh",
                Country = "Ireland",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 27,
                Name = "Kevin Feige",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            }
            );
            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
