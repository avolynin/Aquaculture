#Domain Models

#User

```csharp
    User Create();
    
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "fullname": "Viktor Ivanov",
    "email": "viktor@mail.ru",
    "password": "password123", //TODO: Hash this
    "createdDateTime": "2022-02-02T00:00:00.0000000Z",
    "updatedDateTime": "2022-02-02T00:00:00.0000000Z"
}
```