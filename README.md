# Kogane Json Formatter

Json 形式の文字列を読みやすい形式に整形する機能

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        var json         = @"{""Id"":25,""Name"":""ピカチュウ""}";
        var readableJson = JsonFormatter.ToReadable( json );

        Debug.Log( readableJson );
    }
}
```

```json
{
    "Id":25,
    "Name":"ピカチュウ"
}
```

## 謝辞

* このリポジトリは下記のサイト様で公開されているソースコードを使用させていただいております
    * https://qiita.com/sh_akira/items/9829de2d76f8f36361aa
