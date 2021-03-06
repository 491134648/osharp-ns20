﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OSharp.Demo.Security;
using OSharp.Entity;
using OSharp.Filter;
using OSharp.Infrastructure;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("管理-权限安全")]
    [Area("Admin")]
    [Route("api/[area]/[controller]/[action]")]
    public class FunctionController : Controller
    {
        private readonly ISecurityContract _securityContract;

        /// <summary>
        /// 初始化一个<see cref="FunctionController"/>类型的新实例
        /// </summary>
        public FunctionController(ISecurityContract securityContract)
        {
            _securityContract = securityContract;
        }

        [Description("读取")]
        public IActionResult Read()
        {
            var page = _securityContract.Functions.ToPage(m => true,
                1,
                10000,
                new SortCondition[0],
                m => new
                {
                    Id = m.Id.ToString("N"),
                    m.Name,
                    m.Area,
                    m.Controller,
                    m.Action,
                    m.IsController,
                    m.IsAjax,
                    m.AccessType,
                    m.IsAccessTypeChanged,
                    m.AuditOperationEnabled,
                    m.AuditEntityEnabled,
                    m.CacheExpirationSeconds,
                    m.IsCacheSliding,
                    m.IsLocked
                });
            return Json(page.ToPageData());
        }
    }
}
