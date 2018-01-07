# Troubleshooting Translates

Troubleshooting translates is extremely important because it is the only place in Machete where the developer is allowed to manipulate data. So, you've written your translate and somehow it didn't execute in quite the way you expected. What's next? Well, you could debug the old fashion way and write a unit test and step through the code. But, what if Machete's Translator engine had the ability to return the play-by-play action of what happened in the translate? How power would it be to simply inspect what actually happened in the translate and pinpoint where the problem is? Of course this is useful. You should already know by now that Machete makes it easy to do...

```csharp
var definition = translator.ToString();
```

Yep, nothing fancy, that's all there is to it. Call the _ToString_ method on your translator and something like this...

```
translate MessageTranslate {
  translate ReplaceSendingApplication (entity: MSHSegment, type: translate) {
    IsEmpty: (exclude)
    Fields: (exclude)
    SegmentId: (exclude)
    ReceivingApplication: (copy, source: SendingApplication)
    CreationDateTime: (set)
    MessageType: (translate) {
      translate ReplaceMessageType (entity: MSG, type: translate) {
        IsEmpty: (exclude)
        Fields: (exclude)
        MessageCode: (set)
        TriggerEvent: (set)
        MessageStructure: (copy)
      }
    }
    EncodingCharacters: (copy)
    SendingApplication: (copy)
    SendingFacility: (copy)
    ReceivingFacility: (copy)
    Security: (copy)
    MessageControlId: (copy)
    ProcessingId: (copy)
    VersionId: (copy)
    SequenceNumber: (copy)
    ContinuationPointer: (copy)
    AcceptAcknowledgmentType: (copy)
    ApplicationAcknowledgmentType: (copy)
    CountryCode: (copy)
    CharacterSet: (copy)
    PrincipalLanguageOfMessage: (copy)
    AlternateCharacterSetHandlingScheme: (copy)
    MessageProfileId: (copy)
    SendingResponsibleOrganization: (copy)
    ReceivingResponsibleOrganization: (copy)
    SendingNetworkAddress: (copy)
    ReceivingNetworkAddress: (copy)
  }
}
```

The above read out shows what happens on every single field on the target entity. Pretty handy when debugging complex translates, wouldn't you say?

