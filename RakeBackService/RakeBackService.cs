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
                if (user != null && user.UserName != null)
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
                var user = BLL.UserInfo.Get(id);
                if (user == null || user.UserName == null)
                    throw new Exception("找不到该账户信息！");

                user.Iseable = "0";
                if (BLL.UserInfo.Edit(user) <= 0)
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

        public ResponseBase<bool> AddRakeBack(OrderInfo info)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.OrderInfo.Add(info) <= 0)
                    throw new Exception("添加失败");

                response.Content = true;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<bool> UpdateOrderInfo(OrderInfo info)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.OrderInfo.Edit(info) <= 0)
                    throw new Exception("更新失败");

                response.Content = true;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<bool> DelOrderInfo(OrderInfo info)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.OrderInfo.Del(info) <= 0)
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

        public ResponseBase<UserInfo> Login(string loginCode, string password)
        {
            var response = new ResponseBase<UserInfo>();
            try
            {
                var user = BLL.UserInfo.Get(loginCode, password);
                if (user == null || user.UserName == null)
                    throw new Exception("用户名或密码不对");

                response.Content = user;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }

        public ResponseBase<bool> UpdateUserPassword(int userId, string oldPwd, string newPwd)
        {
            var response = new ResponseBase<bool>();
            try
            {
                var user = BLL.UserInfo.Get(userId);
                if (user == null || user.UserName == null)
                    throw new Exception("找不到该账户信息！");

                if(user.UserPwd.Equals(oldPwd)==false)
                    throw new Exception("原密码不匹配");

                user.UserPwd = newPwd;
                if (BLL.UserInfo.Edit(user) <= 0)
                    throw new Exception("修改失败");

                response.Content = true;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }

        public ResponseBase<Tuple<string, string>> GetAmountStatistics(Dictionary<string, string> conditions)
        {
            var response = new ResponseBase<Tuple<string, string>>();
            try
            {
                var count = BLL.OrderInfo.AmountStatisticsCount(conditions);
                var amount = BLL.OrderInfo.AmountStatistics(conditions);               

                response.Content = new Tuple<string,string>(count,amount);
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
