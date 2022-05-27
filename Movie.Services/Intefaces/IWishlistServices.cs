using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Services.Interfaces
{
    public interface IWishlistServices
    {
        void Add(Wishlist wishlist);
        void Edit(Wishlist wishlist);
        void Delete(int id);
        void DeleteByMovieId(int movieID);

        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByMovieId(int movieID);

        IEnumerable<Wishlist> GetAllWishlists();
        IEnumerable<Wishlist> GetAllWishlistByUserId(string userId);
    }
}