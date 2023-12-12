namespace WaiBao.Db.Models;

using System.ComponentModel.DataAnnotations;
using SqlSugar;

/// <summary>
/// 幻灯片
/// </summary>
public class SlideShowEntity : BaseEntity
{
    /// <summary>
    /// 标题
    /// </summary>
    [Required(ErrorMessage ="缺少标题")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 图片地址
    /// </summary>
    [SugarColumn(ColumnDataType = "varchar(500)"), Required(ErrorMessage = "不可缺少图片地址"), MaxLength(500, ErrorMessage = ("地址长度不可超过500位"))]
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// 点击链接
    /// </summary>
    public string? ActionUrl { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    public int Sort { get; set; }
}
