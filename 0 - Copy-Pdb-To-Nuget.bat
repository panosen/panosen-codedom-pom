dotnet restore

dotnet build --no-restore -c Debug

copy-pdb-to-nuget debug

copy Panosen.CodeDom.Pom.Engine\bin\Debug\net472\Panosen.CodeDom.Pom.dll D:\GithubWorkspace\harris2012\elasticsearch\packages\Panosen.CodeDom.Pom.1.0.0\lib\net472\Panosen.CodeDom.Pom.dll

copy Panosen.CodeDom.Pom.Engine\bin\Debug\net472\Panosen.CodeDom.Pom.Engine.dll D:\GithubWorkspace\harris2012\elasticsearch\packages\Panosen.CodeDom.Pom.Engine.1.0.0\lib\net472\Panosen.CodeDom.Pom.Engine.dll

pause