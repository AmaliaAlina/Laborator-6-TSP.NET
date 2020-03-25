using PostComment;
using PostComment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ObjectWCF.DTO
{
    [ServiceContract]
    public interface IPostComment : IPost, IComment, ILoadData
    {
        Comment GetCommentById(int id);
        Post GetPostById(int id);
        int DeletePost(int id);
    }

}
