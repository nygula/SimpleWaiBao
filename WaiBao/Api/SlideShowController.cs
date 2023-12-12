namespace WaiBao.Api;

using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SqlSugar;
using System.Xml.Linq;
using Mapster;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using WaiBao.Db.Models;
using System.Collections.Generic;

/// <summary>
/// 幻灯片
/// </summary>
[Route("api/[controller]/[action]")]
//[ApiController]
public class SlideShowController : BaseApi
{
    /// <summary>
    /// 获取幻灯片列表
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> GetPage([FromBody] ReqPage model)
    {
        var pageInfo = await GetPage<SlideShowEntity>(model, !string.IsNullOrWhiteSpace(model.Key), a => a.Title.Contains(model.Key), a => a.Sort, OrderByType.Desc);
        return Success(pageInfo);
    }

    /// <summary>
    /// 保存幻灯片
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost, Authorize]
    public async Task<ApiResult> SaveSlideShow([FromBody] SlideShowEntity model)
    {
        var hasDuplicate = await db.Queryable<SlideShowEntity>()
        .Where(a => a.Title == model.Title && (model.Id <= 0 || a.Id != model.Id))
        .AnyAsync();
        await SaveAsync<SlideShowEntity>(model);
        return SuccessMsg("保存成功");
    }

    /// <summary>
    /// 删除幻灯片
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet, Authorize]
    public async Task<ApiResult> DelSlideShow(int id) => Success(await DeleteAsync<SlideShowEntity>(id), "删除幻灯片成功");
}
