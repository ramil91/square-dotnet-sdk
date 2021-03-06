
# V1 Cash Drawer Event

V1CashDrawerEvent

## Structure

`V1CashDrawerEvent`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The event's unique ID. |
| `EmployeeId` | `string` | Optional | The ID of the employee that created the event. |
| `EventType` | [`string`](/doc/models/v1-cash-drawer-event-event-type.md) | Optional | - |
| `EventMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `CreatedAt` | `string` | Optional | The time when the event occurred, in ISO 8601 format. |
| `Description` | `string` | Optional | An optional description of the event, entered by the employee that created it. |

## Example (as JSON)

```json
{
  "id": "id0",
  "employee_id": "employee_id0",
  "event_type": "OTHER_TENDER_CANCELED_PAYMENT",
  "event_money": {
    "amount": 148,
    "currency_code": "COP"
  },
  "created_at": "created_at2"
}
```

