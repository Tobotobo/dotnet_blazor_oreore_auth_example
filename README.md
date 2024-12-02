# dotnet_blazor_oreore_auth_example

## 概要
* 以下の記事を参考にオレオレ ログイン機能を付ける
* 追加で以下の機能を付ける
  * 未ログインでアクセスするとログインページに飛ぶ
  * 未ログインではログインページしか表示せず、サイドバーも表示しない
  * 右上にログアウトを追加。ログアウトするとログインページに飛ぶ

.NET 8 の Blazor にオレオレ ログイン機能を付けよう  
https://zenn.dev/microsoft/articles/aspnetcore-blazor-dotnet8-tryaddauth


## 詳細

```
dotnet new blazor --interactivity Server -n DotnetBlazorAuthExample -o .
```
