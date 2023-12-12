namespace WaiBao.Steup
{
    public static class CoresSteup
    {
        /// <summary>
        /// 自定义跨域设置
        /// 对这块知识不清晰的参考：https://www.cnblogs.com/dotnet261010/p/10177166.html
        /// </summary>
        /// <param name="app"></param>
        public static void UseMyCors(this WebApplication app)
        {
       //     app.AllowAnyOrigin()
       //.AllowCredentials();

            #region 特定来源
            // 设置只允许特定来源可以跨域
            //app.UseCors(options =>
            //{
            //    options.WithOrigins("http://localhost:3000", "http://127.0.0.1"); // 允许特定ip跨域
            //    options.AllowAnyHeader();
            //    options.AllowAnyMethod();
            //    options.AllowCredentials();
            //});
            #endregion
        }
    }
}
