
# Retrieve Obs Migration Profile Response

## Structure

`RetrieveObsMigrationProfileResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BannerEnabled` | `bool?` | Optional | Indicates whether the seller has enabled the COVID banner (`true`) or not (`false`). |
| `BannerText` | `string` | Optional | The text appearing on the COVID banner. |
| `BannerCtaText` | `string` | Optional | The text of the label of the CTA button beneath the banner. |
| `BannerCtaUrl` | `string` | Optional | The URL to link to when the CTA button is clicked. |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "banner_enabled": false,
  "banner_text": "banner_text6",
  "banner_cta_text": "banner_cta_text0",
  "banner_cta_url": "banner_cta_url8",
  "errors": [
    {
      "category": "AUTHENTICATION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_SHORT",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "INVALID_REQUEST_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "RATE_LIMIT_ERROR",
      "code": "CARD_EXPIRED",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

