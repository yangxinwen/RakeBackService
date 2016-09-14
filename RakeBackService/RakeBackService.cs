using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public class RakeBackService : IRakeBackService
    {
        public UserInfo sdfsdf(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            return new UserInfo();
        }

        public ResponseBase GetNewRakeBack(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            var response = new ResponseBase();
            try
            {
                response.Count = BLL.UserInfo.Get(0, 0, conditions).Count;
                response.Content = BLL.UserInfo.Get(pageSize, pageIndex, conditions);
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }
    }
}
