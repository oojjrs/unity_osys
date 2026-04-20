# com.oojjrs.osys

Unity에서 자주 쓰는 공용 유틸리티를 모아둔 로컬 패키지입니다.

## 패키지 정보

- Name: `com.oojjrs.osys`
- Version: `1.9.0`
- Unity: `6000.0`

## 구조

```text
Packages/src/
  package.json
  README.md
  Runtime/
    oojjrs.osys.asmdef
    BuildOptions.cs
    DictionaryExtensions.cs
    MyDictionaryListT.cs
    MyEquatableObjectT.cs
    MyHashQueue.cs
    MyRandom.cs
    NotifierBufferInterface.cs
    NotifierBufferT.cs
    ObjectPool.cs
    RegexHelper.cs
    StringExtensions.cs
    StringFormatHelper.cs
    TinyMath.cs
    XmlHelper.cs
```

## 예시

```csharp
using System.Text.RegularExpressions;

var matched = "Player_001".RegexIsLike("Player%");
var matchedIgnoreCase = "player_001".RegexIsLike("PLAYER%", RegexOptions.IgnoreCase);
```

## 참고

- 런타임 코드는 `Runtime` 아래에 배치되어 있습니다.
- `ObjectPool`은 새 코드에서 `UnityEngine.Pool.ObjectPool` 사용을 권장합니다.
