# API Method Types with Requests and Responses

## 1. GET /api/items
### Description: Retrieves a list of all items.
### Request:
```
GET http://localhost:5000/api/items
```
### Response:
```
[
    {
        "id": 1,
        "name": "Item1"
    },
    {
        "id": 2,
        "name": "Item2"
    }
]
```

## 2. GET /api/items/{id}
### Description: Retrieves a specific item by its ID.
### Request:
```
GET http://localhost:5000/api/items/1
```
### Response:
```
{
    "id": 1,
    "name": "Item1"
}
```
### Response (if not found):
```
404 Not Found
```

## 3. POST /api/items
### Description: Creates a new item with the provided details.
### Request:
```
POST http://localhost:5000/api/items
Content-Type: application/json

{
    "name": "NewItem"
}
```
### Response:
```
{
    "id": 3,
    "name": "NewItem"
}
```

## 4. PUT /api/items/{id}
### Description: Updates an existing item by its ID with the new information.
### Request:
```
PUT http://localhost:5000/api/items/1
Content-Type: application/json

{
    "name": "UpdatedItem"
}
```
### Response:
```
204 No Content
```

## 5. PATCH /api/items/{id}
### Description: Partially updates an existing item by applying a JSON Patch document.
### Request:
```
PATCH http://localhost:5000/api/items/1
Content-Type: application/json

[
    {
        "op": "replace",
        "path": "/name",
        "value": "PartiallyUpdatedItem"
    }
]
```
### Response:
```
204 No Content
```

## 6. DELETE /api/items/{id}
### Description: Deletes an item by its ID.
### Request:
```
DELETE http://localhost:5000/api/items/1
```
### Response:
```
204 No Content
```

## 7. HEAD /api/items/{id}
### Description: Checks if an item exists by its ID without returning the item itself.
### Request:
```
HEAD http://localhost:5000/api/items/1
```
### Response:
```
204 No Content
```
### Response (if not found):
```
404 Not Found
```

![Demo Image](https://raw.githubusercontent.com/mehedihasan9339/WebAPIMethods/refs/heads/master/demo.png)

