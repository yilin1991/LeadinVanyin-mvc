using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vanyin.Admin.Models;

namespace Vanyin.Admin.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
     
        public ActionResult Login()
        {
            return View();
        }

       
       
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            Leadin.BLL.AdminInfo bllAdmin = new Leadin.BLL.AdminInfo();

            if (ModelState.IsValid)
            {
                string _passowrd = Leadin.Common.DESEncrypt.Encrypt(loginViewModel.Password);


                System.Data.DataSet ds = bllAdmin.GetList("Account='" + loginViewModel.Accounts + "' and Pwd='" + _passowrd + "'");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session.Add("AdminID", ds.Tables[0].Rows[0]["Num"].ToString());
                    Session.Add("Accounts", ds.Tables[0].Rows[0]["Account"].ToString());

                    return RedirectToAction("Index", "Index");
                }
                else
                {

                    return Content("未找到该用户");
                    //ModelState.AddModelError("", "未找到该用户！");
                }
                //    var _response = adminManager.Verify(loginViewModel.Accounts, _passowrd);
                //    if (_response.Code == 1)
                //    {
                //        var _admin = adminManager.Find(loginViewModel.Accounts);
                //        Session.Add("AdminID", _admin.AdministratorID);
                //        Session.Add("Accounts", _admin.Accounts);
                //        _admin.LoginTime = DateTime.Now;
                //        _admin.LoginIP = Request.UserHostAddress;
                //        adminManager.Update(_admin);
                //        return RedirectToAction("Index", "Home");
                //    }
                //    else if (_response.Code == 2) ModelState.AddModelError("Accounts", _response.Message);
                //    else if (_response.Code == 3) ModelState.AddModelError("Password", _response.Message);
                //    else ModelState.AddModelError("", _response.Message);
            }
            else
            {
                //ModelState.AddModelError("", "用户名或密码不正确");
                return Content("用户名或密码不正确");
            }


            

        }

    }
}