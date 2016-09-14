using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace WebCommon
{
    public class WebControlBind : System.Web.UI.Page
    {
        /// <summary>
        /// DropDownList绑定
        /// </summary>
        /// <param name="drop">DropDownList控件</param>
        /// <param name="list">数据源</param>
        /// <param name="DataTextField">DropDownList显示文本</param>
        /// <param name="DataValueField">DropDownList值数据</param>
        public static void DropDownListBind(DropDownList drop, object list, string DataTextField, string DataValueField)
        {
            try
            {
                drop.DataSource = list;
                drop.DataTextField = DataTextField;
                drop.DataValueField = DataValueField;
                drop.DataBind();
                drop.Items.Insert(0, "请选择");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 检查权限
        /// 仅适用于本程序
        /// </summary>
        /// <param name="powerRemark"></param>
        /// <returns></returns>
        public bool CheckPower(string powerRemark, int isleft)
        {
            Model.UserInfo user = Session["userinfo"] as Model.UserInfo;
            string PowerStr = BLL.RoleInfo.Get(user.RoleId).PowerStr;

            IList<Model.PowerInfo> list = DAL.PowerInfo.Get(PowerStr, 0, isleft);

            foreach (var item in list)
            {
                if (item.Remark == powerRemark)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
