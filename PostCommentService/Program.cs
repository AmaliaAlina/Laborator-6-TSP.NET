using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using ObjectWCF;
using AutoMapper;
using AutoMapper.Configuration;
using ObjectWCF.DTO;
using System.Threading.Tasks;
using PostComment.DTO;
using PostComment;
using PostComment.APIStatic;

namespace PostCommentService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServicePostComment : IPostComment
    {

        
        MapperConfiguration config;
        IMapper iMapper;
        public ServicePostComment()
        {
            
            // Configurare AutoMapper
            config = new MapperConfiguration(
            cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            iMapper = config.CreateMapper();
        }
        public void Cleanup()
        {
            Cleanup();
        }
        // Interfata ILoadData
        public List<PostDTO> GetAllPosts()
        {
            var lp = API.GetAllPosts();
            // Constructie lista PostDTO
            List<PostDTO> lpDto = new List<PostDTO>();
            lpDto = iMapper.Map<List<Post>, List<PostDTO>>(lp);
            return lpDto;
            #region Comentariu
            /* Cam acest lucru face AutoMapper.
           Construieste DTO din obiectele din server (EF)
            foreach (var p in lp)
            {
            PostDTO pd = new PostDTO()
            {
            PostId = p.PostId,
           Title = p.Title
            };
            if (p.Comments.Count > 0)
            {
            foreach (var c in p.Comments)
           {
            //pd.Comments = new List<CommentDTO>();
           CommentDTO cd = new CommentDTO();
           cd.CommentId = c.CommentId;
           cd.CommentText = c.CommentText;
           //cd.PostId = c.PostId;
           //cd.PostPostId = c.PostPostId;
           pd.Comments.Add(cd);
            }
            }
            lpDto.Add(pd);
            }
            return lpDto;
            */
            #endregion
        }
        public void DeleteComment(CommentDTO comment)
        {
            Comment comm = new Comment();
            // map CommentDTO la Comment
            comm = iMapper.Map<CommentDTO, Comment>(comment);
            API.DeleteComment(comm);
        }
        public PostDTO GetPostByTitle(string title)
        {
            Post post = API.GetPostByTitle(title);
            if (post != null)
            {
                PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
                return postDTO;
            }
            return null;
        }
        // IPost implementation methods
        public PostDTO GetPostById(int id)
        {
            Post post = API.GetPostById(id);
            // Reconstructie obiecte cunoscute in serviciu
            PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public PostDTO SubmitPost(PostDTO postDTO)
        {
            Post post = new Post();
            post = iMapper.Map<PostDTO, Post>(postDTO);
            post = API.SubmitPost(post);
            postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public PostDTO UpdatePost(PostDTO newPost)
        {
            Post post = iMapper.Map<PostDTO, Post>(newPost);
            post = API.UpdatePost(post);
            PostDTO postDTO = iMapper.Map<PostComment.Post, PostDTO>(post);
            return postDTO;
        }
        public int DeletePost(int postId)
        {
            return API.DeletePost(postId);
        }
        // IComment implementation method
        public CommentDTO GetCommentById(int id)
        {
            Comment comment = API.GetCommentById(id);
            CommentDTO commentDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commentDTO;
        }
        public CommentDTO SubmitComment(CommentDTO commentDTO)
        {
            Comment comment = iMapper.Map<CommentDTO, Comment>(commentDTO);
            comment = API.SubmitComment(comment);
            CommentDTO commDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commDTO;
        }
        public CommentDTO SubmitComment(int postId, CommentDTO commentDTO)
        {
            Comment comment = iMapper.Map<CommentDTO, Comment>(commentDTO);
            comment = API.SubmitComment(postId, comment);
            CommentDTO comm = iMapper.Map<Comment, CommentDTO>(comment);
            return comm;
        }
        public CommentDTO UpdateComment(CommentDTO oldCommentDTO,
       CommentDTO newCommentDTO)
        {
            Comment oldComment = iMapper.Map<CommentDTO, Comment>(oldCommentDTO);
            Comment newComment = iMapper.Map<CommentDTO, Comment>(newCommentDTO);
            Comment comment = API.UpdateComment(oldComment, newComment);
            CommentDTO comm = iMapper.Map<Comment, CommentDTO>(comment);
            return comm;
        }
        public bool DeleteComment(int commentId)
        {
            return API.DeleteComment(commentId);
        }
        List<PostDTO> ILoadData.GetAllPostsAndRelatedComments()
        {
            // redirectare !!!!????
            return GetAllPosts();
        }

        public bool AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Post UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        int IPostComment.DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        Post IPostComment.GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Post[] GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post[]> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public bool AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddCommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment UpdateComment(Comment newComment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> UpdateCommentAsync(PostComment.Comment newComment)
        {
            throw new NotImplementedException();
        }

        Comment IPostComment.GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetCommentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        bool IPost.DeletePost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
