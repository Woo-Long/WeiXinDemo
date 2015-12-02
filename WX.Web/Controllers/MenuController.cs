﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using WX.Core;

namespace WX.Web.Controllers
{
    public class MenuController : Controller
    {
        private static readonly string APPID = WebConfigurationManager.AppSettings["WXAPPID"];
        private static readonly string APPSECRET = WebConfigurationManager.AppSettings["WXAPPSECRET"];
        private static readonly string TOKEN = WebConfigurationManager.AppSettings["WXTOKEN"];

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<ActionResult> CreateMenu(string jsonMenu)
        {
            await WXApi.RefreshAccessToken(APPID, APPSECRET);
            string content = await WXApi.CreateMenuAsync(WXApi.AccessToken, jsonMenu);
            return this.Content(content);
        }

        public ActionResult Index()
        {
            return base.View();
        }

    }
}

