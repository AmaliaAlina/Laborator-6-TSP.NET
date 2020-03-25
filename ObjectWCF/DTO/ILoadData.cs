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
    public interface ILoadData
    {
        [OperationContract]
        List<PostDTO> GetAllPostsAndRelatedComments();
    }
}
