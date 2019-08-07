using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public class InMemoryPostService : IPostService
    {
        private readonly List<Post> _posts;

        public InMemoryPostService()
        {
            _posts = new List<Post>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {i}"
                });
            }
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await Task<List<Post>>.Run(() => _posts);
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await Task<Post>.Run(() => _posts.SingleOrDefault(x => x.Id == postId));
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            var exists = await GetPostByIdAsync(postToUpdate.Id) != null;

            if (!exists)
            {
                return false;
            }

            var index = _posts.FindIndex(x => x.Id == postToUpdate.Id);
            _posts[index] = postToUpdate;
            return true;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);

            if (post == null)
            {
                return false;
            }

            _posts.Remove(post);
            return true;
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            post.Id = Guid.NewGuid();
            var posts = await GetPostsAsync();
            posts.Add(post);
            return true;
        }

        public Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}