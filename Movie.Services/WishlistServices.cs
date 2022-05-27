using System;
using System.Collections.Generic;
using System.Text;
using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class WishlistServices : IWishlistServices
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistServices(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }
        public void Add(Wishlist wishlist)
        {
            _wishlistRepository.Add(wishlist);
        }

        public void Delete(int id)
        {
            _wishlistRepository.Delete(id);
        }

        public void DeleteByMovieId(int movieID)
        {
            _wishlistRepository.DeleteByMovieId(movieID);
        }

        public void Edit(Wishlist wishlist)
        {
            _wishlistRepository.Edit(wishlist);
        }

        public IEnumerable<Wishlist> GetAllWishlistByUserId(string userId)
        {
            var result = _wishlistRepository.GetAllWishlistByUserId(userId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _wishlistRepository.GetAllWishlists();
            return result;
        }

        public Wishlist GetWishlistByMovieId(int movieID)
        {
            var result = _wishlistRepository.GetWishlistByMovieId(movieID);
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _wishlistRepository.GetWishlistById(id);
            return result;
        }
    }
}
