namespace WaiBao.Db.Models;

/// <summary>
/// 文件资源
/// </summary>
public class FileSourceEntity : BaseEntity
{
    public string Name { get; set; }
    /// <summary>
    /// 本地 路径
    /// </summary>
    public string Path { get; set; }
    public string Ur { get; set; }
    /// <summary>
    /// 0 图片  1 视频
    /// </summary>
    public Int16 SourceType { get; set; }
}
