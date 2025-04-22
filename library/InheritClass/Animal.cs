namespace Library.InheritClass;

public abstract class Animal(string name)
{
    /// <summary>
    /// 名前を表す文字列を取得または設定します。
    /// </summary>
    public string Name { get; protected set; } = name;

    /// <summary>
    /// 動物の種類を表す文字列を取得します。
    /// </summary>
    public string Species => GetType().Name;

    /// <summary>
    /// 染色体に基づき、生物学上の性別を取得します。
    /// </summary>
    public required GeneticSex GeneticSex { get; init; }

    /// <summary>
    /// 動物の鳴き声を表す文字列を取得します。
    /// </summary>
    /// <param name="word">鳴き声に変換したい単語</param>
    public abstract string ConvertToCry(string word);

    public override string ToString()
    {
        return Name + ", " + Species;
    }
}
