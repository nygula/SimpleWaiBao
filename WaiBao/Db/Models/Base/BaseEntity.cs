using SqlSugar;

namespace WaiBao.Db.Models;

/// <summary>
/// 数据库实体基类
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// 主键ID
    /// </summary>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    /// <summary>
    /// 标识版本字段,用于乐观锁
    /// </summary>
    [SqlSugar.SugarColumn(IsEnableUpdateVersionValidation = true)]
    public long Ver { get; set; }
}
