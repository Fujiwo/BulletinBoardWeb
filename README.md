# BulletinBoardWeb

ASP.NET Core で画像ファイルをアップロードし、データベースに格納し、表示するサンプル。

* 2022年9月5日版
* .NET のバージョン、参照パッケージなどは BulletinBoardWeb.csproj を参照のこと。

## 主なソースコード

* Controllers
** HomeController.cs - トップ ページのコントローラー
** ImageFileController.cs - 画像ファイル アップロード用のコントローラー
* Models - モデル クラス群
** PostContext.cs
* ViewModels
** ImageFileUploadViewModel.cs - Upload.cshtml 用
* Views
** ImageFile
*** Index.cshtml - トップ ページ
*** Upload.cshtml - 画像ファイル アップロード ページ
*** Edit.cshtml - 画像ファイル編集ページ
*** Delete.cshtml - 画像ファイル削除ページ
* appsettings.json - 接続文字列などの設定
* Program.cs - Main

## 利用方法

1. 最初に Migrations を削除し、コマンドラインで下記を実行

>dotnet ef migrations add InitialCreate

>dotnet ef database update

2. 適宜、接続文字列を変更

appsettings.json

> "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=BulletinBoard;Integrated Security=True;"
