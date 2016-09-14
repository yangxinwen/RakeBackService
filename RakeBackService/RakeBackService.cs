using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Threading;

namespace Services
{
    public class RakeBackService : IRakeBackService
    {

        public ResponseBase<IList<UserInfo>> GetNewRakeBack(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            var response = new ResponseBase<IList<UserInfo>>();
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

        public ResponseBase<IList<OrderInfo>> GetRakeBack(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            var response = new ResponseBase<IList<OrderInfo>>();
            try
            {
                response.Count = BLL.OrderInfo.Get(0, 0, conditions).Count;
                response.Content = BLL.OrderInfo.Get(pageSize, pageIndex, conditions);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }
        public ResponseBase<IList<RoleInfo>> GetRoleInfo()
        {
            var response = new ResponseBase<IList<RoleInfo>>();
            try
            {
                response.Content = BLL.RoleInfo.Get();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<IList<UserInfo>> GetUserInfo(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            var response = new ResponseBase<IList<UserInfo>>();
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

        public ResponseBase<UserInfo> AddUserInfo(UserInfo info)
        {
            var response = new ResponseBase<UserInfo>();
            try
            {
                var user = BLL.UserInfo.GetByLoginId(info.LoginId);
                if (user != null&& user.UserName!=null)
                    throw new Exception("已经存在该登陆账号，请从新设置！");

                if (BLL.UserInfo.Add(info) <= 0)
                    throw new Exception("添加失败");

                response.Content = info;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }
        public ResponseBase<UserInfo> UpdateUserInfo(UserInfo info)
        {
            var response = new ResponseBase<UserInfo>();
            try
            {
                if (BLL.UserInfo.Edit(info) <= 0)
                    throw new Exception("修改失败");
                
                response.Content = info;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }
        public ResponseBase<bool> DelUserInfo(int id)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.UserInfo.Del(id) <= 0)
                    throw new Exception("删除失败");

                response.Content = true;
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
