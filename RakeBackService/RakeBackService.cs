using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;

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

        public ResponseBase<UserInfo> AddUserInfo(UserInfo info, string operateLoginId)
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

                try
                {
                    var sb = new StringBuilder();
                    sb.Append("新增用户信息为：");
                    sb.Append(string.Format("【userName={0}】", info.UserName));
                    sb.Append(string.Format("【userPhone={0}】", info.UserPhone));
                    sb.Append(string.Format("【userPwd={0}】", info.UserPwd));
                    sb.Append(string.Format("【remark={0}】", info.Remark));
                    sb.Append(string.Format("【roleId={0}】", info.RoleId));
                    sb.Append(string.Format("【loginId={0}】", info.LoginId));
                    sb.Append(string.Format("【createBank={0}】", info.CreateBank));
                    sb.Append(string.Format("【branchBank={0}】", info.BranchBank));
                    sb.Append(string.Format("【branchBankZH={0}】", info.BranchBankZH));
                    sb.Append(string.Format("【bankNumber={0}】", info.BankNumber));
                    sb.Append(string.Format("【belongTo={0}】", info.BelongTo));
                    sb.Append(string.Format("【api={0}】", info.Api));
                    sb.Append(string.Format("【isUpdatePass={0}】", info.IsUpdatePass));
                    sb.Append(string.Format("【Iseable={0}】", info.Iseable));

                    var operInfo = BLL.UserInfo.GetByLoginId(operateLoginId);
                    if (operInfo != null)
                    {
                        //加入操作日志
                        BLL.OperInfo.Add(operInfo.UserId, operInfo.UserName, sb.ToString());
                    }
                }
                catch (Exception) { }

            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }
        public ResponseBase<UserInfo> UpdateUserInfo(UserInfo info, string operateLoginId)
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
        public ResponseBase<bool> DelUserInfo(int id, string operateLoginId)
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


                try
                {
                    var operInfo = BLL.UserInfo.GetByLoginId(operateLoginId);
                    if (operInfo != null)
                    {
                        var sb = new StringBuilder();
                        sb.AppendFormat("删除客户ID:{0},客户姓名:{1}", user.UserId, user.UserName);

                        //加入操作日志
                        BLL.OperInfo.Add(operInfo.UserId, operInfo.UserName, sb.ToString());
                    }

                }
                catch (Exception)
                {
                }

            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }

        public ResponseBase<bool> AddRakeBack(OrderInfo info, string operateLoginId)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.OrderInfo.Add(info) <= 0)
                    throw new Exception("添加失败");

                response.Content = true;
                response.IsSuccess = true;

                try
                {
                    //加入订单日志
                    BLL.FlowInfo.AddFlow("新单创建成功", "新单", info.OrderId);
                }
                catch (Exception) { }


                try
                {
                    var sb = new StringBuilder();
                    sb.Append("创建返佣新单，");
                    sb.Append(string.Format("订单号为：{0}，", info.OrderId));
                    sb.Append(string.Format("客户为：{0}", info.UserName));

                    var operInfo = BLL.UserInfo.GetByLoginId(operateLoginId);
                    if (operInfo != null)
                    {
                        //加入操作日志
                        BLL.OperInfo.Add(operInfo.UserId, operInfo.UserName, sb.ToString());
                    }
                }
                catch (Exception) { }


            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<bool> UpdateOrderInfo(OrderInfo info, string operateLoginId)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.OrderInfo.Edit(info) <= 0)
                    throw new Exception("更新失败");

                response.Content = true;
                response.IsSuccess = true;

                if (info.OrderStatus.Equals("" + (int)OrderStatus.Audited))
                {
                    try
                    {
                        //加入订单日志
                        BLL.FlowInfo.AddFlow("通过审核", "已审核", info.OrderId);
                    }
                    catch (Exception) { }
                }


                try
                {
                    //审核通过
                    if (info.OrderStatus.Equals("" + (int)OrderStatus.Audited))
                    {
                        var operInfo = BLL.UserInfo.GetByLoginId(operateLoginId);
                        if (operInfo != null)
                        {
                            var sb = new StringBuilder();
                            sb.AppendFormat("{0}通过返佣单号为{1}的审核", operInfo.UserName, info.OrderId);

                            //加入操作日志
                            BLL.OperInfo.Add(operInfo.UserId, operInfo.UserName, sb.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                }


            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<bool> DelOrderInfo(OrderInfo info,string operateLoginId)
        {
            var response = new ResponseBase<bool>();
            try
            {
                if (BLL.OrderInfo.Del(info) <= 0)
                    throw new Exception("删除失败");

                response.Content = true;
                response.IsSuccess = true;

                try
                {
                    //加入订单日志
                    BLL.FlowInfo.AddFlow("删除", "已审核", info.OrderId);
                }
                catch (Exception) { }



                try
                {
                    var operInfo = BLL.UserInfo.GetByLoginId(operateLoginId);
                    if (operInfo != null)
                    {
                        var sb = new StringBuilder();
                        sb.AppendFormat("{0} 删除返佣单号为 {1} 的订单", operInfo.UserName, info.OrderId);

                        //加入操作日志
                        BLL.OperInfo.Add(operInfo.UserId, operInfo.UserName, sb.ToString());
                    }

                }
                catch (Exception)
                {
                }
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

                Console.WriteLine("login:"+loginCode +" "+DateTime.Now.ToString());
                try
                {
                    //加入操作日志
                    BLL.OperInfo.Add(user.UserId, user.UserName, "登陆系统");
                }
                catch (Exception) { }

            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<bool> OutLogin(int userId, string userName)
        {
            var response = new ResponseBase<bool>();
            try
            {
                response.Content = true;
                response.IsSuccess = true;

                try
                {
                    //加入操作日志
                    BLL.OperInfo.Add(userId, userName, "注销登陆");
                }
                catch (Exception) { }

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

                if (user.UserPwd.Equals(oldPwd) == false)
                    throw new Exception("原密码不匹配");

                user.UserPwd = newPwd;
                user.IsUpdatePass = "1";

                if (BLL.UserInfo.Edit(user) <= 0)
                    throw new Exception("修改失败");

                response.Content = true;
                response.IsSuccess = true;


                try
                {
                    //加入操作日志
                    BLL.OperInfo.Add(user.UserId, user.UserName, "修改密码");
                }
                catch (Exception)
                {
                }

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

                response.Content = new Tuple<string, string>(count, amount);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }


        public ResponseBase<IList<OperInfo>> GetOperateLog(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            var response = new ResponseBase<IList<OperInfo>>();
            try
            {
                response.Count = BLL.OperInfo.Get(0, 0, conditions).Count;
                response.Content = BLL.OperInfo.Get(pageSize, pageIndex, conditions);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
            }
            return response;
        }
        public ResponseBase<IList<FlowInfo>> GetOrderLog(int pageSize, int pageIndex, Dictionary<string, string> conditions)
        {
            var response = new ResponseBase<IList<FlowInfo>>();
            try
            {
                response.Count = BLL.FlowInfo.Get(0, 0, conditions).Count;
                response.Content = BLL.FlowInfo.Get(pageSize, pageIndex, conditions);
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
