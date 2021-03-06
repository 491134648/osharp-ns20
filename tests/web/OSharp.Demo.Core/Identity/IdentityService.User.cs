﻿// -----------------------------------------------------------------------
//  <copyright file="IdentityService.User.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2017 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-11-16 14:54</last-date>
// -----------------------------------------------------------------------

using System.Linq;

using OSharp.Demo.Identity.Entities;


namespace OSharp.Demo.Identity
{
    public partial class IdentityService
    {
        /// <summary>
        /// 获取 用户信息查询数据集
        /// </summary>
        public IQueryable<User> Users
        {
            get { return _userRepository.Query(); }
        }
    }
}