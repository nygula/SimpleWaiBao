color 5
echo "if u install template error,pls connect QQ:1714227099"


color 3
REM 安装包 --force 是信任不安全源，http://localhost:6001/v3/index.json 是本地私有nuget服务
REM 如果不需要私有把 --nuget-source http://localhost:6001/v3/index.json 去掉 --forece 也去掉
dotnet new install KinghtNing.JustApi --force --nuget-source http://localhost:6001/v3/index.json

set /p OP=Please set your project name(for example:MyProject):

md .1YourProject

cd .1YourProject

dotnet new kinghtningapi -n %OP%

cd ../


echo "Create Successfully!!!! ^ please see the folder .1YourProject"

REM 删除包
dotnet new uninstall KinghtNing.JustApi


echo "Delete Template Successfully"

pause
