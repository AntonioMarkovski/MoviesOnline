using System;
using System.Collections.Generic;
using System.Text;
using Movie.Entities;

namespace Movie.Repository.Interfaces
{
    public interface IWishlistRepository
    {
        void Add(Wishlist wishlist);
        void Edit(Wishlist wishlist);
        void Delete(int id);
        IEnumerable<Wishlist> GetAllWishlists();
        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByMovieId(int movieID);
        void DeleteByMovieId(int movieID);

        // Important
        IEnumerable<Wishlist> GetAllWishlistByUserId(string userId);
    }
}