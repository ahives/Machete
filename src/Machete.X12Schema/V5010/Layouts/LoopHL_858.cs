namespace Machete.X12Schema.V5010
{
    using X12;


    public interface LoopHL_858 : 
        X12Layout
    {
        Segment<HL> EquipmentDetails { get; }
        
        Segment<N7> EquipmentCharacteristics { get; }
        
        SegmentList<NA> CrossReferenceEquipment { get; }
        
        SegmentList<M7> SealNumbers { get; }
        
        Segment<N5> EquipmentOrdered { get; }
        
        SegmentList<REF> ReferenceInformation { get; }
        
        Segment<IC> IntermodalChassisEquipment { get; }
        
        SegmentList<VC> MotorVehicleControl { get; }
        
        Segment<L7> TariffReference { get; }
        
        Segment<SLI> TariffDetails { get; }
        
        Segment<N9> ExtendedReferenceInformation { get; }
        
        Segment<H3> SpecialHandlingInstructions { get; }
        
        SegmentList<X1> ExportLicense { get; }
        
        Segment<X2> ImportLicense { get; }
        
        SegmentList<L5> DescriptionMarksAndNumbers { get; }
        
        SegmentList<PER> AdministrativeCommunicationsContact { get; }
        
        SegmentList<LH2> HazardousClassificationInformation { get; }
        
        SegmentList<LHR> HazardousMaterialIdentifyingReferenceNumbers { get; }
        
        SegmentList<LH6> HazardousCertification { get; }
        
        SegmentList<Y7> CargoBookingPriority { get; }
        
        SegmentList<G62> DateOrTime { get; }
        
        SegmentList<NTE> NotesOrSpecialInstruction { get; }
        
        SegmentList<LP> LoadPlanning { get; }
        
        SegmentList<AXL> VehicleAxleMeasurements { get; }
        
        LayoutList<LoopE1_858> LoopE1 { get;  }
        
        LayoutList<LoopL0_858> LoopL0 { get;  }
        
        LayoutList<LoopLH1_858> LoopLH1 { get;  }
        
        LayoutList<LoopFA1_858> LoopFA1 { get;  }
        
        LayoutList<LoopN1_3_858> LoopN1 { get;  }
    }
}