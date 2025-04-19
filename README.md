# practice-csharp
C# の勉強用Repository

## Introduction
1. 自分の名前でブランチを作成して push します
    ```bash
    git switch -C <your_name>/master
    git push
    ```
2. 作業用ブランチを作成します
    ```bash
    git switch -C <your_name>/hogehoge
    ```
3. `practice-csharp.sln` or `practice-csharp.slnx` を Visual Studio で開きます
4. `implementation` プロジェクトのC#コードを TODO に沿って変更します
5. `Traits` が `TestOf=<class_name>` のテストを実行して Pass することを確認します
6. コミットします
    ```bash
    git add <edited_file>
    git commit -m "<wonderful_commit_message>"
    ```
7. `<your_name>/master` ブランチにPRを送ります
    ```bash
    git push
    ```
    GitHub から PR を作成

## 基本的な進め方 (With Visual Studio)
後で記載  
[基本的な進め方 (With VSCode)](#基本的な進め方-with-vscode) 参照

## 基本的な進め方 (With VSCode)
1. 作業用ブランチを作成
    ```bash
    git switch -C <your_name>/hogehoge
    ```
    
2. `implementation` ディレクトリ内の C# ソースコードを TODO に沿って編集
    1. ビルドできるかの確認
        ```bash
        dotnet build ./practice-csharp.sln
        ```
        
    2. テストを実行して Pass するかの確認
        ```bash
        dotnet test ./practice-csharp.sln --filter "TestOf=<class_name>"
        ```
3. コミット & プッシュ する
    ```bash
    git add <edited_file>
    git commit -m "<wonderful_commit_message>"
    git push
    ```
4. GitHub から PR を作成

## 新しいテストの取得
```bash
git fetch origin
git switch <your_name>/master
git rebase origin/master
git push --force-with-lease
```


