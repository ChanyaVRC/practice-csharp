# practice-csharp
C# の勉強用Repository

## 必要な環境
このリポジトリを使用するためには、以下の環境が必要です。

1. **.NET SDK**  
   - バージョン: 9.0 以上
   - ダウンロード: [.NET SDK ダウンロードページ](https://dotnet.microsoft.com/download)

2. **Git**  
   - バージョン: 最新の安定版
   - ダウンロード: [Git ダウンロードページ](https://git-scm.com/)

3. **Visual Studio** (任意)  
   - バージョン: 2022 Preview 以上
   - 必要なワークロード: 
     - .NET デスクトップ開発

4. **テキストエディタ** (任意)  
   - Visual Studio Code などのテキストエディタを使用すると便利です。

これらの環境を整えることで、C# のプロジェクトを効率的に開発・管理することができます。

## Introduction
1. issue を作成し、プロジェクトのメンバーに追加してもらいます。
   - issue のタイトルに「メンバー追加希望」と記載してください。
   - issue の本文に合言葉「CSharpRocks」を記載してください。
   - プロジェクト管理者が確認後、メンバーに追加されます。

2. 自分の名前で新しいブランチを作成し、リモートにプッシュします。
    ```bash
    git switch -C <your_name>/master
    git push
    ```
   - `<your_name>` を自分の名前に置き換えてください。
   - `master` ブランチは、あなたの作業の基盤となるブランチです。

## 基本的な進め方 (With Visual Studio)
1. 作業用ブランチを作成
    - 新しいブランチを作成し、作業を開始します。以下のコマンドを使用して、`<your_name>/hogehoge` という名前のブランチを作成します。
    ```bash
    git switch -C <your_name>/hogehoge
    ```
    - `<your_name>` をあなたの名前に置き換えてください。
    - `hogehoge` は作業内容に応じて適切な名前に変更してください。

2. Visual Studio で `exercises.slnx` ソリューションを開きます。
    - `exercises.slnx` は、プロジェクト全体を管理するソリューションファイルです。
    - Visual Studio を使用して、プロジェクトを開発します。

3. `implementation` プロジェクト内の C# コードを、TODO コメントに従って修正します。
    - `implementation` プロジェクトは、実際にコードを変更する場所です。
    - TODO コメントは、修正が必要な箇所を示しています。

4. ビルドとテストを行います。
    1. ビルドできるかの確認
        - プロジェクト全体が正しくビルドされるか確認します。Visual Studio のビルド機能を使用します。
        - ビルドが成功した場合、次のステップに進みます。

    2. テストを実行して Pass するかの確認
        - 変更したコードが正しく動作するか確認するために、テストを実行します。
        - `Traits` 属性が `TestOf=<class_name>` であるテストを実行し、すべてのテストが成功することを確認します。

5. コミット & プッシュ する
    - 変更をコミットし、リモートリポジトリにプッシュします。以下のコマンドを順に実行します。
    ```bash
    git add <edited_file>
    git commit -m "<wonderful_commit_message>"
    git push
    ```
    - `<edited_file>` には、編集したファイルのパスを指定します。
    - `<wonderful_commit_message>` には、変更内容を簡潔に説明するメッセージを記述します。

6. GitHub から PR を作成
    - GitHub 上でプルリクエストを作成し、コードレビューを依頼します。
    - プルリクエストは、他の開発者に変更を確認してもらうための手段です。
    - 必要に応じて、レビュアーを指定し、コメントを追加します。

## 基本的な進め方 (With VSCode)
1. 作業用ブランチを作成
    - 新しいブランチを作成し、作業を開始します。以下のコマンドを使用して、`<your_name>/hogehoge` という名前のブランチを作成します。
    ```bash
    git switch -C <your_name>/hogehoge
    ```
    - `<your_name>` をあなたの名前に置き換えてください。
    - `hogehoge` は作業内容に応じて適切な名前に変更してください。

2. `implementation` ディレクトリ内の C# ソースコードを TODO に沿って編集
    - `implementation` ディレクトリに移動し、TODO コメントに従ってコードを編集します。
    - 編集が完了したら、以下の手順でビルドとテストを行います。

    1. ビルドできるかの確認
        - プロジェクト全体が正しくビルドされるか確認します。以下のコマンドを実行します。
        ```bash
        dotnet build ./exercises.slnx
        ```
        - ビルドが成功した場合、次のステップに進みます。

    2. テストを実行して Pass するかの確認
        - 変更したコードが正しく動作するか確認するために、テストを実行します。以下のコマンドを使用します。
        ```bash
        dotnet test ./exercises.slnx --filter "TestOf=<class_name>"
        ```
        - `<class_name>` をテスト対象のクラス名に置き換えてください。
        - すべてのテストが成功することを確認します。

3. コミット & プッシュ する
    - 変更をコミットし、リモートリポジトリにプッシュします。以下のコマンドを順に実行します。
    ```bash
    git add <edited_file>
    git commit -m "<wonderful_commit_message>"
    git push
    ```
    - `<edited_file>` には、編集したファイルのパスを指定します。
    - `<wonderful_commit_message>` には、変更内容を簡潔に説明するメッセージを記述します。

4. GitHub から PR を作成
    - GitHub 上でプルリクエストを作成し、コードレビューを依頼します。
    - プルリクエストは、他の開発者に変更を確認してもらうための手段です。
    - 必要に応じて、レビュアーを指定し、コメントを追加します。

## 新しいテストの取得
```bash
git fetch origin
git switch <your_name>/master
git rebase origin/master
git push --force-with-lease
```
