# Api Design Document

## Lookup Values

Regions

- site names

## Peoples

Auditor / Health and Safety Advisor,

Regional manager,

- - Site manager

## Static Design

``` mermaid

classDiagram



SiteInspectionReport -- Auditor : Audited By (auditorId)

    class SiteInspectionReport {
        +Guid siteInspectionId
        +Guid siteId
        +Auditor Auditor
        +Date dateOfInspection
    }

    class Auditor {
        +Guid auditorId
        +String firstName
        +String lastName
    }

```

### site inspection

- site inspection report

**[Post]** `/Api/siteInpectionReport/`


``` json
{
    "siteInspectionId": "{9EF6A426-71E9-467E-A2E2-36FA98FFA7C1}",
    "siteId": "{8E1554AA-FE97-4F79-84EC-850814A0D5FA}",
    "auditorId": "{8572150F-F46F-4A7B-BA9F-79D6BF601D82}",
    "dateOfInspection": "01-02-2025",
    "issues": [
        {
            "issueId": "{8E1554AA-FE97-4F79-84EC-850814A0D5FA}",
            "riskId": "{095274BA-BA90-463B-9A0B-8022A5C41754}",
            "specificIssueRiskId": "{095274BA-BA90-463B-9A0B-8022A5C41789}",
            "riskDescription": "Details",
            "riskCodeId": "{095274BA-BA90-463B-9A0B-8022A5C41789}",
            "issuesStatusId": "{095274BA-BA90-463B-9A0B-8022A5C41789}",
            "dateOfInspection": "01-02-2025",
        }
    ]
}
```

### Resolutions

```json
{
    "remediationPlanId": "{9EF6A426-71E9-467E-A2E2-36FA98FFA7C1}",
    "siteInspectionId": "{9EF6A426-71E9-467E-A2E2-36FA98FFA7C1}",
    "resolutions": [
        {
            "resolutionId": "{8E1554AA-FE97-4F79-84EC-850814A0D5FA}",
            "issueId": "{8E1554AA-FE97-4F79-84EC-850814A0D5FA}",
            "resolutionDetail": "details",
            "resolutionStatusId": "{8E1554AA-FE97-4F79-84EC-850814A0D5FA}",
            ""


        }
    ]

}
```

- What has been done about the issue.
- Pictures of the resolution
- date of resolution

### images



### Status

- completed
- not completed
- on going

```json
{
    "siteInspectionId": "{9EF6A426-71E9-467E-A2E2-36FA98FFA7C1}",
    "siteId": "{8E1554AA-FE97-4F79-84EC-850814A0D5FA}",
    "auditorId": "{8572150F-F46F-4A7B-BA9F-79D6BF601D82}",
    "riskId": "{095274BA-BA90-463B-9A0B-8022A5C41754}",
    "SpecificIssueRiskId": "{095274BA-BA90-463B-9A0B-8022A5C41789}",
    "riskDescription": "Details",
    "riskCodeID": "{095274BA-BA90-463B-9A0B-8022A5C41789}",
    "dateOfInspection": "01-02-2025",
    "SpecificIssueRiskIdResolutionStatus": "{095274BA-BA90-463B-9A0B-8022A5C41789}",

}
```

### People

```json
{
    "auditorId": "{095274BA-BA90-463B-9A0B-8022A5C41754}",
    "firstName": "Bob",
    "lastName": "Blogs",
}
```

## Thoughts and Ideas
