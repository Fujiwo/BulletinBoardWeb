# BulletinBoardWeb

最初に Migrations を削除し、コマンドラインで下記を実行

dotnet ef migrations add InitialCreate
dotnet ef database update

適宜、接続文字列を変更

appsettings.json
    "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=BulletinBoard;Integrated Security=True;"
