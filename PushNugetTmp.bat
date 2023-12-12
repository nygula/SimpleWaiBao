@echo off
chcp 65001 > nul

REM 打包 nuspec 文件
nuget.exe pack WaiBao/apiTmp.nuspec

REM 查找最新创建的 .nupkg 文件
for /f "delims=" %%a in ('dir /b /o-d /a-d *.nupkg') do (
    set "latest=%%a"
    goto :confirm
)

:confirm
REM 输出最新的 .nupkg 文件名
echo look: %latest%

REM 等待用户确认后再推送
pause

REM 从 apiKey.txt 文件中读取 API 密钥
set "apiKey="
for /f "usebackq delims=" %%a in ("apiKey.txt") do (
    set "apiKey=%%a"
    goto :push
)

:push
REM 检查是否成功读取到 API 密钥
if not defined apiKey (
    echo Failed to read API key from apiKey.txt.
    exit /b
)

REM 推送最新的 .nupkg 文件 http://localhost:6001/v3/index.json https://api.nuget.org/v3/index.json
REM nuget push "%latest%" -Source "https://api.nuget.org/v3/index.json" -ApiKey "%apiKey%"

nuget push "%latest%" -Source "http://localhost:6001/v3/index.json"
