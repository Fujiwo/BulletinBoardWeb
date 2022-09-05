# BulletinBoardWeb

* 2022年9月5日版
* .NET のバージョン、参照パッケージなどは BulletinBoardWeb.csproj を参照のこと。

## 利用方法

1. 最初に Migrations を削除し、コマンドラインで下記を実行

dotnet ef migrations add InitialCreate
dotnet ef database update

2. 適宜、接続文字列を変更

appsettings.json
    "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=BulletinBoard;Integrated Security=True;"

