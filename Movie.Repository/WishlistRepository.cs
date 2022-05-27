using MoreLinq;
using Movie.Data;
using Movie.Entities;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _dataContext;

        public WishlistRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(Wishlist wishlist)
        {
            _dataContext.WishLists.Add(wishlist);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var wishlist = GetWishlistById(id);
            _dataContext.WishLists.Remove(wishlist);
            _dataContext.SaveChanges();
        }

        public void DeleteByMovieId(int Id)
        {
            // TODO: 
            var wishlist = GetWishlistByMovieId(Id);
            _dataContext.WishLists.Remove(wishlist);
            _dataContext.SaveChanges();
        }

        public void Edit(Wishlist wishlist)
        {
            _dataContext.WishLists.Update(wishlist);
            _dataContext.SaveChanges();
        }

        // Important
        public IEnumerable<Wishlist> GetAllWishlistByUserId(string userId)
        {
            // Use of MoreLinq Library from NuGet Package (DistinctBy)
            var result = _dataContext.WishLists.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.MovieId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _dataContext.WishLists.AsEnumerable();
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _dataContext.WishLists.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Wishlist GetWishlistByMovieId(int movieID)
        {
            var result = _dataContext.WishLists.FirstOrDefault(x => x.MovieId == movieID);
            return result;
        }
    }
}
