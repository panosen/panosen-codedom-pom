@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Pom\bin\Release\Panosen.CodeDom.Pom.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Pom.Engine\bin\Release\Panosen.CodeDom.Pom.Engine.*.nupkg D:\LocalSavoryNuget\

pause