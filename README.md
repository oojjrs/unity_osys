# UnityOsys

Unity에서 자주 쓰는 공용 유틸리티 모음입니다.

## 환경

- Unity `6000.3.3f1`
- Assembly: `oojjrs.osys`
- Package: `com.oojjrs.osys`

## 포함 기능

- `BuildOptions`: 빌드 매크로 분기 (`USE_STANDALONE`, `USE_STEAM`, `USE_STOVE`)
- `DictionaryExtensions`: `Dictionary` 일괄 추가
- `MyDictionaryListT<TKey, TValue>`: 키 하나에 여러 값 저장
- `MyEquatableObjectT<T>`: 값 비교 기반 클래스
- `MyHashQueue<T>`: 중복 없는 큐
- `MyRandom`: 랜덤 범위, 셔플, 선택, 가중치 선택
- `NotifierBufferT<T>`: 변경 버퍼링 후 일괄 이벤트 전달
- `ObjectPool`: 기존 커스텀 오브젝트 풀
- `RegexHelper`: `%` 와일드카드 기반 문자열 매칭
- `StringExtensions`: 문자열 -> enum 변환
- `StringFormatHelper`: 숫자/화폐/퍼센트 포맷
- `TinyMath`: `Clamp`, `Clamp01`
- `XmlHelper`: XML 문자열 -> 배열 객체 역직렬화

## 빠른 사용 예시

### MyHashQueue

```csharp
var queue = new MyHashQueue<int>();
queue.Enqueue(1);   // true
queue.Enqueue(1);   // false

if (queue.TryDequeue(out var value))
{
    // use value
}
```

### StringExtensions

```csharp
public enum GameState
{
    Idle,
    Play,
}

var state = "Play".ToEnum(GameState.Idle);
```

### RegexHelper

```csharp
var matched = "Player_001".RegexIsLike("Player%");
var matchedIgnoreCase = "player_001".RegexIsLike("PLAYER%", RegexOptions.IgnoreCase);
```

### NotifierBufferT

```csharp
var buffer = new NotifierBufferT<int>();
buffer.OnUpserted += values =>
{
    foreach (var value in values)
    {
        // handle value
    }
};

buffer.Add(1);
buffer.Add(2);
buffer.Broadcast(3);
```

### XmlHelper

```csharp
XmlHelper.Build<MyData>(xmlText, values =>
{
    foreach (var value in values)
    {
        // handle value
    }
});
```

## 참고

- `ObjectPool`은 `[Obsolete("Use UnityEngine.Pool.ObjectPool instead.")]` 상태입니다.
- 새 코드에서는 `UnityEngine.Pool.ObjectPool` 사용을 권장합니다.

## 파일 구성

```text
Assets/
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
