# Translating

&lt;say something cool here&gt;

```csharp
public class MessageTranslate :
    HL7TranslateMap<HL7Entity>
{
    public MessageTranslation()
    {
        Translate<MSH>(x => x.Using<ReplaceSendingApplication>());
    }
}

class ReplaceSendingApplication :
    HL7SegmentTranslateMap<MSH, MSH, HL7Entity>
{
    public ReplaceSendingApplication()
    {
        Copy(x => x.ReceivingApplication, x => x.SendingApplication);
        Set(x => x.CreationDateTime, x => DateTimeOffset.UtcNow);
        Translate(x => x.MessageType, x => x.Using<ReplaceMessageType>());
    }
}

class ReplaceMessageType :
    HL7ComponentTranslateMap<MSG, MSG, HL7Entity>
{
    public ReplaceMessageType()
    {
        Set(x => x.MessageCode, x => x.Value("ADT"));
        Set(x => x.TriggerEvent, x => x.Value("A04"));
    }
}
```

Debug Info

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



